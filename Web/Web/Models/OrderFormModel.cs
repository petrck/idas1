namespace Erzasoft.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;
    using KendoUtility;
    using Helpers;
    public class OrderFormModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        //[ScaffoldColumn(false)]
        [Display(Name = "Zákazník")]
        public string ShopName { get; set; }

        [Display(Name = "Datum objednání")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Datum rozvozu")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Metoda platby")]
        [EnumList]
        public Payment Payment { get; set; }

        [Display(Name = "Typ objednávky")]
        [EnumList]
        public OrderType Type { get; set; }

        [Display(Name = "Zákazník")]
        [DropDown(DataSourceName = "ShopDataSource")]
        public int ShopId { get; set; }

        [Display(Name = "Product - pro jednoduchost moznost pridat pouze jeden produkt. Databazove lze vice (M:N vazba)")]
        [DropDown(DataSourceName = "ProductDataSource")]
        public int ProductId { get; set; }


        public static Expression<Func<Order, OrderFormModel>> ToModel()
        {
            Expression<Func<Order, OrderFormModel>> select =
                s =>
                new OrderFormModel
                {
                    Id = s.Id,
                    OrderDate = s.OrderDate,
                    DeliveryDate = s.DeliveryDate,
                    Payment = s.Payment,
                    Type = s.Type,
                    ShopName = s.Shop.Name
                };

            return select;
        }


        public static void ToData(Order order, OrderFormModel model)
        {
            order.OrderDate = model.OrderDate;
            order.DeliveryDate = model.DeliveryDate;
            order.Payment = model.Payment;
            order.Type = model.Type;
            order.ShopId = model.ShopId;
            
        }
    }
}