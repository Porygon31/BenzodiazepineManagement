namespace BenzodiazepineManagement.Forms
{
    partial class FormPrescriptionMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPrescriptions = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnManageDoctors = new System.Windows.Forms.Button();
            this.btnManagePatients = new System.Windows.Forms.Button();
            this.btnDeletePrescription = new System.Windows.Forms.Button();
            this.btnEditPrescription = new System.Windows.Forms.Button();
            this.btnAddPrescription = new System.Windows.Forms.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblNombreRenouvellements = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblRenouvelable = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listBoxMedicaments = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDoctorSpecialite = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDoctorRPPS = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDoctorNom = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPatientSecu = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPatientAge = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPatientDateNaissance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPatientNom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblValidite = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDateExpiration = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDatePrescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrescriptions)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // splitContainer1
            //
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            //
            // splitContainer1.Panel1
            //
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewPrescriptions);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 700);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 0;
            //
            // dataGridViewPrescriptions
            //
            this.dataGridViewPrescriptions.AllowUserToAddRows = false;
            this.dataGridViewPrescriptions.AllowUserToDeleteRows = false;
            this.dataGridViewPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPrescriptions.Location = new System.Drawing.Point(0, 60);
            this.dataGridViewPrescriptions.MultiSelect = false;
            this.dataGridViewPrescriptions.Name = "dataGridViewPrescriptions";
            this.dataGridViewPrescriptions.ReadOnly = true;
            this.dataGridViewPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrescriptions.Size = new System.Drawing.Size(600, 640);
            this.dataGridViewPrescriptions.TabIndex = 1;
            this.dataGridViewPrescriptions.SelectionChanged += new System.EventHandler(this.dataGridViewPrescriptions_SelectionChanged);
            //
            // panel1
            //
            this.panel1.Controls.Add(this.btnManageDoctors);
            this.panel1.Controls.Add(this.btnManagePatients);
            this.panel1.Controls.Add(this.btnDeletePrescription);
            this.panel1.Controls.Add(this.btnEditPrescription);
            this.panel1.Controls.Add(this.btnAddPrescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 60);
            this.panel1.TabIndex = 0;
            //
            // btnManageDoctors
            //
            this.btnManageDoctors.Location = new System.Drawing.Point(464, 12);
            this.btnManageDoctors.Name = "btnManageDoctors";
            this.btnManageDoctors.Size = new System.Drawing.Size(110, 36);
            this.btnManageDoctors.TabIndex = 4;
            this.btnManageDoctors.Text = "Gérer Médecins";
            this.btnManageDoctors.UseVisualStyleBackColor = true;
            this.btnManageDoctors.Click += new System.EventHandler(this.btnManageDoctors_Click);
            //
            // btnManagePatients
            //
            this.btnManagePatients.Location = new System.Drawing.Point(348, 12);
            this.btnManagePatients.Name = "btnManagePatients";
            this.btnManagePatients.Size = new System.Drawing.Size(110, 36);
            this.btnManagePatients.TabIndex = 3;
            this.btnManagePatients.Text = "Gérer Patients";
            this.btnManagePatients.UseVisualStyleBackColor = true;
            this.btnManagePatients.Click += new System.EventHandler(this.btnManagePatients_Click);
            //
            // btnDeletePrescription
            //
            this.btnDeletePrescription.Location = new System.Drawing.Point(232, 12);
            this.btnDeletePrescription.Name = "btnDeletePrescription";
            this.btnDeletePrescription.Size = new System.Drawing.Size(110, 36);
            this.btnDeletePrescription.TabIndex = 2;
            this.btnDeletePrescription.Text = "Supprimer";
            this.btnDeletePrescription.UseVisualStyleBackColor = true;
            this.btnDeletePrescription.Click += new System.EventHandler(this.btnDeletePrescription_Click);
            //
            // btnEditPrescription
            //
            this.btnEditPrescription.Location = new System.Drawing.Point(116, 12);
            this.btnEditPrescription.Name = "btnEditPrescription";
            this.btnEditPrescription.Size = new System.Drawing.Size(110, 36);
            this.btnEditPrescription.TabIndex = 1;
            this.btnEditPrescription.Text = "Modifier";
            this.btnEditPrescription.UseVisualStyleBackColor = true;
            this.btnEditPrescription.Click += new System.EventHandler(this.btnEditPrescription_Click);
            //
            // btnAddPrescription
            //
            this.btnAddPrescription.Location = new System.Drawing.Point(0, 12);
            this.btnAddPrescription.Name = "btnAddPrescription";
            this.btnAddPrescription.Size = new System.Drawing.Size(110, 36);
            this.btnAddPrescription.TabIndex = 0;
            this.btnAddPrescription.Text = "Ajouter";
            this.btnAddPrescription.UseVisualStyleBackColor = true;
            this.btnAddPrescription.Click += new System.EventHandler(this.btnAddPrescription_Click);
            //
            // groupBoxDetails
            //
            this.groupBoxDetails.Controls.Add(this.txtObservations);
            this.groupBoxDetails.Controls.Add(this.label15);
            this.groupBoxDetails.Controls.Add(this.lblNombreRenouvellements);
            this.groupBoxDetails.Controls.Add(this.label14);
            this.groupBoxDetails.Controls.Add(this.lblRenouvelable);
            this.groupBoxDetails.Controls.Add(this.label12);
            this.groupBoxDetails.Controls.Add(this.listBoxMedicaments);
            this.groupBoxDetails.Controls.Add(this.label11);
            this.groupBoxDetails.Controls.Add(this.lblDoctorSpecialite);
            this.groupBoxDetails.Controls.Add(this.label9);
            this.groupBoxDetails.Controls.Add(this.lblDoctorRPPS);
            this.groupBoxDetails.Controls.Add(this.label7);
            this.groupBoxDetails.Controls.Add(this.lblDoctorNom);
            this.groupBoxDetails.Controls.Add(this.label10);
            this.groupBoxDetails.Controls.Add(this.lblPatientSecu);
            this.groupBoxDetails.Controls.Add(this.label8);
            this.groupBoxDetails.Controls.Add(this.lblPatientAge);
            this.groupBoxDetails.Controls.Add(this.label6);
            this.groupBoxDetails.Controls.Add(this.lblPatientDateNaissance);
            this.groupBoxDetails.Controls.Add(this.label4);
            this.groupBoxDetails.Controls.Add(this.lblPatientNom);
            this.groupBoxDetails.Controls.Add(this.label5);
            this.groupBoxDetails.Controls.Add(this.lblValidite);
            this.groupBoxDetails.Controls.Add(this.label3);
            this.groupBoxDetails.Controls.Add(this.lblDateExpiration);
            this.groupBoxDetails.Controls.Add(this.label2);
            this.groupBoxDetails.Controls.Add(this.lblDatePrescription);
            this.groupBoxDetails.Controls.Add(this.label1);
            this.groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(596, 700);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Détails de l\'ordonnance";
            //
            // txtObservations
            //
            this.txtObservations.Location = new System.Drawing.Point(20, 590);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.ReadOnly = true;
            this.txtObservations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservations.Size = new System.Drawing.Size(550, 80);
            this.txtObservations.TabIndex = 27;
            //
            // label15
            //
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(20, 570);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 15);
            this.label15.TabIndex = 26;
            this.label15.Text = "Observations :";
            //
            // lblNombreRenouvellements
            //
            this.lblNombreRenouvellements.AutoSize = true;
            this.lblNombreRenouvellements.Location = new System.Drawing.Point(220, 540);
            this.lblNombreRenouvellements.Name = "lblNombreRenouvellements";
            this.lblNombreRenouvellements.Size = new System.Drawing.Size(28, 15);
            this.lblNombreRenouvellements.TabIndex = 25;
            this.lblNombreRenouvellements.Text = "N/A";
            //
            // label14
            //
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(220, 520);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "Nombre renouvellements :";
            //
            // lblRenouvelable
            //
            this.lblRenouvelable.AutoSize = true;
            this.lblRenouvelable.Location = new System.Drawing.Point(20, 540);
            this.lblRenouvelable.Name = "lblRenouvelable";
            this.lblRenouvelable.Size = new System.Drawing.Size(28, 15);
            this.lblRenouvelable.TabIndex = 23;
            this.lblRenouvelable.Text = "N/A";
            //
            // label12
            //
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(20, 520);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Renouvelable :";
            //
            // listBoxMedicaments
            //
            this.listBoxMedicaments.FormattingEnabled = true;
            this.listBoxMedicaments.ItemHeight = 15;
            this.listBoxMedicaments.Location = new System.Drawing.Point(20, 380);
            this.listBoxMedicaments.Name = "listBoxMedicaments";
            this.listBoxMedicaments.Size = new System.Drawing.Size(550, 124);
            this.listBoxMedicaments.TabIndex = 21;
            //
            // label11
            //
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(20, 360);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Médicaments prescrits :";
            //
            // lblDoctorSpecialite
            //
            this.lblDoctorSpecialite.AutoSize = true;
            this.lblDoctorSpecialite.Location = new System.Drawing.Point(20, 330);
            this.lblDoctorSpecialite.Name = "lblDoctorSpecialite";
            this.lblDoctorSpecialite.Size = new System.Drawing.Size(28, 15);
            this.lblDoctorSpecialite.TabIndex = 19;
            this.lblDoctorSpecialite.Text = "N/A";
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(20, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Spécialité :";
            //
            // lblDoctorRPPS
            //
            this.lblDoctorRPPS.AutoSize = true;
            this.lblDoctorRPPS.Location = new System.Drawing.Point(300, 280);
            this.lblDoctorRPPS.Name = "lblDoctorRPPS";
            this.lblDoctorRPPS.Size = new System.Drawing.Size(28, 15);
            this.lblDoctorRPPS.TabIndex = 17;
            this.lblDoctorRPPS.Text = "N/A";
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(300, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "RPPS :";
            //
            // lblDoctorNom
            //
            this.lblDoctorNom.AutoSize = true;
            this.lblDoctorNom.Location = new System.Drawing.Point(20, 280);
            this.lblDoctorNom.Name = "lblDoctorNom";
            this.lblDoctorNom.Size = new System.Drawing.Size(28, 15);
            this.lblDoctorNom.TabIndex = 15;
            this.lblDoctorNom.Text = "N/A";
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(20, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 19);
            this.label10.TabIndex = 14;
            this.label10.Text = "Médecin prescripteur";
            //
            // lblPatientSecu
            //
            this.lblPatientSecu.AutoSize = true;
            this.lblPatientSecu.Location = new System.Drawing.Point(300, 200);
            this.lblPatientSecu.Name = "lblPatientSecu";
            this.lblPatientSecu.Size = new System.Drawing.Size(28, 15);
            this.lblPatientSecu.TabIndex = 13;
            this.lblPatientSecu.Text = "N/A";
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(300, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "N° Sécurité Sociale :";
            //
            // lblPatientAge
            //
            this.lblPatientAge.AutoSize = true;
            this.lblPatientAge.Location = new System.Drawing.Point(300, 150);
            this.lblPatientAge.Name = "lblPatientAge";
            this.lblPatientAge.Size = new System.Drawing.Size(28, 15);
            this.lblPatientAge.TabIndex = 11;
            this.lblPatientAge.Text = "N/A";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(300, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Âge :";
            //
            // lblPatientDateNaissance
            //
            this.lblPatientDateNaissance.AutoSize = true;
            this.lblPatientDateNaissance.Location = new System.Drawing.Point(20, 200);
            this.lblPatientDateNaissance.Name = "lblPatientDateNaissance";
            this.lblPatientDateNaissance.Size = new System.Drawing.Size(28, 15);
            this.lblPatientDateNaissance.TabIndex = 9;
            this.lblPatientDateNaissance.Text = "N/A";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date de naissance :";
            //
            // lblPatientNom
            //
            this.lblPatientNom.AutoSize = true;
            this.lblPatientNom.Location = new System.Drawing.Point(20, 150);
            this.lblPatientNom.Name = "lblPatientNom";
            this.lblPatientNom.Size = new System.Drawing.Size(28, 15);
            this.lblPatientNom.TabIndex = 7;
            this.lblPatientNom.Text = "N/A";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Patient";
            //
            // lblValidite
            //
            this.lblValidite.AutoSize = true;
            this.lblValidite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblValidite.Location = new System.Drawing.Point(300, 80);
            this.lblValidite.Name = "lblValidite";
            this.lblValidite.Size = new System.Drawing.Size(28, 15);
            this.lblValidite.TabIndex = 5;
            this.lblValidite.Text = "N/A";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(300, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Validité :";
            //
            // lblDateExpiration
            //
            this.lblDateExpiration.AutoSize = true;
            this.lblDateExpiration.Location = new System.Drawing.Point(20, 80);
            this.lblDateExpiration.Name = "lblDateExpiration";
            this.lblDateExpiration.Size = new System.Drawing.Size(28, 15);
            this.lblDateExpiration.TabIndex = 3;
            this.lblDateExpiration.Text = "N/A";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date d\'expiration :";
            //
            // lblDatePrescription
            //
            this.lblDatePrescription.AutoSize = true;
            this.lblDatePrescription.Location = new System.Drawing.Point(20, 40);
            this.lblDatePrescription.Name = "lblDatePrescription";
            this.lblDatePrescription.Size = new System.Drawing.Size(28, 15);
            this.lblDatePrescription.TabIndex = 1;
            this.lblDatePrescription.Text = "N/A";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date de prescription :";
            //
            // FormPrescriptionMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormPrescriptionMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionnaire d\'Ordonnances";
            this.Load += new System.EventHandler(this.FormPrescriptionMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrescriptions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewPrescriptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeletePrescription;
        private System.Windows.Forms.Button btnEditPrescription;
        private System.Windows.Forms.Button btnAddPrescription;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDatePrescription;
        private System.Windows.Forms.Label lblDateExpiration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValidite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPatientNom;
        private System.Windows.Forms.Label lblPatientDateNaissance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatientAge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPatientSecu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDoctorNom;
        private System.Windows.Forms.Label lblDoctorRPPS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDoctorSpecialite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBoxMedicaments;
        private System.Windows.Forms.Label lblRenouvelable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblNombreRenouvellements;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnManagePatients;
        private System.Windows.Forms.Button btnManageDoctors;
    }
}
