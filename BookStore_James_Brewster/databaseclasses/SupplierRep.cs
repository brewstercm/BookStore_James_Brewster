using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_James_Brewster.databaseclasses
{
	internal class SupplierRep
	{
		public string fName { get; set; }
		public string lName { get; set; }
		public int workNum { get; set; }
		public int cellNum { get; set; }
		public string email { get; set; }
		public int supplierID { get; set; }
		public SupplierRep(string fName, string lName, int workNum, int cellNum, string email, int supplierID) 
		{
			this.fName = fName;
			this.lName = lName;
			this.workNum = workNum;
			this.cellNum = cellNum;
			this.email = email;
			this.supplierID = supplierID;
		}
	}
}
