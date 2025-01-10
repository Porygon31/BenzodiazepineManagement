using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Data
{
    // Classe abstraite servant de base pour la gestion de la base de donn�es
    public abstract class DatabaseManagerBase
    {
        // Cha�ne de connexion � la base de donn�es SQLite
        private readonly string _connectionString;

        // Constructeur pour initialiser la cha�ne de connexion
        public DatabaseManagerBase(string connectionString) => _connectionString = connectionString;

        // M�thode pour ins�rer des donn�es avec des param�tres dans la base de donn�es
        public async Task<int> InsertAsync(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Ajout des param�tres � la commande SQL
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        // Ex�cution de la commande et retour du nombre de lignes affect�es
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

        // M�thode pour ex�cuter une requ�te et retourner les r�sultats sous forme de liste d'objets
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
                        // Parcours des r�sultats et application de la fonction de mapping
                        while (await reader.ReadAsync())
                        {
                            results.Add(mapFunction(reader));
                        }
                    }
                }
            }

            return results;
        }

        // Ex�cute une commande SQL sans retourner de r�sultat
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

        // Ex�cute une commande SQL et retourne une valeur scalaire
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

        // M�thodes abstraites pour les op�rations sp�cifiques sur les benzodiaz�pines
        internal abstract Task<object> AddBenzodiazepineAsync(Benzodiazepine benzodiazepine);
        internal abstract Task DeleteBenzodiazepineAsync(int id);
        internal abstract Task<List<Benzodiazepine>> GetAllBenzodiazepinesAsync();
        internal abstract Task UpdateBenzodiazepineAsync(Benzodiazepine benzodiazepine);

        // V�rifie si une table existe dans la base de donn�es
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

        // Cr�e une nouvelle table dans la base de donn�es
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
