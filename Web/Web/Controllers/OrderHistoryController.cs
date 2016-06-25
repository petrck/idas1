namespace Erzasoft.Web.Controllers
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    using Erzasoft.DataModel.Semestralka;
    using Erzasoft.MvcUtility.Results;
    using Erzasoft.Repository;
    using Erzasoft.Web.Models;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System.Collections.Generic;
    public class OrderHistoryController : Controller
    {
        public OrderHistoryController(IUnityOfWork unityOfWork, IRepository<OrderHistory> orderHistory)
        {
            this.UnityOfWork = unityOfWork;
            this.OrderHistoryRepository = orderHistory;
        }


        protected IRepository<OrderHistory> OrderHistoryRepository { get; private set; }

        /// <summary>
        /// Gets the unity of work.
        /// </summary>
        protected IUnityOfWork UnityOfWork { get; private set; }
        
        // GET: Admin/ProductExamples
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>

        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The read.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var productItems = this.OrderHistoryRepository.GetQueryable().Select(OrderHistoryFormModel.ToModel());

            return this.Json(productItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}