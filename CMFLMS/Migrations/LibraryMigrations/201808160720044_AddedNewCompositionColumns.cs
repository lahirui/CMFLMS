namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewCompositionColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabrics", "Composition2", c => c.String());
            AddColumn("dbo.Fabrics", "Composition3", c => c.String());
            AddColumn("dbo.Fabrics", "Composition4", c => c.String());
            AddColumn("dbo.Fabrics", "Composition5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fabrics", "Composition5");
            DropColumn("dbo.Fabrics", "Composition4");
            DropColumn("dbo.Fabrics", "Composition3");
            DropColumn("dbo.Fabrics", "Composition2");
        }
    }
}
