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
             string fullpath = System.IO.Directory.GetCurrentDirectory();
        fullpath = fullpath.Replace(@"\ConstructedLanguageOrganizerTool\bin\Debug", "");
       // var dbFile = fullpath + fileBox.Text + ".db";
            //var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbFile);
        }






        //private void saveButton_Click(object sender, RoutedEventArgs e)
        //{
            
        //    if (contentFrame.Content.GetType() == typeof(BasicsPage))
        //    {
        //        var basicsPage = contentFrame.Content as BasicsPage;
        //        var bpl = basicsPage.conlangLettersValue.Text;
        //        MessageBox.Show("You have saved to " + bpl);
        //    }
        //}

        //private void loadButton_Click(object sender, RoutedEventArgs e)
        //{
        //   // MessageBox.Show("You have loaded " + fileBox.Text + ".db");
        //}

   


    }
}
