namespace BenzodiazepineManagement.Forms
{
    partial class FormAddBenzodiazepine
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
            txtOfficialName = new TextBox();
            txtMoleculeName = new TextBox();
            txtMetabolism = new TextBox();
            txtElimination = new TextBox();
            txtDosage = new TextBox();
            txtImagePath = new TextBox();
            numericHalfLife = new NumericUpDown();
            numericActionDuration = new NumericUpDown();
            numericBioavailability = new NumericUpDown();
            numericOnsetTime = new NumericUpDown();
            btnBrowseImage = new Button();
            checkedListBoxProperties = new CheckedListBox();
            checkedListBoxIndications = new CheckedListBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblOfficialName = new Label();
            lblHalfLife = new Label();
            lblBioavailability = new Label();
            lblActionDuration = new Label();
            lblElimination = new Label();
            lblDosage = new Label();
            lblImagePath = new Label();
            lblIndications = new Label();
            lblProperties = new Label();
            lblMetabolism = new Label();
            lblOnsetTime = new Label();
            lblMoleculeName = new Label();
            numericHalfLifeMax = new NumericUpDown();
            numericActionDurationMax = new NumericUpDown();
            numericBioavailabilityMax = new NumericUpDown();
            numericOnsetTimeMax = new NumericUpDown();
            checkBoxHalfLifeIsRange = new CheckBox();
            checkBoxOnsetTimeIsRange = new CheckBox();
            checkBoxBioavailabilityIsRange = new CheckBox();
            checkBoxActionDurationIsRange = new CheckBox();
            lblHalfLifeSeparator = new Label();
            lblOnsetTimeSeparator = new Label();
            lblBioavailabilitySeparator = new Label();
            lblActionDurationSeparator = new Label();
            ((System.ComponentModel.ISupportInitialize)numericHalfLife).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericOnsetTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHalfLifeMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDurationMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailabilityMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericOnsetTimeMax).BeginInit();
            SuspendLayout();
            // 
            // txtOfficialName
            // 
            txtOfficialName.Location = new Point(494, 23);
            txtOfficialName.Name = "txtOfficialName";
            txtOfficialName.Size = new Size(335, 27);
            txtOfficialName.TabIndex = 0;
            // 
            // txtMoleculeName
            // 
            txtMoleculeName.Location = new Point(494, 81);
            txtMoleculeName.Name = "txtMoleculeName";
            txtMoleculeName.Size = new Size(335, 27);
            txtMoleculeName.TabIndex = 1;
            // 
            // txtMetabolism
            // 
            txtMetabolism.Location = new Point(517, 320);
            txtMetabolism.Name = "txtMetabolism";
            txtMetabolism.Size = new Size(335, 27);
            txtMetabolism.TabIndex = 2;
            // 
            // txtElimination
            // 
            txtElimination.Location = new Point(517, 372);
            txtElimination.Name = "txtElimination";
            txtElimination.Size = new Size(335, 27);
            txtElimination.TabIndex = 3;
            // 
            // txtDosage
            // 
            txtDosage.Location = new Point(517, 424);
            txtDosage.Name = "txtDosage";
            txtDosage.Size = new Size(335, 27);
            txtDosage.TabIndex = 4;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(517, 472);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(335, 27);
            txtImagePath.TabIndex = 5;
            // 
            // numericHalfLife
            // 
            numericHalfLife.Location = new Point(517, 139);
            numericHalfLife.Name = "numericHalfLife";
            numericHalfLife.Size = new Size(90, 27);
            numericHalfLife.TabIndex = 6;
            // 
            // numericActionDuration
            // 
            numericActionDuration.Location = new Point(517, 265);
            numericActionDuration.Name = "numericActionDuration";
            numericActionDuration.Size = new Size(90, 27);
            numericActionDuration.TabIndex = 8;
            // 
            // numericBioavailability
            // 
            numericBioavailability.Location = new Point(517, 232);
            numericBioavailability.Name = "numericBioavailability";
            numericBioavailability.Size = new Size(90, 27);
            numericBioavailability.TabIndex = 9;
            // 
            // numericOnsetTime
            // 
            numericOnsetTime.Location = new Point(517, 183);
            numericOnsetTime.Name = "numericOnsetTime";
            numericOnsetTime.Size = new Size(90, 27);
            numericOnsetTime.TabIndex = 10;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Location = new Point(881, 459);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(224, 48);
            btnBrowseImage.TabIndex = 11;
            btnBrowseImage.Text = "Séléctionner le .svg de la molécule";
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // checkedListBoxProperties
            // 
            checkedListBoxProperties.FormattingEnabled = true;
            checkedListBoxProperties.Location = new Point(517, 594);
            checkedListBoxProperties.Name = "checkedListBoxProperties";
            checkedListBoxProperties.Size = new Size(287, 114);
            checkedListBoxProperties.TabIndex = 12;
            // 
            // checkedListBoxIndications
            // 
            checkedListBoxIndications.FormattingEnabled = true;
            checkedListBoxIndications.Location = new Point(1109, 594);
            checkedListBoxIndications.Name = "checkedListBoxIndications";
            checkedListBoxIndications.Size = new Size(268, 114);
            checkedListBoxIndications.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(517, 736);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(224, 40);
            btnSave.TabIndex = 14;
            btnSave.Text = "Sauvegarder";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_ClickAsync;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(517, 798);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(224, 40);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Annuler";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblOfficialName
            // 
            lblOfficialName.AutoSize = true;
            lblOfficialName.Location = new Point(390, 26);
            lblOfficialName.Name = "lblOfficialName";
            lblOfficialName.Size = new Size(101, 20);
            lblOfficialName.TabIndex = 16;
            lblOfficialName.Text = "Nom Princeps";
            // 
            // lblHalfLife
            // 
            lblHalfLife.AutoSize = true;
            lblHalfLife.Location = new Point(398, 146);
            lblHalfLife.Name = "lblHalfLife";
            lblHalfLife.Size = new Size(72, 20);
            lblHalfLife.TabIndex = 17;
            lblHalfLife.Text = "Demi-Vie";
            // 
            // lblBioavailability
            // 
            lblBioavailability.AutoSize = true;
            lblBioavailability.Location = new Point(398, 232);
            lblBioavailability.Name = "lblBioavailability";
            lblBioavailability.Size = new Size(96, 20);
            lblBioavailability.TabIndex = 18;
            lblBioavailability.Text = "Bioavabilitée";
            // 
            // lblActionDuration
            // 
            lblActionDuration.AutoSize = true;
            lblActionDuration.Location = new Point(398, 265);
            lblActionDuration.Name = "lblActionDuration";
            lblActionDuration.Size = new Size(49, 20);
            lblActionDuration.TabIndex = 19;
            lblActionDuration.Text = "Durée";
            // 
            // lblElimination
            // 
            lblElimination.AutoSize = true;
            lblElimination.Location = new Point(406, 379);
            lblElimination.Name = "lblElimination";
            lblElimination.Size = new Size(90, 20);
            lblElimination.TabIndex = 20;
            lblElimination.Text = "Eliminations";
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Location = new Point(398, 424);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(60, 20);
            lblDosage.TabIndex = 21;
            lblDosage.Text = "Dosage";
            // 
            // lblImagePath
            // 
            lblImagePath.AutoSize = true;
            lblImagePath.Location = new Point(231, 475);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(289, 20);
            lblImagePath.TabIndex = 22;
            lblImagePath.Text = "Chemin vers l'image de la molécules (.svg)";
            // 
            // lblIndications
            // 
            lblIndications.AutoSize = true;
            lblIndications.Location = new Point(1007, 628);
            lblIndications.Name = "lblIndications";
            lblIndications.Size = new Size(81, 20);
            lblIndications.TabIndex = 23;
            lblIndications.Text = "Indications";
            // 
            // lblProperties
            // 
            lblProperties.AutoSize = true;
            lblProperties.Location = new Point(307, 648);
            lblProperties.Name = "lblProperties";
            lblProperties.Size = new Size(204, 20);
            lblProperties.TabIndex = 24;
            lblProperties.Text = "Propriétés pharmacologiques";
            // 
            // lblMetabolism
            // 
            lblMetabolism.AutoSize = true;
            lblMetabolism.Location = new Point(398, 327);
            lblMetabolism.Name = "lblMetabolism";
            lblMetabolism.Size = new Size(96, 20);
            lblMetabolism.TabIndex = 25;
            lblMetabolism.Text = "Métabolisme";
            // 
            // lblOnsetTime
            // 
            lblOnsetTime.AutoSize = true;
            lblOnsetTime.Location = new Point(398, 185);
            lblOnsetTime.Name = "lblOnsetTime";
            lblOnsetTime.Size = new Size(60, 20);
            lblOnsetTime.TabIndex = 26;
            lblOnsetTime.Text = "Montée";
            // 
            // lblMoleculeName
            // 
            lblMoleculeName.AutoSize = true;
            lblMoleculeName.Location = new Point(384, 84);
            lblMoleculeName.Name = "lblMoleculeName";
            lblMoleculeName.Size = new Size(107, 20);
            lblMoleculeName.TabIndex = 28;
            lblMoleculeName.Text = "Nom Molécule";
            // 
            // numericHalfLifeMax
            // 
            numericHalfLifeMax.Location = new Point(773, 142);
            numericHalfLifeMax.Name = "numericHalfLifeMax";
            numericHalfLifeMax.Size = new Size(90, 27);
            numericHalfLifeMax.TabIndex = 29;
            numericHalfLifeMax.Visible = false;
            // 
            // numericActionDurationMax
            // 
            numericActionDurationMax.Location = new Point(773, 268);
            numericActionDurationMax.Name = "numericActionDurationMax";
            numericActionDurationMax.Size = new Size(90, 27);
            numericActionDurationMax.TabIndex = 30;
            numericActionDurationMax.Visible = false;
            // 
            // numericBioavailabilityMax
            // 
            numericBioavailabilityMax.Location = new Point(773, 235);
            numericBioavailabilityMax.Name = "numericBioavailabilityMax";
            numericBioavailabilityMax.Size = new Size(90, 27);
            numericBioavailabilityMax.TabIndex = 31;
            numericBioavailabilityMax.Visible = false;
            // 
            // numericOnsetTimeMax
            // 
            numericOnsetTimeMax.Location = new Point(773, 186);
            numericOnsetTimeMax.Name = "numericOnsetTimeMax";
            numericOnsetTimeMax.Size = new Size(90, 27);
            numericOnsetTimeMax.TabIndex = 32;
            numericOnsetTimeMax.Visible = false;
            // 
            // checkBoxHalfLifeIsRange
            // 
            checkBoxHalfLifeIsRange.AutoSize = true;
            checkBoxHalfLifeIsRange.Location = new Point(613, 140);
            checkBoxHalfLifeIsRange.Name = "checkBoxHalfLifeIsRange";
            checkBoxHalfLifeIsRange.Size = new Size(68, 24);
            checkBoxHalfLifeIsRange.TabIndex = 33;
            checkBoxHalfLifeIsRange.Text = "Plage";
            checkBoxHalfLifeIsRange.UseVisualStyleBackColor = true;
            checkBoxHalfLifeIsRange.CheckedChanged += checkBoxHalfLifeIsRange_CheckedChanged;
            // 
            // checkBoxOnsetTimeIsRange
            // 
            checkBoxOnsetTimeIsRange.AutoSize = true;
            checkBoxOnsetTimeIsRange.Location = new Point(613, 187);
            checkBoxOnsetTimeIsRange.Name = "checkBoxOnsetTimeIsRange";
            checkBoxOnsetTimeIsRange.Size = new Size(68, 24);
            checkBoxOnsetTimeIsRange.TabIndex = 34;
            checkBoxOnsetTimeIsRange.Text = "Plage";
            checkBoxOnsetTimeIsRange.UseVisualStyleBackColor = true;
            checkBoxOnsetTimeIsRange.CheckedChanged += checkBoxOnsetTimeIsRange_CheckedChanged;
            // 
            // checkBoxBioavailabilityIsRange
            // 
            checkBoxBioavailabilityIsRange.AutoSize = true;
            checkBoxBioavailabilityIsRange.Location = new Point(613, 233);
            checkBoxBioavailabilityIsRange.Name = "checkBoxBioavailabilityIsRange";
            checkBoxBioavailabilityIsRange.Size = new Size(68, 24);
            checkBoxBioavailabilityIsRange.TabIndex = 35;
            checkBoxBioavailabilityIsRange.Text = "Plage";
            checkBoxBioavailabilityIsRange.UseVisualStyleBackColor = true;
            checkBoxBioavailabilityIsRange.CheckedChanged += checkBoxBioavailabilityIsRange_CheckedChanged;
            // 
            // checkBoxActionDurationIsRange
            // 
            checkBoxActionDurationIsRange.AutoSize = true;
            checkBoxActionDurationIsRange.Location = new Point(613, 266);
            checkBoxActionDurationIsRange.Name = "checkBoxActionDurationIsRange";
            checkBoxActionDurationIsRange.Size = new Size(68, 24);
            checkBoxActionDurationIsRange.TabIndex = 36;
            checkBoxActionDurationIsRange.Text = "Plage";
            checkBoxActionDurationIsRange.UseVisualStyleBackColor = true;
            checkBoxActionDurationIsRange.CheckedChanged += checkBoxActionDurationIsRange_CheckedChanged;
            // 
            // lblHalfLifeSeparator
            // 
            lblHalfLifeSeparator.AutoSize = true;
            lblHalfLifeSeparator.Location = new Point(715, 144);
            lblHalfLifeSeparator.Name = "lblHalfLifeSeparator";
            lblHalfLifeSeparator.Size = new Size(15, 20);
            lblHalfLifeSeparator.TabIndex = 37;
            lblHalfLifeSeparator.Text = "-";
            lblHalfLifeSeparator.Visible = false;
            // 
            // lblOnsetTimeSeparator
            // 
            lblOnsetTimeSeparator.AutoSize = true;
            lblOnsetTimeSeparator.Location = new Point(715, 186);
            lblOnsetTimeSeparator.Name = "lblOnsetTimeSeparator";
            lblOnsetTimeSeparator.Size = new Size(15, 20);
            lblOnsetTimeSeparator.TabIndex = 38;
            lblOnsetTimeSeparator.Text = "-";
            lblOnsetTimeSeparator.Visible = false;
            // 
            // lblBioavailabilitySeparator
            // 
            lblBioavailabilitySeparator.AutoSize = true;
            lblBioavailabilitySeparator.Location = new Point(715, 237);
            lblBioavailabilitySeparator.Name = "lblBioavailabilitySeparator";
            lblBioavailabilitySeparator.Size = new Size(15, 20);
            lblBioavailabilitySeparator.TabIndex = 39;
            lblBioavailabilitySeparator.Text = "-";
            lblBioavailabilitySeparator.Visible = false;
            // 
            // lblActionDurationSeparator
            // 
            lblActionDurationSeparator.AutoSize = true;
            lblActionDurationSeparator.Location = new Point(715, 275);
            lblActionDurationSeparator.Name = "lblActionDurationSeparator";
            lblActionDurationSeparator.Size = new Size(15, 20);
            lblActionDurationSeparator.TabIndex = 40;
            lblActionDurationSeparator.Text = "-";
            lblActionDurationSeparator.Visible = false;
            // 
            // FormAddBenzodiazepine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 900);
            Controls.Add(lblActionDurationSeparator);
            Controls.Add(lblBioavailabilitySeparator);
            Controls.Add(lblOnsetTimeSeparator);
            Controls.Add(lblHalfLifeSeparator);
            Controls.Add(checkBoxActionDurationIsRange);
            Controls.Add(checkBoxBioavailabilityIsRange);
            Controls.Add(checkBoxOnsetTimeIsRange);
            Controls.Add(checkBoxHalfLifeIsRange);
            Controls.Add(numericOnsetTimeMax);
            Controls.Add(numericBioavailabilityMax);
            Controls.Add(numericActionDurationMax);
            Controls.Add(numericHalfLifeMax);
            Controls.Add(lblMoleculeName);
            Controls.Add(lblOnsetTime);
            Controls.Add(lblMetabolism);
            Controls.Add(lblProperties);
            Controls.Add(lblIndications);
            Controls.Add(lblImagePath);
            Controls.Add(lblDosage);
            Controls.Add(lblElimination);
            Controls.Add(lblActionDuration);
            Controls.Add(lblBioavailability);
            Controls.Add(lblHalfLife);
            Controls.Add(lblOfficialName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(checkedListBoxIndications);
            Controls.Add(checkedListBoxProperties);
            Controls.Add(btnBrowseImage);
            Controls.Add(numericOnsetTime);
            Controls.Add(numericBioavailability);
            Controls.Add(numericActionDuration);
            Controls.Add(numericHalfLife);
            Controls.Add(txtImagePath);
            Controls.Add(txtDosage);
            Controls.Add(txtElimination);
            Controls.Add(txtMetabolism);
            Controls.Add(txtMoleculeName);
            Controls.Add(txtOfficialName);
            Name = "FormAddBenzodiazepine";
            Text = "FormAddBenzodiazepine";
            Load += FormAddBenzodiazepine_Load;
            ((System.ComponentModel.ISupportInitialize)numericHalfLife).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailability).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericOnsetTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHalfLifeMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDurationMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailabilityMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericOnsetTimeMax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtOfficialName;
        private TextBox txtMoleculeName;
        private TextBox txtMetabolism;
        private TextBox txtElimination;
        private TextBox txtDosage;
        private TextBox txtImagePath;
        private NumericUpDown numericHalfLife;
        private NumericUpDown numericActionDuration;
        private NumericUpDown numericBioavailability;
        private NumericUpDown numericOnsetTime;
        private Button btnBrowseImage;
        private CheckedListBox checkedListBoxProperties;
        private CheckedListBox checkedListBoxIndications;
        private Button btnSave;
        private Button btnCancel;
        private Label lblOfficialName;
        private Label lblHalfLife;
        private Label lblBioavailability;
        private Label lblActionDuration;
        private Label lblElimination;
        private Label lblDosage;
        private Label lblImagePath;
        private Label lblIndications;
        private Label lblProperties;
        private Label lblMetabolism;
        private Label lblOnsetTime;
        private Label lblMoleculeName;
        private NumericUpDown numericHalfLifeMax;
        private NumericUpDown numericActionDurationMax;
        private NumericUpDown numericBioavailabilityMax;
        private NumericUpDown numericOnsetTimeMax;
        private CheckBox checkBoxHalfLifeIsRange;
        private CheckBox checkBoxOnsetTimeIsRange;
        private CheckBox checkBoxBioavailabilityIsRange;
        private CheckBox checkBoxActionDurationIsRange;
        private Label lblHalfLifeSeparator;
        private Label lblOnsetTimeSeparator;
        private Label lblBioavailabilitySeparator;
        private Label lblActionDurationSeparator;
    }
}