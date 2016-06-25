namespace Erzasoft.Service
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Web;
    using System.Web.Hosting;

    using Erzasoft.DataModel;
    using Erzasoft.DataModel.Semestralka;
    using Erzasoft.ImageProcessor;
    using Erzasoft.Repository;

    /// <summary>
    /// The image service.
    /// </summary>
    public class ImageService : Repository<Image>, IImageService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageService"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        /// <param name="imageProcessor">
        /// The image processor.
        /// </param>
        public ImageService(
            DbContext dbContext,
            IImageProcessor imageProcessor)
            : base(dbContext)
        {
            Contract.Requires(imageProcessor != null);

            this.ImageProcessor = imageProcessor;
        }

        /// <summary>
        /// Gets the image processor.
        /// </summary>
        protected IImageProcessor ImageProcessor { get; private set; }

        /// <summary>
        /// The save image.
        /// </summary>
        /// <param name="imageFile">
        /// The image file.
        /// </param>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public Image SaveImage(HttpPostedFileBase imageFile, string folder)
        {
            var image = this.Create();
            image.Title = Path.GetFileNameWithoutExtension(imageFile.FileName);
            image.Date = DateTime.Now;

            var bitmap = this.ImageProcessor.ReadBitmapFrame(imageFile.InputStream);
            image.Width = (int)bitmap.Width;
            image.Height = (int)bitmap.Height;

            imageFile.InputStream.Position = 0;

            var fileExtension = Path.GetExtension(imageFile.FileName);
            var fileName = string.Format(
                "{0}_{1}{2}",
                image.Date.ToString("yyyyMMddHHmmssfff"),
                Guid.NewGuid(),
                fileExtension);

            var imagePath = "~/Upload/" + folder + "/" + fileName;
            var imageMapedPath = HostingEnvironment.MapPath(imagePath);
            Directory.CreateDirectory(Path.GetDirectoryName(imageMapedPath));

            image.Source = imagePath;

            imageFile.InputStream.Position = 0;
            
            imageFile.SaveAs(imageMapedPath);            

            return image;
        }

        /// <summary>
        /// The delete image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        public void DeleteImage(Image image)
        {
            var serverFile = HostingEnvironment.MapPath(image.Source);
            if (File.Exists(serverFile))
            {
                File.Delete(serverFile);
            }

            this.Delete(image);
        }
    }
}
