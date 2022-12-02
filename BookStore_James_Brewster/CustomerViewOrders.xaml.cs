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
	/// Interaction logic for CustomerViewOrders.xaml
	/// </summary>
	public partial class CustomerViewOrders : Window
	{
		public CustomerViewOrders()
		{
			InitializeComponent();
            foreach (Order o in DatabaseInstance.viewCustomerOrders(BlazorBookStore1.Customer.customerID))
            {
                TableRow tableRow = new TableRow();

                TableCell orderIDCell = new TableCell();
                Paragraph orderIDParagraph = new Paragraph();
                Run orderIDRun = new Run();
                orderIDRun.Text = o.orderID.ToString();
                orderIDParagraph.Inlines.Add(orderIDRun);
                orderIDCell.Blocks.Add(orderIDParagraph);
                tableRow.Cells.Add(orderIDCell);

                TableCell orderDateCell = new TableCell();
                Paragraph orderDateParagraph = new Paragraph();
                Run orderDateRun = new Run();
                orderDateRun.Text = o.orderDate;
                orderDateParagraph.Inlines.Add(orderDateRun);
                orderDateCell.Blocks.Add(orderDateParagraph);
                tableRow.Cells.Add(orderDateCell);

                TableCell orderValCell = new TableCell();
                Paragraph orderValParagraph = new Paragraph();
                Run orderValRun = new Run();
                orderValRun.Text = o.orderVal.ToString();
                orderValParagraph.Inlines.Add(orderValRun);
                orderValCell.Blocks.Add(orderValParagraph);
                tableRow.Cells.Add(orderValCell);

                TableCell customerIDCell = new TableCell();
                Paragraph customerIDParagraph = new Paragraph();
                Run customerIDRun = new Run();
                customerIDRun.Text = o.customerID.ToString();
                customerIDParagraph.Inlines.Add(customerIDRun);
                customerIDCell.Blocks.Add(customerIDParagraph);
                tableRow.Cells.Add(customerIDCell);

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
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
