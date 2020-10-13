namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCompositionColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Fabrics", "Composition");
            DropColumn("dbo.Fabrics", "Composition2");
            DropColumn("dbo.Fabrics", "Composition3");
            DropColumn("dbo.Fabrics", "Composition4");
            DropColumn("dbo.Fabrics", "Composition5");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fabrics", "Composition5", c => c.String());
            AddColumn("dbo.Fabrics", "Composition4", c => c.String());
            AddColumn("dbo.Fabrics", "Composition3", c => c.String());
            AddColumn("dbo.Fabrics", "Composition2", c => c.String());
            AddColumn("dbo.Fabrics", "Composition", c => c.String(nullable: false));
        }
    }
}
