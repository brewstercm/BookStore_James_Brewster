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
	/// Interaction logic for AdminBookBrowser.xaml
	/// </summary>
	public partial class AdminBookBrowser : Window
	{
		public AdminBookBrowser()
		{
			InitializeComponent();
            foreach (Book book in DatabaseInstance.viewBooks())
            {
                TableRow tableRow = new TableRow();
                TableCell isbnCell = new TableCell();
                Paragraph isbnParagraph = new Paragraph();
                Run isbnRun = new Run();
                isbnRun.Text = book.isbnNum;
                isbnParagraph.Inlines.Add(isbnRun);
                isbnCell.Blocks.Add(isbnParagraph);
                tableRow.Cells.Add(isbnCell);

                TableCell titleCell = new TableCell();
                Paragraph titleParagraph = new Paragraph();
                Run titleRun = new Run();
                titleRun.Text = book.title;
                titleParagraph.Inlines.Add(titleRun);
                titleCell.Blocks.Add(titleParagraph);
                tableRow.Cells.Add(titleCell);

                TableCell pubDateCell = new TableCell();
                Paragraph pubDateParagraph = new Paragraph();
                Run pubDateRun = new Run();
                pubDateRun.Text = book.pubDate;
                pubDateParagraph.Inlines.Add(pubDateRun);
                pubDateCell.Blocks.Add(pubDateParagraph);
                tableRow.Cells.Add(pubDateCell);

                TableCell priceCell = new TableCell();
                Paragraph priceParagraph = new Paragraph();
                Run priceRun = new Run();
                priceRun.Text = book.price.ToString();
                priceParagraph.Inlines.Add(priceRun);
                priceCell.Blocks.Add(priceParagraph);
                tableRow.Cells.Add(priceCell);

                TableCell reviewsCell = new TableCell();
                Paragraph reviewsParagraph = new Paragraph();
                Run reviewsRun = new Run();
                reviewsRun.Text = book.reviews.ToString();
                reviewsParagraph.Inlines.Add(reviewsRun);
                reviewsCell.Blocks.Add(reviewsParagraph);
                tableRow.Cells.Add(reviewsCell);
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
	}
}
