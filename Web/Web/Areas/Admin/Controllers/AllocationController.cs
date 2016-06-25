//// --------------------------------------------------------------------------------------------------------------------
//// <copyright file="AllocationController.cs" company="Erzasoft">
////   Copyright 2015 Erzasoft
//// </copyright>
//// <summary>
////   Defines the InclusionController type.
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------

//namespace Erzasoft.Web.Areas.Admin.Controllers
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data.Entity;
//    using System.Diagnostics.Contracts;
//    using System.Linq;
//    using System.Web;
//    using System.Web.Mvc;

//    using Erzasoft.DataModel;
//    using Erzasoft.MvcUtility;
//    using Erzasoft.Repository;
//    using Erzasoft.Service;
//    using Erzasoft.Service.Models;

//    using Kendo.Mvc.Extensions;
//    using Kendo.Mvc.UI;

//    //using ProductModel = Erzasoft.Web.Areas.Admin.Models.ProductModel;

//    /// <summary>
//    /// The inclusion controller.
//    /// </summary>
//    [Authorize]
//    public class AllocationController : Controller
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AllocationController"/> class.
//        /// </summary>
//        /// <param name="unityOfWork">
//        /// The unity of work.
//        /// </param>
//        /// <param name="urlIdGeneratorService">
//        /// The url id generator service.
//        /// </param>
//        /// <param name="seoUrlGenerator">
//        /// The seo url generator.
//        /// </param>
//        /// <param name="seoDataService">
//        /// The seo data service.
//        /// </param>
//        /// <param name="productService">
//        /// The product service.
//        /// </param>
//        /// <param name="allocationService">
//        /// The allocation service.
//        /// </param>
//        /// <param name="imageService">
//        /// The image Service.
//        /// </param>
//        public AllocationController(
//            IUnityOfWork unityOfWork,
//            IUrlGeneratorService urlIdGeneratorService,
//            ISeoUrlGenerator seoUrlGenerator,
//            ISeoDataService seoDataService,
//            //IProductService productService,
//            IAllocationService allocationService,
//            IImageService imageService)
//        {
//            this.ImageService = imageService;
//            Contract.Requires(allocationService != null);
//           // Contract.Requires(productService != null);
//            Contract.Requires(seoDataService != null);
//            Contract.Requires(seoUrlGenerator != null);
//            Contract.Requires(urlIdGeneratorService != null);
//            Contract.Requires(unityOfWork != null);

//            this.AllocationService = allocationService;
//           // this.ProductService = productService;
//            this.SeoDataService = seoDataService;
//            this.SeoUrlGenerator = seoUrlGenerator;
//            this.UrlGeneratorService = urlIdGeneratorService;
//            this.UnityOfWork = unityOfWork;
//        }

//        /// <summary>
//        /// Gets the product service.
//        /// </summary>
//        //protected IProductService ProductService { get; private set; }

//        /// <summary>
//        /// Gets the unity of work.
//        /// </summary>
//        protected IUnityOfWork UnityOfWork { get; private set; }

//        /// <summary>
//        /// Gets the url generator service.
//        /// </summary>
//        protected IUrlGeneratorService UrlGeneratorService { get; private set; }

//        /// <summary>
//        /// Gets the seo url generator.
//        /// </summary>
//        protected ISeoUrlGenerator SeoUrlGenerator { get; private set; }

//        /// <summary>
//        /// Gets the seo data service.
//        /// </summary>
//        protected ISeoDataService SeoDataService { get; private set; }

//        /// <summary>
//        /// Gets the allocation service.
//        /// </summary>
//        protected IAllocationService AllocationService { get; private set; }

//        /// <summary>
//        /// Gets the image service.
//        /// </summary>
//        protected IImageService ImageService { get; private set; }

//        /// <summary>
//        /// The index.
//        /// </summary>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult Index()
//        {
//            return this.View();
//        }

  
//        public ActionResult GetCategories([DataSourceRequest] DataSourceRequest request, AllocationTypeEnum allocationType)
//        {
//            var categories = this.AllocationService.GetQueryable().Where(s => !s.ParentId.HasValue && s.AllocationType == allocationType).Select(j =>
//                new AllocationModel
//                {
//                    Id = j.Id,
//                    Name = j.Name,
//                    Description = j.Description,
//                    SeoTitle = j.SeoData.Title,
//                    SeoDescription = j.SeoData.Description,
//                    SeoKeywords = j.SeoData.Keywords,
//                    Visible = j.Visible,
//                    Order = j.Order,
//                    Color = j.Color
//                });

