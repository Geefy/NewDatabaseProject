using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;

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
            if (!imageLocation.ToLower().Contains("drop") || !imageLocation.ToLower().Contains("select") || !imageLocation.ToLower().Contains("insert") || !imageLocation.ToLower().Contains("table") || !imageLocation.ToLower().Contains("database"))
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
    }
}
