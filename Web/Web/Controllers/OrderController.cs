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
    public class OrderController : Controller
    {
        public OrderController(IUnityOfWork unityOfWork, IRepository<Shop> shopRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository, IRepository<OrderHistory> orderHistory)
        {
            this.UnityOfWork = unityOfWork;
            this.ShopRepository = shopRepository;
            this.OrderRepository = orderRepository;
            this.ProductRepository = productRepository;
            this.OrderHistoryRepository = orderHistory;
        }

        /// <summary>
        /// Gets or sets the product examples repository.
        /// </summary>
        protected IRepository<Shop> ShopRepository { get; private set; }

        protected IRepository<Order> OrderRepository { get; private set; }

        protected IRepository<Product> ProductRepository { get; private set; }

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
            this.ViewData["ShopDataSource"] = this.ShopRepository.GetQueryable().Select(s => new DropDownListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            this.ViewData["ProductDataSource"] = this.ProductRepository.GetQueryable().Select(s => new DropDownListItem
            {
                Text = s.Description,
                Value = s.Id.ToString()
            }).ToList();

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
            var productItems = this.OrderRepository.GetQueryable().Select(OrderFormModel.ToModel());

            return this.Json(productItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(OrderFormModel model, [DataSourceRequest] DataSourceRequest request)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var order = this.OrderRepository.Create();

                var orderHistory = this.OrderHistoryRepository.Create();

                OrderFormModel.ToData(order, model);

                var product = this.ProductRepository.GetQueryable().FirstOrDefault(s => s.Id == model.ProductId);

                if (order.Products == null) {
                    order.Products = new List<Product>();
                }

                order.Products.Add(product);

                orderHistory.Amount = product.StorageCapacity;
                orderHistory.Price = product.Price;

                this.OrderHistoryRepository.Insert(orderHistory);
                this.OrderRepository.Insert(order);

                this.UnityOfWork.Save();

                model.Id = order.Id;
            }


            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, OrderFormModel model)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var order = this.OrderRepository.GetById(model.Id);

                if (order == null)
                {
                    throw new Exception("Objednávka nenalezen.");
                }

                OrderFormModel.ToData(order, model);

                this.OrderRepository.Update(order);

                this.UnityOfWork.Save();
            }

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, OrderFormModel model)
        {
            Contract.Requires(model != null);

            var order = this.OrderRepository.GetQueryable().SingleOrDefault(s => s.Id == model.Id);
            if (order == null)
            {
                throw new NullReferenceException("Objednavka nenalezena.");
            }

            this.OrderRepository.Delete(order);

            this.UnityOfWork.Save();

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}