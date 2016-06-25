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
    public class ShopController : Controller
    {
        public ShopController(IUnityOfWork unityOfWork, IRepository<Shop> shopRepository, IRepository<Address> addressRepository)
        {
            this.UnityOfWork = unityOfWork;
            this.ShopRepository = shopRepository;
            this.AddressRepository = addressRepository;
        }

        /// <summary>
        /// Gets or sets the product examples repository.
        /// </summary>
        protected IRepository<Shop> ShopRepository { get; private set; }

        protected IRepository<Address> AddressRepository { get; private set; }

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
            var productItems = this.ShopRepository.GetQueryable().Select(ShopViewModel.ToModel());

            return this.Json(productItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ShopFormModel model, [DataSourceRequest] DataSourceRequest request)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var shop = this.ShopRepository.Create();

                var address = this.AddressRepository.Create();
                
                ShopFormModel.ToData(shop, model, address);
                address.Shop = shop;
                shop.Adresses = new List<Address>();
                shop.Adresses.Add(address);

                this.ShopRepository.Insert(shop);

                this.UnityOfWork.Save();

                model.Id = shop.Id;
            }


            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ShopFormModel model)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var shop = this.ShopRepository.GetById(model.Id);

                if (shop == null)
                {
                    throw new Exception("Zaměstnanec nenalezen.");
                }

                var address = this.AddressRepository.GetQueryable().SingleOrDefault(s => s.ShopId == model.Id);

                ShopFormModel.ToData(shop, model, address);

                this.AddressRepository.Update(address);

                this.ShopRepository.Update(shop);

                this.UnityOfWork.Save();
            }

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ShopFormModel  model)
        {
            Contract.Requires(model != null);

            var product = this.ShopRepository.GetQueryable().SingleOrDefault(s => s.Id == model.Id);
            if (product == null)
            {
                throw new NullReferenceException("Zaměstnanec nenalezen.");
            }

            this.ShopRepository.Delete(product);

            this.UnityOfWork.Save();

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}