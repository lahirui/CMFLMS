namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddednewtableProductCatagory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCatagories",
                c => new
                    {
                        ProductCatagoryId = c.Int(nullable: false, identity: true),
                        ProductCatagoryName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCatagoryId);
            
            AddColumn("dbo.Fabrics", "ProductCatagoryId", c => c.Int());
            CreateIndex("dbo.Fabrics", "ProductCatagoryId");
            AddForeignKey("dbo.Fabrics", "ProductCatagoryId", "dbo.ProductCatagories", "ProductCatagoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "ProductCatagoryId", "dbo.ProductCatagories");
            DropIndex("dbo.Fabrics", new[] { "ProductCatagoryId" });
            DropColumn("dbo.Fabrics", "ProductCatagoryId");
            DropTable("dbo.ProductCatagories");
        }
    }
}
