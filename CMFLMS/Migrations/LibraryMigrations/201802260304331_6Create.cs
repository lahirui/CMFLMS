namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6Create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Samples", "FactoryId", "dbo.Factories");
            DropIndex("dbo.Samples", new[] { "FactoryId" });
            RenameColumn(table: "dbo.Samples", name: "FactoryId", newName: "Factory_FactoryId");
            AddColumn("dbo.Samples", "Factory", c => c.Int(nullable: false));
            AlterColumn("dbo.Samples", "Factory_FactoryId", c => c.Int());
            CreateIndex("dbo.Samples", "Factory_FactoryId");
            AddForeignKey("dbo.Samples", "Factory_FactoryId", "dbo.Factories", "FactoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samples", "Factory_FactoryId", "dbo.Factories");
            DropIndex("dbo.Samples", new[] { "Factory_FactoryId" });
            AlterColumn("dbo.Samples", "Factory_FactoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Samples", "Factory");
            RenameColumn(table: "dbo.Samples", name: "Factory_FactoryId", newName: "FactoryId");
            CreateIndex("dbo.Samples", "FactoryId");
            AddForeignKey("dbo.Samples", "FactoryId", "dbo.Factories", "FactoryId", cascadeDelete: true);
        }
    }
}
