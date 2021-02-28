using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Logic;

namespace Nikse.SubtitleEdit.Forms
{
    public partial class BeautifyTimeCodes : Form
    {
        public BeautifyTimeCodes()
        {
            UiUtil.PreInitialize(this);
            InitializeComponent();
            UiUtil.FixFonts(this);

            var language = LanguageSettings.Current.Settings;
            var settings = Configuration.Settings.General;
            // TODO
            //Text = language.FixContinuationStyleSettings;

            buttonOK.Text = LanguageSettings.Current.General.Ok;
            buttonCancel.Text = LanguageSettings.Current.General.Cancel;
            UiUtil.FixLargeFonts(this, buttonOK);
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            using (var form = new BeautifyTimeCodesProfile())
            {
                form.ShowDialog(this);
            }
        }
    }
}
