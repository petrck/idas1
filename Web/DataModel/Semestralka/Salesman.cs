// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.DataModel
{
    using System;
    using System.Collections.Generic;

    using Erzasoft.DataModel.Semestralka;

    /// <summary>
    /// The user.
    /// </summary>
    public class Salesman
    {
        public int Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public virtual ICollection<Commission> Commissions { get; set; } 
    }
}