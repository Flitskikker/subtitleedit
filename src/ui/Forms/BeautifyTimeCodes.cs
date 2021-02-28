using System;
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
using Nikse.SubtitleEdit.Logic;

namespace Nikse.SubtitleEdit.Forms
{
    public partial class BeautifyTimeCodes : Form
    {
        private readonly Subtitle _subtitle;
        private readonly VideoInfo _videoInfo;
        private readonly double _frameRate = 25;
        private readonly string _videoFileName;

        private List<double> timeCodes = new List<double>();
        private List<double> shotChanges = new List<double>();

        public List<double> ShotChangesInSeconds = new List<double>();
        public Subtitle FixedSubtitle { get; private set; }
        public int FixedCount { get; private set; }

        public BeautifyTimeCodes(Subtitle subtitle, VideoInfo videoInfo, string videoFileName, List<double> shotChanges)
        {
            UiUtil.PreInitialize(this);
            InitializeComponent();
            UiUtil.FixFonts(this);

            if (videoInfo != null && videoInfo.FramesPerSecond > 1)
            {
                _frameRate = videoInfo.FramesPerSecond;
            }

            _videoInfo = videoInfo;
            _videoFileName = videoFileName;
            _subtitle = subtitle;

            var language = LanguageSettings.Current.BeautifyTimeCodes;
            var settings = Configuration.Settings.BeautifyTimeCodes;
            Text = language.Title;
            // TODO
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
                this.timeCodes = TimeCodesFileHelper.FromDisk(videoFileName);
                this.shotChanges = shotChanges;

                // Check if ffprobe is available
                var ffProbePath = Path.GetDirectoryName(Configuration.Settings.General.FFmpegLocation) + Path.DirectorySeparatorChar + Path.GetExtension(Configuration.Settings.General.FFmpegLocation);
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

            if (timeCodes.Count > 0)
            {
                labelTimeCodesStatus.Text = string.Format("{0} time codes loaded", timeCodes.Count);
                buttonExtractTimeCodes.Enabled = false;
                progressBarExtractTimeCodes.Enabled = false;
            }
            else
            {
                labelTimeCodesStatus.Text = "No time codes loaded";
                buttonExtractTimeCodes.Enabled = true;
                progressBarExtractTimeCodes.Enabled = true;
            }

            if (shotChanges.Count > 0)
            {
                labelShotChangesStatus.Text = string.Format("{0} shot changes loaded", shotChanges.Count);
                buttonImportShotChanges.Enabled = false;
            }
            else
            {
                labelShotChangesStatus.Text = "No shot changes loaded";
                buttonImportShotChanges.Enabled = true;
            }
        }

        private void buttonExtractTimeCodes_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            using (var form = new BeautifyTimeCodesProfile())
            {
                form.ShowDialog(this);
            }
        }

        private void buttonImportShotChanges_Click(object sender, EventArgs e)
        {
            using (var form = new ImportSceneChanges(_videoInfo, _videoFileName))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.shotChanges = form.SceneChangesInSeconds;
                    this.ShotChangesInSeconds = form.SceneChangesInSeconds;
                    SceneChangeHelper.SaveSceneChanges(_videoFileName, form.SceneChangesInSeconds);
                    RefreshControls();
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Validation
            if (checkBoxExtractExactTimeCodes.Enabled && timeCodes.Count == 0)
            {
                MessageBox.Show(this, "No time codes loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBoxSnapToShotChanges.Enabled && shotChanges.Count == 0)
            {
                MessageBox.Show(this, "No shot changes loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
