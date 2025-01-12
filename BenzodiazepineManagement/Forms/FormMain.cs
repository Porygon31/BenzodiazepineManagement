using BenzodiazepineManagement.Data;
using BenzodiazepineManagement.Forms;
using BenzodiazepineManagement.Models;
using SkiaSharp;
using Svg.Skia;

namespace BenzodiazepineManagement
{
    public partial class FormMain : Form
    {
        private DatabaseManager _databaseManager;
        private List<Benzodiazepine> _benzodiazepines;

        public FormMain()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager("benzodiazepines.db");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadBenzodiazepines();
        }

        /// <summary>
        /// Charge les benzodiazépines depuis la base de données et les affiche dans le DataGridView.
        /// </summary>
        private void LoadBenzodiazepines()
        {
            _benzodiazepines = _databaseManager.GetAllBenzodiazepines();

            dataGridViewBenzos.DataSource = null;
            dataGridViewBenzos.AutoGenerateColumns = false;
            dataGridViewBenzos.Columns.Clear();

            // Ajoutez les colonnes que vous souhaitez afficher
            dataGridViewBenzos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OfficialName",
                HeaderText = "Nom Officiel"
            });

            dataGridViewBenzos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoleculeName",
                HeaderText = "Nom de la Molécule"
            });

            dataGridViewBenzos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HalfLifeFormatted",
                HeaderText = "Demi-vie"
            });

            dataGridViewBenzos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OnsetTimeFormatted",
                HeaderText = "Temps d'Apparition"
            });

            dataGridViewBenzos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BioavailabilityFormatted",
                HeaderText = "Biodisponibilité"
            });

            // Ajoutez d'autres colonnes si nécessaire

            dataGridViewBenzos.DataSource = _benzodiazepines;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter".
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new FormAddBenzodiazepine(_databaseManager);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadBenzodiazepines();
            }
        }

        private void dataGridViewBenzos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBenzos.CurrentRow != null)
            {
                var selectedBenzo = (Benzodiazepine)dataGridViewBenzos.CurrentRow.DataBoundItem;
                DisplayBenzodiazepineDetails(selectedBenzo);
            }
        }

        /// <summary>
        /// Affiche les détails de la benzodiazépine sélectionnée dans les labels correspondants.
        /// </summary>
        /// <param name="benzo">La benzodiazépine à afficher.</param>
        private void DisplayBenzodiazepineDetails(Benzodiazepine benzo)
        {
            lblOfficialName.Text = benzo.OfficialName;
            lblMoleculeName.Text = benzo.MoleculeName;

            // Affichage de HalfLife
            lblHalfLife.Text = benzo.HalfLife.IsRange && benzo.HalfLife.MaxValue.HasValue
                ? $"{benzo.HalfLife.Value} - {benzo.HalfLife.MaxValue.Value} heures"
                : $"{benzo.HalfLife.Value} heures";

            // Affichage de OnsetTime
            lblOnsetTime.Text = benzo.OnsetTime.IsRange && benzo.OnsetTime.MaxValue.HasValue
                ? $"{benzo.OnsetTime.Value} - {benzo.OnsetTime.MaxValue.Value} heures"
                : $"{benzo.OnsetTime.Value} heures";

            // Affichage de Bioavailability
            lblBioavailability.Text = benzo.Bioavailability.IsRange && benzo.Bioavailability.MaxValue.HasValue
                ? $"{benzo.Bioavailability.Value}% - {benzo.Bioavailability.MaxValue.Value}%"
                : $"{benzo.Bioavailability.Value}%";

            // Affichage de ActionDurationHours
            lblActionDuration.Text = benzo.ActionDurationHours.IsRange && benzo.ActionDurationHours.MaxValue.HasValue
                ? $"{benzo.ActionDurationHours.Value} - {benzo.ActionDurationHours.MaxValue.Value} heures"
                : $"{benzo.ActionDurationHours.Value} heures";

            lblMetabolism.Text = benzo.Metabolism;
            lblElimination.Text = benzo.Elimination;
            lblDosage.Text = benzo.Dosage;
            lblTherapeuticIndications.Text = string.Join(", ", benzo.TherapeuticIndications);
            lblPharmacologicalProperties.Text = string.Join(", ", benzo.PharmacologicalProperties.Select(p => p.Name));

            // Chargement de l'image SVG
            if (!string.IsNullOrEmpty(benzo.ImagePath) && System.IO.File.Exists(benzo.ImagePath))
            {
                try
                {
                    var svg = new SKSvg();
                    using (var stream = System.IO.File.OpenRead(benzo.ImagePath))
                    {
                        svg.Load(stream);
                    }

                    var picture = svg.Picture;

                    // Utiliser picture.CullRect pour obtenir les dimensions
                    var bounds = picture.CullRect;
                    int width = (int)bounds.Width;
                    int height = (int)bounds.Height;

                    var bitmap = new SKBitmap(width, height);
                    using var canvas = new SKCanvas(bitmap);
                    canvas.Clear(SKColors.Transparent);
                    canvas.DrawPicture(picture);

                    using var image = bitmap.Encode(SKEncodedImageFormat.Png, 100);
                    pictureBoxMolecule.Image = Image.FromStream(image.AsStream());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du chargement de l'image SVG : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBoxMolecule.Image = null;
                }
            }
            else
            {
                pictureBoxMolecule.Image = null;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBenzos.CurrentRow != null)
            {
                var selectedBenzo = (Benzodiazepine)dataGridViewBenzos.CurrentRow.DataBoundItem;
                var editForm = new FormEditBenzodiazepine(_databaseManager, selectedBenzo);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBenzodiazepines();
                }
            }

        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var compareForm = new FormCompareBenzodiazepines(_databaseManager);
            compareForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBenzos.CurrentRow != null)
            {
                var selectedBenzo = (Benzodiazepine)dataGridViewBenzos.CurrentRow.DataBoundItem;
                var result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer {selectedBenzo.OfficialName} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _databaseManager.DeleteBenzodiazepine(selectedBenzo.Id);
                    LoadBenzodiazepines();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text.ToLower();

            var filteredList = _benzodiazepines.Where(b =>
                b.OfficialName.ToLower().Contains(searchTerm) ||
                b.MoleculeName.ToLower().Contains(searchTerm) ||
                b.HalfLifeFormatted.ToLower().Contains(searchTerm) ||
                b.OnsetTimeFormatted.ToLower().Contains(searchTerm) ||
                b.BioavailabilityFormatted.ToLower().Contains(searchTerm) ||
                b.PharmacologicalProperties.Any(p => p.Name.ToLower().Contains(searchTerm)) ||
                b.TherapeuticIndications.Any(i => i.ToLower().Contains(searchTerm))
            ).ToList();

            dataGridViewBenzos.DataSource = filteredList;
        }
    }
}