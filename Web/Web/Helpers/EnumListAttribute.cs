// <copyright file="EnumListAttribute.cs" company="Erzasoft s.r.o.">
// Copyright (c) Erzasoft s.r.o.. All rights reserved.
// </copyright>

namespace Erzasoft.Web.Helpers
{
    using System.Web.Mvc;

    using Erzasoft.MvcUtility;

    public class EnumListAttribute : MultiColumnFormFieldAttribute
    {
        public const string DefaultValueKey = "__DefaultValue__";
        public const string Placeholderkey = "__Placeholder__";

        public string DefaultValue { get; set; }

        public string Placeholder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumListAttribute"/> class.
        /// </summary>
        public EnumListAttribute()
        {
            this.EditorTemplate = "EnumDropDown";
            this.DefaultValue = "Vyberte položku";
            this.Placeholder = "";
        }

        public override void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add(DefaultValueKey, this.DefaultValue);
            metadata.AdditionalValues.Add(Placeholderkey, this.Placeholder);

            base.OnMetadataCreated(metadata);
        }
    }
}