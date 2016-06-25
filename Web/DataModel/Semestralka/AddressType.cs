using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.DataModel.Semestralka
{
    using System.ComponentModel.DataAnnotations;

    public enum AddressType
    {
        [Display(Name = "Fakturační")]
        Billing = 1,

        [Display(Name = "Dodací")]
        Delivery = 2,

        [Display(Name = "Sklad")]
        Stock = 3
    }
}
