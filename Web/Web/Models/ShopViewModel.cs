namespace Erzasoft.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;

    public class ShopViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Název")]
        public string Name { get; set; }

        [Display(Name = "Město")]
        public string City { get; set; }

        [Display(Name = "Stát")]
        public string State { get; set; }

        [Display(Name = "Země")]
        public string Country { get; set; }

        [Display(Name = "PSČ")]
        public string Zip { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        public static Expression<Func<Shop, ShopViewModel>> ToModel()
        {
            Expression<Func<Shop, ShopViewModel>> select =
                s =>
                new ShopViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Phone = s.Phone,
                    City = s.Adresses.FirstOrDefault(a => a.ShopId == s.Id).City,
                    State = s.Adresses.FirstOrDefault(a => a.ShopId == s.Id).State,
                    Country = s.Adresses.FirstOrDefault(a => a.ShopId == s.Id).Country,
                    Zip = s.Adresses.FirstOrDefault(a => a.ShopId == s.Id).Zip                    
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