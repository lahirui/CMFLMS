namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedValueFields29Crate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fabrics", "Composition", c => c.String(nullable: false));
            AlterColumn("dbo.Fabrics", "Quality", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fabrics", "Quality", c => c.Double(nullable: false));
            AlterColumn("dbo.Fabrics", "Composition", c => c.Double(nullable: false));
        }
    }
}
