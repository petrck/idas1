// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.DataModel.Semestralka
{
    using System;

    /// <summary>
    /// The user.
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public decimal Pay { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }
    }
}