using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteamMarketWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logik logik = new Logik();
        Item windowItem = new Item();
        public MainWindow()
        {
            InitializeComponent();
            Test();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            windowItem = logik.GetItem(comboBox.SelectedValue.ToString());
            skinImage.Source = logik.ConvertByteArrayToBitmap(windowItem.Img);
            skinName.Content = windowItem.ItemName;
            skinWear.Content = "Wear: " + windowItem.Wear;
            skinMinPrice.Content = "Lowest price: " + windowItem.LowestPrice;
            skinMedianPrice.Content = "Median price: " + windowItem.MedianPrice;
            skinAmountLeft.Content = "Amount left: " + windowItem.AmountLeft;

        }
        private void Test()
        {
            foreach (Item item in logik.Items)
            {
                comboBox.Items.Add(item.ItemName);
            }
            //skinImage.Source = logik.ConvertByteArrayToBitmap(item.Img);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logik.GetAPI();
            //AddItemPage a = new AddItemPage();
            //a.Show();
        }
    }
}
