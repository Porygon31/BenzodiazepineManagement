using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Newtonsoft.Json;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Data
{
    /// <summary>
    /// Gestionnaire d'accès aux données SQLite pour les benzodiazépines.
    /// </summary>
    public class DatabaseManager
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="DatabaseManager"/> avec le chemin du fichier de base de données.
        /// </summary>
        /// <param name="databasePath">Chemin vers le fichier de base de données SQLite.</param>
        public DatabaseManager(string databasePath)
        {
            _connectionString = $"Data Source={databasePath};Version=3;";
            InitializeDatabase();
        }

        /// <summary>
        /// Initialise la base de données en créant la table des benzodiazépines si elle n'existe pas.
        /// </summary>
        private void InitializeDatabase()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Benzodiazepines (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    OfficialName TEXT NOT NULL,
                    MoleculeName TEXT NOT NULL,
                    PharmacologicalProperties TEXT NOT NULL,  -- stocké en JSON
                    HalfLife TEXT NOT NULL,                    -- stocké en JSON (ValueRange)
                    OnsetTime TEXT NOT NULL,                   -- stocké en JSON (ValueRange)
                    Bioavailability TEXT,                     -- stocké en JSON (ValueRange)
                    Metabolism TEXT,
                    Elimination TEXT,
                    ActionDurationHours TEXT,                 -- stocké en JSON (ValueRange)
                    TherapeuticIndications TEXT,              -- stocké en JSON (List<string>)
                    Dosage TEXT,
                    ImagePath TEXT
                );";
            // Création de la table si non existante
            using var command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Ajoute une nouvelle benzodiazépine dans la base de données.
        /// </summary>
        /// <param name="benzo">Objet Benzodiazepine à insérer.</param>
        public void AddBenzodiazepine(Benzodiazepine benzo)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string insertQuery = @"
                INSERT INTO Benzodiazepines (
                    OfficialName, MoleculeName, PharmacologicalProperties, HalfLife, OnsetTime,
                    Bioavailability, Metabolism, Elimination, ActionDurationHours, TherapeuticIndications,
                    Dosage, ImagePath
                ) VALUES (
                    @OfficialName, @MoleculeName, @PharmacologicalProperties, @HalfLife, @OnsetTime,
                    @Bioavailability, @Metabolism, @Elimination, @ActionDurationHours, @TherapeuticIndications,
                    @Dosage, @ImagePath
                );";

            using var command = new SQLiteCommand(insertQuery, connection);
            // Les propriétés complexes (listes, objets ValueRange) sont sérialisées en JSON pour stockage
            command.Parameters.AddWithValue("@OfficialName", benzo.OfficialName);
            command.Parameters.AddWithValue("@MoleculeName", benzo.MoleculeName);
            command.Parameters.AddWithValue("@PharmacologicalProperties", JsonConvert.SerializeObject(benzo.PharmacologicalProperties));
            command.Parameters.AddWithValue("@HalfLife", JsonConvert.SerializeObject(benzo.HalfLife));
            command.Parameters.AddWithValue("@OnsetTime", JsonConvert.SerializeObject(benzo.OnsetTime));
            command.Parameters.AddWithValue("@Bioavailability", JsonConvert.SerializeObject(benzo.Bioavailability));
            command.Parameters.AddWithValue("@Metabolism", benzo.Metabolism);
            command.Parameters.AddWithValue("@Elimination", benzo.Elimination);
            command.Parameters.AddWithValue("@ActionDurationHours", JsonConvert.SerializeObject(benzo.ActionDurationHours));
            command.Parameters.AddWithValue("@TherapeuticIndications", JsonConvert.SerializeObject(benzo.TherapeuticIndications));
            command.Parameters.AddWithValue("@Dosage", benzo.Dosage);
            command.Parameters.AddWithValue("@ImagePath", benzo.ImagePath ?? string.Empty);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupère toutes les benzodiazépines depuis la base de données.
        /// </summary>
        /// <returns>Liste de toutes les benzodiazépines stockées.</returns>
        public List<Benzodiazepine> GetAllBenzodiazepines()
        {
            var benzodiazepines = new List<Benzodiazepine>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string selectQuery = "SELECT * FROM Benzodiazepines;";
            using var command = new SQLiteCommand(selectQuery, connection);
            using SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Désérialisation des champs JSON en objets C#
                var benzo = new Benzodiazepine
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    OfficialName = reader["OfficialName"].ToString(),
                    MoleculeName = reader["MoleculeName"].ToString(),
                    PharmacologicalProperties = DeserializeOrDefault<List<PharmacologicalProperty>>(reader["PharmacologicalProperties"]),
                    HalfLife = DeserializeOrDefault<ValueRange>(reader["HalfLife"]),
                    OnsetTime = DeserializeOrDefault<ValueRange>(reader["OnsetTime"]),
                    Bioavailability = DeserializeOrDefault<ValueRange>(reader["Bioavailability"]),
                    Metabolism = reader["Metabolism"].ToString(),
                    Elimination = reader["Elimination"].ToString(),
                    ActionDurationHours = DeserializeOrDefault<ValueRange>(reader["ActionDurationHours"]),
                    TherapeuticIndications = DeserializeOrDefault<List<string>>(reader["TherapeuticIndications"]),
                    Dosage = reader["Dosage"].ToString(),
                    ImagePath = reader["ImagePath"].ToString()
                };
                benzodiazepines.Add(benzo);
            }

            return benzodiazepines;
        }

        /// <summary>
        /// Met à jour une benzodiazépine existante dans la base de données.
        /// </summary>
        /// <param name="benzo">Objet benzodiazépine avec les nouvelles valeurs (doit avoir un Id valide).</param>
        public void UpdateBenzodiazepine(Benzodiazepine benzo)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string updateQuery = @"
                UPDATE Benzodiazepines SET
                    OfficialName = @OfficialName,
                    MoleculeName = @MoleculeName,
                    PharmacologicalProperties = @PharmacologicalProperties,
                    HalfLife = @HalfLife,
                    OnsetTime = @OnsetTime,
                    Bioavailability = @Bioavailability,
                    Metabolism = @Metabolism,
                    Elimination = @Elimination,
                    ActionDurationHours = @ActionDurationHours,
                    TherapeuticIndications = @TherapeuticIndications,
                    Dosage = @Dosage,
                    ImagePath = @ImagePath
                WHERE Id = @Id;";

            using var command = new SQLiteCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@OfficialName", benzo.OfficialName);
            command.Parameters.AddWithValue("@MoleculeName", benzo.MoleculeName);
            command.Parameters.AddWithValue("@PharmacologicalProperties", JsonConvert.SerializeObject(benzo.PharmacologicalProperties));
            command.Parameters.AddWithValue("@HalfLife", JsonConvert.SerializeObject(benzo.HalfLife));
            command.Parameters.AddWithValue("@OnsetTime", JsonConvert.SerializeObject(benzo.OnsetTime));
            command.Parameters.AddWithValue("@Bioavailability", JsonConvert.SerializeObject(benzo.Bioavailability));
            command.Parameters.AddWithValue("@Metabolism", benzo.Metabolism);
            command.Parameters.AddWithValue("@Elimination", benzo.Elimination);
            command.Parameters.AddWithValue("@ActionDurationHours", JsonConvert.SerializeObject(benzo.ActionDurationHours));
            command.Parameters.AddWithValue("@TherapeuticIndications", JsonConvert.SerializeObject(benzo.TherapeuticIndications));
            command.Parameters.AddWithValue("@Dosage", benzo.Dosage);
            command.Parameters.AddWithValue("@ImagePath", benzo.ImagePath ?? string.Empty);
            command.Parameters.AddWithValue("@Id", benzo.Id);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Supprime une benzodiazépine de la base de données par son identifiant.
        /// </summary>
        /// <param name="id">Id de la benzodiazépine à supprimer.</param>
        public void DeleteBenzodiazepine(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM Benzodiazepines WHERE Id = @Id;";
            using var command = new SQLiteCommand(deleteQuery, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Désérialise un champ JSON depuis la base de données ou retourne une valeur par défaut si échec.
        /// </summary>
        private T DeserializeOrDefault<T>(object data)
        {
            if (data == null || data == DBNull.Value || string.IsNullOrWhiteSpace(data.ToString()))
            {
                return default;
            }
            try
            {
                return JsonConvert.DeserializeObject<T>(data.ToString());
            }
            catch (Exception ex)
            {
                // En cas d'erreur de désérialisation, on peut logguer l'erreur et retourner une valeur par défaut
                System.Diagnostics.Debug.WriteLine($"Erreur lors de la désérialisation de {typeof(T).Name}: {ex.Message}");
                if (typeof(T) == typeof(ValueRange))
                {
                    return (T)(object)new ValueRange();
                }
                else if (typeof(T) == typeof(List<PharmacologicalProperty>))
                {
                    return (T)(object)new List<PharmacologicalProperty>();
                }
                else if (typeof(T) == typeof(List<string>))
                {
                    return (T)(object)new List<string>();
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
