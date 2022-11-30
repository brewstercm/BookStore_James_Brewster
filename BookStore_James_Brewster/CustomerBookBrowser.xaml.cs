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
	/// Interaction logic for CustomerBookBrowser.xaml
	/// </summary>
	public partial class CustomerBookBrowser : Window
	{
		public CustomerBookBrowser()
		{
			InitializeComponent();

			foreach(Book book in DatabaseInstance.viewBooks())
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
	}
}
