using BlazorBookStore1;
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

namespace BookStore_James_Brewster
{
	/// <summary>
	/// Interaction logic for AdminAddBook.xaml
	/// </summary>
	public partial class AdminAddBook : Window
	{
		public AdminAddBook()
		{
			InitializeComponent();
		}

		private void btnAddBook_Click(object sender, RoutedEventArgs e)
		{
			if(!txtISBN.Text.Equals(string.Empty) && !txtTitle.Text.Equals(string.Empty) && !txtPubDate.Text.Equals(String.Empty) && !txtPrice.Text.Equals(String.Empty) && !txtReviews.Text.Equals(string.Empty))
			{
                DatabaseInstance.addBook(txtISBN.Text, txtTitle.Text, txtPubDate.Text, float.Parse(txtPrice.Text), float.Parse(txtReviews.Text));
				txtISBN.Text = string.Empty;
				txtTitle.Text = string.Empty;
				txtPubDate.Text = string.Empty;
				txtPrice.Text = string.Empty;
				txtReviews.Text = string.Empty;
            }
        }
	}
}
