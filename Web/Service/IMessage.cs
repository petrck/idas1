// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageService.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// <summary>
//   The type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.PoznaniImport.Services
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The type.
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// The information.
        /// </summary>
        Info = 1,

        /// <summary>
        /// The error.
        /// </summary>
        Error = 2
    }

    /// <summary>
    /// The i message service.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets or sets the typeof message.
        /// </summary>
        Type TypeofMessage { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        string Key { get; set; }
    }
}


