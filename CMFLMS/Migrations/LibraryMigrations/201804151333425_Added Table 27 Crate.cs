namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable27Crate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Fabrics", "FactoryId");
            AddForeignKey("dbo.Fabrics", "FactoryId", "dbo.Factories", "FactoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "FactoryId", "dbo.Factories");
            DropIndex("dbo.Fabrics", new[] { "FactoryId" });
        }
    }
}
