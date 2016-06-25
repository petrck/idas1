// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FilterConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Web
{
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
