using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TotalPaid { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<SaleItem> SaleItems { get; set; }
    }
}
