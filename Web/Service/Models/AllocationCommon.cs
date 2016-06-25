// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllocationCommon.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// <summary>
//   Defines the AllocationCommon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Service.Models
{
    using System.ComponentModel.DataAnnotations;

    using Erzasoft.MvcUtility;
    using Erzasoft.Service.Resources;

    [MultiColumnForm]
    public class AllocationCommon
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Display(ResourceType = typeof(ModelResource), Name = "AllocationName")]
        [Required(ErrorMessageResourceType = typeof(ModelResource), ErrorMessageResourceName = "AllocationNameRequired")]
        [MultiColumnFormField(Position = 1)]
        public string Name { get; set; }

        //[UIHint("Color")]
        [Display(ResourceType = typeof(ModelResource), Name = "Color")]
        [ScaffoldColumn(false)]
        //[Required(ErrorMessageResourceType = typeof(ModelResource), ErrorMessageResourceName = "ColorRequired")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the parent id.
        /// </summary>
        [ScaffoldColumn(false)]
        public int? ParentId { get; set; }
    }
}
