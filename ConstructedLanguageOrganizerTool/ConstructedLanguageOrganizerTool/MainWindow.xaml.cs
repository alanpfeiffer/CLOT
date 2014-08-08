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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void grammerPageButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Source = new Uri("GrammarPage.xaml", UriKind.Relative);
        }

        private void wordsPageButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Source = new Uri("WordsPage.xaml", UriKind.Relative);
        }

        private void basicsPageButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Source = new Uri("BasicsPage.xaml", UriKind.Relative);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            WordsPage wp = new WordsPage();
            //string wpl = 
            

            //MessageBox.Show("You have saved to " + wpl);
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have loaded " + fileBox.Text + ".txt");
            BasicsPage bp = new BasicsPage();
            
        }


    }
}
