namespace CMFLMS.Migrations.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7Create : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "FactoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FactoryId", c => c.Int(nullable: false));
        }
    }
}
