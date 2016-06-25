using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.DataModel.Semestralka
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Warehouse
    {
        public int Id { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual Region Region { get; set; }

        [ForeignKey("Region")]
        public virtual int RegionId { get; set; }
    }
}
