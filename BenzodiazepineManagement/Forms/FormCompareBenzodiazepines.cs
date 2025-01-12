using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using BenzodiazepineManagement.Models;
using BenzodiazepineManagement.Data;
using SkiaSharp;
using Svg.Skia;

namespace BenzodiazepineManagement.Forms
{
    /// <summary>
    /// Fenêtre pour comparer deux benzodiazépines.
    /// </summary>
    public partial class FormCompareBenzodiazepines : Form
    {
        private DatabaseManagerBase _databaseManager;
        private List<Benzodiazepine> _benzodiazepines;

        public FormCompareBenzodiazepines(DatabaseManagerBase databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
        }

        /// <summary>
        /// Événement déclenché lors du chargement de la fenêtre.
        /// </summary>
        private async void FormCompareBenzodiazepines_Load(object sender, EventArgs e)
        {
            _benzodiazepines = await _databaseManager.GetAllBenzodiazepinesAsync();

            // Remplir les ComboBox avec les benzodiazépines
            comboBoxBenzo1.DataSource = new List<Benzodiazepine>(_benzodiazepines);
            comboBoxBenzo1.DisplayMember = "OfficialName";

            comboBoxBenzo2.DataSource = new List<Benzodiazepine>(_benzodiazepines);
            comboBoxBenzo2.DisplayMember = "OfficialName";
        }

        /// <summary>
        /// Événement déclenché lors de la sélection d'une benzodiazépine dans la première ComboBox.
        /// </summary>
        private void comboBoxBenzo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBenzo = (Benzodiazepine)comboBoxBenzo1.SelectedItem;
            DisplayBenzoDetails(selectedBenzo, isFirst: true);
        }

        /// <summary>
        /// Événement déclenché lors de la sélection d'une benzodiazépine dans la deuxième ComboBox.
        /// </summary>
        private void comboBoxBenzo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBenzo = (Benzodiazepine)comboBoxBenzo2.SelectedItem;
            DisplayBenzoDetails(selectedBenzo, isFirst: false);
        }

        /// <summary>
        /// Affiche les détails de la benzodiazépine sélectionnée.
        /// </summary>
        /// <param name="benzo">La benzodiazépine à afficher.</param>
        /// <param name="isFirst">Indique s'il s'agit de la première ou de la deuxième benzodiazépine.</param>
        private void DisplayBenzoDetails(Benzodiazepine benzo, bool isFirst)
        {
            if (benzo == null)
                return;

            // Préparer les textes pour les champs qui peuvent être des plages
            string halfLifeText = benzo.HalfLife.IsRange && benzo.HalfLife.MaxValue.HasValue
                ? $"{benzo.HalfLife.Value} - {benzo.HalfLife.MaxValue.Value} heures"
                : $"{benzo.HalfLife.Value} heures";

            string onsetTimeText = benzo.OnsetTime.IsRange && benzo.OnsetTime.MaxValue.HasValue
                ? $"{benzo.OnsetTime.Value} - {benzo.OnsetTime.MaxValue.Value} heures"
                : $"{benzo.OnsetTime.Value} heures";

            string bioavailabilityText = benzo.Bioavailability.IsRange && benzo.Bioavailability.MaxValue.HasValue
                ? $"{benzo.Bioavailability.Value}% - {benzo.Bioavailability.MaxValue.Value}%"
                : $"{benzo.Bioavailability.Value}%";

            string actionDurationText = benzo.ActionDurationHours.IsRange && benzo.ActionDurationHours.MaxValue.HasValue
                ? $"{benzo.ActionDurationHours.Value} - {benzo.ActionDurationHours.MaxValue.Value} heures"
                : $"{benzo.ActionDurationHours.Value} heures";

            if (isFirst)
            {
                lblOfficialName1.Text = benzo.OfficialName;
                lblMoleculeName1.Text = benzo.MoleculeName;
                lblHalfLife1.Text = halfLifeText;
                lblOnsetTime1.Text = onsetTimeText;
                lblBioavailability1.Text = bioavailabilityText;
                lblMetabolism1.Text = benzo.Metabolism;
                lblElimination1.Text = benzo.Elimination;
                lblActionDuration1.Text = actionDurationText;
                lblDosage1.Text = benzo.Dosage;
                lblTherapeuticIndications1.Text = string.Join(", ", benzo.TherapeuticIndications);
                lblPharmacologicalProperties1.Text = string.Join(", ", benzo.PharmacologicalProperties.Select(p => p.Name));

                // Charger l'image SVG
                if (!string.IsNullOrEmpty(benzo.ImagePath) && File.Exists(benzo.ImagePath))
                {
                    try
                    {
                        var svg = new SKSvg();
                        using (var stream = File.OpenRead(benzo.ImagePath))
                        {
                            svg.Load(stream);
                        }

                        var picture = svg.Picture;
                        var bounds = picture.CullRect;
                        int width = (int)bounds.Width;
                        int height = (int)bounds.Height;

                        var bitmap = new SKBitmap(width, height);
                        using var canvas = new SKCanvas(bitmap);
                        canvas.Clear(SKColors.Transparent);
                        canvas.DrawPicture(picture);

                        using var image = bitmap.Encode(SKEncodedImageFormat.Png, 100);
                        pictureBoxMolecule1.Image = Image.FromStream(image.AsStream());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors du chargement de l'image SVG : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBoxMolecule1.Image = null;
                    }
                }
                else
                {
                    pictureBoxMolecule1.Image = null;
                }
            }
            else
            {
                lblOfficialName2.Text = benzo.OfficialName;
                lblMoleculeName2.Text = benzo.MoleculeName;
                lblHalfLife2.Text = halfLifeText;
                lblOnsetTime2.Text = onsetTimeText;
                lblBioavailability2.Text = bioavailabilityText;
                lblMetabolism2.Text = benzo.Metabolism;
                lblElimination2.Text = benzo.Elimination;
                lblActionDuration2.Text = actionDurationText;
                lblDosage2.Text = benzo.Dosage;
                lblTherapeuticIndications2.Text = string.Join(", ", benzo.TherapeuticIndications);
                lblPharmacologicalProperties2.Text = string.Join(", ", benzo.PharmacologicalProperties.Select(p => p.Name));

                // Charger l'image SVG
                if (!string.IsNullOrEmpty(benzo.ImagePath) && File.Exists(benzo.ImagePath))
                {
                    try
                    {
                        var svg = new SKSvg();
                        using (var stream = File.OpenRead(benzo.ImagePath))
                        {
                            svg.Load(stream);
                        }

                        var picture = svg.Picture;
                        var bounds = picture.CullRect;
                        int width = (int)bounds.Width;
                        int height = (int)bounds.Height;

                        var bitmap = new SKBitmap(width, height);
                        using var canvas = new SKCanvas(bitmap);
                        canvas.Clear(SKColors.Transparent);
                        canvas.DrawPicture(picture);

                        using var image = bitmap.Encode(SKEncodedImageFormat.Png, 100);
                        pictureBoxMolecule2.Image = Image.FromStream(image.AsStream());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors du chargement de l'image SVG : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBoxMolecule2.Image = null;
                    }
                }
                else
                {
                    pictureBoxMolecule2.Image = null;
                }
            }
        }
    }
}