//            return this.Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }

//        /// <summary>
//        /// The get category products.
//        /// </summary>
//        /// <param name="aaacategoryId">
//        /// The aaacategory id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult GetCategoryProducts(int aaacategoryId, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    var products = this.ProductService.GetQueryable().Where(s => s.Allocations.Any(t => t.Id == aaacategoryId)).Select(j =>
//        //        new ProductModel
//        //        {
//        //            Id = j.Id,
//        //            Name = j.Name
//        //        });

//        //    return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        //}

//        /// <summary>
//        /// The get all category products.
//        /// </summary>
//        /// <param name="categoryId">
//        /// The category id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult GetAllCategoryProducts(int categoryId, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    var products = this.ProductService.GetQueryable().Select(ProductModel.ToAllocationModel(categoryId));

//        //    return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        //}

//        /// <summary>
//        /// The get groups.
//        /// </summary>
//        /// <param name="aaacategoryId">
//        /// The aaacategory id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult GetGroups(int aaacategoryId, [DataSourceRequest] DataSourceRequest request)
//        {
//            var groups = this.AllocationService.GetQueryable().Where(s => s.ParentId == aaacategoryId).Select(j =>
//                new AllocationModel
//                {
//                    Id = j.Id,
//                    Name = j.Name,
//                    Description = j.Description,
//                    SeoTitle = j.SeoData.Title,
//                    SeoDescription = j.SeoData.Description,
//                    SeoKeywords = j.SeoData.Keywords,
//                    ParentId = j.ParentId.Value,
//                    Visible = j.Visible,
//                    Order = j.Order,
//                    Color = j.Color,
//                    HasDescendants = j.Descendants.Any()
//                });

//            return this.Json(groups.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }

//        /// <summary>
//        /// The get all group products.
//        /// </summary>
//        /// <param name="groupId">
//        /// The group id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult GetAllGroupProducts(int groupId, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    var products = this.ProductService.GetQueryable().Select(ProductModel.ToAllocationModel(groupId));

//        //    return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        //}

//        /// <summary>
//        /// The get group products.
//        /// </summary>
//        /// <param name="aaagroupId">
//        /// The aaagroup id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult GetGroupProducts(int aaagroupId, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    var products = this.ProductService.GetQueryable().Where(s => s.Allocations.Any(t => t.Id == aaagroupId)).Select(j =>
//        //        new ProductModel
//        //        {
//        //            Id = j.Id,
//        //            Name = j.Name
//        //        });

//        //    return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        //}

//        /// <summary>
//        /// The get sub groups.
//        /// </summary>
//        /// <param name="aaagroupId">
//        /// The aaagroup id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult GetSubGroups(int aaagroupId, [DataSourceRequest] DataSourceRequest request)
//        {
//            var subGroups = this.AllocationService.GetQueryable().Where(s => s.ParentId == aaagroupId).Select(j =>
//                new AllocationModel
//                {
//                    Id = j.Id,
//                    Name = j.Name,
//                    Description = j.Description,
//                    SeoTitle = j.SeoData.Title,
//                    SeoDescription = j.SeoData.Description,
//                    SeoKeywords = j.SeoData.Keywords,
//                    Visible = j.Visible,
//                    Order = j.Order,
//                    Color = j.Color
//                });

//            return this.Json(subGroups.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }

//        /// <summary>
//        /// The get all sub group products.
//        /// </summary>
//        /// <param name="subGroupId">
//        /// The sub group id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult GetAllSubGroupProducts(int subGroupId, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    var products = this.ProductService.GetQueryable().Select(ProductModel.ToAllocationModel(subGroupId));

//        //    return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        //}

//        /// <summary>
//        /// The get sub group products.
//        /// </summary>
//        /// <param name="aaasubGroupId">
//        /// The aaasub group id.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult GetSubGroupProducts(int aaasubGroupId, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    var products = this.ProductService.GetQueryable().Where(s => s.Allocations.Any(t => t.Id == aaasubGroupId)).Select(ProductModel.ToAllocationModel(aaasubGroupId));

