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
	/// Interaction logic for AdminViewAuthors.xaml
	/// </summary>
	public partial class AdminViewAuthors : Window
	{
		public AdminViewAuthors()
		{
			InitializeComponent();
			foreach(AuthorDetails ad in DatabaseInstance.viewAuthors())
			{
                //TableRow tableRow = new TableRow();
                //TableCell isbnCell = new TableCell();
                //Paragraph isbnParagraph = new Paragraph();
                //Run isbnRun = new Run();
                //isbnRun.Text = book.isbnNum;
                //isbnParagraph.Inlines.Add(isbnRun);
                //isbnCell.Blocks.Add(isbnParagraph);
                //tableRow.Cells.Add(isbnCell);
            }
		}

		private void btnEditAuthor_Click(object sender, RoutedEventArgs e)
		{
			if(!txtAuthorID.Text.Equals(string.Empty) && Int32.TryParse(txtAuthorID.Text, out int authorID))
			{
				AuthorDetails ad = DatabaseInstance.getAuthor(Int32.Parse(txtAuthorID.Text));
				AdminEditAuthorData aead = new AdminEditAuthorData(ad);
				aead.Activate();
				this.Close();
			}
		}
	}
}
