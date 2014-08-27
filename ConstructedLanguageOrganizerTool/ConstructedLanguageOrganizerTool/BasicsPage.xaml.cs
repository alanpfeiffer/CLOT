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
            DatabaseParser dbp = new DatabaseParser();
            string fileDir = dbp.GetFileLocation();
            conlangsListBox.Items.Clear();

            foreach (string file in Directory.EnumerateFiles(fileDir, "*.db"))
            {
                string filedb = file.Replace(fileDir, "");
                filedb = filedb.Replace(".db", "");
                conlangsListBox.Items.Add(filedb);
            }
            conlangsListBox.SelectedItem = "Example";

        }

        private void conlangAddButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            dbp.SetConlang(conlangNameValue.Text);
            dbp.CreateDB(conlangNameValue.Text); //Create, if doesn't exist, and Open db.

            int i = 0;
            string[] pageInfo = new string [(conlangBasicsGrid.Children.Count-2)];
            if (i < conlangBasicsGrid.Children.Count)
            {
                foreach (object child in conlangBasicsGrid.Children)
                {
                    if (child is Label)
                        pageInfo[i] = (child as Label).Name;
                    
                    if (child is TextBox)
                        pageInfo[i] = (child as TextBox).Text;
                    
                    i++;

                }
            }


            dbp.AddOrUpdateDB(pageInfo, "Basics");
          

        }

        private void conlangsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (conlangsListBox.SelectedItem != null)
            {
                DatabaseParser dbp = new DatabaseParser();
                dbp.SetConlang(conlangsListBox.SelectedItem.ToString());
                string[] dbEntry = dbp.ReadDB("Basics", "*", "", "");

                int i = 0;
                if (i <= conlangBasicsGrid.Children.Count)
                {
                    foreach (object child in conlangBasicsGrid.Children)
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

        private void conlangDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            dbp.DeleteDB(conlangNameValue.Text);
            MessageBox.Show("Deleted: " + conlangNameValue.Text);

        }
    }
}
