namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iSDELETEDNULLABLE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCatagories", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.ProductCatagories", "DeletedDate", c => c.DateTime());
            AlterColumn("dbo.SourcingTypes", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.SourcingTypes", "DeletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SourcingTypes", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SourcingTypes", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductCatagories", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductCatagories", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
