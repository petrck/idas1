using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erzasoft.DataModel.Semestralka
{
    public enum Payment
    {
        [Display(Name = "Platební karta")]
        ONLINE = 1
    }
}
