// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UrlIdService.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// <summary>
//   Defines the UrlIdService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using MvcUtility;

    /// <summary>
    /// The url id service.
    /// </summary>
    public class UrlIdService : IUrlIdService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlIdService"/> class.
        /// </summary>
        /// <param name="seoUrlGenerator">
        /// The seo url generator.
        /// </param>
        public UrlIdService(ISeoUrlGenerator seoUrlGenerator)
        {
            this.SeoUrlGenerator = seoUrlGenerator;
        }

        /// <summary>
        /// Gets the seo url generator.
        /// </summary>
        protected ISeoUrlGenerator SeoUrlGenerator { get; private set; }

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
        public string GetUrlId(string name, IEnumerable<string> urlIds)
        {
            //Pouze odstraňuje diakritiku. Možná zvážit přejmenování SeoUrlGenerator?
            var urlId = this.SeoUrlGenerator.Convert(name, 100);

            var tempUrlId = urlId;
            var i = 0;
            while (urlIds.Any(s => s == tempUrlId))
            {
                tempUrlId = string.Format("{0}-{1}", urlId, ++i);
            }

            return tempUrlId;
        }
    }
}
