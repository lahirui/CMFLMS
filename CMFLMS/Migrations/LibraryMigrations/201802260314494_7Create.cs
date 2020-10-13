namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7Create : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Samples", "Fac", c => c.Int(nullable: false));
            DropColumn("dbo.Samples", "Factory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samples", "Factory", c => c.Int(nullable: false));
            DropColumn("dbo.Samples", "Fac");
        }
    }
}