//        //    return this.Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        //}

//        ///// <summary>
//        ///// The create division.
//        ///// </summary>
//        ///// <param name="model">
//        ///// The model.
//        ///// </param>
//        ///// <param name="request">
//        ///// The request.
//        ///// </param>
//        ///// <returns>
//        ///// The <see cref="ActionResult"/>.
//        ///// </returns>
//        //public ActionResult CreateDivision(AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    Contract.Requires(model != null);

//        //    if (this.ModelState.IsValid)
//        //    {
//        //        var division = this.AllocationService.Create();

//        //        division.SeoData = this.SeoDataService.Create();
//        //        //division.Visible = true;

//        //        this.SetAllocationData(division, model);

//        //        this.AllocationService.Insert(division);

//        //        this.UnityOfWork.Save();

//        //        model.Id = division.Id;
//        //    }

//        //    return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
//        //}

//        ///// <summary>
//        ///// The create category.
//        ///// </summary>
//        ///// <param name="aaadivisionId">
//        ///// The aaadivision id.
//        ///// </param>
//        ///// <param name="model">
//        ///// The model.
//        ///// </param>
//        ///// <param name="request">
//        ///// The request.
//        ///// </param>
//        ///// <returns>
//        ///// The <see cref="ActionResult"/>.
//        ///// </returns>
//        //public ActionResult CreateCategory(int aaadivisionId, AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    Contract.Requires(model != null);

//        //    if (this.ModelState.IsValid)
//        //    {
//        //        var category = this.AllocationService.Create();

//        //        category.SeoData = this.SeoDataService.Create();
//        //        category.ParentId = aaadivisionId;
//        //        category.Visible = true;

//        //        this.SetAllocationData(category, model);

//        //        this.AllocationService.Insert(category);

//        //        this.UnityOfWork.Save();

//        //        model.Id = category.Id;
//        //    }

//        //    return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        //}

//        /// <summary>
//        /// The create category.
//        /// </summary>
//        /// <param name="aaadivisionId">
//        /// The aaadivision id.
//        /// </param>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult CreateCategory(AllocationModel model, [DataSourceRequest] DataSourceRequest request, AllocationTypeEnum allocationType)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var category = this.AllocationService.Create();

//                this.SetAllocationData(category, model);

//                category.AllocationType = allocationType;

//                this.AllocationService.Insert(category);

//                this.UnityOfWork.Save();

//                model.Id = category.Id;
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The create group.
//        /// </summary>
//        /// <param name="aaacategoryId">
//        /// The aaacategory id.
//        /// </param>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult CreateGroup(int aaacategoryId, AllocationModel model, [DataSourceRequest] DataSourceRequest request, AllocationTypeEnum allocationType)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var group = this.AllocationService.Create();

//                group.SeoData = this.SeoDataService.Create();
//                group.ParentId = aaacategoryId;
//                group.AllocationType = allocationType;

//                this.SetAllocationData(group, model);

//                this.AllocationService.Insert(group);

//                this.UnityOfWork.Save();

//                model.Id = group.Id;
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The display allocation.
//        /// </summary>
//        /// <param name="aaaallocationId">
//        /// The aaaallocation id.
//        /// </param>
//        /// <param name="visible">
//        /// The visible.
//        /// </param>
//        /// <returns>
//        /// The <see cref="JsonResult"/>.
//        /// </returns>
//        public JsonResult DisplayAllocation(int aaaallocationId, bool visible)
//        {
//            var allocation = this.AllocationService.GetById(aaaallocationId);
//            if (allocation == null)
//            {
//                throw new NullReferenceException("Allocation nenalezeno.");
//            }

//            allocation.Visible = visible;

//            this.AllocationService.Update(allocation);

//            this.UnityOfWork.Save();

//            return this.Json(new { });
//        }

//        /// <summary>
//        /// The add category product.
//        /// </summary>
//        /// <param name="categoryId">
//        /// The category id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        [HttpGet]
//        public ActionResult AddCategoryProduct(int categoryId)
//        {
//            var category = this.AllocationService.GetById(categoryId);
//            if (category == null)
//            {
//                throw new NullReferenceException("Kategorie nenalezena.");
//            }

