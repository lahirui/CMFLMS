namespace CMFLMS.Migrations.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9Create : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FactoryId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FactoryId");
        }
    }
}
