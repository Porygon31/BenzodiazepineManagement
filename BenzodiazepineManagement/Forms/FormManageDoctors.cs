using BenzodiazepineManagement.Data;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Forms
{
    /// <summary>
    /// Formulaire simplifié pour gérer les médecins
    /// </summary>
    public partial class FormManageDoctors : Form
    {
        private DatabaseManager _databaseManager;

        public FormManageDoctors(DatabaseManager databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
        }

        private void FormManageDoctors_Load(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            var doctors = _databaseManager.GetAllDoctors();
            listBoxDoctors.DataSource = doctors;
            listBoxDoctors.DisplayMember = "NomComplet";
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                var doctor = new Doctor
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    NumeroRPPS = txtRPPS.Text.Trim(),
                    Specialite = txtSpecialite.Text.Trim(),
                    Adresse = txtAdresse.Text.Trim(),
                    CodePostal = txtCodePostal.Text.Trim(),
                    Ville = txtVille.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                if (string.IsNullOrWhiteSpace(doctor.Nom) || string.IsNullOrWhiteSpace(doctor.Prenom) ||
                    string.IsNullOrWhiteSpace(doctor.NumeroRPPS))
                {
                    MessageBox.Show("Le nom, le prénom et le numéro RPPS sont obligatoires.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _databaseManager.AddDoctor(doctor);
                LoadDoctors();
                ClearFields();
                MessageBox.Show("Médecin ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtRPPS.Clear();
            txtSpecialite.Clear();
            txtAdresse.Clear();
            txtCodePostal.Clear();
            txtVille.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
        }
    }
}
