namespace Erzasoft.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web;
    

    using Erzasoft.DataModel;
    using Erzasoft.DataModel.Semestralka;
    using Erzasoft.DependecyInterface;
    using Erzasoft.Repository;

    /// <summary>
    /// The ImageService interface.
    /// </summary>
    public interface IImageService : IRepository<Image>, IDependency
    {
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
        Image SaveImage(HttpPostedFileBase imageFile, string folder);

        /// <summary>
        /// The delete image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        void DeleteImage(Image image);
    }
}
