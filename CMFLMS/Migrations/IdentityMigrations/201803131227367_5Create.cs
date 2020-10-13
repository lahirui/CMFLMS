namespace CMFLMS.Migrations.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5Create : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FactoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FactoryId");
        }
    }
}
