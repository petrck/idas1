// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUrlIdService.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// <summary>
//   The UrlIdService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Service
{
    using System.Collections.Generic;

    using Erzasoft.DependecyInterface;

    /// <summary>
    /// The UrlIdService interface.
    /// </summary>
    public interface IUrlIdService : IDependency
    {
        /// <summary>
        /// The get url id.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="urlIds">
        /// The url ids.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetUrlId(string name, IEnumerable<string> urlIds);
    }
}
