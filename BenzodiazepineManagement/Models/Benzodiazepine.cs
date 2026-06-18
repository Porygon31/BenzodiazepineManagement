using System.Collections.Generic;

namespace BenzodiazepineManagement.Models
{
    /// <summary>
    /// Représente une benzodiazépine avec ses propriétés pharmacologiques et pharmacocinétiques.
    /// </summary>
    public class Benzodiazepine
    {
        // Identifiant unique en base de données
        public int Id { get; set; }
        // Nom commercial (princeps) de la benzodiazépine, ex: "Lexomil"
        public string OfficialName { get; set; }
        // Nom de la molécule (DCI), ex: "bromazépam"
        public string MoleculeName { get; set; }
        // Liste des propriétés pharmacologiques (anxiolytique, sédatif, etc.)
        public List<PharmacologicalProperty> PharmacologicalProperties { get; set; }
        // Demi-vie (élimination) exprimée en heures, éventuellement sous forme de plage de valeurs
        public ValueRange HalfLife { get; set; }
        // Temps de montée de l'effet (Tmax ou délai d'action) en heures, éventuellement en plage
        public ValueRange OnsetTime { get; set; }
        // Biodisponibilité en %, éventuellement fournie en plage
        public ValueRange Bioavailability { get; set; }
        // Métabolisme (chemin principal de biotransformation, par ex. hépatique)
        public string Metabolism { get; set; }
        // Élimination (voie principale d'excrétion, par ex. rénale)
        public string Elimination { get; set; }
        // Durée d'action (durée approximative des effets cliniques) en heures, éventuellement en plage
        public ValueRange ActionDurationHours { get; set; }
        // Indications thérapeutiques (liste des utilisations cliniques principales)
        public List<string> TherapeuticIndications { get; set; }
        // Dosage usuel ou forme galénique (ex: "Comprimé 6 mg, 1 à 3x/j")
        public string Dosage { get; set; }
        // Chemin vers une image SVG représentant la molécule (structure, logo, etc.)
        public string ImagePath { get; set; }

        // Propriétés calculées pour formatage (chaînes prêtes à l'affichage)
        public string HalfLifeFormatted => HalfLife?.ToString() ?? string.Empty;
        public string OnsetTimeFormatted => OnsetTime?.ToString() ?? string.Empty;
        public string BioavailabilityFormatted => Bioavailability?.ToString() ?? string.Empty;
        public string ActionDurationFormatted => ActionDurationHours?.ToString() ?? string.Empty;
    }
}
