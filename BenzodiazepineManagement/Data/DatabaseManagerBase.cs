using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Data
{
    // Classe abstraite servant de base pour la gestion de la base de données
    public abstract class DatabaseManagerBase
    {
        // Chaîne de connexion à la base de données SQLite
        private readonly string _connectionString;

        // Constructeur pour initialiser la chaîne de connexion
        public DatabaseManagerBase(string connectionString) => _connectionString = connectionString;

        // Méthode pour insérer des données avec des paramètres dans la base de données
        public async Task<int> InsertAsync(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Ajout des paramètres à la commande SQL
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        // Exécution de la commande et retour du nombre de lignes affectées
                        return await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                // Gestion des erreurs SQLite
                Console.Error.WriteLine($"SQLite error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Gestion des autres erreurs
                Console.Error.WriteLine($"General error: {ex.Message}");
                throw;
            }
        }

        // Méthode pour exécuter une requête et retourner les résultats sous forme de liste d'objets
        public async Task<List<T>> QueryAsync<T>(string query, Func<SQLiteDataReader, T> mapFunction)
        {
            var results = new List<T>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Parcours des résultats et application de la fonction de mapping
                        while (await reader.ReadAsync())
                        {
                            results.Add(mapFunction(reader));
                        }
                    }
                }
            }

            return results;
        }

        // Exécute une commande SQL sans retourner de résultat
        public async Task<int> ExecuteNonQueryAsync(string query)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(query, connection))
                {
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Exécute une commande SQL et retourne une valeur scalaire
        public async Task<T> ExecuteScalarAsync<T>(string query)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(query, connection))
                {
                    return (T)await command.ExecuteScalarAsync();
                }
            }
        }

        // Méthodes abstraites pour les opérations spécifiques sur les benzodiazépines
        internal abstract Task<object> AddBenzodiazepineAsync(Benzodiazepine benzodiazepine);
        internal abstract Task DeleteBenzodiazepineAsync(int id);
        internal abstract Task<List<Benzodiazepine>> GetAllBenzodiazepinesAsync();
        internal abstract Task UpdateBenzodiazepineAsync(Benzodiazepine benzodiazepine);

        // Vérifie si une table existe dans la base de données
        public async Task<bool> TableExistsAsync(string tableName)
        {
            var query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(query, connection))
                {
                    var result = await command.ExecuteScalarAsync();
                    return result != null;
                }
            }
        }

        // Crée une nouvelle table dans la base de données
        public async Task CreateTableAsync(string createTableQuery)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Supprime une table si elle existe
        public async Task DropTableAsync(string tableName)
        {
            var query = $"DROP TABLE IF EXISTS {tableName};";
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SQLiteCommand(query, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
