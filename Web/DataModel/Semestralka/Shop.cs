using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.DataModel.Semestralka
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Address>  Adresses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public string Phone { get; set; }
    }
}
