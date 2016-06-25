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

    public class EmployeeController : Controller
    {
        public EmployeeController(IUnityOfWork unityOfWork, IRepository<Employee> employeeRepository)
        {
            this.UnityOfWork = unityOfWork;
            this.EmployeeRepository = employeeRepository;
        }

        /// <summary>
        /// Gets or sets the product examples repository.
        /// </summary>
        protected IRepository<Employee> EmployeeRepository { get; private set; }

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
            var productItems = this.EmployeeRepository.GetQueryable().Select(EmployeeViewModel.ToModel());

            return this.Json(productItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EmployeeViewModel model, [DataSourceRequest] DataSourceRequest request)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var employee = this.EmployeeRepository.Create();

                EmployeeViewModel.ToData(employee, model);
                this.EmployeeRepository.Insert(employee);

                this.UnityOfWork.Save();

                model.Id = employee.Id;
            }


            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, EmployeeViewModel model)
        {
            Contract.Requires(model != null);

            if (this.ModelState.IsValid)
            {
                var employee = this.EmployeeRepository.GetById(model.Id);

                if (employee == null)
                {
                    throw new Exception("Zaměstnanec nenalezen.");
                }

                EmployeeViewModel.ToData(employee, model);

                this.EmployeeRepository.Update(employee);

                this.UnityOfWork.Save();
            }

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, EmployeeViewModel model)
        {
            Contract.Requires(model != null);

            var product = this.EmployeeRepository.GetQueryable().SingleOrDefault(s => s.Id == model.Id);
            if (product == null)
            {
                throw new NullReferenceException("Zaměstnanec nenalezen.");
            }

            this.EmployeeRepository.Delete(product);

            this.UnityOfWork.Save();

            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}