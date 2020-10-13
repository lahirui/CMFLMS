namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16Crate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisterViewModels", "FactoryId", "dbo.Factories");
            DropIndex("dbo.RegisterViewModels", new[] { "FactoryId" });
            DropTable("dbo.RegisterViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        RegisterViewModelId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        FactoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegisterViewModelId);
            
            CreateIndex("dbo.RegisterViewModels", "FactoryId");
            AddForeignKey("dbo.RegisterViewModels", "FactoryId", "dbo.Factories", "FactoryId", cascadeDelete: true);
        }
    }
}
