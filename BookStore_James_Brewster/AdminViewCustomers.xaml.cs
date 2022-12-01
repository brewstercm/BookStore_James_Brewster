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
	/// Interaction logic for AdminViewCustomers.xaml
	/// </summary>
	public partial class AdminViewCustomers : Window
	{
		public AdminViewCustomers()
		{
			InitializeComponent();
            foreach (CustomerDetails cd in DatabaseInstance.viewCustomers())
            {
                TableRow tableRow = new TableRow();
                TableCell cusIDCell = new TableCell();
                Paragraph cusIDParagraph = new Paragraph();
                Run cusIDRun = new Run();
				cusIDRun.Text = cd.customerID.ToString();
                cusIDParagraph.Inlines.Add(cusIDRun);
                cusIDCell.Blocks.Add(cusIDParagraph);
                tableRow.Cells.Add(cusIDCell);

                TableCell fnameCell = new TableCell();
                Paragraph fnameParagraph = new Paragraph();
                Run fnameRun = new Run();
                fnameRun.Text = cd.fName;
                fnameParagraph.Inlines.Add(fnameRun);
                fnameCell.Blocks.Add(fnameParagraph);
                tableRow.Cells.Add(fnameCell);

                TableCell lnameCell = new TableCell();
                Paragraph lnameParagraph = new Paragraph();
                Run lnameRun = new Run();
                lnameRun.Text = cd.lName;
                lnameParagraph.Inlines.Add(lnameRun);
                lnameCell.Blocks.Add(lnameParagraph);
                tableRow.Cells.Add(lnameCell);

                TableCell addressCell = new TableCell();
                Paragraph addressParagraph = new Paragraph();
                Run addressRun = new Run();
                addressRun.Text = cd.address;
                addressParagraph.Inlines.Add(addressRun);
                addressCell.Blocks.Add(addressParagraph);
                tableRow.Cells.Add(addressCell);

                TableCell emailCell = new TableCell();
                Paragraph emailParagraph = new Paragraph();
                Run emailRun = new Run();
                emailRun.Text = cd.email;
                emailParagraph.Inlines.Add(emailRun);
                emailCell.Blocks.Add(emailParagraph);
                tableRow.Cells.Add(emailCell);

                TableCell phoneCell = new TableCell();
                Paragraph phoneParagraph = new Paragraph();
                Run phoneRun = new Run();
                phoneRun.Text = cd.phone;
                phoneParagraph.Inlines.Add(phoneRun);
                phoneCell.Blocks.Add(phoneParagraph);
                tableRow.Cells.Add(phoneCell);

				tblRow.Rows.Add(tableRow);
            }
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

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
			if(!txtCustomerID.Text.Equals(string.Empty) && Int32.TryParse(txtCustomerID.Text, out int result))
			{
				CustomerDetails cd = DatabaseInstance.getCustomer(Int32.Parse(txtCustomerID.Text));
                AdminEditCustomer a = new AdminEditCustomer(cd);
				a.Show();
				this.Close();
            }
        }
    }
}
