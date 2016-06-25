// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageModel.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// <summary>
//   The image.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Service.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Erzasoft.DataModel;
    using Erzasoft.DataModel.Semestralka;

    /// <summary>
    /// The image.
    /// </summary>
    public class ImageModel
    {
        /// <summary>
        /// Gets or sets the product image id.
        /// </summary>
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        [ScaffoldColumn(false)]
        public int? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the allocation id.
        /// </summary>
        [ScaffoldColumn(false)]
        public int? AllocationId { get; set; }

        /// <summary>
        /// Gets or sets the actuality id.
        /// </summary>
        [ScaffoldColumn(false)]
        public int? ActualityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is main.
        /// </summary>
        [ScaffoldColumn(false)]
        public bool IsMain { get; set; }

        // <summary>
        /// Gets or sets the source.
        /// </summary>
        [ScaffoldColumn(false)]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        //[Display(ResourceType = typeof(EshopResource), Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        [ScaffoldColumn(false)]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        [ScaffoldColumn(false)]
        public int Height { get; set; }

        /// <summary>
        /// The to model.
        /// </summary>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<Image, ImageModel>> ToModel()
        {
            Expression<Func<Image, ImageModel>> select =
                s =>
                new ImageModel
                {
                    Id = s.Id,
                    Title = s.Title
                };

            return select;
        }
    }
}