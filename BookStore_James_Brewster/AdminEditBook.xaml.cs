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
            if (BlazorBookStore1.Customer.customerID == -1)
            {
                hideProfileButtons();
            }
            else
            {
                hideLoggedInButtons();
            }
            if (!BlazorBookStore1.Customer.isAdministrator)
            {
                hideAdminButtons();
            }
        }

        private void hideLoggedInButtons()
        {
            btnLogin.Visibility = Visibility.Hidden;
            btnCreateAccount.Visibility = Visibility.Hidden;
        }
        private void hideAdminButtons()
        {
            btnAdminBookBrowser.Visibility = Visibility.Hidden;
            btnAdminCreateCategory.Visibility = Visibility.Hidden;
            btnAdminSpacer.Visibility = Visibility.Hidden;
            btnAdminViewCustomers.Visibility = Visibility.Hidden;
			btnAdminViewAuthors.Visibility = Visibility.Hidden;
			btnAdminViewOrders.Visibility = Visibility.Hidden;
            btnAdminViewSuppliers.Visibility = Visibility.Hidden;
            btnAdminCreateCategory.Visibility = Visibility.Hidden;

        }
        private void hideProfileButtons()
        {
            btnLogout.Visibility = Visibility.Hidden;
            btnCustomerUpdateAccount.Visibility = Visibility.Hidden;
            btnCustomerViewOrders.Visibility = Visibility.Hidden;
            btnCustomerBookBrowser.Visibility = Visibility.Hidden;
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            DatabaseInstance.Logout();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
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
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AdminAddBook a = new AdminAddBook();
			a.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			AdminBookBrowser a = new AdminBookBrowser();
			a.Show();
			this.Close();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			AdminCreateCategory a = new AdminCreateCategory();
			a.Show();
			this.Close();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			//Admineditauthordata
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			//admineditbook
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			AdminViewAuthors a = new AdminViewAuthors();
			a.Show();
			this.Close();
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			AdminViewCustomers a = new AdminViewCustomers();
			a.Show();
			this.Close();
		}

		private void Button_Click_7(object sender, RoutedEventArgs e)
		{
			AdminViewOrders a = new AdminViewOrders();
			a.Show();
			this.Close();
		}

		private void Button_Click_8(object sender, RoutedEventArgs e)
		{
			AdminViewSuppliers a = new AdminViewSuppliers();
			a.Show();
			this.Close();
		}

		private void Button_Click_9(object sender, RoutedEventArgs e)
		{
			CreateAccount a = new CreateAccount();
			a.Show();
			this.Close();
		}

		private void Button_Click_10(object sender, RoutedEventArgs e)
		{
			CustomerBookBrowser a = new CustomerBookBrowser();
			a.Show();
			this.Close();
		}

		private void Button_Click_11(object sender, RoutedEventArgs e)
		{
			CustomerUpdateAccount a = new CustomerUpdateAccount();
			a.Show();
			this.Close();
		}

		private void Button_Click_12(object sender, RoutedEventArgs e)
		{
			CustomerViewOrders a = new CustomerViewOrders();
			a.Show();
			this.Close();
		}

		private void Button_Click_13(object sender, RoutedEventArgs e)
		{
			CreateAccount a = new CreateAccount();
			a.Show();
			this.Close();
		}

		private void Button_Click_14(object sender, RoutedEventArgs e)
		{
			Login a = new Login();
			a.Show();
			this.Close();
		}

		private void Button_Click_15(object sender, RoutedEventArgs e)
		{
			MainWindow a = new MainWindow();
			a.Show();
			this.Close();
		}

		private void btntDeleteBook_Click(object sender, RoutedEventArgs e)
		{
			DatabaseInstance.deleteBook(book.isbnNum);
			AdminBookBrowser a = new AdminBookBrowser();
			a.Show();
			this.Close();
		}

		private void btnConfirmEditBook_Click(object sender, RoutedEventArgs e)
		{
			DatabaseInstance.editBook(book.isbnNum, book.title, book.pubDate, book.price, book.reviews, book.supplierID);
			AdminBookBrowser a = new AdminBookBrowser();
			a.Show();
			this.Close();
		}
	}
}
