using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Win32;
using System.Net;

namespace SteamMarketWPF
{
    class Logik
    {

        Database db = new Database();
        private List<Item> items;

        internal List<Item> Items { get => items; set => items = value; }

        public Logik()
        {
            Items = db.GetFromDatabase();
        }
        public void InsertItem(string itemName, string imageLocation)
        {
            string query = "INSERT INTO GoSkins(SkinName, Img) SELECT " + itemName + ", BulkColumn FROM OPENROWSET(Bulk'" + imageLocation + "', SINGLE_BLOB) AS BLOB;";
            if (itemName.Contains(";"))
            {
                return;
            }
            else
            {
                db.InsertIntoDatabase(query);
            }
        }

        public Item GetItem(string itemName)
        {

            Item temp = new Item();
            foreach (Item item in Items)
            {
                if (itemName == item.ItemName)
                {
                    temp = item;
                }
            }
            return temp;
        }
        
        public BitmapImage ConvertByteArrayToBitmap(byte[] byteArray)
        {
            BitmapImage bitmap = new BitmapImage();
            try
            {
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(byteArray);
                bitmap.EndInit();
            }
            catch (Exception s)
            {

                throw s;
            }

            return bitmap;
        }

        public string ChooseFile()
        {
            string imgPath = "";
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = @"C:\Users\rene2756\Desktop\GoImgs";
            if (op.ShowDialog() == true)
            {
                imgPath = op.FileName;
            }
            return imgPath;
        }

        public void GetAPI()
        {
        string yeet = new WebClient().DownloadString("https://steamcommunity.com/market/priceoverview/?currency=3&appid=730&market_hash_name=StatTrak%E2%84%A2%20P250%20%7C%20Steel%20Disruption%20%28Factory%20New%29");
            int pFrom = yeet.IndexOf("{\"success\":true,\"lowest_price\":\"") + "{\"success\":true,\"lowest_price\":\"".Length;
            int pTo = yeet.LastIndexOf("7");
            string price = yeet.Substring(pFrom, pTo - pFrom);
        }
    }
}
