using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Newtonsoft.Json;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Data
{
    /// <summary>
    /// Gestionnaire pour les opérations de base de données SQLite.
    /// </summary>
    public class DatabaseManager
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DatabaseManager"/>.
        /// </summary>
        /// <param name="databasePath">Chemin vers le fichier de base de données SQLite.</param>
        public DatabaseManager(string databasePath)
        {
            _connectionString = $"Data Source={databasePath};Version=3;";
            InitializeDatabase();
        }

        /// <summary>
        /// Initialise la base de données en créant la table si elle n'existe pas.
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
                    PharmacologicalProperties TEXT NOT NULL,
                    HalfLife TEXT NOT NULL,
                    OnsetTime TEXT NOT NULL,
                    Bioavailability TEXT,
                    Metabolism TEXT,
                    Elimination TEXT,
                    ActionDurationHours TEXT,
                    TherapeuticIndications TEXT,
                    Dosage TEXT,
                    ImagePath TEXT
                );

                CREATE TABLE IF NOT EXISTS Patients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nom TEXT NOT NULL,
                    Prenom TEXT NOT NULL,
                    DateNaissance TEXT NOT NULL,
                    NumeroSecuriteSociale TEXT,
                    Adresse TEXT,
                    CodePostal TEXT,
                    Ville TEXT,
                    Telephone TEXT
                );

                CREATE TABLE IF NOT EXISTS Doctors (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nom TEXT NOT NULL,
                    Prenom TEXT NOT NULL,
                    NumeroRPPS TEXT NOT NULL,
                    Specialite TEXT,
                    Adresse TEXT,
                    CodePostal TEXT,
                    Ville TEXT,
                    Telephone TEXT,
                    Email TEXT
                );

                CREATE TABLE IF NOT EXISTS Prescriptions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PatientId INTEGER NOT NULL,
                    DoctorId INTEGER NOT NULL,
                    DatePrescription TEXT NOT NULL,
                    Observations TEXT,
                    Renouvelable INTEGER NOT NULL DEFAULT 0,
                    NombreRenouvellements INTEGER,
                    FOREIGN KEY (PatientId) REFERENCES Patients(Id),
                    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
                );

                CREATE TABLE IF NOT EXISTS PrescriptionItems (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PrescriptionId INTEGER NOT NULL,
                    BenzodiazepineId INTEGER,
                    NomMedicament TEXT NOT NULL,
                    Dosage TEXT NOT NULL,
                    Posologie TEXT NOT NULL,
                    DureeTraitementJours INTEGER NOT NULL,
                    QuantitePrescrite INTEGER NOT NULL,
                    Instructions TEXT,
                    FOREIGN KEY (PrescriptionId) REFERENCES Prescriptions(Id),
                    FOREIGN KEY (BenzodiazepineId) REFERENCES Benzodiazepines(Id)
                );";

            using var command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Ajoute une nouvelle benzodiazépine à la base de données.
        /// </summary>
        /// <param name="benzo">L'objet benzodiazépine à ajouter.</param>
        public void AddBenzodiazepine(Benzodiazepine benzo)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string insertQuery = @"
                INSERT INTO Benzodiazepines (
                    OfficialName, MoleculeName, PharmacologicalProperties, HalfLife, OnsetTime,
                    Bioavailability, Metabolism, Elimination, ActionDurationHours, TherapeuticIndications,
                    Dosage, ImagePath)
                VALUES (
                    @OfficialName, @MoleculeName, @PharmacologicalProperties, @HalfLife, @OnsetTime,
                    @Bioavailability, @Metabolism, @Elimination, @ActionDurationHours, @TherapeuticIndications,
                    @Dosage, @ImagePath);";

            using var command = new SQLiteCommand(insertQuery, connection);
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
            command.Parameters.AddWithValue("@ImagePath", benzo.ImagePath);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupère toutes les benzodiazépines de la base de données.
        /// </summary>
        /// <returns>Liste des benzodiazépines.</returns>
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
        /// <param name="benzo">L'objet benzodiazépine à mettre à jour.</param>
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
            command.Parameters.AddWithValue("@ImagePath", benzo.ImagePath);
            command.Parameters.AddWithValue("@Id", benzo.Id);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Supprime une benzodiazépine de la base de données.
        /// </summary>
        /// <param name="id">Identifiant de la benzodiazépine à supprimer.</param>
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
        /// Désérialise une valeur depuis la base de données ou retourne une valeur par défaut.
        /// </summary>
        /// <typeparam name="T">Type de l'objet à désérialiser.</typeparam>
        /// <param name="data">Données à désérialiser.</param>
        /// <returns>Objet désérialisé ou valeur par défaut.</returns>
        private T DeserializeOrDefault<T>(object data)
        {
            if (data == null || data == DBNull.Value || string.IsNullOrWhiteSpace(data.ToString()))
            {
                return default(T);
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(data.ToString());
            }
            catch (Exception ex)
            {
                // Afficher le message d'erreur pour le débogage
                System.Diagnostics.Debug.WriteLine($"Erreur lors de la désérialisation de {typeof(T).Name}: {ex.Message}");
                
                // Vous pouvez également enregistrer l'erreur dans un fichier de log ou afficher un message à l'utilisateur
                // throw; // Vous pouvez lever l'exception si vous souhaitez arrêter le programme

                // Retourner une valeur par défaut appropriée
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
                    return default(T);
                }
            }
        }

        #region Gestion des Patients

        /// <summary>
        /// Ajoute un nouveau patient à la base de données.
        /// </summary>
        public void AddPatient(Patient patient)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string insertQuery = @"
                INSERT INTO Patients (Nom, Prenom, DateNaissance, NumeroSecuriteSociale, Adresse, CodePostal, Ville, Telephone)
                VALUES (@Nom, @Prenom, @DateNaissance, @NumeroSecuriteSociale, @Adresse, @CodePostal, @Ville, @Telephone);
                SELECT last_insert_rowid();";

            using var command = new SQLiteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Nom", patient.Nom);
            command.Parameters.AddWithValue("@Prenom", patient.Prenom);
            command.Parameters.AddWithValue("@DateNaissance", patient.DateNaissance.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@NumeroSecuriteSociale", patient.NumeroSecuriteSociale);
            command.Parameters.AddWithValue("@Adresse", patient.Adresse);
            command.Parameters.AddWithValue("@CodePostal", patient.CodePostal);
            command.Parameters.AddWithValue("@Ville", patient.Ville);
            command.Parameters.AddWithValue("@Telephone", patient.Telephone);

            patient.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        /// <summary>
        /// Récupère tous les patients de la base de données.
        /// </summary>
        public List<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string selectQuery = "SELECT * FROM Patients ORDER BY Nom, Prenom;";
            using var command = new SQLiteCommand(selectQuery, connection);
            using SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                patients.Add(new Patient
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nom = reader["Nom"].ToString(),
                    Prenom = reader["Prenom"].ToString(),
                    DateNaissance = DateTime.Parse(reader["DateNaissance"].ToString()),
                    NumeroSecuriteSociale = reader["NumeroSecuriteSociale"].ToString(),
                    Adresse = reader["Adresse"].ToString(),
                    CodePostal = reader["CodePostal"].ToString(),
                    Ville = reader["Ville"].ToString(),
                    Telephone = reader["Telephone"].ToString()
                });
            }

            return patients;
        }

        /// <summary>
        /// Met à jour un patient existant dans la base de données.
        /// </summary>
        public void UpdatePatient(Patient patient)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string updateQuery = @"
                UPDATE Patients SET
                    Nom = @Nom, Prenom = @Prenom, DateNaissance = @DateNaissance,
                    NumeroSecuriteSociale = @NumeroSecuriteSociale, Adresse = @Adresse,
                    CodePostal = @CodePostal, Ville = @Ville, Telephone = @Telephone
                WHERE Id = @Id;";

            using var command = new SQLiteCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@Nom", patient.Nom);
            command.Parameters.AddWithValue("@Prenom", patient.Prenom);
            command.Parameters.AddWithValue("@DateNaissance", patient.DateNaissance.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@NumeroSecuriteSociale", patient.NumeroSecuriteSociale);
            command.Parameters.AddWithValue("@Adresse", patient.Adresse);
            command.Parameters.AddWithValue("@CodePostal", patient.CodePostal);
            command.Parameters.AddWithValue("@Ville", patient.Ville);
            command.Parameters.AddWithValue("@Telephone", patient.Telephone);
            command.Parameters.AddWithValue("@Id", patient.Id);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Supprime un patient de la base de données.
        /// </summary>
        public void DeletePatient(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM Patients WHERE Id = @Id;";
            using var command = new SQLiteCommand(deleteQuery, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        #endregion

        #region Gestion des Médecins

        /// <summary>
        /// Ajoute un nouveau médecin à la base de données.
        /// </summary>
        public void AddDoctor(Doctor doctor)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string insertQuery = @"
                INSERT INTO Doctors (Nom, Prenom, NumeroRPPS, Specialite, Adresse, CodePostal, Ville, Telephone, Email)
                VALUES (@Nom, @Prenom, @NumeroRPPS, @Specialite, @Adresse, @CodePostal, @Ville, @Telephone, @Email);
                SELECT last_insert_rowid();";

            using var command = new SQLiteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Nom", doctor.Nom);
            command.Parameters.AddWithValue("@Prenom", doctor.Prenom);
            command.Parameters.AddWithValue("@NumeroRPPS", doctor.NumeroRPPS);
            command.Parameters.AddWithValue("@Specialite", doctor.Specialite);
            command.Parameters.AddWithValue("@Adresse", doctor.Adresse);
            command.Parameters.AddWithValue("@CodePostal", doctor.CodePostal);
            command.Parameters.AddWithValue("@Ville", doctor.Ville);
            command.Parameters.AddWithValue("@Telephone", doctor.Telephone);
            command.Parameters.AddWithValue("@Email", doctor.Email);

            doctor.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        /// <summary>
        /// Récupère tous les médecins de la base de données.
        /// </summary>
        public List<Doctor> GetAllDoctors()
        {
            var doctors = new List<Doctor>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string selectQuery = "SELECT * FROM Doctors ORDER BY Nom, Prenom;";
            using var command = new SQLiteCommand(selectQuery, connection);
            using SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                doctors.Add(new Doctor
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nom = reader["Nom"].ToString(),
                    Prenom = reader["Prenom"].ToString(),
                    NumeroRPPS = reader["NumeroRPPS"].ToString(),
                    Specialite = reader["Specialite"].ToString(),
                    Adresse = reader["Adresse"].ToString(),
                    CodePostal = reader["CodePostal"].ToString(),
                    Ville = reader["Ville"].ToString(),
                    Telephone = reader["Telephone"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }

            return doctors;
        }

        /// <summary>
        /// Met à jour un médecin existant dans la base de données.
        /// </summary>
        public void UpdateDoctor(Doctor doctor)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string updateQuery = @"
                UPDATE Doctors SET
                    Nom = @Nom, Prenom = @Prenom, NumeroRPPS = @NumeroRPPS, Specialite = @Specialite,
                    Adresse = @Adresse, CodePostal = @CodePostal, Ville = @Ville,
                    Telephone = @Telephone, Email = @Email
                WHERE Id = @Id;";

            using var command = new SQLiteCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@Nom", doctor.Nom);
            command.Parameters.AddWithValue("@Prenom", doctor.Prenom);
            command.Parameters.AddWithValue("@NumeroRPPS", doctor.NumeroRPPS);
            command.Parameters.AddWithValue("@Specialite", doctor.Specialite);
            command.Parameters.AddWithValue("@Adresse", doctor.Adresse);
            command.Parameters.AddWithValue("@CodePostal", doctor.CodePostal);
            command.Parameters.AddWithValue("@Ville", doctor.Ville);
            command.Parameters.AddWithValue("@Telephone", doctor.Telephone);
            command.Parameters.AddWithValue("@Email", doctor.Email);
            command.Parameters.AddWithValue("@Id", doctor.Id);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Supprime un médecin de la base de données.
        /// </summary>
        public void DeleteDoctor(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM Doctors WHERE Id = @Id;";
            using var command = new SQLiteCommand(deleteQuery, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        #endregion

        #region Gestion des Ordonnances

        /// <summary>
        /// Ajoute une nouvelle ordonnance à la base de données.
        /// </summary>
        public void AddPrescription(Prescription prescription)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                // Insérer l'ordonnance
                string insertPrescriptionQuery = @"
                    INSERT INTO Prescriptions (PatientId, DoctorId, DatePrescription, Observations, Renouvelable, NombreRenouvellements)
                    VALUES (@PatientId, @DoctorId, @DatePrescription, @Observations, @Renouvelable, @NombreRenouvellements);
                    SELECT last_insert_rowid();";

                using var command = new SQLiteCommand(insertPrescriptionQuery, connection, transaction);
                command.Parameters.AddWithValue("@PatientId", prescription.PatientId);
                command.Parameters.AddWithValue("@DoctorId", prescription.DoctorId);
                command.Parameters.AddWithValue("@DatePrescription", prescription.DatePrescription.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@Observations", prescription.Observations ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Renouvelable", prescription.Renouvelable ? 1 : 0);
                command.Parameters.AddWithValue("@NombreRenouvellements", prescription.NombreRenouvellements ?? (object)DBNull.Value);

                prescription.Id = Convert.ToInt32(command.ExecuteScalar());

                // Insérer les éléments de l'ordonnance
                foreach (var item in prescription.Items)
                {
                    AddPrescriptionItem(item, prescription.Id, connection, transaction);
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Ajoute un élément d'ordonnance (usage interne avec transaction).
        /// </summary>
        private void AddPrescriptionItem(PrescriptionItem item, int prescriptionId, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            string insertQuery = @"
                INSERT INTO PrescriptionItems (PrescriptionId, BenzodiazepineId, NomMedicament, Dosage, Posologie,
                    DureeTraitementJours, QuantitePrescrite, Instructions)
                VALUES (@PrescriptionId, @BenzodiazepineId, @NomMedicament, @Dosage, @Posologie,
                    @DureeTraitementJours, @QuantitePrescrite, @Instructions);
                SELECT last_insert_rowid();";

            using var command = new SQLiteCommand(insertQuery, connection, transaction);
            command.Parameters.AddWithValue("@PrescriptionId", prescriptionId);
            command.Parameters.AddWithValue("@BenzodiazepineId", item.BenzodiazepineId ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NomMedicament", item.NomMedicament);
            command.Parameters.AddWithValue("@Dosage", item.Dosage);
            command.Parameters.AddWithValue("@Posologie", item.Posologie);
            command.Parameters.AddWithValue("@DureeTraitementJours", item.DureeTraitementJours);
            command.Parameters.AddWithValue("@QuantitePrescrite", item.QuantitePrescrite);
            command.Parameters.AddWithValue("@Instructions", item.Instructions ?? (object)DBNull.Value);

            item.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        /// <summary>
        /// Récupère toutes les ordonnances de la base de données.
        /// </summary>
        public List<Prescription> GetAllPrescriptions()
        {
            var prescriptions = new List<Prescription>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string selectQuery = @"
                SELECT p.*,
                    pat.Nom as PatientNom, pat.Prenom as PatientPrenom, pat.DateNaissance as PatientDateNaissance,
                    pat.NumeroSecuriteSociale, pat.Adresse as PatientAdresse, pat.CodePostal as PatientCodePostal,
                    pat.Ville as PatientVille, pat.Telephone as PatientTelephone,
                    doc.Nom as DoctorNom, doc.Prenom as DoctorPrenom, doc.NumeroRPPS, doc.Specialite,
                    doc.Adresse as DoctorAdresse, doc.CodePostal as DoctorCodePostal, doc.Ville as DoctorVille,
                    doc.Telephone as DoctorTelephone, doc.Email as DoctorEmail
                FROM Prescriptions p
                INNER JOIN Patients pat ON p.PatientId = pat.Id
                INNER JOIN Doctors doc ON p.DoctorId = doc.Id
                ORDER BY p.DatePrescription DESC;";

            using var command = new SQLiteCommand(selectQuery, connection);
            using SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var prescription = new Prescription
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PatientId = Convert.ToInt32(reader["PatientId"]),
                    DoctorId = Convert.ToInt32(reader["DoctorId"]),
                    DatePrescription = DateTime.Parse(reader["DatePrescription"].ToString()),
                    Observations = reader["Observations"].ToString(),
                    Renouvelable = Convert.ToInt32(reader["Renouvelable"]) == 1,
                    NombreRenouvellements = reader["NombreRenouvellements"] == DBNull.Value ? null : Convert.ToInt32(reader["NombreRenouvellements"]),
                    Patient = new Patient
                    {
                        Id = Convert.ToInt32(reader["PatientId"]),
                        Nom = reader["PatientNom"].ToString(),
                        Prenom = reader["PatientPrenom"].ToString(),
                        DateNaissance = DateTime.Parse(reader["PatientDateNaissance"].ToString()),
                        NumeroSecuriteSociale = reader["NumeroSecuriteSociale"].ToString(),
                        Adresse = reader["PatientAdresse"].ToString(),
                        CodePostal = reader["PatientCodePostal"].ToString(),
                        Ville = reader["PatientVille"].ToString(),
                        Telephone = reader["PatientTelephone"].ToString()
                    },
                    Doctor = new Doctor
                    {
                        Id = Convert.ToInt32(reader["DoctorId"]),
                        Nom = reader["DoctorNom"].ToString(),
                        Prenom = reader["DoctorPrenom"].ToString(),
                        NumeroRPPS = reader["NumeroRPPS"].ToString(),
                        Specialite = reader["Specialite"].ToString(),
                        Adresse = reader["DoctorAdresse"].ToString(),
                        CodePostal = reader["DoctorCodePostal"].ToString(),
                        Ville = reader["DoctorVille"].ToString(),
                        Telephone = reader["DoctorTelephone"].ToString(),
                        Email = reader["DoctorEmail"].ToString()
                    }
                };

                // Charger les éléments de l'ordonnance
                prescription.Items = GetPrescriptionItems(prescription.Id);

                prescriptions.Add(prescription);
            }

            return prescriptions;
        }

        /// <summary>
        /// Récupère les éléments d'une ordonnance spécifique.
        /// </summary>
        private List<PrescriptionItem> GetPrescriptionItems(int prescriptionId)
        {
            var items = new List<PrescriptionItem>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string selectQuery = "SELECT * FROM PrescriptionItems WHERE PrescriptionId = @PrescriptionId;";
            using var command = new SQLiteCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@PrescriptionId", prescriptionId);
            using SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new PrescriptionItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PrescriptionId = Convert.ToInt32(reader["PrescriptionId"]),
                    BenzodiazepineId = reader["BenzodiazepineId"] == DBNull.Value ? null : Convert.ToInt32(reader["BenzodiazepineId"]),
                    NomMedicament = reader["NomMedicament"].ToString(),
                    Dosage = reader["Dosage"].ToString(),
                    Posologie = reader["Posologie"].ToString(),
                    DureeTraitementJours = Convert.ToInt32(reader["DureeTraitementJours"]),
                    QuantitePrescrite = Convert.ToInt32(reader["QuantitePrescrite"]),
                    Instructions = reader["Instructions"].ToString()
                });
            }

            return items;
        }

        /// <summary>
        /// Met à jour une ordonnance existante dans la base de données.
        /// </summary>
        public void UpdatePrescription(Prescription prescription)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                // Mettre à jour l'ordonnance
                string updateQuery = @"
                    UPDATE Prescriptions SET
                        PatientId = @PatientId, DoctorId = @DoctorId, DatePrescription = @DatePrescription,
                        Observations = @Observations, Renouvelable = @Renouvelable, NombreRenouvellements = @NombreRenouvellements
                    WHERE Id = @Id;";

                using var command = new SQLiteCommand(updateQuery, connection, transaction);
                command.Parameters.AddWithValue("@PatientId", prescription.PatientId);
                command.Parameters.AddWithValue("@DoctorId", prescription.DoctorId);
                command.Parameters.AddWithValue("@DatePrescription", prescription.DatePrescription.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@Observations", prescription.Observations ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Renouvelable", prescription.Renouvelable ? 1 : 0);
                command.Parameters.AddWithValue("@NombreRenouvellements", prescription.NombreRenouvellements ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Id", prescription.Id);
                command.ExecuteNonQuery();

                // Supprimer les anciens éléments
                string deleteItemsQuery = "DELETE FROM PrescriptionItems WHERE PrescriptionId = @PrescriptionId;";
                using var deleteCommand = new SQLiteCommand(deleteItemsQuery, connection, transaction);
                deleteCommand.Parameters.AddWithValue("@PrescriptionId", prescription.Id);
                deleteCommand.ExecuteNonQuery();

                // Insérer les nouveaux éléments
                foreach (var item in prescription.Items)
                {
                    AddPrescriptionItem(item, prescription.Id, connection, transaction);
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Supprime une ordonnance de la base de données.
        /// </summary>
        public void DeletePrescription(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                // Supprimer les éléments de l'ordonnance
                string deleteItemsQuery = "DELETE FROM PrescriptionItems WHERE PrescriptionId = @PrescriptionId;";
                using var deleteItemsCommand = new SQLiteCommand(deleteItemsQuery, connection, transaction);
                deleteItemsCommand.Parameters.AddWithValue("@PrescriptionId", id);
                deleteItemsCommand.ExecuteNonQuery();

                // Supprimer l'ordonnance
                string deleteQuery = "DELETE FROM Prescriptions WHERE Id = @Id;";
                using var command = new SQLiteCommand(deleteQuery, connection, transaction);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        #endregion
    }
}
