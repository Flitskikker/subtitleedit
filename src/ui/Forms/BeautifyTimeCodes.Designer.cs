
namespace Nikse.SubtitleEdit.Forms
{
    partial class BeautifyTimeCodes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxTimeCodes = new System.Windows.Forms.GroupBox();
            this.labelExtractTimeCodesProgress = new System.Windows.Forms.Label();
            this.progressBarExtractTimeCodes = new System.Windows.Forms.ProgressBar();
            this.buttonExtractTimeCodes = new System.Windows.Forms.Button();
            this.labelTimeCodesStatus = new System.Windows.Forms.Label();
            this.checkBoxExtractExactTimeCodes = new System.Windows.Forms.CheckBox();
            this.checkBoxAlignTimeCodes = new System.Windows.Forms.CheckBox();
            this.groupBoxShotChanges = new System.Windows.Forms.GroupBox();
            this.buttonImportShotChanges = new System.Windows.Forms.Button();
            this.labelShotChangesStatus = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.checkBoxSnapToShotChanges = new System.Windows.Forms.CheckBox();
            this.groupBoxTimeCodes.SuspendLayout();
            this.groupBoxShotChanges.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(414, 318);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(495, 318);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimeCodes
            // 
            this.groupBoxTimeCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimeCodes.Controls.Add(this.labelExtractTimeCodesProgress);
            this.groupBoxTimeCodes.Controls.Add(this.progressBarExtractTimeCodes);
            this.groupBoxTimeCodes.Controls.Add(this.buttonExtractTimeCodes);
            this.groupBoxTimeCodes.Controls.Add(this.labelTimeCodesStatus);
            this.groupBoxTimeCodes.Controls.Add(this.checkBoxExtractExactTimeCodes);
            this.groupBoxTimeCodes.Controls.Add(this.checkBoxAlignTimeCodes);
            this.groupBoxTimeCodes.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTimeCodes.Name = "groupBoxTimeCodes";
            this.groupBoxTimeCodes.Size = new System.Drawing.Size(558, 152);
            this.groupBoxTimeCodes.TabIndex = 1;
            this.groupBoxTimeCodes.TabStop = false;
            this.groupBoxTimeCodes.Text = "Time codes";
            // 
            // labelExtractTimeCodesProgress
            // 
            this.labelExtractTimeCodesProgress.AutoSize = true;
            this.labelExtractTimeCodesProgress.Enabled = false;
            this.labelExtractTimeCodesProgress.Location = new System.Drawing.Point(184, 90);
            this.labelExtractTimeCodesProgress.Name = "labelExtractTimeCodesProgress";
            this.labelExtractTimeCodesProgress.Size = new System.Drawing.Size(167, 15);
            this.labelExtractTimeCodesProgress.TabIndex = 5;
            this.labelExtractTimeCodesProgress.Text = "Extracting... 00:00:00 / 00:50:00";
            // 
            // progressBarExtractTimeCodes
            // 
            this.progressBarExtractTimeCodes.Location = new System.Drawing.Point(30, 115);
            this.progressBarExtractTimeCodes.Name = "progressBarExtractTimeCodes";
            this.progressBarExtractTimeCodes.Size = new System.Drawing.Size(516, 23);
            this.progressBarExtractTimeCodes.TabIndex = 4;
            // 
            // buttonExtractTimeCodes
            // 
            this.buttonExtractTimeCodes.Location = new System.Drawing.Point(29, 86);
            this.buttonExtractTimeCodes.Name = "buttonExtractTimeCodes";
            this.buttonExtractTimeCodes.Size = new System.Drawing.Size(149, 23);
            this.buttonExtractTimeCodes.TabIndex = 3;
            this.buttonExtractTimeCodes.Text = "Extract time codes";
            this.buttonExtractTimeCodes.UseVisualStyleBackColor = true;
            // 
            // labelTimeCodesStatus
            // 
            this.labelTimeCodesStatus.AutoSize = true;
            this.labelTimeCodesStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeCodesStatus.Location = new System.Drawing.Point(26, 68);
            this.labelTimeCodesStatus.Name = "labelTimeCodesStatus";
            this.labelTimeCodesStatus.Size = new System.Drawing.Size(132, 15);
            this.labelTimeCodesStatus.TabIndex = 2;
            this.labelTimeCodesStatus.Text = "123 time codes loaded";
            // 
            // checkBoxExtractExactTimeCodes
            // 
            this.checkBoxExtractExactTimeCodes.AutoSize = true;
            this.checkBoxExtractExactTimeCodes.Checked = true;
            this.checkBoxExtractExactTimeCodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExtractExactTimeCodes.Location = new System.Drawing.Point(10, 45);
            this.checkBoxExtractExactTimeCodes.Name = "checkBoxExtractExactTimeCodes";
            this.checkBoxExtractExactTimeCodes.Size = new System.Drawing.Size(266, 19);
            this.checkBoxExtractExactTimeCodes.TabIndex = 2;
            this.checkBoxExtractExactTimeCodes.Text = "Use ffmpeg to extract exact frame time codes";
            this.checkBoxExtractExactTimeCodes.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlignTimeCodes
            // 
            this.checkBoxAlignTimeCodes.AutoSize = true;
            this.checkBoxAlignTimeCodes.Checked = true;
            this.checkBoxAlignTimeCodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlignTimeCodes.Location = new System.Drawing.Point(10, 22);
            this.checkBoxAlignTimeCodes.Name = "checkBoxAlignTimeCodes";
            this.checkBoxAlignTimeCodes.Size = new System.Drawing.Size(168, 19);
            this.checkBoxAlignTimeCodes.TabIndex = 1;
            this.checkBoxAlignTimeCodes.Text = "Align time codes to frames";
            this.checkBoxAlignTimeCodes.UseVisualStyleBackColor = true;
            // 
            // groupBoxShotChanges
            // 
            this.groupBoxShotChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxShotChanges.Controls.Add(this.buttonImportShotChanges);
            this.groupBoxShotChanges.Controls.Add(this.labelShotChangesStatus);
            this.groupBoxShotChanges.Controls.Add(this.buttonEditProfile);
            this.groupBoxShotChanges.Controls.Add(this.checkBoxSnapToShotChanges);
            this.groupBoxShotChanges.Location = new System.Drawing.Point(12, 170);
            this.groupBoxShotChanges.Name = "groupBoxShotChanges";
            this.groupBoxShotChanges.Size = new System.Drawing.Size(558, 137);
            this.groupBoxShotChanges.TabIndex = 2;
            this.groupBoxShotChanges.TabStop = false;
            this.groupBoxShotChanges.Text = "Shot changes";
            // 
            // buttonImportShotChanges
            // 
            this.buttonImportShotChanges.Location = new System.Drawing.Point(29, 62);
            this.buttonImportShotChanges.Name = "buttonImportShotChanges";
            this.buttonImportShotChanges.Size = new System.Drawing.Size(221, 23);
            this.buttonImportShotChanges.TabIndex = 2;
            this.buttonImportShotChanges.Text = "Generate / import shot changes...";
            this.buttonImportShotChanges.UseVisualStyleBackColor = true;
            // 
            // labelShotChangesStatus
            // 
            this.labelShotChangesStatus.AutoSize = true;
            this.labelShotChangesStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShotChangesStatus.Location = new System.Drawing.Point(26, 44);
            this.labelShotChangesStatus.Name = "labelShotChangesStatus";
            this.labelShotChangesStatus.Size = new System.Drawing.Size(143, 15);
            this.labelShotChangesStatus.TabIndex = 5;
            this.labelShotChangesStatus.Text = "123 shot changes loaded";
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Location = new System.Drawing.Point(29, 101);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(149, 23);
            this.buttonEditProfile.TabIndex = 3;
            this.buttonEditProfile.Text = "Edit profile...";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // checkBoxSnapToShotChanges
            // 
            this.checkBoxSnapToShotChanges.AutoSize = true;
            this.checkBoxSnapToShotChanges.Checked = true;
            this.checkBoxSnapToShotChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSnapToShotChanges.Location = new System.Drawing.Point(10, 22);
            this.checkBoxSnapToShotChanges.Name = "checkBoxSnapToShotChanges";
            this.checkBoxSnapToShotChanges.Size = new System.Drawing.Size(166, 19);
            this.checkBoxSnapToShotChanges.TabIndex = 1;
            this.checkBoxSnapToShotChanges.Text = "Snap cues to shot changes";
            this.checkBoxSnapToShotChanges.UseVisualStyleBackColor = true;
            // 
            // BeautifyTimeCodes
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.groupBoxShotChanges);
            this.Controls.Add(this.groupBoxTimeCodes);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeautifyTimeCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BeautifyTimeCodes";
            this.groupBoxTimeCodes.ResumeLayout(false);
            this.groupBoxTimeCodes.PerformLayout();
            this.groupBoxShotChanges.ResumeLayout(false);
            this.groupBoxShotChanges.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxTimeCodes;
        private System.Windows.Forms.Label labelExtractTimeCodesProgress;
        private System.Windows.Forms.ProgressBar progressBarExtractTimeCodes;
        private System.Windows.Forms.Button buttonExtractTimeCodes;
        private System.Windows.Forms.Label labelTimeCodesStatus;
        private System.Windows.Forms.CheckBox checkBoxExtractExactTimeCodes;
        private System.Windows.Forms.CheckBox checkBoxAlignTimeCodes;
        private System.Windows.Forms.GroupBox groupBoxShotChanges;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.CheckBox checkBoxSnapToShotChanges;
        private System.Windows.Forms.Button buttonImportShotChanges;
        private System.Windows.Forms.Label labelShotChangesStatus;
    }
}