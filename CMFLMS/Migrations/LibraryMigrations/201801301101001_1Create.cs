namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        ContactPerson = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        AddedDate = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Suppliers", new[] { "CategoryId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
        }
    }
}
