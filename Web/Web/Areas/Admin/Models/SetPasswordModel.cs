// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetPasswordModel.cs" company="Erzasoft">
//   Copyright 2015 Erzasoft
// </copyright>
// <summary>
//   The change password model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The change password model.
    /// </summary>
    public class SetPasswordModel
    {
        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        //[Display(ResourceType = typeof(EshopResource), Name = "NewPassword")]
        //[DataType(DataType.Password)]        
        //[Required(ErrorMessageResourceType = typeof(EshopResource), ErrorMessageResourceName = "NewPasswordRequired")]
        //[UIHint("Password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        //[Display(ResourceType = typeof(EshopResource), Name = "ConfirmPassword")]
        //[DataType(DataType.Password)]
        //[Compare("NewPassword", ErrorMessageResourceType = typeof(EshopResource), ErrorMessageResourceName = "NewPasswordCompare")]
        //[Required(ErrorMessageResourceType = typeof(EshopResource), ErrorMessageResourceName = "ConfirmPasswordRequired")]
        //[UIHint("Password")]        
        public string ConfirmPassword { get; set; }
    }
}