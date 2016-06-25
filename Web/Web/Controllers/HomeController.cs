using System.Collections.Generic;
using System.Web.Mvc;
using Erzasoft.DataModel;
using Erzasoft.Repository;
using Kendo.Mvc.Extensions;
using System.Linq;

namespace Erzasoft.Web.Controllers
{
    public class HomeController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }
    }
}