//            this.ViewData["category"] = category;

//            return this.View();
//        }

//        /// <summary>
//        /// The add category product.
//        /// </summary>
//        /// <param name="categoryId">
//        /// The category id.
//        /// </param>
//        /// <param name="productId">
//        /// The product id.
//        /// </param>
//        /// <param name="isSet">
//        /// The is set.
//        /// </param>
//        /// <returns>
//        /// The <see cref="JsonResult"/>.
//        /// </returns>
//        //[HttpPost]
//        //public JsonResult AddCategoryProduct(int categoryId, int productId, bool isSet)
//        //{
//        //    var category = this.AllocationService.GetQueryable().Include(s => s.Products).SingleOrDefault(s => s.Id == categoryId);
//        //    if (category == null)
//        //    {
//        //        throw new NullReferenceException("Kategorie nenalezena.");
//        //    }

//        //    var product = this.ProductService.GetById(productId);
//        //    if (product == null)
//        //    {
//        //        throw new NullReferenceException("Produkt nenalezena.");
//        //    }

//        //    var change = false;
//        //    if (isSet)
//        //    {
//        //        if (!category.Products.Contains(product))
//        //        {
//        //            category.Products.Add(product);
//        //            change = true;
//        //        }
//        //    }
//        //    else
//        //    {
//        //        if (category.Products.Contains(product))
//        //        {
//        //            category.Products.Remove(product);
//        //            change = true;
//        //        }
//        //    }

//        //    if (change)
//        //    {
//        //        this.AllocationService.Update(category);

//        //        this.UnityOfWork.Save();
//        //    }

//        //    return this.Json(new { success = true, message = "Produkt byl přidán do kategorie." });
//        //}

//        /// <summary>
//        /// The add group product.
//        /// </summary>
//        /// <param name="groupId">
//        /// The group id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        [HttpGet]
//        public ActionResult AddGroupProduct(int groupId)
//        {
//            var group = this.AllocationService.GetById(groupId);
//            if (group == null)
//            {
//                throw new NullReferenceException("Skupina nenalezena.");
//            }

//            this.ViewData["group"] = group;

//            return this.View();
//        }

//        /// <summary>
//        /// The add group product.
//        /// </summary>
//        /// <param name="groupId">
//        /// The group id.
//        /// </param>
//        /// <param name="productId">
//        /// The product id.
//        /// </param>
//        /// <param name="isSet">
//        /// The is set.
//        /// </param>
//        /// <returns>
//        /// The <see cref="JsonResult"/>.
//        /// </returns>
//        //[HttpPost]
//        //public JsonResult AddGroupProduct(int groupId, int productId, bool isSet)
//        //{
//        //    var group = this.AllocationService.GetQueryable().Include(s => s.Products).SingleOrDefault(s => s.Id == groupId);
//        //    if (group == null)
//        //    {
//        //        throw new NullReferenceException("Skupina nenalezena.");
//        //    }

//        //    var product = this.ProductService.GetById(productId);
//        //    if (product == null)
//        //    {
//        //        throw new NullReferenceException("Produkt nenalezena.");
//        //    }

//        //    var change = false;
//        //    if (isSet)
//        //    {
//        //        if (!group.Products.Contains(product))
//        //        {
//        //            group.Products.Add(product);
//        //            change = true;
//        //        }
//        //    }
//        //    else
//        //    {
//        //        if (group.Products.Contains(product))
//        //        {
//        //            group.Products.Remove(product);
//        //            change = true;
//        //        }
//        //    }

//        //    if (change)
//        //    {
//        //        this.AllocationService.Update(group);

//        //        this.UnityOfWork.Save();
//        //    }

//        //    return this.Json(new { success = true, message = "Produkt byl přidán do skupiny." });
//        //}

//        /// <summary>
//        /// The create sub group.
//        /// </summary>
//        /// <param name="aaagroupId">
//        /// The aaagroup id.
//        /// </param>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult CreateSubGroup(int aaagroupId, AllocationModel model, [DataSourceRequest] DataSourceRequest request, AllocationTypeEnum allocationType)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var subGroup = this.AllocationService.Create();

//                subGroup.SeoData = this.SeoDataService.Create();
//                subGroup.ParentId = aaagroupId;
//                subGroup.AllocationType = allocationType;

