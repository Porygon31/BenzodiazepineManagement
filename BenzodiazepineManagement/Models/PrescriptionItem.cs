namespace BenzodiazepineManagement.Models
{
    /// <summary>
    /// Représente un médicament prescrit dans une ordonnance
    /// </summary>
    public class PrescriptionItem
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public int? BenzodiazepineId { get; set; } // Référence optionnelle à un benzodiazépine de la base
        public string NomMedicament { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Posologie { get; set; } = string.Empty; // Ex: "1 comprimé matin et soir"
        public int DureeTraitementJours { get; set; }
        public int QuantitePrescrite { get; set; } // Nombre de boîtes/unités
        public string? Instructions { get; set; } // Instructions spéciales

        /// <summary>
        /// Référence vers le benzodiazépine associé (si applicable)
        /// </summary>
        public Benzodiazepine? Benzodiazepine { get; set; }

        public override string ToString()
        {
            return $"{NomMedicament} {Dosage}";
        }
    }
}
