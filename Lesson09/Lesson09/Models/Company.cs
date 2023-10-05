﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EMP> Employees { get; set; }
    }
}
