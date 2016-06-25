using Erzasoft.Service.Models;

namespace Erzasoft.Web.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The product image extension.
    /// </summary>
    public static class ImageExtension
    {
        /// <summary>
        /// The get image id.
        /// </summary>
        /// <param name="images">
        /// The images.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static ImageModel GetMainImage(this IEnumerable<ImageModel> images)
        {
            var image = new ImageModel { Id = 0, Height = 0, Width = 0 };

            if (images != null && images.Any(s => s != null))
            {
                var mainImage = images.FirstOrDefault(s => s != null && s.IsMain) ?? images.FirstOrDefault(s => s != null);

                if (mainImage != null)
                {
                    image = mainImage;
                }
            }

            return image;
        }

        //public static ImageModel GetMainImage(this IEnumerable<ImageModel> images)
        //{
        //    if (!images.Any())
        //    {
        //        var defaulImage = new ImageModel();
        //        defaulImage.Source = 
        //    }

        //    return images.FirstOrDefault(s => s.IsMain) ?? images.FirstOrDefault();
        //}

    }
}