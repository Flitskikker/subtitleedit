﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nikse.SubtitleEdit.Core;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Forms.ShotChanges;
using Nikse.SubtitleEdit.Logic;

namespace Nikse.SubtitleEdit.Forms
{
    public partial class BeautifyTimeCodes : Form
    {
        private readonly Subtitle _subtitle;
        private readonly VideoInfo _videoInfo;
        private readonly double _frameRate = 25;
        private readonly double _duration = 0;
        private readonly string _videoFileName;

        private List<double> _timeCodes = new List<double>();
        private List<double> _shotChanges = new List<double>();

        public List<double> ShotChangesInSeconds = new List<double>();
        public Subtitle FixedSubtitle { get; private set; }
        public int FixedCount { get; private set; }

        private bool _abortTimeCodes;
        private TimeCodesGenerator _timeCodesGenerator;

        public BeautifyTimeCodes(Subtitle subtitle, VideoInfo videoInfo, string videoFileName, List<double> shotChanges)
        {
            UiUtil.PreInitialize(this);
            InitializeComponent();
            UiUtil.FixFonts(this);

            if (videoInfo != null && videoInfo.FramesPerSecond > 1)
            {
                _frameRate = videoInfo.FramesPerSecond;
            }

            if (videoInfo != null && videoInfo.TotalMilliseconds > 0)
            {
                _duration = videoInfo.TotalMilliseconds;
            }

            _videoInfo = videoInfo;
            _videoFileName = videoFileName;
            _subtitle = subtitle;

            var language = LanguageSettings.Current.BeautifyTimeCodes;
            var settings = Configuration.Settings.BeautifyTimeCodes;
            Text = language.Title;
            groupBoxTimeCodes.Text = language.GroupTimeCodes;
            groupBoxShotChanges.Text = language.GroupShotChanges;
            checkBoxAlignTimeCodes.Text = language.AlignTimeCodes;
            checkBoxExtractExactTimeCodes.Text = language.ExtractExactTimeCodes;
            buttonExtractTimeCodes.Text = language.ExtractTimeCodes;
            buttonCancelTimeCodes.Text = language.CancelTimeCodes;
            checkBoxSnapToShotChanges.Text = language.SnapToShotChanges;
            buttonImportShotChanges.Text = language.ImportShotChanges;
            buttonEditProfile.Text = language.EditProfile;
            labelExtractTimeCodesProgress.Text = "";

            buttonOK.Text = LanguageSettings.Current.General.Ok;
            buttonCancel.Text = LanguageSettings.Current.General.Cancel;
            UiUtil.FixLargeFonts(this, buttonOK);

            labelTimeCodesStatus.Font = new Font(labelTimeCodesStatus.Font, FontStyle.Bold);
            labelShotChangesStatus.Font = new Font(labelShotChangesStatus.Font, FontStyle.Bold);

            checkBoxAlignTimeCodes.Checked = settings.AlignTimeCodes;
            checkBoxExtractExactTimeCodes.Checked = settings.ExtractExactTimeCodes;
            checkBoxSnapToShotChanges.Checked = settings.SnapToShotChanges;

            // Check if video is loaded
            if (_videoFileName != null)
            {
                // Load time codes
                this._timeCodes = TimeCodesFileHelper.FromDisk(videoFileName);
                this._shotChanges = shotChanges;

                // Check if ffprobe is available
                var ffProbePath = Path.GetDirectoryName(Configuration.Settings.General.FFmpegLocation) + Path.DirectorySeparatorChar + "ffprobe" + Path.GetExtension(Configuration.Settings.General.FFmpegLocation);
                var isffProbeAvailable = !string.IsNullOrEmpty(ffProbePath) && File.Exists(ffProbePath);
                if (!isffProbeAvailable)
                {
                    checkBoxExtractExactTimeCodes.Enabled = false;
                    checkBoxExtractExactTimeCodes.Checked = false;
                }
            }
            else
            {
                checkBoxExtractExactTimeCodes.Enabled = false;
                checkBoxExtractExactTimeCodes.Checked = false;
                groupBoxShotChanges.Enabled = false;
                checkBoxSnapToShotChanges.Enabled = false;
                checkBoxSnapToShotChanges.Checked = false;
            }

            RefreshControls();
        }

        private void RefreshControls()
        {
            panelTimeCodes.Enabled = checkBoxAlignTimeCodes.Checked;
            panelExtractTimeCodes.Enabled = checkBoxExtractExactTimeCodes.Checked;
            panelShotChanges.Enabled = checkBoxSnapToShotChanges.Checked;

            if (_timeCodes.Count > 0)
            {
                labelTimeCodesStatus.Text = string.Format(LanguageSettings.Current.BeautifyTimeCodes.XTimeCodesLoaded, _timeCodes.Count);
                buttonExtractTimeCodes.Enabled = false;
                progressBarExtractTimeCodes.Enabled = false;
            }
            else
            {
                labelTimeCodesStatus.Text = LanguageSettings.Current.BeautifyTimeCodes.NoTimeCodesLoaded;
                buttonExtractTimeCodes.Enabled = true;
                progressBarExtractTimeCodes.Enabled = true;
                progressBarExtractTimeCodes.Value = 0;
            }

            if (_shotChanges.Count > 0)
            {
                labelShotChangesStatus.Text = string.Format(LanguageSettings.Current.BeautifyTimeCodes.XShotChangesLoaded, _shotChanges.Count);
                buttonImportShotChanges.Enabled = false;
            }
            else
            {
                labelShotChangesStatus.Text = LanguageSettings.Current.BeautifyTimeCodes.NoShotChangesLoaded;
                buttonImportShotChanges.Enabled = true;
            }
        }

