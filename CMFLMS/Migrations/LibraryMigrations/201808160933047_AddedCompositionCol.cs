namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompositionCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "Compisition1", c => c.String(nullable: false));
            AddColumn("dbo.Fabrics", "Compisition2", c => c.String());
            AddColumn("dbo.Fabrics", "Compisition3", c => c.String());
            AddColumn("dbo.Fabrics", "Compisition4", c => c.String());
            AddColumn("dbo.Fabrics", "Compisition5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fabrics", "Compisition5");
            DropColumn("dbo.Fabrics", "Compisition4");
            DropColumn("dbo.Fabrics", "Compisition3");
            DropColumn("dbo.Fabrics", "Compisition2");
            DropColumn("dbo.Fabrics", "Compisition1");
        }
    }
}
