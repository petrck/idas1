namespace Erzasoft.Service
{
    using System.Data.Entity;

    using Erzasoft.CMS.Model;
    using Erzasoft.Repository;

    public class SeoDataService : Repository<SeoData>, ISeoDataService
    {
        public SeoDataService(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
