using BlazorBookStore1;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_James_Brewster.databaseclasses
{

	public static class Administrator
	{

		public static void CheckAdmin()
		{
			if (BlazorBookStore1.Customer.isAdministrator)
			{
				AdminBookBrowser aab = new AdminBookBrowser();
				aab.Show();
			}
			else { 
				CustomerBookBrowser cbb = new CustomerBookBrowser();
				cbb.Show();
			}
		}
	}

}
