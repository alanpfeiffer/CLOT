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


        public string GetFileLocation()
        {
            string fullpath = System.IO.Directory.GetCurrentDirectory();
            fullpath = fullpath.Replace(@"ConstructedLanguageOrganizerTool\bin\Debug", "");

            return fullpath;
        }


        public bool CreateDB(string conlangName)
        {
            var dbFile = GetFileLocation();
            dbFile = dbFile + conlangName + ".db";

            var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbFile);
            SQLiteConnection dbConn = new SQLiteConnection(connString);

            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();


            if (File.Exists(dbFile))
            {
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Basics (conlang string primary key, ipa string, letters string, basicForm string);";
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                
                return false;
            }


        }

        // Basics DB Add
        public void AddOrUpdateDB(string conlangName, string ipaValue, string conletters, string basicWordForm, int genders)
        {
            
        }

        // Word DB Add
        public void AddOrUpdateDB(string conWord, string localWord, string pronunciation, string pos, int gender, string declension)
        {

        }

        // Grammar DB Add
        public void AddOrUpdateDB(string grammarName, string grammarType, string grammarPoint)
        {

        }



        public static void Test2(string connString)
        {

            

            using (var dbConn = new System.Data.SQLite.SQLiteConnection(connString))
            {
                dbConn.Open();
                using (System.Data.SQLite.SQLiteCommand cmd = dbConn.CreateCommand())
                {
                    //create table
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS T1 (ID integer primary key, T text);";
                    cmd.ExecuteNonQuery();

                    //parameterized insert - more flexibility on parameter creation
                    cmd.CommandText = @"INSERT INTO T1 (ID,T) VALUES(@id,@t)";

                    cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
                    {
                        ParameterName = "@id",
                        Value = 1
                    });

                    cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
                    {
                        ParameterName = "@t",
                        Value = "test2"
                    });

                    cmd.ExecuteNonQuery();

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
