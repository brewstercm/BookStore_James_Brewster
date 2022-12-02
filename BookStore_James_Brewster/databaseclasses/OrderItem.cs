using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_James_Brewster.databaseclasses
{
    public class OrderItem
    {
        public int itemNum { get; set; }
        public decimal itemPrice { get; set; }
        public int orderID { get; set; }
        public string isbnNum { get; set; }

        public OrderItem(int itemNum, decimal itemPrice, int orderID, string isbnNum)
        {
            this.itemNum = itemNum;
            this.itemPrice = itemPrice;
            this.orderID = orderID;
            this.isbnNum = isbnNum;
        }
    }
}
