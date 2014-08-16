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

            string[] dbEntry = dbp.ReadDB("Lexicon", "conword", "", "");

            for (int i = 0; i<dbEntry.Length; i++)
                wordListBox.Items.Add(dbEntry[i]);


        }

        private void conwordAddButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            dbp.AddOrUpdateDB(conlangWordBox.Text,localWordBox.Text,pronunciationBox.Text,partOfSpeechBox.Text,genderBox.Text,declensionBox.Text);
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
                string[] dbEntry = dbp.ReadDB("Lexicon", "*", "", "");

                conlangWordBox.Text = dbEntry[0];
                localWordBox.Text = dbEntry[1];
                pronunciationBox.Text = dbEntry[2];
                partOfSpeechBox.Text = dbEntry[3];
                genderBox.Text = dbEntry[4];
                declensionBox.Text = dbEntry[5];


            }
        }
    }
}
