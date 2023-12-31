﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Entities
{
    public class SaleItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