//                this.SetAllocationData(subGroup, model);

//                this.AllocationService.Insert(subGroup);

//                this.UnityOfWork.Save();

//                model.Id = subGroup.Id;
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The add sub group product.
//        /// </summary>
//        /// <param name="subGroupId">
//        /// The sub group id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //[HttpGet]
//        //public ActionResult AddSubGroupProduct(int subGroupId)
//        //{
//        //    var subGroup = this.AllocationService.GetById(subGroupId);
//        //    if (subGroup == null)
//        //    {
//        //        throw new NullReferenceException("Podskupina nenalezena.");
//        //    }

//        //    this.ViewData["subGroup"] = subGroup;

//        //    return this.View();
//        //}

//        /// <summary>
//        /// The add sub group product.
//        /// </summary>
//        /// <param name="subGroupId">
//        /// The sub group id.
//        /// </param>
//        /// <param name="productId">
//        /// The product id.
//        /// </param>
//        /// <param name="isSet">
//        /// The is set.
//        /// </param>
//        /// <returns>
//        /// The <see cref="JsonResult"/>.
//        /// </returns>
//        //[HttpPost]
//        //public JsonResult AddSubGroupProduct(int subGroupId, int productId, bool isSet)
//        //{
//        //    var subGroup = this.AllocationService.GetQueryable().Include(s => s.Products).SingleOrDefault(s => s.Id == subGroupId);
//        //    if (subGroup == null)
//        //    {
//        //        throw new NullReferenceException("Podskupina nenalezena.");
//        //    }

//        //    var product = this.ProductService.GetById(productId);
//        //    if (product == null)
//        //    {
//        //        throw new NullReferenceException("Produkt nenalezena.");
//        //    }

//        //    var change = false;
//        //    if (isSet)
//        //    {
//        //        if (!subGroup.Products.Contains(product))
//        //        {
//        //            subGroup.Products.Add(product);
//        //            change = true;
//        //        }
//        //    }
//        //    else
//        //    {
//        //        if (subGroup.Products.Contains(product))
//        //        {
//        //            subGroup.Products.Remove(product);
//        //            change = true;
//        //        }
//        //    }

//        //    if (change)
//        //    {
//        //        this.AllocationService.Update(subGroup);

//        //        this.UnityOfWork.Save();
//        //    }

//        //    return this.Json(new { success = true, message = "Produkt byl přidán do podskupiny." });
//        //}

//        /// <summary>
//        /// The update division.
//        /// </summary>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult UpdateDivision(AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var division = this.AllocationService.GetQueryable().Include(s => s.SeoData).SingleOrDefault(s => s.Id == model.Id);
//                if (division == null)
//                {
//                    throw new NullReferenceException("Rozdělení nenalezeno.");
//                }

//                this.SetAllocationData(division, model);

//                this.AllocationService.Update(division);

//                this.UnityOfWork.Save();
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The update category.
//        /// </summary>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult UpdateCategory(AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var category = this.AllocationService.GetQueryable().Include(s => s.SeoData).SingleOrDefault(s => s.Id == model.Id);
//                if (category == null)
//                {
//                    throw new NullReferenceException("Kategorie nenalezeno.");
//                }

//                this.SetAllocationData(category, model);

//                this.AllocationService.Update(category);

//                this.UnityOfWork.Save();
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The update group.
//        /// </summary>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult UpdateGroup(AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var group = this.AllocationService.GetQueryable().Include(s => s.SeoData).SingleOrDefault(s => s.Id == model.Id);
//                if (group == null)
//                {
//                    throw new NullReferenceException("Skupina nenalezeno.");
//                }

//                this.SetAllocationData(group, model);

//                this.AllocationService.Update(group);

//                this.UnityOfWork.Save();
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The update sub group.
//        /// </summary>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult UpdateSubGroup(AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        {
//            Contract.Requires(model != null);

//            if (this.ModelState.IsValid)
//            {
//                var subGroup = this.AllocationService.GetQueryable().Include(s => s.SeoData).SingleOrDefault(s => s.Id == model.Id);
//                if (subGroup == null)
//                {
//                    throw new NullReferenceException("Podskupina nenalezeno.");
//                }

