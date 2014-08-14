using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace ConstructedLanguageOrganizerTool
{
    class DatabaseParser
    {
        string conlanguageName;

        public string GetFileLocation()
        {
            string fullpath = System.IO.Directory.GetCurrentDirectory();
            fullpath = fullpath.Replace(@"ConstructedLanguageOrganizerTool\bin\Debug", "");

            return fullpath;
        }

        public string DBstring(string conlangName)
        {
            var dbFile = GetFileLocation();
            conlanguageName = conlangName;
            dbFile = dbFile + conlanguageName + ".db";

            var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbFile);

            return connString;
        }


        public void CreateDB(string conlangName)
        {
            var connString = DBstring(conlangName);
            
            SQLiteConnection dbConn = new SQLiteConnection(connString);

            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Basics (conlang string primary key, ipa string, letters string, basicForm string, genders string);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Lexicon (conword string primary key, localWord string, pronunciation string, pos string, gender string, declension string);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Grammar (grammarName string primary key, grammarType string, gramarPoint string);";
            cmd.ExecuteNonQuery();


            dbConn.Close();


        }

        // Basics DB Add
        public void AddOrUpdateDB(string conlangName, string ipaValue, string conletters, string basicWordForm, string genders)
        {
            var connString = DBstring(conlangName);

            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();


            cmd.CommandText = @"INSERT INTO Basics (conlang, ipa, letters, basicForm, genders) VALUES(@conlang, @ipa, @letters, @basicForm, @genders)";

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@conlang",
                Value = conlangName
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@ipa",
                Value = ipaValue
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@letters",
                Value = conletters
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@basicForm",
                Value = basicWordForm
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@genders",
                Value = genders
            });
            cmd.ExecuteNonQuery();

            dbConn.Close();

        }

        // Word DB Add
        public void AddOrUpdateDB(string conWord, string localWord, string pronunciation, string pos, int gender, string declension)
        {
            var connString = DBstring(conlanguageName);
            
            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();


            cmd.CommandText = @"INSERT INTO Lexicon (conlang, ipa, letters, basicForm, genders) VALUES(@conword, @localWord, @pronunciation, @pos, @gender, @declension)";

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@conword",
                Value = conWord
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@localWord",
                Value = localWord
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@pronunciation",
                Value = pronunciation
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@pos",
                Value = pos
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@gender",
                Value = gender
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@declension",
                Value = declension
            });
            cmd.ExecuteNonQuery();

            dbConn.Close();
        }

        // Grammar DB Add
        public void AddOrUpdateDB(string grammarName, string grammarType, string grammarPoint)
        {
            var connString = DBstring(conlanguageName);

            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();


            cmd.CommandText = @"INSERT INTO Grammar (grammarName, grammarType, grammarPoint) VALUES(@grammarName, @grammarType, @grammarPoint)";

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@grammarName",
                Value = grammarName
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@grammarType",
                Value = grammarType
            });

            cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
            {
                ParameterName = "@grammarPoint",
                Value = grammarPoint
            });

            cmd.ExecuteNonQuery();

            dbConn.Close();

        }

        public string[] ReadDB(string page, string conlanguageName)
        {
            var connString = DBstring(conlanguageName);

            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();

            cmd.CommandText = @"select * from Basics";

            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();

            string[] dbValues = new string[reader.FieldCount];
            while (reader.Read())
                reader.GetValues(dbValues);

            dbConn.Close();

            return dbValues;

        }


        public static void Test2(string connString)
        {

            

            using (var dbConn = new System.Data.SQLite.SQLiteConnection(connString))
            {
                dbConn.Open();
                using (System.Data.SQLite.SQLiteCommand cmd = dbConn.CreateCommand())
                {
                   
                    //read from the table
                    cmd.CommandText = @"SELECT ID, T FROM T1";
                    using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            string t = reader.GetString(1);
                        }
                    }
                }
                if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
            }
        }

    }
}
