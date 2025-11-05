namespace BenzodiazepineManagement.Models
{
    /// <summary>
    /// Représente les informations d'un médecin selon le modèle français
    /// </summary>
    public class Doctor
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string NumeroRPPS { get; set; } = string.Empty; // Répertoire Partagé des Professionnels de Santé
        public string Specialite { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Retourne le nom complet du médecin avec son titre
        /// </summary>
        public string NomComplet => $"Dr {Prenom} {Nom}";

        public override string ToString()
        {
            return NomComplet;
        }
    }
}
