using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamMarketWPF
{
    class Item
    {
        string itemName;
        string wear;
        string lowestPrice;
        string medianPrice;
        string amountLeft;
        byte[] img;

        public string ItemName { get => itemName; set => itemName = value; }
        public string Wear { get => wear; set => wear = value; }
        public string LowestPrice { get => lowestPrice; set => lowestPrice = value; }
        public string MedianPrice { get => medianPrice; set => medianPrice = value; }
        public byte[] Img { get => img; set => img = value; }
        public string AmountLeft { get => amountLeft; set => amountLeft = value; }
    }
}
