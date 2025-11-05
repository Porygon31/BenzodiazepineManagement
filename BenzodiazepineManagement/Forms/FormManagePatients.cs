using BenzodiazepineManagement.Data;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Forms
{
    /// <summary>
    /// Formulaire simplifié pour gérer les patients
    /// </summary>
    public partial class FormManagePatients : Form
    {
        private DatabaseManager _databaseManager;

        public FormManagePatients(DatabaseManager databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
        }

        private void FormManagePatients_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void LoadPatients()
        {
            var patients = _databaseManager.GetAllPatients();
            listBoxPatients.DataSource = patients;
            listBoxPatients.DisplayMember = "NomComplet";
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            try
            {
                var patient = new Patient
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    DateNaissance = dateTimePickerNaissance.Value.Date,
                    NumeroSecuriteSociale = txtSecu.Text.Trim(),
                    Adresse = txtAdresse.Text.Trim(),
                    CodePostal = txtCodePostal.Text.Trim(),
                    Ville = txtVille.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim()
                };

                if (string.IsNullOrWhiteSpace(patient.Nom) || string.IsNullOrWhiteSpace(patient.Prenom))
                {
                    MessageBox.Show("Le nom et le prénom sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _databaseManager.AddPatient(patient);
                LoadPatients();
                ClearFields();
                MessageBox.Show("Patient ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            dateTimePickerNaissance.Value = DateTime.Now.AddYears(-30);
            txtSecu.Clear();
            txtAdresse.Clear();
            txtCodePostal.Clear();
            txtVille.Clear();
            txtTelephone.Clear();
        }
    }
}
