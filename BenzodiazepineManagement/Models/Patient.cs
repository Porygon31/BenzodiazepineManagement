namespace BenzodiazepineManagement.Models
{
    /// <summary>
    /// Représente les informations d'un patient selon le modèle français
    /// </summary>
    public class Patient
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string NumeroSecuriteSociale { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;

        /// <summary>
        /// Retourne le nom complet du patient
        /// </summary>
        public string NomComplet => $"{Prenom} {Nom}";

        /// <summary>
        /// Calcule l'âge du patient
        /// </summary>
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateNaissance.Year;
                if (DateNaissance.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public override string ToString()
        {
            return NomComplet;
        }
    }
}
