using BenzodiazepineManagement.Data;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Forms
{
    /// <summary>
    /// Formulaire pour modifier une ordonnance existante
    /// </summary>
    public partial class FormEditPrescription : Form
    {
        private DatabaseManager _databaseManager;
        private Prescription _prescription;
        private List<PrescriptionItem> _prescriptionItems;

        public FormEditPrescription(DatabaseManager databaseManager, Prescription prescription)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
            _prescription = prescription;
            _prescriptionItems = new List<PrescriptionItem>(prescription.Items ?? new List<PrescriptionItem>());
        }

        private void FormEditPrescription_Load(object sender, EventArgs e)
        {
            // Charger les patients
            var patients = _databaseManager.GetAllPatients();
            comboBoxPatient.DataSource = patients;
            comboBoxPatient.DisplayMember = "NomComplet";
            comboBoxPatient.ValueMember = "Id";
            comboBoxPatient.SelectedValue = _prescription.PatientId;

            // Charger les médecins
            var doctors = _databaseManager.GetAllDoctors();
            comboBoxDoctor.DataSource = doctors;
            comboBoxDoctor.DisplayMember = "NomComplet";
            comboBoxDoctor.ValueMember = "Id";
            comboBoxDoctor.SelectedValue = _prescription.DoctorId;

            // Charger les benzodiazépines
            var benzos = _databaseManager.GetAllBenzodiazepines();
            comboBoxBenzo.DataSource = benzos;
            comboBoxBenzo.DisplayMember = "OfficialName";
            comboBoxBenzo.ValueMember = "Id";

            // Charger les données de l'ordonnance
            dateTimePickerPrescription.Value = _prescription.DatePrescription;
            txtObservations.Text = _prescription.Observations ?? "";
            checkBoxRenouvelable.Checked = _prescription.Renouvelable;
            if (_prescription.NombreRenouvellements.HasValue)
            {
                numericRenouvellements.Value = _prescription.NombreRenouvellements.Value;
            }

            UpdateMedicamentsList();
        }

        private void btnAddMedicament_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new PrescriptionItem
                {
                    NomMedicament = txtNomMedicament.Text.Trim(),
                    Dosage = txtDosage.Text.Trim(),
                    Posologie = txtPosologie.Text.Trim(),
                    DureeTraitementJours = (int)numericDuree.Value,
                    QuantitePrescrite = (int)numericQuantite.Value,
                    Instructions = txtInstructions.Text.Trim()
                };

                if (comboBoxBenzo.SelectedValue != null)
                {
                    item.BenzodiazepineId = (int)comboBoxBenzo.SelectedValue;
                }

                if (string.IsNullOrWhiteSpace(item.NomMedicament) || string.IsNullOrWhiteSpace(item.Dosage) ||
                    string.IsNullOrWhiteSpace(item.Posologie))
                {
                    MessageBox.Show("Le nom du médicament, le dosage et la posologie sont obligatoires.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _prescriptionItems.Add(item);
                UpdateMedicamentsList();
                ClearMedicamentFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du médicament : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveMedicament_Click(object sender, EventArgs e)
        {
            if (listBoxMedicaments.SelectedIndex >= 0)
            {
                _prescriptionItems.RemoveAt(listBoxMedicaments.SelectedIndex);
                UpdateMedicamentsList();
            }
        }

        private void btnUseBenzo_Click(object sender, EventArgs e)
        {
            if (comboBoxBenzo.SelectedItem is Benzodiazepine benzo)
            {
                txtNomMedicament.Text = benzo.OfficialName;
                txtDosage.Text = benzo.Dosage ?? "";
            }
        }

        private void UpdateMedicamentsList()
        {
            listBoxMedicaments.Items.Clear();
            foreach (var item in _prescriptionItems)
            {
                listBoxMedicaments.Items.Add(
                    $"{item.NomMedicament} {item.Dosage} - {item.Posologie} - {item.DureeTraitementJours}j - Qté: {item.QuantitePrescrite}");
            }

            lblMedicamentsCount.Text = $"Nombre de médicaments : {_prescriptionItems.Count}";
        }

        private void ClearMedicamentFields()
        {
            txtNomMedicament.Clear();
            txtDosage.Clear();
            txtPosologie.Clear();
            numericDuree.Value = 7;
            numericQuantite.Value = 1;
            txtInstructions.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPatient.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un patient.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxDoctor.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un médecin.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_prescriptionItems.Count == 0)
                {
                    MessageBox.Show("Veuillez ajouter au moins un médicament à l'ordonnance.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _prescription.PatientId = (int)comboBoxPatient.SelectedValue;
                _prescription.DoctorId = (int)comboBoxDoctor.SelectedValue;
                _prescription.DatePrescription = dateTimePickerPrescription.Value;
                _prescription.Observations = txtObservations.Text.Trim();
                _prescription.Renouvelable = checkBoxRenouvelable.Checked;
                _prescription.NombreRenouvellements = checkBoxRenouvelable.Checked ? (int?)numericRenouvellements.Value : null;
                _prescription.Items = _prescriptionItems;

                _databaseManager.UpdatePrescription(_prescription);

                MessageBox.Show("Ordonnance modifiée avec succès.", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBoxRenouvelable_CheckedChanged(object sender, EventArgs e)
        {
            numericRenouvellements.Enabled = checkBoxRenouvelable.Checked;
        }
    }
}
