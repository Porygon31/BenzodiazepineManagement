using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SkiaSharp;
using Svg.Skia;
using BenzodiazepineManagement.Data;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement
{
    public partial class FormMain : Form
    {
        // Gestionnaire de base de données SQLite
        private DatabaseManager _databaseManager;
        // Liste complète des benzodiazépines en mémoire (issue de la base)
        private List<Benzodiazepine> _allBenzos;

        public FormMain()
        {
            InitializeComponent();
            // Déterminer le chemin du fichier de base de données (stocké dans AppData de l'utilisateur)
            string baseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BenzodiazepineManagement");
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }
            string dbPath = Path.Combine(baseFolder, "benzodiazepines.db");
            // Initialiser le gestionnaire de base de données
            _databaseManager = new DatabaseManager(dbPath);
        }

        /// <summary>
        /// Événement déclenché au chargement de la fenêtre principale.
        /// Initialise la grille et charge les données.
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Récupérer toutes les benzodiazépines depuis la base de données
            _allBenzos = _databaseManager.GetAllBenzodiazepines();
            // Si la base est vide, on insère des données initiales (Lexomil, Xanax, Témesta)
            if (_allBenzos.Count == 0)
            {
                AddInitialBenzodiazepines();
                // Recharger la liste après insertion des données initiales
                _allBenzos = _databaseManager.GetAllBenzodiazepines();
            }

            // Configuration du DataGridView pour afficher les benzodiazépines
            dataGridViewBenzos.AutoGenerateColumns = false;       // on va définir manuellement les colonnes
            dataGridViewBenzos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBenzos.MultiSelect = false;
            dataGridViewBenzos.ReadOnly = true;
            dataGridViewBenzos.AllowUserToAddRows = false;
            dataGridViewBenzos.AllowUserToDeleteRows = false;
            dataGridViewBenzos.Columns.Clear();
            // Colonne pour le nom commercial (OfficialName)
            var colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "Princeps";
            colName.DataPropertyName = "OfficialName";
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.FillWeight = 50;  // poids relatif pour l'ajustement
            // Colonne pour le nom de molécule (MoleculeName)
            var colMolecule = new DataGridViewTextBoxColumn();
            colMolecule.HeaderText = "Molécule";
            colMolecule.DataPropertyName = "MoleculeName";
            colMolecule.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMolecule.FillWeight = 50;
            dataGridViewBenzos.Columns.Add(colName);
            dataGridViewBenzos.Columns.Add(colMolecule);

            // Lier la liste complète à la grille (affiche tous les éléments initialement)
            dataGridViewBenzos.DataSource = _allBenzos;
        }

        /// <summary>
        /// Insère les benzodiazépines initiales dans la base de données (Lexomil, Xanax, Témesta avec valeurs réelles).
        /// </summary>
        private void AddInitialBenzodiazepines()
        {
            // 1. Lexomil (bromazépam)
            var lexomil = new Benzodiazepine
            {
                OfficialName = "Lexomil",
                MoleculeName = "Bromazépam",
                // Propriétés pharmacologiques principales : anxiolytique et sédatif
                PharmacologicalProperties = new List<PharmacologicalProperty>
                {
                    new PharmacologicalProperty
                    {
                        Name = "Anxiolytique",
                        Description = "Réduction de l'anxiété en modulant l'activité du GABA au niveau du système limbique."
                    },
                    new PharmacologicalProperty
                    {
                        Name = "Sédatif et hypnotique",
                        Description = "Effet calmant et induction du sommeil, utilisé pour les troubles du sommeil et les états d'agitation."
                    }
                },
                // Demi-vie ~10-20h
                HalfLife = new ValueRange { IsRange = true, Value = 10.0, MaxValue = 20.0 },
                // Temps de montée (Tmax) ~1-4h
                OnsetTime = new ValueRange { IsRange = true, Value = 1.0, MaxValue = 4.0 },
                // Biodisponibilité ~84%
                Bioavailability = new ValueRange { IsRange = false, Value = 84.0, MaxValue = null },
                // Métabolisme essentiellement hépatique (oxydation via CYP450)
                Metabolism = "Hépatique (CYP450)",
                // Élimination principalement rénale sous forme métabolisée
                Elimination = "Rénale (métabolites)",
                // Durée d'action ~12h (effet anxiolytique d'une dose)
                ActionDurationHours = new ValueRange { IsRange = false, Value = 12.0, MaxValue = null },
                // Indications thérapeutiques principales: troubles anxieux 
                TherapeuticIndications = new List<string>
                {
                    "Troubles anxieux (psychologique)",
                    "Troubles anxieux physiques (tremblements, palpitations, sueurs, etc.)"
                },
                // Posologie usuelle (exemple pour Lexomil 6 mg fractionnable)
                Dosage = "1,5 à 6 mg/j (comprimé 6 mg fractionnable)",
                // Pas d'image initiale fournie
                ImagePath = string.Empty
            };
            _databaseManager.AddBenzodiazepine(lexomil);

            // 2. Xanax (alprazolam)
            var xanax = new Benzodiazepine
            {
                OfficialName = "Xanax",
                MoleculeName = "Alprazolam",
                // Propriétés : anxiolytique et sédatif principalement
                PharmacologicalProperties = new List<PharmacologicalProperty>
                {
                    new PharmacologicalProperty
                    {
                        Name = "Anxiolytique",
                        Description = "Réduction de l'anxiété en modulant l'activité du GABA au niveau du système limbique."
                    },
                    new PharmacologicalProperty
                    {
                        Name = "Sédatif et hypnotique",
                        Description = "Effet calmant et induction du sommeil, utilisé pour les troubles du sommeil et les états d'agitation."
                    }
                },
                // Demi-vie ~6-12h chez l'adulte
                HalfLife = new ValueRange { IsRange = true, Value = 6.0, MaxValue = 12.0 },
                // Temps de montée ~0,5-1h (action rapide)
                OnsetTime = new ValueRange { IsRange = true, Value = 0.5, MaxValue = 1.0 },
                // Biodisponibilité ~90%
                Bioavailability = new ValueRange { IsRange = false, Value = 90.0, MaxValue = null },
                // Métabolisme hépatique (CYP3A4 principalement)
                Metabolism = "Hépatique (CYP3A4)",
                // Élimination rénale (métabolites inactifs)
                Elimination = "Rénale (métabolites)",
                // Durée d'action ~4-6h (effet relativement court)
                ActionDurationHours = new ValueRange { IsRange = true, Value = 4.0, MaxValue = 6.0 },
                // Indications : troubles anxieux (notamment attaques de panique)
                TherapeuticIndications = new List<string>
                {
                    "Troubles anxieux (psychologique)",
                    "Troubles anxieux physiques (tremblements, palpitations, sueurs, etc.)"
                },
                // Posologie usuelle : de 0,25 mg à 0,5 mg jusqu'à 3 fois par jour
                Dosage = "0,25 à 0,5 mg jusqu'à 3x/j (max ~4 mg/j)",
                ImagePath = string.Empty
            };
            _databaseManager.AddBenzodiazepine(xanax);

            // 3. Témesta (lorazépam)
            var temesta = new Benzodiazepine
            {
                OfficialName = "Témesta",
                MoleculeName = "Lorazépam",
                // Propriétés : anxiolytique, sédatif, anticonvulsivant, amnésique
                PharmacologicalProperties = new List<PharmacologicalProperty>
                {
                    new PharmacologicalProperty
                    {
                        Name = "Anxiolytique",
                        Description = "Réduction de l'anxiété en modulant l'activité du GABA au niveau du système limbique."
                    },
                    new PharmacologicalProperty
                    {
                        Name = "Sédatif et hypnotique",
                        Description = "Effet calmant et induction du sommeil, utilisé pour les troubles du sommeil et les états d'agitation."
                    },
                    new PharmacologicalProperty
                    {
                        Name = "Anticonvulsivant",
                        Description = "Prévention ou arrêt des crises épileptiques, utilisé dans l'épilepsie et les convulsions aiguës."
                    },
                    new PharmacologicalProperty
                    {
                        Name = "Amnésique",
                        Description = "Effet d'amnésie antérograde, souvent utilisé dans des contextes médicaux comme la prémédication avant une anesthésie."
                    }
                },
                // Demi-vie ~10-20h
                HalfLife = new ValueRange { IsRange = true, Value = 10.0, MaxValue = 20.0 },
                // Temps de montée ~1-2h (voie orale)
                OnsetTime = new ValueRange { IsRange = true, Value = 1.0, MaxValue = 2.0 },
                // Biodisponibilité ~90%
                Bioavailability = new ValueRange { IsRange = false, Value = 90.0, MaxValue = null },
                // Métabolisme hépatique (glucuronoconjugaison, pas de métabolites actifs)
                Metabolism = "Hépatique (glucuronidation)",
                // Élimination rénale (sous forme de glucuronides)
                Elimination = "Rénale (conjugué)",
                // Durée d'action ~6-8h
                ActionDurationHours = new ValueRange { IsRange = true, Value = 6.0, MaxValue = 8.0 },
                // Indications : anxiolyse, insomnie, épilepsie (status), sevrage alcoolique
                TherapeuticIndications = new List<string>
                {
                    "Troubles anxieux (psychologique)",
                    "Troubles anxieux physiques (tremblements, palpitations, sueurs, etc.)",
                    "Insomnie à court terme",
                    "Crises d’épilepsie (y compris le status epilepticus)",
                    "Sevrage alcoolique"
                },
                // Posologies typiques : 1 à 2,5 mg/j (anxiété) ; 1-2 mg au coucher (insomnie)
                Dosage = "1 à 2,5 mg/j (anxiété) ou 1-2 mg au coucher (insomnie)",
                ImagePath = string.Empty
            };
            _databaseManager.AddBenzodiazepine(temesta);
        }

        /// <summary>
        /// Événement déclenché lors de la modification du texte de recherche.
        /// Met à jour le filtrage dans la grille.
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                // Si la zone de recherche est vide, afficher tous les éléments
                dataGridViewBenzos.DataSource = _allBenzos;
            }
            else
            {
                // Filtrer la liste des benzodiazépines en fonction du texte (dans le nom officiel ou le nom de molécule)
                var filteredList = _allBenzos.Where(b =>
                    b.OfficialName.ToLower().Contains(searchText) ||
                    b.MoleculeName.ToLower().Contains(searchText)
                ).ToList();
                dataGridViewBenzos.DataSource = filteredList;
            }
        }

        /// <summary>
        /// Événement déclenché lorsqu'une sélection de ligne change dans la DataGridView.
        /// Affiche les détails de la benzodiazépine sélectionnée dans les labels et l'image.
        /// </summary>
        private void dataGridViewBenzos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBenzos.SelectedRows.Count > 0)
            {
                // Récupérer l'objet Benzodiazepine de la ligne sélectionnée
                var selectedBenzo = dataGridViewBenzos.SelectedRows[0].DataBoundItem as Benzodiazepine;
                if (selectedBenzo != null)
                {
                    // Mettre à jour les labels de détail avec les informations de l'objet
                    lblOfficialName.Text = $"Princeps: {selectedBenzo.OfficialName}";
                    lblMoleculeName.Text = $"Nom de la molécule: {selectedBenzo.MoleculeName}";
                    // Formater les champs numériques (plages ou valeurs uniques) pour l'affichage
                    string halfLifeText = selectedBenzo.HalfLife != null
                        ? (selectedBenzo.HalfLife.IsRange && selectedBenzo.HalfLife.MaxValue.HasValue
                            ? $"{selectedBenzo.HalfLife.Value} - {selectedBenzo.HalfLife.MaxValue.Value} heures"
                            : $"{selectedBenzo.HalfLife.Value} heures")
                        : "";
                    lblHalfLife.Text = $"Demi Vie: {halfLifeText}";

                    string onsetText = selectedBenzo.OnsetTime != null
                        ? (selectedBenzo.OnsetTime.IsRange && selectedBenzo.OnsetTime.MaxValue.HasValue
                            ? $"{selectedBenzo.OnsetTime.Value} - {selectedBenzo.OnsetTime.MaxValue.Value} heures"
                            : $"{selectedBenzo.OnsetTime.Value} heures")
                        : "";
                    lblOnsetTime.Text = $"Onset: {onsetText}";

                    string bioText = selectedBenzo.Bioavailability != null
                        ? (selectedBenzo.Bioavailability.IsRange && selectedBenzo.Bioavailability.MaxValue.HasValue
                            ? $"{selectedBenzo.Bioavailability.Value}% - {selectedBenzo.Bioavailability.MaxValue.Value}%"
                            : $"{selectedBenzo.Bioavailability.Value}%")
                        : "";
                    lblBioavailability.Text = $"Bioavailabilité: {bioText}";

                    lblMetabolism.Text = $"Métabolisme: {selectedBenzo.Metabolism}";
                    lblElimination.Text = $"Élimination: {selectedBenzo.Elimination}";

                    string actionText = selectedBenzo.ActionDurationHours != null
                        ? (selectedBenzo.ActionDurationHours.IsRange && selectedBenzo.ActionDurationHours.MaxValue.HasValue
                            ? $"{selectedBenzo.ActionDurationHours.Value} - {selectedBenzo.ActionDurationHours.MaxValue.Value} heures"
                            : $"{selectedBenzo.ActionDurationHours.Value} heures")
                        : "";
                    lblActionDuration.Text = $"Durée d'action: {actionText}";

                    lblDosage.Text = $"Dosage: {selectedBenzo.Dosage}";
                    // Afficher les listes sous forme de chaîne jointe
                    lblTherapeuticIndications.Text = $"Indication Thérapeutique: " +
                        string.Join(", ", selectedBenzo.TherapeuticIndications ?? new List<string>());
                    lblPharmacologicalProperties.Text = $"Propriétés pharmacologique: " +
                        string.Join(", ", selectedBenzo.PharmacologicalProperties?.Select(p => p.Name) ?? new string[0]);

                    // Chargement et affichage de l'image SVG via SkiaSharp
                    if (!string.IsNullOrEmpty(selectedBenzo.ImagePath) && File.Exists(selectedBenzo.ImagePath))
                    {
                        try
                        {
                            // Charger le fichier SVG
                            var svg = new SKSvg();
                            using (var stream = File.OpenRead(selectedBenzo.ImagePath))
                            {
                                svg.Load(stream);
                            }
                            // Récupérer l'image vectorielle en mémoire
                            var picture = svg.Picture;
                            var bounds = picture.CullRect;
                            int width = (int)bounds.Width;
                            int height = (int)bounds.Height;
                            // Créer un bitmap SKia aux dimensions de l'image SVG
                            using var bitmap = new SKBitmap(width, height);
                            using var canvas = new SKCanvas(bitmap);
                            canvas.Clear(SKColors.Transparent);
                            // Dessiner l'image SVG sur le bitmap
                            canvas.DrawPicture(picture);
                            // Encoder le bitmap en PNG puis le charger dans un objet Image .NET
                            using var imageData = bitmap.Encode(SKEncodedImageFormat.Png, 100);
                            pictureBoxMolecule.Image = System.Drawing.Image.FromStream(imageData.AsStream());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erreur lors du chargement de l'image SVG : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pictureBoxMolecule.Image = null;
                        }
                    }
                    else
                    {
                        // Si pas d'image, on efface le PictureBox
                        pictureBoxMolecule.Image = null;
                    }
                }
            }
            else
            {
                // Aucune sélection : effacer les détails affichés
                lblOfficialName.Text = "Princeps:";
                lblMoleculeName.Text = "Nom de la molécule:";
                lblHalfLife.Text = "Demi Vie:";
                lblOnsetTime.Text = "Onset:";
                lblBioavailability.Text = "Bioavailabilité:";
                lblMetabolism.Text = "Métabolisme:";
                lblElimination.Text = "Élimination:";
                lblActionDuration.Text = "Durée d'action:";
                lblDosage.Text = "Dosage:";
                lblTherapeuticIndications.Text = "Indication Thérapeutique:";
                lblPharmacologicalProperties.Text = "Propriétés pharmacologique:";
                pictureBoxMolecule.Image = null;
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter".
        /// Ouvre la fenêtre d'ajout d'une benzodiazépine.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var formAdd = new Forms.FormAddBenzodiazepine(_databaseManager);
            if (formAdd.ShowDialog(this) == DialogResult.OK)
            {
                // Après ajout, rafraîchir la liste depuis la base de données
                _allBenzos = _databaseManager.GetAllBenzodiazepines();
                txtSearch.Text = string.Empty; // réinitialiser la recherche pour tout afficher
                dataGridViewBenzos.DataSource = _allBenzos;
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Éditer".
        /// Ouvre la fenêtre d'édition pour la benzodiazépine sélectionnée.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBenzos.SelectedRows.Count > 0)
            {
                var selectedBenzo = dataGridViewBenzos.SelectedRows[0].DataBoundItem as Benzodiazepine;
                if (selectedBenzo != null)
                {
                    var formEdit = new Forms.FormEditBenzodiazepine(_databaseManager, selectedBenzo);
                    if (formEdit.ShowDialog(this) == DialogResult.OK)
                    {
                        // Après modification, recharger les données
                        _allBenzos = _databaseManager.GetAllBenzodiazepines();
                        txtSearch.Text = string.Empty;
                        dataGridViewBenzos.DataSource = _allBenzos;
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une entrée à éditer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer".
        /// Supprime la benzodiazépine sélectionnée après confirmation.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBenzos.SelectedRows.Count > 0)
            {
                var selectedBenzo = dataGridViewBenzos.SelectedRows[0].DataBoundItem as Benzodiazepine;
                if (selectedBenzo != null)
                {
                    // Demander confirmation à l'utilisateur
                    var result = MessageBox.Show($"Supprimer \"{selectedBenzo.OfficialName}\" de la liste ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        _databaseManager.DeleteBenzodiazepine(selectedBenzo.Id);
                        // Mettre à jour la liste locale après suppression
                        _allBenzos = _databaseManager.GetAllBenzodiazepines();
                        txtSearch.Text = string.Empty;
                        dataGridViewBenzos.DataSource = _allBenzos;
                        // Après suppression, on peut effacer les détails affichés
                        pictureBoxMolecule.Image = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une entrée à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Comparer Benzo".
        /// Ouvre la fenêtre de comparaison de deux benzodiazépines.
        /// </summary>
        private void btnCompare_Click(object sender, EventArgs e)
        {
            var formCompare = new Forms.FormCompareBenzodiazepines(_databaseManager);
            formCompare.ShowDialog(this);
        }
    }
}
