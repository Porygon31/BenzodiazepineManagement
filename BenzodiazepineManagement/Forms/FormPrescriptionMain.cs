using BenzodiazepineManagement.Data;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Forms
{
    /// <summary>
    /// Formulaire principal pour la gestion des ordonnances
    /// </summary>
    public partial class FormPrescriptionMain : Form
    {
        private DatabaseManager _databaseManager;
        private List<Prescription> _prescriptions;

        public FormPrescriptionMain(DatabaseManager databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
        }

        private void FormPrescriptionMain_Load(object sender, EventArgs e)
        {
            LoadPrescriptions();
        }

        /// <summary>
        /// Charge les ordonnances depuis la base de données
        /// </summary>
        private void LoadPrescriptions()
        {
            _prescriptions = _databaseManager.GetAllPrescriptions();

            dataGridViewPrescriptions.DataSource = null;
            dataGridViewPrescriptions.AutoGenerateColumns = false;
            dataGridViewPrescriptions.Columns.Clear();

            dataGridViewPrescriptions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DatePrescription",
                HeaderText = "Date",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 100
            });

            dataGridViewPrescriptions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PatientColumn",
                HeaderText = "Patient",
                Width = 150
            });

            dataGridViewPrescriptions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DoctorColumn",
                HeaderText = "Médecin",
                Width = 150
            });

            dataGridViewPrescriptions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemsCountColumn",
                HeaderText = "Nb. Médicaments",
                Width = 120
            });

            dataGridViewPrescriptions.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "EstValide",
                HeaderText = "Valide",
                Width = 60
            });

            dataGridViewPrescriptions.DataSource = _prescriptions;

            // Remplir les colonnes personnalisées
            foreach (DataGridViewRow row in dataGridViewPrescriptions.Rows)
            {
                if (row.DataBoundItem is Prescription prescription)
                {
                    row.Cells["PatientColumn"].Value = prescription.Patient?.NomComplet ?? "";
                    row.Cells["DoctorColumn"].Value = prescription.Doctor?.NomComplet ?? "";
                    row.Cells["ItemsCountColumn"].Value = prescription.Items?.Count ?? 0;
                }
            }
        }

        private void btnAddPrescription_Click(object sender, EventArgs e)
        {
            var addForm = new FormAddPrescription(_databaseManager);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadPrescriptions();
            }
        }

        private void btnEditPrescription_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrescriptions.CurrentRow?.DataBoundItem is Prescription selectedPrescription)
            {
                var editForm = new FormEditPrescription(_databaseManager, selectedPrescription);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPrescriptions();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ordonnance à modifier.", "Aucune sélection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeletePrescription_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrescriptions.CurrentRow?.DataBoundItem is Prescription selectedPrescription)
            {
                var result = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer l'ordonnance du {selectedPrescription.DatePrescription:dd/MM/yyyy} pour {selectedPrescription.Patient?.NomComplet}?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _databaseManager.DeletePrescription(selectedPrescription.Id);
                        LoadPrescriptions();
                        MessageBox.Show("Ordonnance supprimée avec succès.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ordonnance à supprimer.", "Aucune sélection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewPrescriptions_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPrescriptions.CurrentRow?.DataBoundItem is Prescription selectedPrescription)
            {
                DisplayPrescriptionDetails(selectedPrescription);
            }
        }

        /// <summary>
        /// Affiche les détails d'une ordonnance
        /// </summary>
        private void DisplayPrescriptionDetails(Prescription prescription)
        {
            lblDatePrescription.Text = prescription.DatePrescription.ToString("dd/MM/yyyy HH:mm");
            lblDateExpiration.Text = prescription.DateExpiration.ToString("dd/MM/yyyy");
            lblValidite.Text = prescription.EstValide ? "Valide" : "Expirée";
            lblValidite.ForeColor = prescription.EstValide ? Color.Green : Color.Red;

            // Informations patient
            lblPatientNom.Text = prescription.Patient?.NomComplet ?? "N/A";
            lblPatientDateNaissance.Text = prescription.Patient?.DateNaissance.ToString("dd/MM/yyyy") ?? "N/A";
            lblPatientAge.Text = prescription.Patient != null ? $"{prescription.Patient.Age} ans" : "N/A";
            lblPatientSecu.Text = prescription.Patient?.NumeroSecuriteSociale ?? "N/A";

            // Informations médecin
            lblDoctorNom.Text = prescription.Doctor?.NomComplet ?? "N/A";
            lblDoctorRPPS.Text = prescription.Doctor?.NumeroRPPS ?? "N/A";
            lblDoctorSpecialite.Text = prescription.Doctor?.Specialite ?? "N/A";

            // Médicaments prescrits
            listBoxMedicaments.Items.Clear();
            if (prescription.Items != null)
            {
                foreach (var item in prescription.Items)
                {
                    listBoxMedicaments.Items.Add(
                        $"{item.NomMedicament} {item.Dosage} - {item.Posologie} - Durée: {item.DureeTraitementJours}j - Qté: {item.QuantitePrescrite}");
                }
            }

            txtObservations.Text = prescription.Observations ?? "";
            lblRenouvelable.Text = prescription.Renouvelable ? "Oui" : "Non";
            lblNombreRenouvellements.Text = prescription.NombreRenouvellements?.ToString() ?? "N/A";
        }

        private void btnManagePatients_Click(object sender, EventArgs e)
        {
            var managePatientsForm = new FormManagePatients(_databaseManager);
            managePatientsForm.ShowDialog();
        }

        private void btnManageDoctors_Click(object sender, EventArgs e)
        {
            var manageDoctorsForm = new FormManageDoctors(_databaseManager);
            manageDoctorsForm.ShowDialog();
        }
    }
}
