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
	/// Interaction logic for AdminEditAuthorData.xaml
	/// </summary>
	public partial class AdminEditAuthorData : Window
	{
		private AuthorDetails author { get; set; }
		public AdminEditAuthorData(AuthorDetails author)
		{
			InitializeComponent();
			this.author = author;
			txtAddress.Text = author.Address;
			txtDOB.Text = author.DOB;
			txtfName.Text = author.FName;
			txtlName.Text = author.LName;
			txtGender.Text = author.Gender;
			txtAuthorEmail.Text = author.Email;
			txtAuthorPhone.Text = author.Phone;
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
            btnAdminViewOrders.Visibility = Visibility.Hidden;
            btnAdminViewSuppliers.Visibility = Visibility.Hidden;
            btnAdminCreateCategory.Visibility = Visibility.Hidden;
			btnAdminViewAuthors.Visibility = Visibility.Hidden;
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
			Login mw = new Login();
			mw.Show();
            this.Close();
        }

        private void btnEditAuthor_Click(object sender, RoutedEventArgs e)
		{
			if(!txtAddress.Text.Trim().Equals(author.Address) || !txtDOB.Text.Trim().Equals(author.DOB) 
				|| !txtfName.Text.Trim().Equals(author.FName) || !txtlName.Text.Trim().Equals(author.LName) 
				|| !txtGender.Text.Trim().Equals(author.Gender) || !txtAuthorEmail.Text.Trim().Equals(author.Email)
				|| !txtAuthorPhone.Text.Trim().Equals(author.Phone))
			{
				DatabaseInstance.editAuthor(author.AuthorID, txtfName.Text.Trim(), txtlName.Text.Trim(), txtGender.Text.Trim(),
					txtDOB.Text.Trim(), txtAddress.Text.Trim(), txtAuthorEmail.Text.Trim(), txtAuthorPhone.Text.Trim());
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
			AdminAddCategory a = new AdminAddCategory();
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

		private void btnSubmitAuthorChanges_Click(object sender, RoutedEventArgs e)
		{
			DatabaseInstance.editAuthor(author.AuthorID, txtfName.Text.Trim(), txtlName.Text.Trim(), txtGender.Text.Trim(), txtDOB.Text.Trim(), txtAddress.Text.Trim(), txtAuthorEmail.Text.Trim(), txtAuthorPhone.Text.Trim());
			AdminViewAuthors a = new AdminViewAuthors();
			a.Show();
			this.Close();
		}

		private void btnDeleteAuthor_Click(object sender, RoutedEventArgs e) 
		{
			DatabaseInstance.deleteAuthor(author.AuthorID);
		}
	}
}
