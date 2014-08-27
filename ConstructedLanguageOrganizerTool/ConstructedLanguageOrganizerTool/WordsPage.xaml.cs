using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data.SQLite;

namespace ConstructedLanguageOrganizerTool
{
    /// <summary>
    /// Interaction logic for WordsPage.xaml
    /// </summary>
    public partial class WordsPage : UserControl
    {
        public WordsPage()
        {
            InitializeComponent();
        }

        private void wordsPage_Loaded(object sender, RoutedEventArgs e)
        {

            DatabaseParser dbp = new DatabaseParser();
            wordListBox.Items.Clear();

            string[] dbEntry = dbp.ReadDB("Lexicon", "conlangWord", "", "");

            for (int i = 0; i < dbEntry.Length; i++)
                wordListBox.Items.Add(dbEntry[i]);
        }

        private void conwordAddButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            int i = 0;
            string[] pageInfo = new string[(wordDetailsGrid.Children.Count - 2)];
            if (i < wordDetailsGrid.Children.Count)
            {
                foreach (object child in wordDetailsGrid.Children)
                {
                    if (child is Label)
                        pageInfo[i] = (child as Label).Name;

                    if (child is TextBox)
                        pageInfo[i] = (child as TextBox).Text;

                    i++;

                }
            }


            dbp.AddOrUpdateDB(pageInfo, "Lexicon");
        }

        private void conwordDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            dbp.DeleteRow("Lexicon", "conword", conlangWordBox.Text);
        }

        private void wordListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (wordListBox.SelectedItem != null)
            {
                DatabaseParser dbp = new DatabaseParser();
                string[] dbEntry = dbp.ReadDB("Lexicon", "*", "conlangWord", wordListBox.SelectedItem.ToString());

                int i = 0;
                if (i <= wordDetailsGrid.Children.Count)
                {
                    foreach (object child in wordDetailsGrid.Children)
                    {

                        if (child is TextBox)
                        {
                            (child as TextBox).Text = dbEntry[i];
                            i++;
                        }
                    }
                }
            }
        }
    }
}
