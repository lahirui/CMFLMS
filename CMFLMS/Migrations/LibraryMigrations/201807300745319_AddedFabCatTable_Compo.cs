namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFabCatTable_Compo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FabCatoes",
                c => new
                    {
                        FabCatoId = c.Int(nullable: false, identity: true),
                        FabricCat = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.FabCatoId);
            
            CreateTable(
                "dbo.Compositions",
                c => new
                    {
                        CompositionId = c.Int(nullable: false, identity: true),
                        CompositionName = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.CompositionId);
            
            AddColumn("dbo.Fabrics", "FabCatoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fabrics", "FabCatoId");
            AddForeignKey("dbo.Fabrics", "FabCatoId", "dbo.FabCatoes", "FabCatoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "FabCatoId", "dbo.FabCatoes");
            DropIndex("dbo.Fabrics", new[] { "FabCatoId" });
            DropColumn("dbo.Fabrics", "FabCatoId");
            DropTable("dbo.Compositions");
            DropTable("dbo.FabCatoes");
        }
    }
}
