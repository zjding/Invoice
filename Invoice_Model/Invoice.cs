using System;
namespace Invoice_Model
{
	public class Invoice
	{		
		public int id { get; set; }
		public string name { get; set; }
		public string issueDate { get; set; }
		public string dueTerm { get; set; }
		public string dueDate { get; set; }
	}
}
