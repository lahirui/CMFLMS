namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTPRequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "ContactPerson", c => c.String());
            AlterColumn("dbo.Suppliers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "ContactPerson", c => c.String(nullable: false));
        }
    }
}
