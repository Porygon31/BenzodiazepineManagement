namespace BenzodiazepineManagement
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewBenzos = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnCompare = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            lblOfficialName = new Label();
            lblMoleculeName = new Label();
            lblHalfLife = new Label();
            lblOnsetTime = new Label();
            lblBioavailability = new Label();
            lblMetabolism = new Label();
            lblElimination = new Label();
            lblActionDuration = new Label();
            lblDosage = new Label();
            lblTherapeuticIndications = new Label();
            lblPharmacologicalProperties = new Label();
            pictureBoxMolecule = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBenzos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMolecule).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBenzos
            // 
            dataGridViewBenzos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBenzos.Location = new Point(24, 29);
            dataGridViewBenzos.Name = "dataGridViewBenzos";
            dataGridViewBenzos.RowHeadersWidth = 51;
            dataGridViewBenzos.Size = new Size(872, 548);
            dataGridViewBenzos.TabIndex = 0;
            dataGridViewBenzos.SelectionChanged += dataGridViewBenzos_SelectionChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1731, 513);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(164, 42);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Ajouter";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1731, 593);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(164, 42);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Editer";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1731, 748);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(164, 42);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(1731, 667);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(164, 42);
            btnCompare.TabIndex = 4;
            btnCompare.Text = "Commparer Benzo";
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Click += btnCompare_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(1717, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(188, 27);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(1622, 29);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(89, 20);
            lblSearch.TabIndex = 6;
            lblSearch.Text = "Rechercher: ";
            // 
            // lblOfficialName
            // 
            lblOfficialName.AutoSize = true;
            lblOfficialName.Location = new Point(902, 28);
            lblOfficialName.Name = "lblOfficialName";
            lblOfficialName.Size = new Size(67, 20);
            lblOfficialName.TabIndex = 7;
            lblOfficialName.Text = "Princeps:";
            // 
            // lblMoleculeName
            // 
            lblMoleculeName.AutoSize = true;
            lblMoleculeName.Location = new Point(902, 86);
            lblMoleculeName.Name = "lblMoleculeName";
            lblMoleculeName.Size = new Size(144, 20);
            lblMoleculeName.TabIndex = 8;
            lblMoleculeName.Text = "Nom de la molécule";
            // 
            // lblHalfLife
            // 
            lblHalfLife.AutoSize = true;
            lblHalfLife.Location = new Point(902, 139);
            lblHalfLife.Name = "lblHalfLife";
            lblHalfLife.Size = new Size(70, 20);
            lblHalfLife.TabIndex = 9;
            lblHalfLife.Text = "Demi Vie";
            // 
            // lblOnsetTime
            // 
            lblOnsetTime.AutoSize = true;
            lblOnsetTime.Location = new Point(902, 191);
            lblOnsetTime.Name = "lblOnsetTime";
            lblOnsetTime.Size = new Size(47, 20);
            lblOnsetTime.TabIndex = 10;
            lblOnsetTime.Text = "Onset";
            // 
            // lblBioavailability
            // 
            lblBioavailability.AutoSize = true;
            lblBioavailability.Location = new Point(902, 224);
            lblBioavailability.Name = "lblBioavailability";
            lblBioavailability.Size = new Size(88, 20);
            lblBioavailability.TabIndex = 11;
            lblBioavailability.Text = "Bioavabilité";
            // 
            // lblMetabolism
            // 
            lblMetabolism.AutoSize = true;
            lblMetabolism.Location = new Point(902, 266);
            lblMetabolism.Name = "lblMetabolism";
            lblMetabolism.Size = new Size(96, 20);
            lblMetabolism.TabIndex = 12;
            lblMetabolism.Text = "Métabolisme";
            // 
            // lblElimination
            // 
            lblElimination.AutoSize = true;
            lblElimination.Location = new Point(902, 293);
            lblElimination.Name = "lblElimination";
            lblElimination.Size = new Size(93, 20);
            lblElimination.TabIndex = 13;
            lblElimination.Text = "Eliminitation";
            // 
            // lblActionDuration
            // 
            lblActionDuration.AutoSize = true;
            lblActionDuration.Location = new Point(902, 325);
            lblActionDuration.Name = "lblActionDuration";
            lblActionDuration.Size = new Size(106, 20);
            lblActionDuration.TabIndex = 14;
            lblActionDuration.Text = "Durée d'action";
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Location = new Point(902, 367);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(60, 20);
            lblDosage.TabIndex = 15;
            lblDosage.Text = "Dosage";
            // 
            // lblTherapeuticIndications
            // 
            lblTherapeuticIndications.AutoSize = true;
            lblTherapeuticIndications.Location = new Point(902, 398);
            lblTherapeuticIndications.Name = "lblTherapeuticIndications";
            lblTherapeuticIndications.Size = new Size(175, 20);
            lblTherapeuticIndications.TabIndex = 16;
            lblTherapeuticIndications.Text = "Indication Thérapeutique";
            // 
            // lblPharmacologicalProperties
            // 
            lblPharmacologicalProperties.AutoSize = true;
            lblPharmacologicalProperties.Location = new Point(902, 438);
            lblPharmacologicalProperties.Name = "lblPharmacologicalProperties";
            lblPharmacologicalProperties.Size = new Size(198, 20);
            lblPharmacologicalProperties.TabIndex = 17;
            lblPharmacologicalProperties.Text = "Propriétés pharmacologique";
            // 
            // pictureBoxMolecule
            // 
            pictureBoxMolecule.Location = new Point(24, 583);
            pictureBoxMolecule.Name = "pictureBoxMolecule";
            pictureBoxMolecule.Size = new Size(876, 722);
            pictureBoxMolecule.TabIndex = 18;
            pictureBoxMolecule.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1929, 1317);
            Controls.Add(pictureBoxMolecule);
            Controls.Add(lblPharmacologicalProperties);
            Controls.Add(lblTherapeuticIndications);
            Controls.Add(lblDosage);
            Controls.Add(lblActionDuration);
            Controls.Add(lblElimination);
            Controls.Add(lblMetabolism);
            Controls.Add(lblBioavailability);
            Controls.Add(lblOnsetTime);
            Controls.Add(lblHalfLife);
            Controls.Add(lblMoleculeName);
            Controls.Add(lblOfficialName);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnCompare);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewBenzos);
            Name = "FormMain";
            Text = "Form1";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBenzos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMolecule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewBenzos;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnCompare;
        private TextBox txtSearch;
        private Label lblSearch;
        private Label lblOfficialName;
        private Label lblMoleculeName;
        private Label lblHalfLife;
        private Label lblOnsetTime;
        private Label lblBioavailability;
        private Label lblMetabolism;
        private Label lblElimination;
        private Label lblActionDuration;
        private Label lblDosage;
        private Label lblTherapeuticIndications;
        private Label lblPharmacologicalProperties;
        private PictureBox pictureBoxMolecule;
    }
}