//                this.SetAllocationData(subGroup, model);

//                this.AllocationService.Update(subGroup);

//                this.UnityOfWork.Save();
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The delete division.
//        /// </summary>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult DeleteDivision(AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        //{
//        //    Contract.Requires(model != null);

//        //    var division = this.AllocationService.GetQueryable()
//        //        //.Include(s => s.Products)
//        //        .Include(s => s.Descendants)
//        //       // .Include(s => s.Descendants.Select(t => t.Products))
//        //        .Include(s => s.Descendants.Select(t => t.Descendants))
//        //       // .Include(s => s.Descendants.Select(t => t.Descendants.Select(u => u.Products)))
//        //        .Include(s => s.Descendants.Select(t => t.Descendants.Select(u => u.Descendants)))
//        //        .Include(s => s.Descendants.Select(t => t.Descendants.Select(u => u.Descendants.Select(p => p.Products))))
//        //        .SingleOrDefault(s => s.Id == model.Id);
//        //    if (division == null)
//        //    {
//        //        throw new NullReferenceException("Rozdělení nenalezeno.");
//        //    }

//        //    //if (division.Products.Any())
//        //    //{
//        //    //    division.Products.Clear();

//        //        if (division.Descendants.Any())
//        //        {
//        //            foreach (var category in division.Descendants.ToList())
//        //            {
//        //                //if (category.Products.Any())
//        //                //{
//        //                //    category.Products.Clear();

//        //                    if (category.Descendants.Any())
//        //                    {
//        //                        foreach (var group in category.Descendants.ToList())
//        //                        {
//        //                            //if (group.Products.Any())
//        //                            //{
//        //                            //    group.Products.Clear();

//        //                                if (group.Descendants.Any())
//        //                                {
//        //                                    foreach (var subGroup in group.Descendants.ToList())
//        //                                    {
//        //                                        //if (subGroup.Products.Any())
//        //                                        //{
//        //                                        //    subGroup.Products.Clear();
//        //                                        //}

//        //                                        this.AllocationService.Delete(subGroup);
//        //                                    }
//        //                                }
//        //                            }

//        //                            this.AllocationService.Delete(group);
//        //                        }
//        //                    }
//        //                }

//        //                this.AllocationService.Delete(category);
                    
                
            

//        //    this.AllocationService.Delete(division);

//        //    this.UnityOfWork.Save();

//        //    return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        //}

//        /// <summary>
//        /// The delete category.
//        /// </summary>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult Delete(AllocationModel model, [DataSourceRequest] DataSourceRequest request)
//        {
//            Contract.Requires(model != null);

//            var allocation = this.AllocationService.GetQueryable()
//               // .Include(s => s.Products)
//                .Include(s => s.Images)
//                .Include(s => s.SeoData)
//                .SingleOrDefault(s => s.Id == model.Id);
//            if (allocation == null)
//            {
//                throw new NullReferenceException("Kategorie nenalezena.");
//            }

//            this.DeleteRecursive(allocation);

//            this.UnityOfWork.Save();

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The remove category product.
//        /// </summary>
//        /// <param name="categoryId">
//        /// The category id.
//        /// </param>
//        /// <param name="productId">
//        /// The product id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult RemoveCategoryProduct(int categoryId, int productId)
//        //{
//        //    Contract.Requires(categoryId != 0);
//        //    Contract.Requires(productId != 0);

//        //    var text = string.Empty;
//        //    bool status;

//        //    var category = this.AllocationService.GetQueryable().Include(s => s.Products).SingleOrDefault(s => s.Id == categoryId);
//        //    if (category == null)
//        //    {
//        //        status = false;
//        //        text = "Kategorie nenalezeno.";
//        //    }
//        //    else
//        //    {
//        //        var product = category.Products.SingleOrDefault(s => s.Id == productId);
//        //        if (product == null)
//        //        {
//        //            status = false;
//        //            text = "Produkt v kategorii nenalezen.";
//        //        }
//        //        else
//        //        {
//        //            category.Products.Remove(product);

//        //            this.AllocationService.Update(category);

//        //            this.UnityOfWork.Save();

//        //            text = "Produkt byl z odebrán z kategorie.";
//        //            status = true;
//        //        }
//        //    }

