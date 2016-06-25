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
    public class OrderHistoryFormModel
    {
        //[ScaffoldColumn(false)]
        public int Id { get; set; }

        //[ScaffoldColumn(false)]
        [Display(Name = "Množství")]
        public decimal Amount { get; set; }

        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        public static Expression<Func<OrderHistory, OrderHistoryFormModel>> ToModel()
        {
            Expression<Func<OrderHistory, OrderHistoryFormModel>> select =
                s =>
                new OrderHistoryFormModel {
                    Id = s.Id,
                    Amount = s.Amount,
                    Price = s.Price
                };

            return select;
        }
    }
}