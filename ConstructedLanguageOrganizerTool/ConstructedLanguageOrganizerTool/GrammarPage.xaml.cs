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

namespace ConstructedLanguageOrganizerTool
{
    /// <summary>
    /// Interaction logic for GrammarPage.xaml
    /// </summary>
    public partial class GrammarPage : UserControl
    {
        public GrammarPage()
        {
            InitializeComponent();
        }

        private void grammarPage_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            grammarListBox.Items.Clear();

            string[] dbEntry = dbp.ReadDB("Grammar", "grammarPoint", "", "");

            for (int i = 0; i < dbEntry.Length; i++)
                grammarListBox.Items.Add(dbEntry[i]);

        }

        private void grammarAddButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            int i = 0;
            string[] pageInfo = new string[(grammarDetailsGrid.Children.Count - 2)];
            if (i < grammarDetailsGrid.Children.Count)
            {
                foreach (object child in grammarDetailsGrid.Children)
                {
                    if (child is Label)
                        pageInfo[i] = (child as Label).Name;

                    if (child is TextBox)
                        pageInfo[i] = (child as TextBox).Text;

                    i++;

                }
            }
            dbp.AddOrUpdateDB(pageInfo, "Grammar");
        }


        private void grammarDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();
            dbp.DeleteRow("Grammar", "grammarPoint", grammarPointBox.Text);
        }

        private void grammarListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grammarListBox.SelectedItem != null)
            {
                DatabaseParser dbp = new DatabaseParser();
                string[] dbEntry = dbp.ReadDB("Grammar", "*", "", "");

                int i = 0;
                if (i <= grammarDetailsGrid.Children.Count)
                {
                    foreach (object child in grammarDetailsGrid.Children)
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