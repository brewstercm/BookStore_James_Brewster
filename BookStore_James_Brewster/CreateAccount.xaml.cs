using BlazorBookStore1;
using BookStore_James_Brewster.databaseclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
	/// Interaction logic for CreateAccount.xaml
	/// </summary>
	public partial class CreateAccount : Window
	{
		public CreateAccount()
		{
			InitializeComponent();
            lblMessage.Visibility = Visibility.Hidden;
            chkAdmin.IsChecked = false;
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
            btnAdminCreateCategory.Visibility = Visibility.Hidden;
			btnAdminViewAuthors.Visibility = Visibility.Hidden;
			btnAdminViewCustomers.Visibility = Visibility.Hidden;
            btnAdminViewOrders.Visibility = Visibility.Hidden;
            btnAdminViewSuppliers.Visibility = Visibility.Hidden;
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
			Administrator.CheckAdmin();
			this.Close();
		}

        private void btnCreateAccountRedirect_Click(object sender, RoutedEventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            if(!txtfName.Text.Trim().Equals(string.Empty) && !txtlName.Text.Trim().Equals(string.Empty) && !txtAddress.Text.Trim().Equals(string.Empty) && 
                !txtEmail.Text.Trim().Equals(string.Empty) && !txtPassword.Text.Trim().Equals(string.Empty) && !txtPhone.Text.Trim().Equals(string.Empty) && chkAdmin.IsChecked.HasValue)
            {
                lblMessage.Visibility = Visibility.Visible;
                try
                {
                    DatabaseInstance.CreateAccount(txtfName.Text.Trim(), txtlName.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim(), chkAdmin.IsChecked.Value, txtAddress.Text.Trim(), txtPhone.Text.Trim());
                    Login b = new Login();
                    b.Show();
                    this.Close();
                }
                catch(Exception ex)
                {
                    lblMessage.Content=ex.Message.Trim();
                    lblMessage.Width = lblMessage.ActualWidth;
                }
                
            }
        }
    }
}
