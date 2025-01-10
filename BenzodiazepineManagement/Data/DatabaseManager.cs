using System.Data.SQLite;

namespace BenzodiazepineManagement.Data
{
    public class DatabaseManager : DatabaseManagerBase
    {
        public DatabaseManager(string databasePath) : base($"Data Source={databasePath};Version=3;")
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
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
                        );";

                using var command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                System.Diagnostics.Debug.WriteLine($"Erreur lors de l'initialisation de la base de données: {ex.Message}");
            }
        }
    }
}
