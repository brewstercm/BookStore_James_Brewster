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
	/// Interaction logic for AdminCreateCategory.xaml
	/// </summary>
	public partial class AdminCreateCategory : Window
	{
		public AdminCreateCategory()
		{
			InitializeComponent();
		}

		private void btnCreateCategory_Click(object sender, RoutedEventArgs e)
		{
			if(!txtCatDesc.Text.Equals("something") && !txtCatDesc.Text.Equals("TextBlock") && !txtCatDesc.Text.Equals(String.Empty))
			{
                DatabaseInstance.createCategory(txtCatDesc.Text);
            }
		}

	}
}
