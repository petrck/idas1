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
    using System.Data.Entity;
    public class AddressController : Controller
    {
        public AddressController(IUnityOfWork unityOfWork, IRepository<Address> addressRepository)
        {
            this.UnityOfWork = unityOfWork;
            this.AddressRepository = addressRepository;
        }

        /// <summary>
        /// Gets or sets the product examples repository.
        /// </summary>
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

            var productItems = this.AddressRepository.GetQueryable().Select(AddressViewModel.ToModel());

            return this.Json(productItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AddressFormModel model, [DataSourceRequest] DataSourceRequest request)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var address = this.AddressRepository.Create();

                AddressFormModel.ToData(address, model);
                this.AddressRepository.Insert(address);

                this.UnityOfWork.Save();

                model.Id = address.Id;
            }


            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, AddressFormModel model)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var address = this.AddressRepository.GetById(model.Id);

                if (address == null)
                {
                    throw new Exception("Adresa nenalezena.");
                }

                AddressFormModel.ToData(address, model);

                this.AddressRepository.Update(address);

                this.UnityOfWork.Save();
            }

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, AddressFormModel model)
        {
            Contract.Requires(model != null);

            var address = this.AddressRepository.GetQueryable().Include(s => s.Shop).SingleOrDefault(s => s.Id == model.Id);
            if (address == null)
            {
                throw new NullReferenceException("Adresa nenalezena.");
            }

            this.AddressRepository.Delete(address);

            this.UnityOfWork.Save();

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}