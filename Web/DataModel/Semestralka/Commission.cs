// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.DataModel.Semestralka
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The user.
    /// </summary>
    public class Commission
    {
        public int Id { get; set; }

        public decimal CommissionSize { get; set; }

        public virtual Salesman Salesman { get; set; }

        [ForeignKey("Salesman")]
        public virtual int? SalesmanId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}