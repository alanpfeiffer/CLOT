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
    /// Interaction logic for BasicsPage.xaml
    /// </summary>
    public partial class BasicsPage : UserControl
    {
        public BasicsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseParser dp = new DatabaseParser();
            string fileDir = dp.GetFileLocation();
            conlangsListBox.Items.Clear();

            foreach (string file in Directory.EnumerateFiles(fileDir, "*.db"))
            {
                string filedb = file.Replace(fileDir, "");
                filedb = filedb.Replace(".db", "");
                conlangsListBox.Items.Add(filedb);
            }


        }

        private void IPAValues_TextChanged(object sender, TextChangedEventArgs e)
        {



            if (IPAValues.Text == "")
            {
                conlangLettersValue.Visibility = Visibility.Hidden;
                conlangLetters.Visibility = Visibility.Hidden;

                basicWordForm.SetValue(Grid.RowProperty, 2);
                basicWordFormValue.SetValue(Grid.RowProperty, 2);
            }
            else if (IPAValues.Text != "")
            {
                conlangLettersValue.Visibility = Visibility.Visible;
                conlangLetters.Visibility = Visibility.Visible;

                basicWordForm.SetValue(Grid.RowProperty, 3);
                basicWordFormValue.SetValue(Grid.RowProperty, 3);

            }



        }
   

        private void conlangAddButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            dbp.CreateDB(conlangNameValue.Text); //Create, if doesn't exist, and Open db.
            int val;
            if (int.TryParse(gendersValue.Text, out val))
                dbp.AddOrUpdateDB(conlangNameValue.Text, IPAValues.Text, conlangLettersValue.Text, basicWordFormValue.Text, gendersValue.Text);
            else
                MessageBox.Show("Error: Number of genders needs to be a number!");

        }

        private void conlangsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (conlangsListBox.SelectedItem != null)
            {
                DatabaseParser dbp = new DatabaseParser();
                string[] dbEntry = dbp.ReadDB("Basics", conlangsListBox.SelectedItem.ToString());

                conlangNameValue.Text = dbEntry[0];
                IPAValues.Text = dbEntry[1];
                conlangLettersValue.Text = dbEntry[2];
                basicWordFormValue.Text = dbEntry[3];
                gendersValue.Text = dbEntry[4];
            }



        }
    }
}
