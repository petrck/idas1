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

    public class ProductController : Controller
    {
        public ProductController(IUnityOfWork unityOfWork, IRepository<Shop> shopRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository, IRepository<Warehouse> warehouseRepository, IRepository<Commission> commissionRepository)
        {
            this.UnityOfWork = unityOfWork;
            this.ProductRepository = productRepository;
            this.OrderRepository = orderRepository;
            this.WarehouseRepository = warehouseRepository;
            this.CommissionRepository = commissionRepository;
        }

        /// <summary>
        /// Gets or sets the product examples repository.
        /// </summary>
        protected IRepository<Shop> ShopRepository { get; private set; }

        protected IRepository<Product> ProductRepository { get; private set; }

        protected IRepository<Order> OrderRepository { get; private set; }

        protected IRepository<OrderHistory> OrderHistoryRepository { get; private set; }

        protected IRepository<Warehouse> WarehouseRepository { get; private set; }

        protected IRepository<Commission> CommissionRepository { get; private set; }

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
            //this.ViewData["WarehouseDataSource"] = this.WarehouseRepository.GetQueryable().Select(s => new DropDownListItem
            //{
            //    Text = s. Name,
            //    Value = s.Id.ToString()
            //}).ToList();

            //this.ViewData["CommissionDataSource"] = this.CommissionRepository.GetQueryable().Select(s => new DropDownListItem
            //{
            //    Text = s. Name,
            //    Value = s.Id.ToString()
            //}).ToList();

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
            var productItems = this.ProductRepository.GetQueryable().Select(ProductFormModel.ToModel());

            return this.Json(productItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductFormModel model, [DataSourceRequest] DataSourceRequest request)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var product = this.ProductRepository.Create();

                //var orderHistory = this.OrderHistoryRepository.Create();

                ProductFormModel.ToData(product, model);

                this.ProductRepository.Insert(product);

                this.UnityOfWork.Save();

                model.Id = product.Id;
            }

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ProductFormModel model)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var order = this.ProductRepository.GetById(model.Id);

                if (order == null)
                {
                    throw new Exception("Objednávka nenalezen.");
                }

                ProductFormModel.ToData(order, model);

                this.ProductRepository.Update(order);

                this.UnityOfWork.Save();
            }

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ProductFormModel model)
        {
            Contract.Requires(model != null);

            var order = this.ProductRepository.GetQueryable().SingleOrDefault(s => s.Id == model.Id);
            if (order == null)
            {
                throw new NullReferenceException("Objednavka nenalezena.");
            }

            this.ProductRepository.Delete(order);

            this.UnityOfWork.Save();

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}