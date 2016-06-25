namespace Erzasoft.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;

    public class OrderViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Datum objednání")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Datum rozvozu")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Metoda platby")]
        public Payment Payment { get; set; }

        [Display(Name = "Typ objednávky")]
        public OrderType Type { get; set; }
        
        public string Shop { get; set; }

        [Display(Name = "Zákazník")]
      

        public static Expression<Func<Order, OrderViewModel>> ToModel()
        {
            Expression<Func<Order, OrderViewModel>> select =
                s =>
                new OrderViewModel
                {
                    Id = s.Id,
                    OrderDate = s.OrderDate,
                    DeliveryDate = s.DeliveryDate,
                    Payment = s.Payment,
                    Type = s.Type,
                    Shop = s.Shop.Name
                };

            return select;
        }


        public static void ToData(Shop shop, ShopFormModel model)
        {
            shop.Id = model.Id;
            shop.Name = model.Name;
            shop.Phone = model.Phone;
            //shop.City = model.Adresses.First().City;
            //shop.State = s.Adresses.First().Stat;
        }
    }
}