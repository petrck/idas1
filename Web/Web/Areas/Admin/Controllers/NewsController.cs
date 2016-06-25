//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Contracts;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Erzasoft.ConfigService;
//using Erzasoft.DataModel;
//using Erzasoft.MvcUtility.Results;
//using Erzasoft.Repository;
//using Erzasoft.Service;
//using Erzasoft.Web.Models;
//using Kendo.Mvc.Extensions;
//using Kendo.Mvc.UI;

//namespace Erzasoft.Web.Areas.Admin.Controllers
//{
//    [Authorize]
//    public class NewsController : Controller
//    {
//        public NewsController(IRepository<News> newsRepository, IUnityOfWork unityOfWork, IUrlIdService urlIdService, IConfigService configService)
//        {
//            NewsRepository = newsRepository;
//            UnityOfWork = unityOfWork;
//            UrlIdService = urlIdService;
//            ConfigService = configService;
//        }        

//        /// <summary>
//        /// Gets or sets the product examples repository.
//        /// </summary>
//        protected IRepository<News> NewsRepository { get; private set; }

//        /// <summary>
//        /// Gets the unity of work.
//        /// </summary>
//        protected IUnityOfWork UnityOfWork { get; private set; }

//        /// <summary>
//        /// Gets the url id service.
//        /// </summary>
//        protected IUrlIdService UrlIdService { get; private set; }

//        /// <summary>
//        /// Gets the config service.
//        /// </summary>
//        protected IConfigService ConfigService { get; private set; }

//        // GET: Admin/ProductExamples
//        /// <summary>
//        /// The index.
//        /// </summary>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>

//        public ActionResult Index()
//        {
//            return View();
//        }

//        /// <summary>
//        /// The read.
//        /// </summary>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
//        {
//            var productItems = this.NewsRepository.GetQueryable().Select(NewsModel.ToModel());

//            return this.Json(productItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }


//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Create(NewsModel model, [DataSourceRequest] DataSourceRequest request)
//        {
//            //Classa, ktera vyhazuje Exception
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var news = this.NewsRepository.Create();


//                NewsModel.ToData(news, model);
//                news.Urlid = this.UrlIdService.GetUrlId(news.Name, this.NewsRepository.GetQueryable().Select(s => s.Urlid).ToList());
//                this.NewsRepository.Insert(news);

//                this.UnityOfWork.Save();

//                model.Id = news.Id;
//            }


//            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Update([DataSourceRequest] DataSourceRequest request, NewsModel model)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var product = this.NewsRepository.GetById(model.Id);

//                if (product == null)
//                {
//                    throw new Exception("Aktualita nenalezena.");
//                }

//                NewsModel.ToData(product, model);

//                this.NewsRepository.Update(product);

//                this.UnityOfWork.Save();
//            }

//            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, NewsModel model)
//        {
//            Contract.Requires(model != null);

//            var product = this.NewsRepository.GetQueryable().SingleOrDefault(s => s.Id == model.Id);
//            if (product == null)
//            {
//                throw new NullReferenceException("Aktualita nenalezena.");
//            }

//            this.NewsRepository.Delete(product);

//            this.UnityOfWork.Save();

//            return this.JsonNet(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }
//    }
//}