using BlazorBookStore1;
using BookStore_James_Brewster.databaseclasses;
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
using System.Windows.Shapes;

namespace BookStore_James_Brewster
{
	/// <summary>
	/// Interaction logic for AdminAddSupplierRep.xaml
	/// </summary>
	public partial class AdminAddSupplierRep : Window
	{
		public Supplier s;
		public AdminAddSupplierRep(Supplier s)
		{
			this.s = s;
			InitializeComponent();
		}

		private void btnLogout_Click(object sender, RoutedEventArgs e)
		{
			DatabaseInstance.Logout();
			Login mw = new Login();
			mw.Show();
			this.Close();
		}
		private void btnAddSupplierRep_Click(object sender, RoutedEventArgs e)
		{
			DatabaseInstance.addSupplierRep(txtfName.Text.Trim(), txtlName.Text.Trim(), txtWorkNum.Text.Trim(), txtCellNum.Text.Trim(), txtEmail.Text.Trim(), s.supplierID);
			AdminViewSupplierReps avsr = new AdminViewSupplierReps(s);
			avsr.Show();
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
	}
}
