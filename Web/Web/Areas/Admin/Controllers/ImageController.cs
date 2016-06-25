//// --------------------------------------------------------------------------------------------------------------------
//// <copyright file="ImageController.cs" company="Erzasoft">
////   Copyright 2015 Erzasoft
//// </copyright>
//// <summary>
////   The image controller.
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------

//namespace Erzasoft.Web.Areas.Admin.Controllers
//{
//    using System;
//    using System.Web.Mvc;

//    using Erzasoft.Repository;
//    using Erzasoft.Service;
//    using Erzasoft.Service.Models;

//    using Kendo.Mvc.Extensions;
//    using Kendo.Mvc.UI;

//    /// <summary>
//    /// The image controller.
//    /// </summary>
//    public class ImageController : Controller
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="ImageController"/> class.
//        /// </summary>
//        /// <param name="unityOfWork">
//        /// The unity of work.
//        /// </param>
//        /// <param name="imageService">
//        /// The image service.
//        /// </param>
//        public ImageController(IUnityOfWork unityOfWork, IImageService imageService)
//        {
//            this.ImageService = imageService;
//            this.UnityOfWork = unityOfWork;
//        }

//        /// <summary>
//        /// Gets the unity of work.
//        /// </summary>
//        protected IUnityOfWork UnityOfWork { get; private set; }

//        /// <summary>
//        /// Gets the image service.
//        /// </summary>
//        protected IImageService ImageService { get; private set; }

//        /// <summary>
//        /// The delete image.
//        /// </summary>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <param name="model">
//        /// The model.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        [HttpPost]
//        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ImageModel model)
//        {
//            var image = this.ImageService.GetById(model.Id);
//            if (image == null)
//            {
//                throw new NullReferenceException("Obrázek nenalezen.");
//            }

//            this.ImageService.DeleteImage(image);

//            this.UnityOfWork.Save();

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }

//        /// <summary>
//        /// The update image.
//        /// </summary>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <param name="model">
//        /// The product image model.
//        /// </param>
//        /// <returns>
//        /// The <see cref="ActionResult"/>.
//        /// </returns>
//        [HttpPost]
//        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ImageModel model)
//        {
//            if (this.ModelState.IsValid)
//            {
//                var image = this.ImageService.GetById(model.Id);

//                image.Title = model.Title;

//                this.ImageService.Update(image);

//                this.UnityOfWork.Save();
//            }

//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }
//    }
//}