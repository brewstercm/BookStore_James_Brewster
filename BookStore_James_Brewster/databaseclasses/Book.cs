using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBookStore1
{
    public class Book
    {
        public string isbnNum { get; set; }
        public string title { get; set; }
        public string pubDate { get; set; }
        public decimal price { get; set; }
        public decimal reviews { get; set; }
        public int supplierID { get; set; }
        public string category { get; set; }

        public Book(string isbnNum, string title, string pubDate, decimal price, decimal reviews, int supplierID, string category)
        {
            this.isbnNum = isbnNum;
            this.title = title;
            this.pubDate = pubDate;
            this.price = price;
            this.reviews = reviews;
            this.supplierID = supplierID;
            this.category = category;
        }
    }
}
