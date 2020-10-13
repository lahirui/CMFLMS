namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9Create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Samples", "Factory_FactoryId", "dbo.Factories");
            DropIndex("dbo.Samples", new[] { "Factory_FactoryId" });
            DropColumn("dbo.Samples", "Factory_FactoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samples", "Factory_FactoryId", c => c.Int());
            CreateIndex("dbo.Samples", "Factory_FactoryId");
            AddForeignKey("dbo.Samples", "Factory_FactoryId", "dbo.Factories", "FactoryId");
        }
    }
}
