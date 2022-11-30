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
using BlazorBookStore1;

namespace BookStore_James_Brewster
{
	/// <summary>
	/// Interaction logic for AdminEditBook.xaml
	/// </summary>
	public partial class AdminEditBook : Window
	{
		private Book book { get; set; }
		public AdminEditBook(Book book)
		{
			InitializeComponent();
			this.book = book;
			txtISBN.Text = this.book.isbnNum;
			txtTitle.Text = this.book.title;
			txtPubDate.Text = this.book.pubDate;
			txtPrice.Text = this.book.price.ToString();
			txtReviews.Text = this.book.reviews.ToString();
		}

		private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
		{
			DatabaseInstance.deleteBook(this.book.isbnNum);
		}

		private void btnConfirmChanges_Click(object sender, RoutedEventArgs e)
		{
			if(!txtISBN.Text.Equals(string.Empty) && !txtTitle.Text.Equals(string.Empty) && !txtPubDate.Text.Equals(string.Empty) && !txtPrice.Text.Equals(string.Empty) && 
				!txtReviews.Text.Equals(string.Empty) && float.TryParse(txtPrice.Text, out float result) && float.TryParse(txtReviews.Text, out float result2))
			{
                DatabaseInstance.editBook(txtISBN.Text, txtTitle.Text, txtPubDate.Text, float.Parse(txtPrice.Text), float.Parse(txtReviews.Text), this.book.supplierID);
            }
        }
	}
}
