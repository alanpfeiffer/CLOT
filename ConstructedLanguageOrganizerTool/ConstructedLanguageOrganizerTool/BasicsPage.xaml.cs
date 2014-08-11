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
        string conlange;
        string IPASounds;
        string conletters;
        string basicwordform;

        public BasicsPage()
        {
            conlange = "";
            IPASounds = "";
            conletters = "";
            basicwordform = "";
        }

        private void conlangAddButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseParser dbp = new DatabaseParser();

            
            if (dbp.CreateDB(conlangNameValue.Text) == true)
                MessageBox.Show("db already exists");
            else
                MessageBox.Show("Db doesn't exist. Created " + conlangNameValue.Text);


        }
    }
}
