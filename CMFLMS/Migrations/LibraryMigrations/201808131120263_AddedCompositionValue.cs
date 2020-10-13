namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompositionValue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompositionValues",
                c => new
                    {
                        CompositionValuesId = c.Int(nullable: false),
                        FabricId = c.String(nullable: false, maxLength: 128),
                        CompositionId = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        Fabrics_FabricsId = c.Int(),
                    })
                .PrimaryKey(t => new { t.CompositionValuesId, t.FabricId })
                .ForeignKey("dbo.Compositions", t => t.CompositionId, cascadeDelete: true)
                .ForeignKey("dbo.Fabrics", t => t.Fabrics_FabricsId)
                .Index(t => t.CompositionId)
                .Index(t => t.Fabrics_FabricsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompositionValues", "Fabrics_FabricsId", "dbo.Fabrics");
            DropForeignKey("dbo.CompositionValues", "CompositionId", "dbo.Compositions");
            DropIndex("dbo.CompositionValues", new[] { "Fabrics_FabricsId" });
            DropIndex("dbo.CompositionValues", new[] { "CompositionId" });
            DropTable("dbo.CompositionValues");
        }
    }
}
