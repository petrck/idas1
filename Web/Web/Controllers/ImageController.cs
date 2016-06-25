// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageController.cs" company="Erzasoft">
//   Copyright 2015 Erzasoft
// </copyright>
// <summary>
//   The image controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Erzasoft.ConfigService;
    using Erzasoft.DataModel.Semestralka;
    using Erzasoft.ImageProcessor;
    using Erzasoft.Service;

    using Kendo.Mvc.Extensions;

    using Brushes = System.Windows.Media.Brushes;
    using Size = System.Windows.Size;

    /// <summary>
    /// The image controller.
    /// </summary>
    public class ImageController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageController"/> class.
        /// </summary>
        /// <param name="imageProcessor">
        /// The image processor.
        /// </param>
        /// <param name="imageService">
        /// The product Image Service.
        /// </param>
        /// <param name="configService">
        /// The config Service.
        /// </param>
        public ImageController(IImageProcessor imageProcessor, IImageService imageService, IConfigService configService)
        {
            this.ConfigService = configService;
            this.ImageService = imageService;
            this.ImageProcessor = imageProcessor;
            this.SystemName = this.ConfigService.GetItem("SystemName");
        }

        /// <summary>
        /// Gets the product image repository.
        /// </summary>
        protected IImageService ImageService { get; private set; }

        /// <summary>
        /// Gets the image processor.
        /// </summary>
        protected IImageProcessor ImageProcessor { get; private set; }

        /// <summary>
        /// Gets the config service.
        /// </summary>
        protected IConfigService ConfigService { get; private set; }

        /// <summary>
        /// Gets the system name.
        /// </summary>
        public string SystemName { get; private set; }

        /// <summary>
        /// The product image.
        /// </summary>
        /// <param name="imageId">
        /// The image Id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(CacheProfile = "Images")]
        public ActionResult Product(int? imageId)
        {
            var watermark = new TextImageWatermark
            {
                Text = this.SystemName,
                WatermarkPosition = ImageWatermarkPosition.LeftTop,
                TextSize = 15,
                Brush = new SolidColorBrush(Colors.Green) { Opacity = 0.2 },
                OffsetX = 70,
                OffsetY = 125
            };

            //var imageWatermark = new GraphicsImageWatermark
            //{
            //    Image =
            //        new BitmapImage(
            //        new Uri(
            //        HostingEnvironment.MapPath(
            //            "~/Images/Watermark_logo.png"))),
            //    ImagePosition = new Point(59, 108),
            //    ImageSize = new Size(48, 48)
            //};

            return this.GetImage(imageId, 270, 270, ImageResizeMode.KeepAspectRatio, new IImageWatermark[] { watermark });
        }

        /// <summary>
        /// The product advanced.
        /// </summary>
        /// <param name="imageId">
        /// The image id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(CacheProfile = "Images")]
        public ActionResult ProductAdvanced(int? imageId)
        {
            var watermark = new TextImageWatermark
            {
                Text = this.SystemName,
                WatermarkPosition = ImageWatermarkPosition.LeftTop,
                TextSize = 1,
                Brush = new SolidColorBrush(Colors.Green) { Opacity = 0.2 },
                OffsetX = 109,
                OffsetY = 125
            };

            //var imageWatermark = new GraphicsImageWatermark
            //{
            //    Image =
            //        new BitmapImage(
            //        new Uri(
            //        HostingEnvironment.MapPath(
            //            "~/Images/Watermark_logo.png"))),
            //    ImagePosition = new Point(59, 108),
            //    ImageSize = new Size(48, 48)
            //};

            return this.GetImage(imageId, 140, 140, ImageResizeMode.KeepAspectRatio, new IImageWatermark[] { watermark });
        }

        /// <summary>
        /// The cart image.
        /// </summary>
        /// <param name="imageId">
        /// The image id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(CacheProfile = "Images")]
        public ActionResult Cart(int? imageId)
        {
            var watermark = new TextImageWatermark
            {
                Text = this.SystemName,
                WatermarkPosition = ImageWatermarkPosition.LeftTop,
                TextSize = 8,
                Brush = new SolidColorBrush(Colors.Green) { Opacity = 0.2 },
                OffsetX = 5,
                OffsetY = 27
            };

            return this.GetImage(imageId, 200, 200, ImageResizeMode.KeepAspectRatio, new IImageWatermark[] { watermark });
        }

        /// <summary>
        /// The product image.
        /// </summary>
        /// <param name="imageId">
        /// The image Id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(CacheProfile = "Images")]
        public ActionResult ProductDetail(int? imageId)
        {
            var watermark = new TextImageWatermark
            {
                Text = this.SystemName,
                WatermarkPosition = ImageWatermarkPosition.LeftTop,
                TextSize = 20,
                Brush = new SolidColorBrush(Colors.Green) { Opacity = 0.2 },
                OffsetX = 110,
                OffsetY = 137
            };

            //var imageWatermark = new GraphicsImageWatermark
            //{
            //    Image =
            //        new BitmapImage(
            //        new Uri(
            //        HostingEnvironment.MapPath(
            //            "~/Images/Watermark_logo.png"))),
            //    ImagePosition = new Point(59, 123),
            //    ImageSize = new Size(48, 48)
            //};

            return this.GetImage(imageId, 392, 392, ImageResizeMode.KeepAspectRatio, new IImageWatermark[] { watermark });
        }

        /// <summary>
        /// The photo big.
        /// </summary>
        /// <param name="imageId">
        /// The image Id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(CacheProfile = "Images")]
        public ActionResult ProductDetailZoom(int? imageId)
        {
            var watermark = new TextImageWatermark
            {
                Text = this.SystemName,
                WatermarkPosition = ImageWatermarkPosition.LeftTop,
                TextSize = 30,
                Brush = new SolidColorBrush(Colors.Green) { Opacity = 0.1 },
                OffsetX = 320,
                OffsetY = 385
            };

            //var imageWatermark = new GraphicsImageWatermark
            //{
            //    Image =
            //        new BitmapImage(
            //        new Uri(
            //        HostingEnvironment.MapPath(
            //            "~/Images/Watermark_logo.png"))),
            //    ImagePosition = new Point(270, 377),
            //    ImageSize = new Size(48, 48)
            //};

            return this.GetImage(imageId, 800, 600, ImageResizeMode.KeepAspectRatio, new IImageWatermark[] { watermark });
        }

        /// <summary>
        /// The comparer.
        /// </summary>
        /// <param name="imageId">
        /// The image id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(CacheProfile = "Images")]
        public ActionResult Comparer(int? imageId)
        {
            var watermark = new TextImageWatermark
            {
                Text = this.SystemName,
                WatermarkPosition = ImageWatermarkPosition.LeftTop,
                TextSize = 50,
                Brush = new SolidColorBrush(Colors.Green) { Opacity = 0.1 },
                OffsetX = 174,
                OffsetY = 300
            };

            var imageWatermark = new GraphicsImageWatermark
            {
                Image =
                    new BitmapImage(
                    new Uri(
                    HostingEnvironment.MapPath(
                        "~/Images/Watermark_logo.png"))),
                ImagePosition = new Point(59, 98),
                ImageSize = new Size(48, 48)
            };

            return this.GetImage(imageId, 298, 231, ImageResizeMode.KeepAspectRatio, new IImageWatermark[] { watermark, imageWatermark });
        }

        /// <summary>
        /// The get image.
        /// </summary>
        /// <param name="imageId">
        /// The image id.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="imageResizeMode">
        /// The image resize mode.
        /// </param>
        /// <param name="watermarks">
        /// The watermarks.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        private ActionResult GetImage(int? imageId, int? width, int? height, ImageResizeMode imageResizeMode, IEnumerable<IImageWatermark> watermarks)
        {
            Image image = null;
            if (imageId.HasValue)
            {
                image = this.ImageService.GetQueryable().SingleOrDefault(a => a.Id == imageId);
            }

            var settings = new ImageProcessorSetting
            {
                ImageResizeMode = imageResizeMode,
                FeelBackground = true,
                BackgrounBrush = Brushes.White
            };

            settings.Watermarks.AddRange(watermarks);

            var imageWidth = width.HasValue ? (double)width : double.MaxValue;
            var imageHeight = height.HasValue ? (double)height : double.MaxValue;

            var mapedImageFile = this.Server.MapPath("~/Images/no-image.jpg");

            if (image != null && System.IO.File.Exists(HostingEnvironment.MapPath(image.Source)))
            {
                mapedImageFile = this.Server.MapPath(image.Source);

                var originalSize = new Size(image.Width, image.Height);
                var targetSize = new Size(imageWidth, imageHeight);

                var imageSize = width.HasValue && height.HasValue ? new Size(imageWidth, imageHeight) : this.ImageProcessor.ComputeImageAspectSize(originalSize, targetSize);

                return this.File(this.ImageProcessor.ProcesImage(mapedImageFile, imageSize, settings), "image/jpeg");
            }

            var size = width.HasValue ? new Size(imageWidth, imageWidth) : new Size(imageHeight, imageHeight);

            return this.File(this.ImageProcessor.ProcesImage(mapedImageFile, size, settings), "image/jpeg");
        }
    }
}