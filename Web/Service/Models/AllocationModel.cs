// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllocationModel.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// <summary>
//   The allocation model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Service.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Erzasoft.MvcUtility;
    using Erzasoft.Service.Resources;

    /// <summary>
    /// The allocation model.
    /// </summary>
    [MultiColumnForm]
    public class AllocationModel : AllocationCommon
    {
        ///// <summary>
        ///// Gets or sets the products.
        ///// </summary>
        //public IEnumerable<ProductModel> Products { get; set; }

        /// <summary>
        /// Gets or sets the descendants.
        /// </summary>
        public IEnumerable<AllocationModel> Descendants { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has descendants.
        /// </summary>
        [ScaffoldColumn(false)]
        public bool HasDescendants { get; set; }

        /// <summary>
        /// Gets or sets the url id.
        /// </summary>
        [ScaffoldColumn(false)]
        public string UrlId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary> 
        //[ScaffoldColumn(false)]       
        [MultiColumnFormField(Position = 3)]
        [Display(ResourceType = typeof(ModelResource), Name = "Order")]
        public int? Order { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [AllowHtml]
        [MultiColumnFormField(Position = 2)]
        [Display(ResourceType = typeof(ModelResource), Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the seo title.
        /// </summary>
        [Display(ResourceType = typeof(ModelResource), Name = "SeoDataTitle")]
        public string SeoTitle { get; set; }

        /// <summary>
        /// Gets or sets the seo keywords.
        /// </summary>
        [Display(ResourceType = typeof(ModelResource), Name = "SeoDataKeywords")]
        public string SeoKeywords { get; set; }

        /// <summary>
        /// Gets or sets the seo description.
        /// </summary>
        [Display(ResourceType = typeof(ModelResource), Name = "SeoDataDescription")]
        public string SeoDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether visible.
        /// </summary>
        [MultiColumnFormField(Position = 4)]
        [ScaffoldColumn(false)]
        [Display(ResourceType = typeof(ModelResource), Name = "IsVisible")]
        public bool Visible { get; set; }
    }
}