        private void buttonExtractTimeCodes_Click(object sender, EventArgs e)
        {
            _timeCodesGenerator = new TimeCodesGenerator();
            _abortTimeCodes = false;
            checkBoxSnapToShotChanges.Enabled = false;
            panelShotChanges.Enabled = false;
            labelTimeCodesStatus.Enabled = false;
            checkBoxAlignTimeCodes.Enabled = false;
            checkBoxExtractExactTimeCodes.Enabled = false;
            buttonExtractTimeCodes.Enabled = false;
            buttonCancelTimeCodes.Visible = true;
            progressBarExtractTimeCodes.Style = ProgressBarStyle.Marquee;
            labelExtractTimeCodesProgress.Visible = true;
            Cursor = Cursors.WaitCursor;
            buttonOK.Enabled = false;
            buttonCancel.Enabled = false;

            bool success = false;
            using (var process = _timeCodesGenerator.GetProcess(_videoFileName))
            {
                while (!process.HasExited)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);

                    UpdateTimeCodeProgress();

                    if (_abortTimeCodes)
                    {
                        process.Kill();
                        break;
                    }
                }

                if (!_abortTimeCodes)
                {
                    success = process.ExitCode == 0;
                }
            }

            UpdateTimeCodeProgress();

            checkBoxSnapToShotChanges.Enabled = true;
            panelShotChanges.Enabled = true;
            labelTimeCodesStatus.Enabled = true;
            checkBoxAlignTimeCodes.Enabled = true;
            checkBoxExtractExactTimeCodes.Enabled = true;
            buttonExtractTimeCodes.Enabled = true;
            buttonCancelTimeCodes.Visible = false;
            Cursor = Cursors.Default;
            buttonOK.Enabled = true;
            buttonCancel.Enabled = true;
            progressBarExtractTimeCodes.Style = ProgressBarStyle.Blocks;
            progressBarExtractTimeCodes.Value = 0;
            labelExtractTimeCodesProgress.Visible = false;

            if (!_abortTimeCodes && success)
            {
                _timeCodes = _timeCodesGenerator.GetTimeCodes();
                TimeCodesFileHelper.SaveTimeCodes(_videoFileName, _timeCodes);
            }

            RefreshControls();
        }

        private void UpdateTimeCodeProgress()
        {
            if (_duration > 0 && _timeCodesGenerator.LastSeconds > 0)
            {
                if (progressBarExtractTimeCodes.Style != ProgressBarStyle.Blocks)
                {
                    progressBarExtractTimeCodes.Style = ProgressBarStyle.Blocks;
                    progressBarExtractTimeCodes.Maximum = Convert.ToInt32(_duration);
                }

                progressBarExtractTimeCodes.Value = Convert.ToInt32(_timeCodesGenerator.LastSeconds);
                labelExtractTimeCodesProgress.Text = FormatSeconds(_timeCodesGenerator.LastSeconds) + " / " + FormatSeconds(_duration);
            }
        }

        private string FormatSeconds(double seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            return t.ToString(@"hh\:mm\:ss");
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            using (var form = new BeautifyTimeCodesProfile(_frameRate))
            {
                form.ShowDialog(this);
            }
        }

        private void buttonImportShotChanges_Click(object sender, EventArgs e)
        {
            using (var form = new ImportShotChanges(_videoInfo, _videoFileName))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this._shotChanges = form.ShotChangesInSeconds;
                    this.ShotChangesInSeconds = form.ShotChangesInSeconds;
                    ShotChangeHelper.SaveShotChanges(_videoFileName, form.ShotChangesInSeconds);
                    RefreshControls();
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Validation
            if (checkBoxExtractExactTimeCodes.Enabled && _timeCodes.Count == 0)
            {
                MessageBox.Show(this, string.Format(LanguageSettings.Current.BeautifyTimeCodes.NoTimeCodesLoadedError, LanguageSettings.Current.BeautifyTimeCodes.ExtractTimeCodes), LanguageSettings.Current.General.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBoxSnapToShotChanges.Enabled && _shotChanges.Count == 0)
            {
                MessageBox.Show(this, string.Format(LanguageSettings.Current.BeautifyTimeCodes.NoShotChangesLoadedError, LanguageSettings.Current.BeautifyTimeCodes.ImportShotChanges), LanguageSettings.Current.General.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Actual processing
            // TODO

            // Save settings
            Configuration.Settings.BeautifyTimeCodes.AlignTimeCodes = checkBoxAlignTimeCodes.Checked;

            if (checkBoxExtractExactTimeCodes.Enabled)
            {
                Configuration.Settings.BeautifyTimeCodes.ExtractExactTimeCodes = checkBoxExtractExactTimeCodes.Checked;
            }

            if (checkBoxSnapToShotChanges.Enabled)
            {
                Configuration.Settings.BeautifyTimeCodes.SnapToShotChanges = checkBoxSnapToShotChanges.Checked;
            }

            DialogResult = DialogResult.OK;
        }

        private void checkBoxAlignTimeCodes_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void checkBoxExtractExactTimeCodes_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void checkBoxSnapToShotChanges_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void buttonCancelTimeCodes_Click(object sender, EventArgs e)
        {
            _abortTimeCodes = true;
        }
    }
}