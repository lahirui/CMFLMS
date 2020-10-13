namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15Create : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.RegisterViewModelId)
                .ForeignKey("dbo.Factories", t => t.FactoryId, cascadeDelete: true)
                .Index(t => t.FactoryId);
            
            DropColumn("dbo.Fabrics", "Fac");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fabrics", "Fac", c => c.Int(nullable: false));
            DropForeignKey("dbo.RegisterViewModels", "FactoryId", "dbo.Factories");
            DropIndex("dbo.RegisterViewModels", new[] { "FactoryId" });
            DropTable("dbo.RegisterViewModels");
        }
    }
}
