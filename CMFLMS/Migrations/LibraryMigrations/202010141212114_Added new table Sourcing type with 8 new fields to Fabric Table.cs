namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddednewtableSourcingtypewith8newfieldstoFabricTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SourcingTypes",
                c => new
                    {
                        SourcingTypeId = c.Int(nullable: false, identity: true),
                        SourcingTypeName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SourcingTypeId);
            
            AddColumn("dbo.Fabrics", "SourcingTypeId", c => c.Int());
            AddColumn("dbo.Fabrics", "SourcingRoute", c => c.Boolean(nullable: false));
            AddColumn("dbo.Fabrics", "LeadTime", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fabrics", "SustainableProduct", c => c.Boolean(nullable: false));
            AddColumn("dbo.Fabrics", "YarnGuage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fabrics", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Fabrics", "DeletedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Fabrics", "SourcingTypeId");
            AddForeignKey("dbo.Fabrics", "SourcingTypeId", "dbo.SourcingTypes", "SourcingTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "SourcingTypeId", "dbo.SourcingTypes");
            DropIndex("dbo.Fabrics", new[] { "SourcingTypeId" });
            DropColumn("dbo.Fabrics", "DeletedDate");
            DropColumn("dbo.Fabrics", "IsDeleted");
            DropColumn("dbo.Fabrics", "YarnGuage");
            DropColumn("dbo.Fabrics", "SustainableProduct");
            DropColumn("dbo.Fabrics", "LeadTime");
            DropColumn("dbo.Fabrics", "SourcingRoute");
            DropColumn("dbo.Fabrics", "SourcingTypeId");
            DropTable("dbo.SourcingTypes");
        }
    }
}
