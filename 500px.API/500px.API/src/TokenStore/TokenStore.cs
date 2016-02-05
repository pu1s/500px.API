﻿using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using OAuth;

namespace ags.Tokens
{
    public static class TokenStore
    {
        private const string DataSource = "DataSource = ";
        private const string DB = "store.db";
        private const string Version = "Version = 3;";
        private const string ConnectionString = DataSource + DB + ";" + Version;

        public static void CreateDB(string DB)
        {
            if (File.Exists(DB)) return;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                const string qweryString = "CREATE TABLE token ("
                                           + "ID INTEGER PRYMARY KEY,"
                                           + "Token TEXT, "
                                           + "Secret TEXT, "
                                           + "DateCreated TEXT, "
                                           + "BestBefore TEXT, );";
                cmd.CommandText = qweryString;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static OAuthBroker.OAuthToken GetToken()
        {
            var token = new OAuthBroker.OAuthToken();
            if (!File.Exists(DB)) return token;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd = new SQLiteCommand("SELECT * FROM token;", connection);
                var reader = cmd.ExecuteReader();
                token.Token = reader["Token"].ToString();
                token.Secret = reader["Secret"].ToString();
                connection.Close();
            }
            return token;
        }

        public static void SaveToken(OAuthBroker.OAuthToken token)
        {
            if (File.Exists(DB))
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    var id = new Random().Next();
                    var dateCreated = DateTime.UtcNow.ToString();
                    var bestBefore = DateTime.UtcNow.AddMonths(1).ToString();
                    cmd.Parameters.Add("ID", DbType.Int32, new Random().Next(100));
                    cmd.Parameters.Add("Token", DbType.String, 64, token.Token);
                    cmd.
                    var qweryString =
                        string.Format(
                            "INSERT INTO 'token' ( 'ID', 'Token', 'Secret', 'DateCreated', 'BestBefore') VALUES ({0}, {1}, {2}, {3}, {4});",
                            id, token.Token, token.Secret, dateCreated, bestBefore);
                    cmd.CommandText = qweryString;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}