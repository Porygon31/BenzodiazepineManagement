namespace BenzodiazepineManagement.Models
{
    /// <summary>
    /// Représente une ordonnance médicale selon le modèle français
    /// </summary>
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DatePrescription { get; set; }
        public List<PrescriptionItem> Items { get; set; } = new List<PrescriptionItem>();
        public string? Observations { get; set; } // Notes du médecin
        public bool Renouvelable { get; set; } // Si l'ordonnance est renouvelable
        public int? NombreRenouvellements { get; set; } // Nombre de renouvellements autorisés

        /// <summary>
        /// Références vers le patient et le médecin
        /// </summary>
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }

        /// <summary>
        /// Date d'expiration de l'ordonnance (3 mois pour les benzodiazépines en France)
        /// </summary>
        public DateTime DateExpiration => DatePrescription.AddMonths(3);

        /// <summary>
        /// Vérifie si l'ordonnance est encore valide
        /// </summary>
        public bool EstValide => DateTime.Now <= DateExpiration;

        /// <summary>
        /// Retourne un résumé de l'ordonnance
        /// </summary>
        public string Resume
        {
            get
            {
                var itemsCount = Items?.Count ?? 0;
                var medicaments = itemsCount == 1 ? "médicament" : "médicaments";
                return $"{DatePrescription:dd/MM/yyyy} - {Patient?.NomComplet ?? "Patient inconnu"} - {itemsCount} {medicaments}";
            }
        }

        public override string ToString()
        {
            return Resume;
        }
    }
}
