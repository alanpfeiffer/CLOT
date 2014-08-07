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
    public partial class BasicsPage : Page
    {
        public BasicsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            conlangNameValue.Text = "blah";
        }
    }
}
