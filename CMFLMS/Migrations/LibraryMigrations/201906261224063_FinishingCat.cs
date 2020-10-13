namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishingCat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinishCatoes",
                c => new
                    {
                        FinishCatoId = c.Int(nullable: false, identity: true),
                        FinishCat = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.FinishCatoId);
            
            AddColumn("dbo.Fabrics", "FinishCatoId", c => c.Int(nullable: true));
            CreateIndex("dbo.Fabrics", "FinishCatoId");
            AddForeignKey("dbo.Fabrics", "FinishCatoId", "dbo.FinishCatoes", "FinishCatoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "FinishCatoId", "dbo.FinishCatoes");
            DropIndex("dbo.Fabrics", new[] { "FinishCatoId" });
            DropColumn("dbo.Fabrics", "FinishCatoId");
            DropTable("dbo.FinishCatoes");
        }
    }
}
