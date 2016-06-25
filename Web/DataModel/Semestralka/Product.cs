using System.Collections.Generic;

namespace Erzasoft.DataModel.Semestralka
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int Id { get; set; }

        public decimal StorageCapacity { get; set; }

        public bool InStock { get; set; }

        public decimal Price { get; set; }

        public decimal RecommendedPrice { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey("Warehouse")]
        public virtual int? WarehouseId { get; set; }

        public virtual Commission Commission { get; set; }

        [ForeignKey("Commission")]
        public virtual int? CommissionId { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
