namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNewfieldsasNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fabrics", "SourcingRoute", c => c.Boolean());
            AlterColumn("dbo.Fabrics", "LeadTime", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Fabrics", "SustainableProduct", c => c.Boolean());
            AlterColumn("dbo.Fabrics", "YarnGuage", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Fabrics", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Fabrics", "DeletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fabrics", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Fabrics", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Fabrics", "YarnGuage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fabrics", "SustainableProduct", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Fabrics", "LeadTime", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fabrics", "SourcingRoute", c => c.Boolean(nullable: false));
        }
    }
}
