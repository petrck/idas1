namespace Erzasoft.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;
    using Erzasoft.Web.Helpers;
    using KendoUtility;
    public class ProductFormModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Zásob")]
        [Required]
        public decimal StorageCapacity { get; set; }

        [Display(Name = "Skladem")]
        [Required]
        public bool InStock { get; set; }

        [Display(Name = "Cena")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Doporučená")]
        [Required]
        public decimal RecommendedPrice { get; set; }

        [Display(Name = "Popisek")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Dlouhý popis")]
        [Required]
        public string LongDescription { get; set; }

        //public virtual ICollection<Image> Images { get; set; }

        public static Expression<Func<Product, ProductFormModel>> ToModel()
        {
            Expression<Func<Product, ProductFormModel>> select =
                s =>
                new ProductFormModel
                {
                    Id = s.Id,
                    StorageCapacity = s.StorageCapacity,
                    InStock = s.InStock,
                    RecommendedPrice = s.RecommendedPrice,
                    Description = s.Description,
                    LongDescription = s.LongDescription,
                    Price = s.Price
                };

            return select;
        }


        public static void ToData(Product shop, ProductFormModel model)
        {
            shop.StorageCapacity = model.StorageCapacity;
            shop.InStock = model.InStock;
            shop.RecommendedPrice = model.RecommendedPrice;
            shop.Description = model.Description;
            shop.LongDescription = model.LongDescription;
            shop.Price = model.Price;
        }
    }
}