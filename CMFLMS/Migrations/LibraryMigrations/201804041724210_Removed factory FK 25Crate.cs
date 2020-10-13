namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedfactoryFK25Crate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fabrics", "FactoryId", "dbo.Factories");
            DropIndex("dbo.Fabrics", new[] { "FactoryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Fabrics", "FactoryId");
            AddForeignKey("dbo.Fabrics", "FactoryId", "dbo.Factories", "FactoryId", cascadeDelete: true);
        }
    }
}
