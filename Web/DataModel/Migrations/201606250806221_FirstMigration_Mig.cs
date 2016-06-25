namespace Erzasoft.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration_Mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ST43217.IDAS1_Address_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Zip = c.String(),
                        Type = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ShopId = c.Decimal(precision: 10, scale: 0),
                        WarehouseId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ST43217.IDAS1_Shop_V1", t => t.ShopId)
                .ForeignKey("ST43217.IDAS1_Warehouse_V1", t => t.WarehouseId)
                .Index(t => t.ShopId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "ST43217.IDAS1_Shop_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Warehouse_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ST43217.IDAS1_Warehouse_V1", t => t.Warehouse_Id)
                .Index(t => t.Warehouse_Id);
            
            CreateTable(
                "ST43217.IDAS1_Order_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ShopId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Type = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ST43217.IDAS1_Shop_V1", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
            CreateTable(
                "ST43217.IDAS1_Product_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        StorageCapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStock = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecommendedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        LongDescription = c.String(),
                        WarehouseId = c.Decimal(precision: 10, scale: 0),
                        CommissionId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ST43217.IDAS1_Commission_V1", t => t.CommissionId)
                .ForeignKey("ST43217.IDAS1_Warehouse_V1", t => t.WarehouseId)
                .Index(t => t.WarehouseId)
                .Index(t => t.CommissionId);
            
            CreateTable(
                "ST43217.IDAS1_Commission_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CommissionSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesmanId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ST43217.IDAS1_Salesman_V1", t => t.SalesmanId)
                .Index(t => t.SalesmanId);
            
            CreateTable(
                "ST43217.IDAS1_Salesman_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Title = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ST43217.IDAS1_Image_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Title = c.String(),
                        Source = c.String(),
                        IsMain = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Date = c.DateTime(nullable: false),
                        Width = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Height = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ProductId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ST43217.IDAS1_Product_V1", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "ST43217.IDAS1_Warehouse_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        RegionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ST43217.IDAS1_Region_V1", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "ST43217.IDAS1_Region_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nazev = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ST43217.IDAS1_Employee_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Pay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Title = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ST43217.IDAS1_OrderHistory_V1",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ST43217.ProductOrder",
                c => new
                    {
                        Product_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Order_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Order_Id })
                .ForeignKey("ST43217.IDAS1_Product_V1", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("ST43217.IDAS1_Order_V1", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ST43217.IDAS1_Address_V1", "WarehouseId", "ST43217.IDAS1_Warehouse_V1");
            DropForeignKey("ST43217.IDAS1_Address_V1", "ShopId", "ST43217.IDAS1_Shop_V1");
            DropForeignKey("ST43217.IDAS1_Order_V1", "ShopId", "ST43217.IDAS1_Shop_V1");
            DropForeignKey("ST43217.IDAS1_Product_V1", "WarehouseId", "ST43217.IDAS1_Warehouse_V1");
            DropForeignKey("ST43217.IDAS1_Shop_V1", "Warehouse_Id", "ST43217.IDAS1_Warehouse_V1");
            DropForeignKey("ST43217.IDAS1_Warehouse_V1", "RegionId", "ST43217.IDAS1_Region_V1");
            DropForeignKey("ST43217.ProductOrder", "Order_Id", "ST43217.IDAS1_Order_V1");
            DropForeignKey("ST43217.ProductOrder", "Product_Id", "ST43217.IDAS1_Product_V1");
            DropForeignKey("ST43217.IDAS1_Image_V1", "ProductId", "ST43217.IDAS1_Product_V1");
            DropForeignKey("ST43217.IDAS1_Product_V1", "CommissionId", "ST43217.IDAS1_Commission_V1");
            DropForeignKey("ST43217.IDAS1_Commission_V1", "SalesmanId", "ST43217.IDAS1_Salesman_V1");
            DropIndex("ST43217.ProductOrder", new[] { "Order_Id" });
            DropIndex("ST43217.ProductOrder", new[] { "Product_Id" });
            DropIndex("ST43217.IDAS1_Warehouse_V1", new[] { "RegionId" });
            DropIndex("ST43217.IDAS1_Image_V1", new[] { "ProductId" });
            DropIndex("ST43217.IDAS1_Commission_V1", new[] { "SalesmanId" });
            DropIndex("ST43217.IDAS1_Product_V1", new[] { "CommissionId" });
            DropIndex("ST43217.IDAS1_Product_V1", new[] { "WarehouseId" });
            DropIndex("ST43217.IDAS1_Order_V1", new[] { "ShopId" });
            DropIndex("ST43217.IDAS1_Shop_V1", new[] { "Warehouse_Id" });
            DropIndex("ST43217.IDAS1_Address_V1", new[] { "WarehouseId" });
            DropIndex("ST43217.IDAS1_Address_V1", new[] { "ShopId" });
            DropTable("ST43217.ProductOrder");
            DropTable("ST43217.IDAS1_OrderHistory_V1");
            DropTable("ST43217.IDAS1_Employee_V1");
            DropTable("ST43217.IDAS1_Region_V1");
            DropTable("ST43217.IDAS1_Warehouse_V1");
            DropTable("ST43217.IDAS1_Image_V1");
            DropTable("ST43217.IDAS1_Salesman_V1");
            DropTable("ST43217.IDAS1_Commission_V1");
            DropTable("ST43217.IDAS1_Product_V1");
            DropTable("ST43217.IDAS1_Order_V1");
            DropTable("ST43217.IDAS1_Shop_V1");
            DropTable("ST43217.IDAS1_Address_V1");
        }
    }
}
