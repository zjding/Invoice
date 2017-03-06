using System;
namespace Invoice_Model
{
	public class Invoice
	{		
		public int id { get; set; }
		public string name { get; set; }
		public DateTime issueDate { get; set; }
		public string dueTerm { get; set; }
		public DateTime dueDate { get; set; }
	}
}
