using System;
using System.IO;

namespace BenzodiazepineManagement
{
    /// <summary>
    /// Classe contenant les constantes de l'application.
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// Chemin vers le dossier des images SVG.
        /// </summary>
        public static readonly string ImagesFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BenzodiazepineManagement", "Images");
    }
}
