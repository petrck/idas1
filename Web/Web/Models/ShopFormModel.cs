namespace Erzasoft.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;
    using Erzasoft.Web.Helpers;

    public class ShopFormModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Název")]
        public string Name { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Město")]
        public string City { get; set; }

        [Display(Name = "Stát")]
        public string State { get; set; }

        [Display(Name = "Země")]
        public string Country { get; set; }

        [Display(Name = "Psč")]
        public string Zip { get; set; }

        [Display(Name = "Druh adresy")]
        [EnumList]
        public AddressType Type { get; set; }

        public static Expression<Func<Shop, ShopFormModel>> ToModel(Address address)
        {
            Expression<Func<Shop, ShopFormModel>> select =
                s =>
                new ShopFormModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Phone = s.Phone,
                    State = address.State,
                    City = address.City,
                    Country = address.Country,
                    Type = address.Type,
                    Zip = address.Zip
                };

            return select;
        }


        public static void ToData(Shop shop, ShopFormModel model, Address address)
        {
            shop.Name = model.Name;
            shop.Phone = model.Phone;

            address.Country = model.Country;
            address.State = model.State;
            address.Type = model.Type;
            address.Zip = model.Zip;
            address.City = model.City;
        }
    }
}