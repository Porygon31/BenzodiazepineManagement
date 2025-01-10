namespace BenzodiazepineManagement.Forms
{
    partial class FormEditBenzodiazepine
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
            lblActionDurationSeparator = new Label();
            lblBioavailabilitySeparator = new Label();
            lblOnsetTimeSeparator = new Label();
            lblHalfLifeSeparator = new Label();
            checkBoxActionDurationIsRange = new CheckBox();
            checkBoxBioavailabilityIsRange = new CheckBox();
            checkBoxOnsetTimeIsRange = new CheckBox();
            checkBoxHalfLifeIsRange = new CheckBox();
            numericOnsetTimeMax = new NumericUpDown();
            numericBioavailabilityMax = new NumericUpDown();
            numericActionDurationMax = new NumericUpDown();
            numericHalfLifeMax = new NumericUpDown();
            lblMoleculeName = new Label();
            lblOnsetTime = new Label();
            lblMetabolism = new Label();
            lblProperties = new Label();
            lblIndications = new Label();
            lblImagePath = new Label();
            lblDosage = new Label();
            lblElimination = new Label();
            lblActionDuration = new Label();
            lblBioavailability = new Label();
            lblHalfLife = new Label();
            lblOfficialName = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            checkedListBoxIndications = new CheckedListBox();
            checkedListBoxProperties = new CheckedListBox();
            btnBrowseImage = new Button();
            numericOnsetTime = new NumericUpDown();
            numericBioavailability = new NumericUpDown();
            numericActionDuration = new NumericUpDown();
            numericHalfLife = new NumericUpDown();
            txtImagePath = new TextBox();
            txtDosage = new TextBox();
            txtElimination = new TextBox();
            txtMetabolism = new TextBox();
            txtMoleculeName = new TextBox();
            txtOfficialName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericOnsetTimeMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailabilityMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDurationMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHalfLifeMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericOnsetTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHalfLife).BeginInit();
            SuspendLayout();
            // 
            // lblActionDurationSeparator
            // 
            lblActionDurationSeparator.AutoSize = true;
            lblActionDurationSeparator.Location = new Point(851, 265);
            lblActionDurationSeparator.Name = "lblActionDurationSeparator";
            lblActionDurationSeparator.Size = new Size(15, 20);
            lblActionDurationSeparator.TabIndex = 79;
            lblActionDurationSeparator.Text = "-";
            lblActionDurationSeparator.Visible = false;
            // 
            // lblBioavailabilitySeparator
            // 
            lblBioavailabilitySeparator.AutoSize = true;
            lblBioavailabilitySeparator.Location = new Point(851, 233);
            lblBioavailabilitySeparator.Name = "lblBioavailabilitySeparator";
            lblBioavailabilitySeparator.Size = new Size(15, 20);
            lblBioavailabilitySeparator.TabIndex = 78;
            lblBioavailabilitySeparator.Text = "-";
            lblBioavailabilitySeparator.Visible = false;
            // 
            // lblOnsetTimeSeparator
            // 
            lblOnsetTimeSeparator.AutoSize = true;
            lblOnsetTimeSeparator.Location = new Point(851, 185);
            lblOnsetTimeSeparator.Name = "lblOnsetTimeSeparator";
            lblOnsetTimeSeparator.Size = new Size(15, 20);
            lblOnsetTimeSeparator.TabIndex = 77;
            lblOnsetTimeSeparator.Text = "-";
            lblOnsetTimeSeparator.Visible = false;
            // 
            // lblHalfLifeSeparator
            // 
            lblHalfLifeSeparator.AutoSize = true;
            lblHalfLifeSeparator.Location = new Point(851, 142);
            lblHalfLifeSeparator.Name = "lblHalfLifeSeparator";
            lblHalfLifeSeparator.Size = new Size(15, 20);
            lblHalfLifeSeparator.TabIndex = 76;
            lblHalfLifeSeparator.Text = "-";
            lblHalfLifeSeparator.Visible = false;
            // 
            // checkBoxActionDurationIsRange
            // 
            checkBoxActionDurationIsRange.AutoSize = true;
            checkBoxActionDurationIsRange.Location = new Point(755, 266);
            checkBoxActionDurationIsRange.Name = "checkBoxActionDurationIsRange";
            checkBoxActionDurationIsRange.Size = new Size(68, 24);
            checkBoxActionDurationIsRange.TabIndex = 75;
            checkBoxActionDurationIsRange.Text = "Plage";
            checkBoxActionDurationIsRange.UseVisualStyleBackColor = true;
            checkBoxActionDurationIsRange.CheckedChanged += checkBoxActionDurationIsRange_CheckedChanged;
            // 
            // checkBoxBioavailabilityIsRange
            // 
            checkBoxBioavailabilityIsRange.AutoSize = true;
            checkBoxBioavailabilityIsRange.Location = new Point(755, 233);
            checkBoxBioavailabilityIsRange.Name = "checkBoxBioavailabilityIsRange";
            checkBoxBioavailabilityIsRange.Size = new Size(68, 24);
            checkBoxBioavailabilityIsRange.TabIndex = 74;
            checkBoxBioavailabilityIsRange.Text = "Plage";
            checkBoxBioavailabilityIsRange.UseVisualStyleBackColor = true;
            checkBoxBioavailabilityIsRange.CheckedChanged += checkBoxBioavailabilityIsRange_CheckedChanged;
            // 
            // checkBoxOnsetTimeIsRange
            // 
            checkBoxOnsetTimeIsRange.AutoSize = true;
            checkBoxOnsetTimeIsRange.Location = new Point(755, 187);
            checkBoxOnsetTimeIsRange.Name = "checkBoxOnsetTimeIsRange";
            checkBoxOnsetTimeIsRange.Size = new Size(68, 24);
            checkBoxOnsetTimeIsRange.TabIndex = 73;
            checkBoxOnsetTimeIsRange.Text = "Plage";
            checkBoxOnsetTimeIsRange.UseVisualStyleBackColor = true;
            checkBoxOnsetTimeIsRange.CheckedChanged += checkBoxOnsetTimeIsRange_CheckedChanged;
            // 
            // checkBoxHalfLifeIsRange
            // 
            checkBoxHalfLifeIsRange.AutoSize = true;
            checkBoxHalfLifeIsRange.Location = new Point(755, 140);
            checkBoxHalfLifeIsRange.Name = "checkBoxHalfLifeIsRange";
            checkBoxHalfLifeIsRange.Size = new Size(68, 24);
            checkBoxHalfLifeIsRange.TabIndex = 72;
            checkBoxHalfLifeIsRange.Text = "Plage";
            checkBoxHalfLifeIsRange.UseVisualStyleBackColor = true;
            checkBoxHalfLifeIsRange.CheckedChanged += checkBoxHalfLifeIsRange_CheckedChanged;
            // 
            // numericOnsetTimeMax
            // 
            numericOnsetTimeMax.Location = new Point(915, 186);
            numericOnsetTimeMax.Name = "numericOnsetTimeMax";
            numericOnsetTimeMax.Size = new Size(90, 27);
            numericOnsetTimeMax.TabIndex = 71;
            numericOnsetTimeMax.Visible = false;
            // 
            // numericBioavailabilityMax
            // 
            numericBioavailabilityMax.Location = new Point(915, 235);
            numericBioavailabilityMax.Name = "numericBioavailabilityMax";
            numericBioavailabilityMax.Size = new Size(90, 27);
            numericBioavailabilityMax.TabIndex = 70;
            numericBioavailabilityMax.Visible = false;
            // 
            // numericActionDurationMax
            // 
            numericActionDurationMax.Location = new Point(915, 268);
            numericActionDurationMax.Name = "numericActionDurationMax";
            numericActionDurationMax.Size = new Size(90, 27);
            numericActionDurationMax.TabIndex = 69;
            numericActionDurationMax.Visible = false;
            // 
            // numericHalfLifeMax
            // 
            numericHalfLifeMax.Location = new Point(915, 142);
            numericHalfLifeMax.Name = "numericHalfLifeMax";
            numericHalfLifeMax.Size = new Size(90, 27);
            numericHalfLifeMax.TabIndex = 68;
            numericHalfLifeMax.Visible = false;
            // 
            // lblMoleculeName
            // 
            lblMoleculeName.AutoSize = true;
            lblMoleculeName.Location = new Point(526, 84);
            lblMoleculeName.Name = "lblMoleculeName";
            lblMoleculeName.Size = new Size(107, 20);
            lblMoleculeName.TabIndex = 67;
            lblMoleculeName.Text = "Nom Molécule";
            // 
            // lblOnsetTime
            // 
            lblOnsetTime.AutoSize = true;
            lblOnsetTime.Location = new Point(540, 185);
            lblOnsetTime.Name = "lblOnsetTime";
            lblOnsetTime.Size = new Size(60, 20);
            lblOnsetTime.TabIndex = 66;
            lblOnsetTime.Text = "Montée";
            // 
            // lblMetabolism
            // 
            lblMetabolism.AutoSize = true;
            lblMetabolism.Location = new Point(540, 327);
            lblMetabolism.Name = "lblMetabolism";
            lblMetabolism.Size = new Size(96, 20);
            lblMetabolism.TabIndex = 65;
            lblMetabolism.Text = "Métabolisme";
            // 
            // lblProperties
            // 
            lblProperties.AutoSize = true;
            lblProperties.Location = new Point(449, 648);
            lblProperties.Name = "lblProperties";
            lblProperties.Size = new Size(204, 20);
            lblProperties.TabIndex = 64;
            lblProperties.Text = "Propriétés pharmacologiques";
            // 
            // lblIndications
            // 
            lblIndications.AutoSize = true;
            lblIndications.Location = new Point(1149, 628);
            lblIndications.Name = "lblIndications";
            lblIndications.Size = new Size(81, 20);
            lblIndications.TabIndex = 63;
            lblIndications.Text = "Indications";
            // 
            // lblImagePath
            // 
            lblImagePath.AutoSize = true;
            lblImagePath.Location = new Point(373, 475);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(289, 20);
            lblImagePath.TabIndex = 62;
            lblImagePath.Text = "Chemin vers l'image de la molécules (.svg)";
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Location = new Point(540, 424);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(60, 20);
            lblDosage.TabIndex = 61;
            lblDosage.Text = "Dosage";
            // 
            // lblElimination
            // 
            lblElimination.AutoSize = true;
            lblElimination.Location = new Point(548, 379);
            lblElimination.Name = "lblElimination";
            lblElimination.Size = new Size(90, 20);
            lblElimination.TabIndex = 60;
            lblElimination.Text = "Eliminations";
            // 
            // lblActionDuration
            // 
            lblActionDuration.AutoSize = true;
            lblActionDuration.Location = new Point(540, 265);
            lblActionDuration.Name = "lblActionDuration";
            lblActionDuration.Size = new Size(49, 20);
            lblActionDuration.TabIndex = 59;
            lblActionDuration.Text = "Durée";
            // 
            // lblBioavailability
            // 
            lblBioavailability.AutoSize = true;
            lblBioavailability.Location = new Point(540, 232);
            lblBioavailability.Name = "lblBioavailability";
            lblBioavailability.Size = new Size(96, 20);
            lblBioavailability.TabIndex = 58;
            lblBioavailability.Text = "Bioavabilitée";
            // 
            // lblHalfLife
            // 
            lblHalfLife.AutoSize = true;
            lblHalfLife.Location = new Point(540, 146);
            lblHalfLife.Name = "lblHalfLife";
            lblHalfLife.Size = new Size(72, 20);
            lblHalfLife.TabIndex = 57;
            lblHalfLife.Text = "Demi-Vie";
            // 
            // lblOfficialName
            // 
            lblOfficialName.AutoSize = true;
            lblOfficialName.Location = new Point(532, 26);
            lblOfficialName.Name = "lblOfficialName";
            lblOfficialName.Size = new Size(101, 20);
            lblOfficialName.TabIndex = 56;
            lblOfficialName.Text = "Nom Princeps";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(659, 798);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(224, 40);
            btnCancel.TabIndex = 55;
            btnCancel.Text = "Annuler";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(659, 736);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(224, 40);
            btnSave.TabIndex = 54;
            btnSave.Text = "Sauvegarder";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            
            // 
            // checkedListBoxIndications
            // 
            checkedListBoxIndications.FormattingEnabled = true;
            checkedListBoxIndications.Location = new Point(1251, 594);
            checkedListBoxIndications.Name = "checkedListBoxIndications";
            checkedListBoxIndications.Size = new Size(268, 114);
            checkedListBoxIndications.TabIndex = 53;
            // 
            // checkedListBoxProperties
            // 
            checkedListBoxProperties.FormattingEnabled = true;
            checkedListBoxProperties.Location = new Point(659, 594);
            checkedListBoxProperties.Name = "checkedListBoxProperties";
            checkedListBoxProperties.Size = new Size(287, 114);
            checkedListBoxProperties.TabIndex = 52;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Location = new Point(1023, 459);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(224, 48);
            btnBrowseImage.TabIndex = 51;
            btnBrowseImage.Text = "Séléctionner le .svg de la molécule";
            btnBrowseImage.UseVisualStyleBackColor = true;
            // 
            // numericOnsetTime
            // 
            numericOnsetTime.Location = new Point(659, 183);
            numericOnsetTime.Name = "numericOnsetTime";
            numericOnsetTime.Size = new Size(90, 27);
            numericOnsetTime.TabIndex = 50;
            // 
            // numericBioavailability
            // 
            numericBioavailability.Location = new Point(659, 232);
            numericBioavailability.Name = "numericBioavailability";
            numericBioavailability.Size = new Size(90, 27);
            numericBioavailability.TabIndex = 49;
            // 
            // numericActionDuration
            // 
            numericActionDuration.Location = new Point(659, 265);
            numericActionDuration.Name = "numericActionDuration";
            numericActionDuration.Size = new Size(90, 27);
            numericActionDuration.TabIndex = 48;
            // 
            // numericHalfLife
            // 
            numericHalfLife.Location = new Point(659, 139);
            numericHalfLife.Name = "numericHalfLife";
            numericHalfLife.Size = new Size(90, 27);
            numericHalfLife.TabIndex = 47;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(659, 472);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(335, 27);
            txtImagePath.TabIndex = 46;
            // 
            // txtDosage
            // 
            txtDosage.Location = new Point(659, 424);
            txtDosage.Name = "txtDosage";
            txtDosage.Size = new Size(335, 27);
            txtDosage.TabIndex = 45;
            // 
            // txtElimination
            // 
            txtElimination.Location = new Point(659, 372);
            txtElimination.Name = "txtElimination";
            txtElimination.Size = new Size(335, 27);
            txtElimination.TabIndex = 44;
            // 
            // txtMetabolism
            // 
            txtMetabolism.Location = new Point(659, 320);
            txtMetabolism.Name = "txtMetabolism";
            txtMetabolism.Size = new Size(335, 27);
            txtMetabolism.TabIndex = 43;
            // 
            // txtMoleculeName
            // 
            txtMoleculeName.Location = new Point(636, 81);
            txtMoleculeName.Name = "txtMoleculeName";
            txtMoleculeName.Size = new Size(335, 27);
            txtMoleculeName.TabIndex = 42;
            // 
            // txtOfficialName
            // 
            txtOfficialName.Location = new Point(636, 23);
            txtOfficialName.Name = "txtOfficialName";
            txtOfficialName.Size = new Size(335, 27);
            txtOfficialName.TabIndex = 41;
            // 
            // FormEditBenzodiazepine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1880, 899);
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
            Name = "FormEditBenzodiazepine";
            Text = "FormEditBenzodiazepine";
            Load += FormEditBenzodiazepine_Load;
            ((System.ComponentModel.ISupportInitialize)numericOnsetTimeMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailabilityMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDurationMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHalfLifeMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericOnsetTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericBioavailability).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericActionDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHalfLife).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        private async Task btnSave_ClickAsync(object sender, EventArgs e)
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {
            // Your async code here
        }

        #endregion

        private Label lblActionDurationSeparator;
        private Label lblBioavailabilitySeparator;
        private Label lblOnsetTimeSeparator;
        private Label lblHalfLifeSeparator;
        private CheckBox checkBoxActionDurationIsRange;
        private CheckBox checkBoxBioavailabilityIsRange;
        private CheckBox checkBoxOnsetTimeIsRange;
        private CheckBox checkBoxHalfLifeIsRange;
        private NumericUpDown numericOnsetTimeMax;
        private NumericUpDown numericBioavailabilityMax;
        private NumericUpDown numericActionDurationMax;
        private NumericUpDown numericHalfLifeMax;
        private Label lblMoleculeName;
        private Label lblOnsetTime;
        private Label lblMetabolism;
        private Label lblProperties;
        private Label lblIndications;
        private Label lblImagePath;
        private Label lblDosage;
        private Label lblElimination;
        private Label lblActionDuration;
        private Label lblBioavailability;
        private Label lblHalfLife;
        private Label lblOfficialName;
        private Button btnCancel;
        private Button btnSave;
        private CheckedListBox checkedListBoxIndications;
        private CheckedListBox checkedListBoxProperties;
        private Button btnBrowseImage;
        private NumericUpDown numericOnsetTime;
        private NumericUpDown numericBioavailability;
        private NumericUpDown numericActionDuration;
        private NumericUpDown numericHalfLife;
        private TextBox txtImagePath;
        private TextBox txtDosage;
        private TextBox txtElimination;
        private TextBox txtMetabolism;
        private TextBox txtMoleculeName;
        private TextBox txtOfficialName;
    }
}