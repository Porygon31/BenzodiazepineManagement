using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using BenzodiazepineManagement.Models;
using BenzodiazepineManagement.Data;
using BenzodiazepineManagement;

namespace BenzodiazepineManagement.Forms
{
    /// <summary>
    /// Fenêtre pour éditer une benzodiazépine existante.
    /// </summary>
    public partial class FormEditBenzodiazepine : Form
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

        public FormEditBenzodiazepine(DatabaseManager databaseManager, Benzodiazepine benzo)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
            _benzodiazepine = benzo;
        }

        /// <summary>
        /// Événement déclenché lors du chargement de la fenêtre.
        /// </summary>
        private void FormEditBenzodiazepine_Load(object sender, EventArgs e)
        {
            // Initialiser les listes
            checkedListBoxProperties.DataSource = _availableProperties;
            checkedListBoxProperties.DisplayMember = "Name";

            checkedListBoxIndications.DataSource = _therapeuticIndications;

            // Remplir les champs avec les données existantes
            txtOfficialName.Text = _benzodiazepine.OfficialName;
            txtMoleculeName.Text = _benzodiazepine.MoleculeName;
            txtMetabolism.Text = _benzodiazepine.Metabolism;
            txtElimination.Text = _benzodiazepine.Elimination;
            txtDosage.Text = _benzodiazepine.Dosage;
            txtImagePath.Text = _benzodiazepine.ImagePath;

            // Initialisation de HalfLife
            checkBoxHalfLifeIsRange.Checked = _benzodiazepine.HalfLife.IsRange;
            numericHalfLife.Value = (decimal)_benzodiazepine.HalfLife.Value;
            if (_benzodiazepine.HalfLife.IsRange && _benzodiazepine.HalfLife.MaxValue.HasValue)
            {
                numericHalfLifeMax.Value = (decimal)_benzodiazepine.HalfLife.MaxValue.Value;
                numericHalfLifeMax.Visible = true;
                lblHalfLifeSeparator.Visible = true;
            }
            else
            {
                numericHalfLifeMax.Visible = false;
                lblHalfLifeSeparator.Visible = false;
            }

            // Initialisation de OnsetTime
            checkBoxOnsetTimeIsRange.Checked = _benzodiazepine.OnsetTime.IsRange;
            numericOnsetTime.Value = (decimal)_benzodiazepine.OnsetTime.Value;
            if (_benzodiazepine.OnsetTime.IsRange && _benzodiazepine.OnsetTime.MaxValue.HasValue)
            {
                numericOnsetTimeMax.Value = (decimal)_benzodiazepine.OnsetTime.MaxValue.Value;
                numericOnsetTimeMax.Visible = true;
                lblOnsetTimeSeparator.Visible = true;
            }
            else
            {
                numericOnsetTimeMax.Visible = false;
                lblOnsetTimeSeparator.Visible = false;
            }

            // Initialisation de Bioavailability
            checkBoxBioavailabilityIsRange.Checked = _benzodiazepine.Bioavailability.IsRange;
            numericBioavailability.Value = (decimal)_benzodiazepine.Bioavailability.Value;
            if (_benzodiazepine.Bioavailability.IsRange && _benzodiazepine.Bioavailability.MaxValue.HasValue)
            {
                numericBioavailabilityMax.Value = (decimal)_benzodiazepine.Bioavailability.MaxValue.Value;
                numericBioavailabilityMax.Visible = true;
                lblBioavailabilitySeparator.Visible = true;
            }
            else
            {
                numericBioavailabilityMax.Visible = false;
                lblBioavailabilitySeparator.Visible = false;
            }

            // Initialisation de ActionDurationHours
            checkBoxActionDurationIsRange.Checked = _benzodiazepine.ActionDurationHours.IsRange;
            numericActionDuration.Value = (decimal)_benzodiazepine.ActionDurationHours.Value;
            if (_benzodiazepine.ActionDurationHours.IsRange && _benzodiazepine.ActionDurationHours.MaxValue.HasValue)
            {
                numericActionDurationMax.Value = (decimal)_benzodiazepine.ActionDurationHours.MaxValue.Value;
                numericActionDurationMax.Visible = true;
                lblActionDurationSeparator.Visible = true;
            }
            else
            {
                numericActionDurationMax.Visible = false;
                lblActionDurationSeparator.Visible = false;
            }

            // Sélectionner les propriétés pharmacologiques
            foreach (var property in _benzodiazepine.PharmacologicalProperties)
            {
                int index = _availableProperties.FindIndex(p => p.Name == property.Name);
                if (index >= 0)
                {
                    checkedListBoxProperties.SetItemChecked(index, true);
                }
            }

            // Sélectionner les indications thérapeutiques
            foreach (var indication in _benzodiazepine.TherapeuticIndications)
            {
                int index = _therapeuticIndications.IndexOf(indication);
                if (index >= 0)
                {
                    checkedListBoxIndications.SetItemChecked(index, true);
                }
            }
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

            // Enregistrer les modifications dans la base de données
            _databaseManager.UpdateBenzodiazepine(_benzodiazepine);

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