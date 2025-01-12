using BenzodiazepineManagement.Data;
using BenzodiazepineManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenzodiazepineManagement.Forms
{
    public partial class FormAddBenzodiazepine : Form
    {
        private DatabaseManager _databaseManager;
        private Benzodiazepine _benzodiazepine;

        // Liste des propriétés pharmacologiques disponibles
        private List<PharmacologicalProperty> _availableProperties = new List<PharmacologicalProperty>
        {
            new PharmacologicalProperty { Name = "Anxiolytique", Description = "Réduction de l'anxiété en modulant l'activité du GABA au niveau du système limbique." },
            new PharmacologicalProperty { Name = "Sédatif et hypnotique", Description = "Effet calmant et induction du sommeil, utilisé pour les troubles du sommeil et les états d'agitation." },
            new PharmacologicalProperty { Name = "Myorelaxant", Description = "Relaxation des muscles squelettiques, utilisé pour les spasmes musculaires." },
            new PharmacologicalProperty { Name = "Anticonvulsivant", Description = "Prévention ou arrêt des crises épileptiques, utilisé dans l'épilepsie et les convulsions aiguës." },
            new PharmacologicalProperty { Name = "Amnésique", Description = "Effet d'amnésie antérograde, souvent utilisé dans des contextes médicaux comme la prémédication avant une anesthésie." }
        };

        // Liste des indications thérapeutiques disponibles
        private List<string> _therapeuticIndications = new List<string>
        {
            "Troubles anxieux (psychologique)",
            "Troubles anxieux physiques (tremblements, palpitations, sueurs, etc.)",
            "Insomnie à court terme",
            "Crises d’épilepsie (y compris le status epilepticus)",
            "Spasmes musculaires ou dystonie",
            "Sevrage alcoolique"
        };

        public FormAddBenzodiazepine(DatabaseManager databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
            _benzodiazepine = new Benzodiazepine();
        }

        /// <summary>
        /// Événement déclenché lors du chargement de la fenêtre.
        /// </summary>
        private void FormAddBenzodiazepine_Load(object sender, EventArgs e)
        {
            // Initialiser les listes
            checkedListBoxProperties.DataSource = _availableProperties;
            checkedListBoxProperties.DisplayMember = "Name";

            checkedListBoxIndications.DataSource = _therapeuticIndications;

            // Cacher les contrôles des valeurs maximales par défaut
            numericHalfLifeMax.Visible = false;
            lblHalfLifeSeparator.Visible = false;
            numericOnsetTimeMax.Visible = false;
            lblOnsetTimeSeparator.Visible = false;
            numericBioavailabilityMax.Visible = false;
            lblBioavailabilitySeparator.Visible = false;
            numericActionDurationMax.Visible = false;
            lblActionDurationSeparator.Visible = false;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Parcourir" pour sélectionner une image SVG.
        /// </summary>
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SVG Files|*.svg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = ofd.FileName;

                // Vérifier que le dossier Images existe, sinon le créer
                if (!Directory.Exists(AppConstants.ImagesFolderPath))
                {
                    Directory.CreateDirectory(AppConstants.ImagesFolderPath);
                }

                // Générer un nom de fichier unique pour éviter les conflits
                string fileName = Path.GetFileName(sourcePath);
                string destinationPath = Path.Combine(AppConstants.ImagesFolderPath, fileName);

                // Si un fichier avec le même nom existe déjà, ajouter un suffixe
                int count = 1;
                while (File.Exists(destinationPath))
                {
                    string tempFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{count}{Path.GetExtension(fileName)}";
                    destinationPath = Path.Combine(AppConstants.ImagesFolderPath, tempFileName);
                    count++;
                }

                // Copier le fichier dans le dossier Images
                File.Copy(sourcePath, destinationPath);

                // Mettre à jour le chemin de l'image dans le TextBox
                txtImagePath.Text = destinationPath;
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Enregistrer".
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation des champs obligatoires
            if (string.IsNullOrWhiteSpace(txtOfficialName.Text) || string.IsNullOrWhiteSpace(txtMoleculeName.Text))
            {
                MessageBox.Show("Veuillez remplir les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mise à jour de l'objet benzodiazépine
            _benzodiazepine.OfficialName = txtOfficialName.Text;
            _benzodiazepine.MoleculeName = txtMoleculeName.Text;

            // HalfLife
            _benzodiazepine.HalfLife = new ValueRange
            {
                IsRange = checkBoxHalfLifeIsRange.Checked,
                Value = (double)numericHalfLife.Value,
                MaxValue = checkBoxHalfLifeIsRange.Checked ? (double?)numericHalfLifeMax.Value : null
            };

            // OnsetTime
            _benzodiazepine.OnsetTime = new ValueRange
            {
                IsRange = checkBoxOnsetTimeIsRange.Checked,
                Value = (double)numericOnsetTime.Value,
                MaxValue = checkBoxOnsetTimeIsRange.Checked ? (double?)numericOnsetTimeMax.Value : null
            };

            // Bioavailability
            _benzodiazepine.Bioavailability = new ValueRange
            {
                IsRange = checkBoxBioavailabilityIsRange.Checked,
                Value = (double)numericBioavailability.Value,
                MaxValue = checkBoxBioavailabilityIsRange.Checked ? (double?)numericBioavailabilityMax.Value : null
            };

            // ActionDurationHours
            _benzodiazepine.ActionDurationHours = new ValueRange
            {
                IsRange = checkBoxActionDurationIsRange.Checked,
                Value = (double)numericActionDuration.Value,
                MaxValue = checkBoxActionDurationIsRange.Checked ? (double?)numericActionDurationMax.Value : null
            };

            _benzodiazepine.Metabolism = txtMetabolism.Text;
            _benzodiazepine.Elimination = txtElimination.Text;
            _benzodiazepine.Dosage = txtDosage.Text;
            _benzodiazepine.ImagePath = txtImagePath.Text;

            // Récupérer les propriétés pharmacologiques sélectionnées
            _benzodiazepine.PharmacologicalProperties = new List<PharmacologicalProperty>();
            foreach (var item in checkedListBoxProperties.CheckedItems)
            {
                _benzodiazepine.PharmacologicalProperties.Add((PharmacologicalProperty)item);
            }

            // Récupérer les indications thérapeutiques sélectionnées
            _benzodiazepine.TherapeuticIndications = new List<string>();
            foreach (var item in checkedListBoxIndications.CheckedItems)
            {
                _benzodiazepine.TherapeuticIndications.Add(item.ToString());
            }

            // Enregistrer dans la base de données
            _databaseManager.AddBenzodiazepine(_benzodiazepine);

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Annuler".
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Gestion des cases à cocher pour afficher/masquer les contrôles de valeur maximale

        private void checkBoxHalfLifeIsRange_CheckedChanged(object sender, EventArgs e)
        {
            bool isRange = checkBoxHalfLifeIsRange.Checked;
            numericHalfLifeMax.Visible = isRange;
            lblHalfLifeSeparator.Visible = isRange;
        }

        private void checkBoxOnsetTimeIsRange_CheckedChanged(object sender, EventArgs e)
        {
            bool isRange = checkBoxOnsetTimeIsRange.Checked;
            numericOnsetTimeMax.Visible = isRange;
            lblOnsetTimeSeparator.Visible = isRange;
        }

        private void checkBoxBioavailabilityIsRange_CheckedChanged(object sender, EventArgs e)
        {
            bool isRange = checkBoxBioavailabilityIsRange.Checked;
            numericBioavailabilityMax.Visible = isRange;
            lblBioavailabilitySeparator.Visible = isRange;
        }

        private void checkBoxActionDurationIsRange_CheckedChanged(object sender, EventArgs e)
        {
            bool isRange = checkBoxActionDurationIsRange.Checked;
            numericActionDurationMax.Visible = isRange;
            lblActionDurationSeparator.Visible = isRange;
        }
    }
}