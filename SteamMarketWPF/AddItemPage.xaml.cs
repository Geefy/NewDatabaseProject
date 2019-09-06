using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace SteamMarketWPF
{
    /// <summary>
    /// Interaction logic for AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Window
    {
        Logik logik = new Logik();
        string imgPath;
        public AddItemPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logik.InsertItem("'" +itemName.Text+ "'", imgPath);

            }
            catch (Exception s)
            {

                throw s;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                imgPath = logik.ChooseFile();
            }
            catch (Exception s)
            {

                throw s;
            }
        }
    }
}
