namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "Telephone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Telephone", c => c.Int(nullable: false));
        }
    }
}
