//// --------------------------------------------------------------------------------------------------------------------
//// <copyright file="AccountViewModels.cs" company="">
////   
//// </copyright>
//// <summary>
////   The external login confirmation view model.
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------

//using System;

//using System.Linq.Expressions;
//using Erzasoft.DataModel;
//using Erzasoft.KendoUtility;

//namespace Erzasoft.Web.Models
//{
//    using System.ComponentModel.DataAnnotations;
//    using System.Web.Mvc;

//    /// <summary>
//    /// The external login confirmation view model.
//    /// </summary>
//    public class NewsModel
//    {
//        [ScaffoldColumn(false)]
//        public int Id { get; set; }

//        [Display(Name="Nadpis")]
//        [Required]
//        public string Name { get; set; }

//        [Display(Name = "Obsah")]
//        [Required]
//        [Editor]
//        [AllowHtml]
//        public string Text { get; set; }

//        [Display(Name = "Datum")]
//        [Required]
//        public DateTime Insert { get; set; }

//        [ScaffoldColumn(false)]
//        public string Urlid { get; set; }

//        [Display(Name = "Pořadí zobrazení")]
//        [Required]
//        public int Order { get; set; }


//        public static Expression<Func<News, NewsModel>> ToModel()
//        {
//            Expression<Func<News, NewsModel>> select =
//                s =>
//                new NewsModel
//                {
//                    Id = s.Id,
//                    Name = s.Name,
//                    Text = s.Text,                    
//                    Insert = s.Insert,
//                    Urlid = s.Urlid,
//                    Order = s.Order
//                };

//            return select;
//        }

//        public static void ToData(News product, NewsModel model)
//        {
//            product.Name = model.Name;
//            product.Text = model.Text;
//            product.Insert = DateTime.Now;
//            product.Order = model.Order;
//            product.Urlid = model.Urlid;
//        }
//    }
//}
