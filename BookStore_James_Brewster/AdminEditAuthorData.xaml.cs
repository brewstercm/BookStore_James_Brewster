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
			txtMessage.Visibility = Visibility.Hidden;
			this.author = author;
			txtAuthorAddress.Text = author.Address;
			txtAuthorDOB.Text = author.DOB;
			txtAuthorFName.Text = author.FName;
			txtAuthorLName.Text = author.LName;
			txtAuthorGender.Text = author.Gender;
			txtAuthorEmail.Text = author.Email;
			txtAuthorPhone.Text = author.Phone;
		}

		private void btnEditAuthor_Click(object sender, RoutedEventArgs e)
		{
			txtMessage.Visibility = Visibility.Visible;
			txtMessage.Text = "Loading...";
			if(!txtAuthorAddress.Text.Equals(author.Address) || !txtAuthorDOB.Text.Equals(author.DOB) 
				|| !txtAuthorFName.Text.Equals(author.FName) || !txtAuthorLName.Text.Equals(author.LName) 
				|| !txtAuthorGender.Text.Equals(author.Gender) || !txtAuthorEmail.Text.Equals(author.Email)
				|| !txtAuthorPhone.Text.Equals(author.Phone))
			{
				DatabaseInstance.editAuthor(author.AuthorID, txtAuthorFName.Text, txtAuthorLName.Text, txtAuthorGender.Text,
					txtAuthorDOB.Text, txtAuthorAddress.Text, txtAuthorEmail.Text, txtAuthorPhone.Text);
				txtMessage.Text = "Successfully edited author details";
			} else
			{
				txtMessage.Text = "Please change a value before submitting";
			}
		}
	}
}
