namespace Erzasoft.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Erzasoft.DataModel.Semestralka;

    public class AddressFormModel
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

        public static Expression<Func<Address, AddressFormModel>> ToModel()
        {
            Expression<Func<Address, AddressFormModel>> select =
                s =>
                new AddressFormModel
                {
                    Id = s.Id,
                    City = s.City,
                    State = s.State,
                    Country = s.Country,
                    Zip = s.Zip,

                };

            return select;
        }

        public static void ToData(Address address, AddressFormModel model)
        {
            address.State = model.State;
            address.Country = model.Country;
            address.City = model.City;
            address.Zip = model.Zip;
        }
    }
}