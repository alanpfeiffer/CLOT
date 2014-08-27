using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;


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
            
            BasicsPage bp = new BasicsPage();
            WordsPage wp = new WordsPage();
            GrammarPage gp = new GrammarPage();
            

            string commandString = @"CREATE TABLE IF NOT EXISTS Basics(" ;
            int i = 0;
            string temp;

            foreach (object child in bp.conlangBasicsGrid.Children)
            {
                if (child is Label)
                {
                    temp = (child as Label).Name;
                    temp = temp.Replace("Label", "");

                    commandString += temp;
                    commandString += " string";

                    if (i == 0)
                        commandString += " primary key, ";
                    else if (i != ((bp.conlangBasicsGrid.Children.Count - 2) / 2) - 1)
                        commandString += ", ";
                    else
                        commandString += ");";

                    i++;
                }

            }

            cmd.CommandText = commandString;
            cmd.ExecuteNonQuery();

             commandString = @"CREATE TABLE IF NOT EXISTS Lexicon(";
             i = 0;

             foreach (object child in wp.wordDetailsGrid.Children)
            {
                if (child is Label)
                {
                    temp = (child as Label).Name;
                    temp = temp.Replace("Label", "");

                    commandString += temp;
                    commandString += " string";

                    if (i == 0)
                        commandString += " primary key, ";
                    else if (i != ((wp.wordDetailsGrid.Children.Count - 2) / 2) - 1)
                        commandString += ", ";
                    else
                        commandString += ");";

                    i++;
                }

            }
            cmd.CommandText = commandString;
            cmd.ExecuteNonQuery();

             commandString = @"CREATE TABLE IF NOT EXISTS Grammar(";
             i = 0;

            foreach (object child in gp.grammarDetailsGrid.Children)
            {
                if (child is Label)
                {
                    temp = (child as Label).Name;
                    temp = temp.Replace("Label", "");

                    commandString += temp;
                    commandString += " string";

                    if (i == 0)
                        commandString += " primary key, ";
                    else if (i != ((gp.grammarDetailsGrid.Children.Count - 2) / 2) - 1)
                        commandString += ", ";
                    else
                        commandString += ");";

                    i++;
                }

            }
            cmd.CommandText = commandString;
            cmd.ExecuteNonQuery();


            //cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Basics (conlang string primary key, ipa string, letters string, basicForm string, genders string, basicSen string, declensions string);";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Lexicon (conword string primary key, localWord string, pronunciation string, pos string, gender string, declension string);";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Grammar (grammarPoint string primary key, grammarType string, grammarDesc string);";
            //cmd.ExecuteNonQuery();


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


        // DB Add.
        public void AddOrUpdateDB(string[] pageContents, string page)
        {
            var connString = DBstring();

            SQLiteConnection dbConn = new SQLiteConnection(connString);
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();


            string commandString = @"INSERT INTO " + page + " (";
            string temp;
            string secondHalf = ") VALUES(";
            for (int i = 0; i < pageContents.Length; i += 2)
            {
                temp = pageContents[i];
                temp = temp.Replace("Label", "");
                //temp = temp.ToLower();
                commandString += temp;

                secondHalf += "@" +temp;

                if (i != pageContents.Length - 2)
                {
                    commandString += ", ";
                    secondHalf += ", ";
                }
                else
                {
                    secondHalf += ")";
                    commandString += secondHalf;
                }
            }

            cmd.CommandText = commandString;

            for (int i = 0; i < pageContents.Length; i += 2)
            {
                temp = pageContents[i];
                temp = temp.Replace("Label", "");
                temp = temp.ToLower();
                temp = "@" + temp;

                cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
                {
                    ParameterName = temp,
                    Value = pageContents[i + 1]
                });
            }
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

            dbConn.Close();


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
                cmd.CommandText = @"select " + columnToRead + " from " + page + " where " + opColumnForRow + " = \"" + rowToRead + "\"";  //Read for Lexicon


            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();

            string[] dbValues = new string[reader.FieldCount];

            if (columnToRead == "*")
            {
                //dbValues = new string[reader.FieldCount];
                while (reader.Read())
                    reader.GetValues(dbValues);
            }
            else
            {
                dbValues = new string[rowCount];
                int i = 0;
                while (reader.Read())
                {
                    dbValues[i] = reader.GetString(0);
                    i++;
                }

            }

            dbConn.Close();

            return dbValues;

        }
    }
}
