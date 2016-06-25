namespace Erzasoft.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;

    public class AddressViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Město")]
        public string City { get; set; }

        [Display(Name = "Stát")]
        public string State { get; set; }

        [Display(Name = "Země")]
        public string Country { get; set; }

        [Display(Name = "psč")]
        public string Zip { get; set; }

        [Display(Name = "Název zákazníka")]
        public string ShopName { get; set; }

        public static Expression<Func<Address, AddressViewModel>> ToModel()
        {
            Expression<Func<Address, AddressViewModel>> select =
                s =>
                new AddressViewModel
                {
                    Id = s.Id,
                    City = s.City,
                    State = s.State,
                    Country = s.Country,
                    Zip = s.Zip,
                    ShopName = s.Shop.Name
                };

            return select;
        }
    }
}