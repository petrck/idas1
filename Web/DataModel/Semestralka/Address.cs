using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.DataModel.Semestralka
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }

        public AddressType Type { get; set; }

        public virtual Shop Shop { get; set; }

        [ForeignKey("Shop")]
        public virtual int? ShopId { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey("Warehouse")]
        public virtual int? WarehouseId { get; set; }
    }
}
