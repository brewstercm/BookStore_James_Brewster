﻿using BlazorBookStore1;
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
	/// Interaction logic for CreateAccount.xaml
	/// </summary>
	public partial class CreateAccount : Window
	{
		public CreateAccount()
		{
			InitializeComponent();
            chkAdmin.IsChecked = false;
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

        private void btnCreateAccountRedirect_Click(object sender, RoutedEventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            if(!txtfName.Text.Equals(string.Empty) && !txtlName.Text.Equals(string.Empty) && !txtAddress.Text.Equals(string.Empty) && 
                !txtEmail.Text.Equals(string.Empty) && !txtPassword.Text.Equals(string.Empty) && !txtPhone.Text.Equals(string.Empty) && chkAdmin.IsChecked.HasValue)
            {
                DatabaseInstance.CreateAccount(txtfName.Text, txtlName.Text, txtEmail.Text, txtPassword.Text, chkAdmin.IsChecked.Value, txtAddress.Text, txtPhone.Text);
            }
        }
    }
}
