using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool bTaxable { get; set; }
        public string Note { get; set; }
    }
}
