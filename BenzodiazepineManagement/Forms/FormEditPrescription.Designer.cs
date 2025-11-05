namespace BenzodiazepineManagement.Forms
{
    partial class FormEditPrescription
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerPrescription = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPatient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUseBenzo = new System.Windows.Forms.Button();
            this.comboBoxBenzo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericQuantite = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericDuree = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPosologie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomMedicament = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddMedicament = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMedicamentsCount = new System.Windows.Forms.Label();
            this.btnRemoveMedicament = new System.Windows.Forms.Button();
            this.listBoxMedicaments = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericRenouvellements = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBoxRenouvelable = new System.Windows.Forms.CheckBox();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuree)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRenouvellements)).BeginInit();
            this.SuspendLayout();
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.dateTimePickerPrescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxDoctor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPatient);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations générales";
            //
            // dateTimePickerPrescription
            //
            this.dateTimePickerPrescription.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerPrescription.Location = new System.Drawing.Point(650, 40);
            this.dateTimePickerPrescription.Name = "dateTimePickerPrescription";
            this.dateTimePickerPrescription.Size = new System.Drawing.Size(290, 23);
            this.dateTimePickerPrescription.TabIndex = 5;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date :";
            //
            // comboBoxDoctor
            //
            this.comboBoxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(330, 40);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(300, 23);
            this.comboBoxDoctor.TabIndex = 3;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Médecin :";
            //
            // comboBoxPatient
            //
            this.comboBoxPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPatient.FormattingEnabled = true;
            this.comboBoxPatient.Location = new System.Drawing.Point(10, 40);
            this.comboBoxPatient.Name = "comboBoxPatient";
            this.comboBoxPatient.Size = new System.Drawing.Size(300, 23);
            this.comboBoxPatient.TabIndex = 1;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient :";
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.btnUseBenzo);
            this.groupBox2.Controls.Add(this.comboBoxBenzo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtInstructions);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.numericQuantite);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numericDuree);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPosologie);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDosage);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNomMedicament);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnAddMedicament);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ajouter un médicament";
            //
            // btnUseBenzo
            //
            this.btnUseBenzo.Location = new System.Drawing.Point(810, 40);
            this.btnUseBenzo.Name = "btnUseBenzo";
            this.btnUseBenzo.Size = new System.Drawing.Size(130, 23);
            this.btnUseBenzo.TabIndex = 15;
            this.btnUseBenzo.Text = "Utiliser ce benzo";
            this.btnUseBenzo.UseVisualStyleBackColor = true;
            this.btnUseBenzo.Click += new System.EventHandler(this.btnUseBenzo_Click);
            //
            // comboBoxBenzo
            //
            this.comboBoxBenzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBenzo.FormattingEnabled = true;
            this.comboBoxBenzo.Location = new System.Drawing.Point(490, 40);
            this.comboBoxBenzo.Name = "comboBoxBenzo";
            this.comboBoxBenzo.Size = new System.Drawing.Size(300, 23);
            this.comboBoxBenzo.TabIndex = 14;
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(490, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Sélectionner un benzodiazépine :";
            //
            // txtInstructions
            //
            this.txtInstructions.Location = new System.Drawing.Point(490, 100);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(450, 40);
            this.txtInstructions.TabIndex = 12;
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(490, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Instructions spéciales :";
            //
            // numericQuantite
            //
            this.numericQuantite.Location = new System.Drawing.Point(330, 117);
            this.numericQuantite.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numericQuantite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericQuantite.Name = "numericQuantite";
            this.numericQuantite.Size = new System.Drawing.Size(140, 23);
            this.numericQuantite.TabIndex = 10;
            this.numericQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Quantité prescrite :";
            //
            // numericDuree
            //
            this.numericDuree.Location = new System.Drawing.Point(10, 117);
            this.numericDuree.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numericDuree.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericDuree.Name = "numericDuree";
            this.numericDuree.Size = new System.Drawing.Size(140, 23);
            this.numericDuree.TabIndex = 8;
            this.numericDuree.Value = new decimal(new int[] { 7, 0, 0, 0 });
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Durée traitement (jours) :";
            //
            // txtPosologie
            //
            this.txtPosologie.Location = new System.Drawing.Point(330, 40);
            this.txtPosologie.Name = "txtPosologie";
            this.txtPosologie.Size = new System.Drawing.Size(140, 23);
            this.txtPosologie.TabIndex = 6;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Posologie :";
            //
            // txtDosage
            //
            this.txtDosage.Location = new System.Drawing.Point(170, 40);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(140, 23);
            this.txtDosage.TabIndex = 4;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Dosage :";
            //
            // txtNomMedicament
            //
            this.txtNomMedicament.Location = new System.Drawing.Point(10, 40);
            this.txtNomMedicament.Name = "txtNomMedicament";
            this.txtNomMedicament.Size = new System.Drawing.Size(140, 23);
            this.txtNomMedicament.TabIndex = 2;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nom du médicament :";
            //
            // btnAddMedicament
            //
            this.btnAddMedicament.Location = new System.Drawing.Point(10, 145);
            this.btnAddMedicament.Name = "btnAddMedicament";
            this.btnAddMedicament.Size = new System.Drawing.Size(150, 25);
            this.btnAddMedicament.TabIndex = 0;
            this.btnAddMedicament.Text = "Ajouter à l\'ordonnance";
            this.btnAddMedicament.UseVisualStyleBackColor = true;
            this.btnAddMedicament.Click += new System.EventHandler(this.btnAddMedicament_Click);
            //
            // groupBox3
            //
            this.groupBox3.Controls.Add(this.lblMedicamentsCount);
            this.groupBox3.Controls.Add(this.btnRemoveMedicament);
            this.groupBox3.Controls.Add(this.listBoxMedicaments);
            this.groupBox3.Location = new System.Drawing.Point(12, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(960, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Médicaments prescrits";
            //
            // lblMedicamentsCount
            //
            this.lblMedicamentsCount.AutoSize = true;
            this.lblMedicamentsCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMedicamentsCount.Location = new System.Drawing.Point(10, 125);
            this.lblMedicamentsCount.Name = "lblMedicamentsCount";
            this.lblMedicamentsCount.Size = new System.Drawing.Size(163, 15);
            this.lblMedicamentsCount.TabIndex = 2;
            this.lblMedicamentsCount.Text = "Nombre de médicaments : 0";
            //
            // btnRemoveMedicament
            //
            this.btnRemoveMedicament.Location = new System.Drawing.Point(820, 20);
            this.btnRemoveMedicament.Name = "btnRemoveMedicament";
            this.btnRemoveMedicament.Size = new System.Drawing.Size(120, 25);
            this.btnRemoveMedicament.TabIndex = 1;
            this.btnRemoveMedicament.Text = "Retirer";
            this.btnRemoveMedicament.UseVisualStyleBackColor = true;
            this.btnRemoveMedicament.Click += new System.EventHandler(this.btnRemoveMedicament_Click);
            //
            // listBoxMedicaments
            //
            this.listBoxMedicaments.FormattingEnabled = true;
            this.listBoxMedicaments.ItemHeight = 15;
            this.listBoxMedicaments.Location = new System.Drawing.Point(10, 20);
            this.listBoxMedicaments.Name = "listBoxMedicaments";
            this.listBoxMedicaments.Size = new System.Drawing.Size(800, 94);
            this.listBoxMedicaments.TabIndex = 0;
            //
            // groupBox4
            //
            this.groupBox4.Controls.Add(this.numericRenouvellements);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.checkBoxRenouvelable);
            this.groupBox4.Controls.Add(this.txtObservations);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(12, 440);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(960, 120);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Observations et renouvellement";
            //
            // numericRenouvellements
            //
            this.numericRenouvellements.Enabled = false;
            this.numericRenouvellements.Location = new System.Drawing.Point(210, 80);
            this.numericRenouvellements.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numericRenouvellements.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericRenouvellements.Name = "numericRenouvellements";
            this.numericRenouvellements.Size = new System.Drawing.Size(120, 23);
            this.numericRenouvellements.TabIndex = 4;
            this.numericRenouvellements.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // label12
            //
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(210, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Nombre de renouvellements :";
            //
            // checkBoxRenouvelable
            //
            this.checkBoxRenouvelable.AutoSize = true;
            this.checkBoxRenouvelable.Location = new System.Drawing.Point(10, 80);
            this.checkBoxRenouvelable.Name = "checkBoxRenouvelable";
            this.checkBoxRenouvelable.Size = new System.Drawing.Size(99, 19);
            this.checkBoxRenouvelable.TabIndex = 2;
            this.checkBoxRenouvelable.Text = "Renouvelable";
            this.checkBoxRenouvelable.UseVisualStyleBackColor = true;
            this.checkBoxRenouvelable.CheckedChanged += new System.EventHandler(this.checkBoxRenouvelable_CheckedChanged);
            //
            // txtObservations
            //
            this.txtObservations.Location = new System.Drawing.Point(10, 40);
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(930, 23);
            this.txtObservations.TabIndex = 1;
            //
            // label11
            //
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Observations :";
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(762, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(872, 575);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // FormEditPrescription
            //
            this.ClientSize = new System.Drawing.Size(984, 622);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditPrescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier l\'Ordonnance";
            this.Load += new System.EventHandler(this.FormEditPrescription_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuree)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRenouvellements)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerPrescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNomMedicament;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddMedicament;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPosologie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericDuree;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericQuantite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxBenzo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUseBenzo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxMedicaments;
        private System.Windows.Forms.Button btnRemoveMedicament;
        private System.Windows.Forms.Label lblMedicamentsCount;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxRenouvelable;
        private System.Windows.Forms.NumericUpDown numericRenouvellements;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
