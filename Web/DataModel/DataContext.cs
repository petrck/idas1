// <copyright file="DataContext.cs" company="Erzasoft">
//   Copyright 2014 Erzasoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.DataModel
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Erzasoft.DataModel.Semestralka;

    /// <summary>
    /// The data context.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        public DataContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = true;
        }

        private string schemaName = "ST43217";

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(schemaName);

            modelBuilder.Entity<Address>().ToTable("IDAS1_Address_V1");
            modelBuilder.Entity<Commission>().ToTable("IDAS1_Commission_V1");
            modelBuilder.Entity<Employee>().ToTable("IDAS1_Employee_V1");
            modelBuilder.Entity<Image>().ToTable("IDAS1_Image_V1");
            modelBuilder.Entity<Order>().ToTable("IDAS1_Order_V1");
            modelBuilder.Entity<OrderHistory>().ToTable("IDAS1_OrderHistory_V1");
            modelBuilder.Entity<Product>().ToTable("IDAS1_Product_V1");
            modelBuilder.Entity<Region>().ToTable("IDAS1_Region_V1");
            modelBuilder.Entity<Salesman>().ToTable("IDAS1_Salesman_V1");
            modelBuilder.Entity<Shop>().ToTable("IDAS1_Shop_V1");
            modelBuilder.Entity<Warehouse>().ToTable("IDAS1_Warehouse_V1");
        }
    }
}