//        //    return this.Json(new { success = status, message = text });
//        //}

//        /// <summary>
//        /// The remove group product.
//        /// </summary>
//        /// <param name="groupId">
//        /// The group id.
//        /// </param>
//        /// <param name="productId">
//        /// The product id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult RemoveGroupProduct(int groupId, int productId)
//        //{
//        //    Contract.Requires(groupId != 0);
//        //    Contract.Requires(productId != 0);

//        //    var text = string.Empty;
//        //    bool status;

//        //    var group = this.AllocationService.GetQueryable().Include(s => s.Products).SingleOrDefault(s => s.Id == groupId);
//        //    if (group == null)
//        //    {
//        //        status = false;
//        //        text = "Skupina nenalezeno.";
//        //    }
//        //    else
//        //    {
//        //        var product = group.Products.SingleOrDefault(s => s.Id == productId);
//        //        if (product == null)
//        //        {
//        //            status = false;
//        //            text = "Produkt ve skupině nenalezen.";
//        //        }
//        //        else
//        //        {
//        //            group.Products.Remove(product);

//        //            this.AllocationService.Update(group);

//        //            this.UnityOfWork.Save();

//        //            text = "Produkt byl z odebrán ze skupiny.";
//        //            status = true;
//        //        }
//        //    }

//        //    return this.Json(new { success = status, message = text });
//        //}

//        /// <summary>
//        /// The remove sub group product.
//        /// </summary>
//        /// <param name="subGroupId">
//        /// The sub group id.
//        /// </param>
//        /// <param name="productId">
//        /// The product id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        //public ActionResult RemoveSubGroupProduct(int subGroupId, int productId)
//        //{
//        //    Contract.Requires(subGroupId != 0);
//        //    Contract.Requires(productId != 0);

//        //    var text = string.Empty;
//        //    bool status;

//        //    var subGroup = this.AllocationService.GetQueryable().Include(s => s.Products).SingleOrDefault(s => s.Id == subGroupId);
//        //    if (subGroup == null)
//        //    {
//        //        status = false;
//        //        text = "Podskupina nenalezeno.";
//        //    }
//        //    else
//        //    {
//        //        var product = subGroup.Products.SingleOrDefault(s => s.Id == productId);
//        //        if (product == null)
//        //        {
//        //            status = false;
//        //            text = "Produkt v podskupině nenalezen.";
//        //        }
//        //        else
//        //        {
//        //            subGroup.Products.Remove(product);

//        //            this.AllocationService.Update(subGroup);

//        //            this.UnityOfWork.Save();

//        //            text = "Produkt byl z odebrán z podskupiny.";
//        //            status = true;
//        //        }
//        //    }

//        //    return this.Json(new { success = status, message = text });
//        //}

//        /// <summary>
//        /// The images.
//        /// </summary>
//        /// <param name="allocationId">
//        /// The product id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult Images(int allocationId)
//        {
//            var allocation = this.AllocationService.GetById(allocationId);

//            this.ViewData.Add("allocation", allocation);

//            return this.View();
//        }

//        /// <summary>
//        /// The get images.
//        /// </summary>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <param name="allocationId">
//        /// The product id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        public ActionResult GetImages([DataSourceRequest] DataSourceRequest request, int allocationId)
//        {
//            var images = this.ImageService.GetQueryable().Where(s => s.AllocationId == allocationId).Select(s => new
//                ImageModel
//            {
//                Height = s.Height,
//                Id = s.Id,
//                //ProductId = s.ProductId,
//                IsMain = s.IsMain,
//                Source = s.Source,
//                Title = s.Title,
//                Width = s.Width
//            });

//            return this.Json(images.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }

//        /// <summary>
//        /// The upload image.
//        /// </summary>
//        /// <param name="imagesUpload">
//        /// The images upload.
//        /// </param>
//        /// <param name="allocationId">
//        /// The product id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        [HttpPost]
//        public ActionResult UploadImage(IEnumerable<HttpPostedFileBase> imagesUpload, int allocationId)
//        {
//            var allocation = this.AllocationService.GetById(allocationId);
//            if (allocation == null)
//            {
//                throw new NullReferenceException("Kategorie nenalezen.");
//            }

