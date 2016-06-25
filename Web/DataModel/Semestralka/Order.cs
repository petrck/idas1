using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.DataModel.Semestralka
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Payment Payment { get; set; }

        public virtual Shop Shop { get; set; }

        [ForeignKey("Shop")]
        public virtual int ShopId { get; set; }

        public OrderType Type { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
