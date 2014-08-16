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
        static string conlanguageName;

        public void SetConlang(string conlang)
        {
            conlanguageName = conlang;
        }

        public string GetFileLocation()
        {
            string fullpath = System.IO.Directory.GetCurrentDirectory();
            fullpath = fullpath.Replace(@"ConstructedLanguageOrganizerTool\bin\Debug", "");

            return fullpath;
        }

        public string DBstring()
        {
            var dbFile = GetFileLocation();
            dbFile = dbFile + conlanguageName + ".db";

            var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbFile);

            return connString;
        }

        public void CreateDB(string conlangName)
        {
            var connString = DBstring();

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

        public void DeleteDB(string database)
        {
            string dbToDelete = GetFileLocation();
            dbToDelete += conlanguageName + ".db";
            SQLiteConnection.ClearAllPools();
            GC.Collect();
            File.Delete(dbToDelete);
        }


        // Basics DB Add
        public void AddOrUpdateDB(string conlangName, string ipaValue, string conletters, string basicWordForm, string genders)
        {
            var connString = DBstring();

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
        public void AddOrUpdateDB(string conWord, string localWord, string pronunciation, string pos, string gender, string declension)
        {
            var connString = DBstring();

            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();


            cmd.CommandText = @"INSERT INTO Lexicon (conword, localWord, pronunciation, pos, gender,declension) VALUES(@conword, @localWord, @pronunciation, @pos, @gender, @declension)";

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
            var connString = DBstring();

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

        // Remove an DB entry
        public void DeleteRow(string page, string colName, string entryToDelete)
        {
            var connString = DBstring();

            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();


            cmd.CommandText = @"delete from " + page + " where " + colName + " = \"" + entryToDelete + "\"";
            cmd.ExecuteNonQuery();

        }


        public string[] ReadDB(string page, string columnToRead, string opColumnForRow, string rowToRead)
        {
            var connString = DBstring();
            int rowCount = 0;

            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();

            if (opColumnForRow == "")
            {
                cmd.CommandText = @"select count(*) from " + page;
                rowCount = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = @"select " + columnToRead + " from " + page; //Read for Basics or other pages listboxes. columnToRead value is either '*' or Col name.
            }
            else
                cmd.CommandText = @"select " + columnToRead + " from " + page + "where" + opColumnForRow + " = \"" + rowToRead + "\"";  //Read for Lexicon


            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();

            string[] dbValues;
            int test;

            if (columnToRead == "*")
                dbValues = new string[reader.FieldCount];
            else
                dbValues = new string[rowCount];

            while (reader.Read())
                test = reader.GetValues(dbValues);


            dbConn.Close();

            return dbValues;

        }
    }
}