//            if (imagesUpload != null)
//            {
//                foreach (var imageUpload in imagesUpload)
//                {
//                    var type = allocation.GetType();
//                    var folder = type.BaseType.Name;

//                    var image = this.ImageService.SaveImage(imageUpload, folder);

//                    image.AllocationId = allocationId;

//                    this.ImageService.Insert(image);
//                }
//            }

//            this.UnityOfWork.Save();

//            // Return an empty string to signify success
//            return this.Content(string.Empty);
//        }

//        /// <summary>
//        /// The set main image.
//        /// </summary>
//        /// <param name="imageId">
//        /// The image Id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        [HttpPost]
//        public ActionResult SetMainImage(int imageId)
//        {
//            this.AllocationService.SetAllocationMainImage(imageId);

//            this.UnityOfWork.Save();

//            return this.Json(string.Empty);
//        }

//        public ActionResult Gallery()
//        {
//            return this.View();
//        }

//        public ActionResult LunchMenu()
//        {
//            var currentDate = DateTime.Now;
//            var nextWeekDate = currentDate.AddDays(7);

//            if (!this.AllocationService.GetQueryable().Any(s => s.AllocationType == AllocationTypeEnum.LunchMenu && s.Date == currentDate))
//            {
//            }

//            if (!this.AllocationService.GetQueryable().Any(s => s.AllocationType == AllocationTypeEnum.LunchMenu && s.Date == nextWeekDate))
//            {
//            }

//            //var allocations = this.AllocationService.GetQueryable().Where(s => s.AllocationType == AllocationTypeEnum.LunchMenu).ToList();

//            return this.View();
//        }

//        //public ActionResult WeekMenu()
//        //{
//        //    return this.View();
//        //}

//        /// <summary>
//        /// The set allocation data.
//        /// </summary>
//        /// <param name="allocation">
//        /// The division.
//        /// </param>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        private void SetAllocationData(Allocation allocation, AllocationModel model)
//        {
//            if (allocation.Name != model.Name)
//            {
//                allocation.Name = model.Name;
//            }

//            if (allocation.Id == 0)
//            {
//                allocation.InsertDate = DateTime.Now;
//            }

//            if (string.IsNullOrEmpty(allocation.UrlId))
//            {
//                var name = this.SeoUrlGenerator.Convert(allocation.Name, 100);
//                allocation.UrlId = this.UrlGeneratorService.GenerateUniqueUrlId<Allocation>(name, art => art.UrlId);
//            }

//            allocation.Description = model.Description;
//            allocation.Order = model.Order;
//            allocation.Visible = model.Visible;
//            allocation.UpdateDate = DateTime.Now;
//            allocation.Color = model.Color;

//            if (allocation.SeoData == null)
//            {
//                allocation.SeoData = this.SeoDataService.Create();
//            }

//            if (string.IsNullOrEmpty(allocation.SeoData.Key))
//            {
//                allocation.SeoData.Key = Guid.NewGuid().ToString();
//            }

//            allocation.SeoData.Title = string.IsNullOrEmpty(allocation.SeoData.Title) ? model.Name : model.SeoTitle;

//            allocation.SeoData.Keywords = string.IsNullOrEmpty(allocation.SeoData.Keywords) ? model.Name : model.SeoKeywords;

//            allocation.SeoData.Description = string.IsNullOrEmpty(allocation.SeoData.Description) ? model.Name : model.SeoDescription;
//        }

//        private void DeleteRecursive(Allocation allocation)
//        {
//            //if (allocation.Products.Any())
//            //{
//            //    allocation.Products.Clear();
//            //}

//            if (allocation.Images.Any())
//            {
//                foreach (var image in allocation.Images.ToList())
//                {
//                    this.ImageService.DeleteImage(image);
//                }
//            }

//            if (allocation.SeoData != null)
//            {
//                this.SeoDataService.Delete(allocation.SeoData);
//            }

//            var descendants = this.AllocationService.GetQueryable()
//                .Where(a => a.ParentId == allocation.Id)
//                //.Include(s => s.Products)
//                .Include(s => s.Images)
//                .Include(s => s.SeoData)
//                .ToList();

//            foreach (var descendant in descendants)
//            {
//                this.DeleteRecursive(descendant);
//            }

//            this.AllocationService.Delete(allocation);
//        }
//    }
//}