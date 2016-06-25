﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.DataModel.Semestralka
{
    public class Region
    {
        public int Id { get; set; }

        public string Nazev { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
