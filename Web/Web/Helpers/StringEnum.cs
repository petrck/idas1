// <copyright file="StringEnum.cs" company="Erzasoft s.r.o.">
// Copyright (c) Erzasoft s.r.o.. All rights reserved.
// </copyright>

namespace Erzasoft.Eshop.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class StringEnum
    {
        public static string EnumToString(this Enum value)
        {
            var indexOfItem = Array.IndexOf(Enum.GetValues(value.GetType()), value);
            return EnumHelper.GetSelectList(value.GetType())[indexOfItem].Text;
        }

        public static IEnumerable<SelectListItem> GetBindData(Type enumType)
        {
            return (from object item in Enum.GetValues(enumType) let enumValue = Enum.GetName(enumType, item) let member = enumType.GetMember(enumValue)[0] let attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false) select new SelectListItem { Text = attrs.Length > 0 ? ((DisplayAttribute)attrs[0]).Name : enumValue, Value = ((int)item).ToString() }).ToList();
        }
    }
}