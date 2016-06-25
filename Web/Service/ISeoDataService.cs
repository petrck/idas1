// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISeoDataService.cs" company="KOLF s.r.o.">
//   Lékárna KOLF s.r.o.
// </copyright>
// <summary>
//   Defines the ISeoDataService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Service
{
    using Erzasoft.CMS.Model;
    using Erzasoft.DependecyInterface;
    using Erzasoft.Repository;

    /// <summary>
    /// The SeoDataService interface.
    /// </summary>
    public interface ISeoDataService : IRepository<SeoData>, IDependency
    {
    }
}
