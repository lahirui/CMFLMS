namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabrics",
                c => new
                    {
                        FabricsId = c.Int(nullable: false, identity: true),
                        FabricId = c.String(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Composition = c.Double(nullable: false),
                        Quality = c.Double(nullable: false),
                        ConstructionId = c.Int(nullable: false),
                        YarnId = c.Int(nullable: false),
                        WidthInches = c.Double(nullable: false),
                        WidthCm = c.Double(nullable: false),
                        AddedDate = c.String(nullable: false),
                        Weight = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        LocationsId = c.Int(nullable: false),
                        KnitId = c.Int(nullable: false),
                        StructureId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                        FactoryId = c.Int(nullable: false),
                        Fac = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.FabricsId)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.Constructions", t => t.ConstructionId, cascadeDelete: true)
                .ForeignKey("dbo.Factories", t => t.FactoryId, cascadeDelete: true)
                .ForeignKey("dbo.Knits", t => t.KnitId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationsId, cascadeDelete: true)
                .ForeignKey("dbo.Structures", t => t.StructureId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Yarns", t => t.YarnId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.ConstructionId)
                .Index(t => t.YarnId)
                .Index(t => t.LocationsId)
                .Index(t => t.KnitId)
                .Index(t => t.StructureId)
                .Index(t => t.ColourId)
                .Index(t => t.FactoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabrics", "YarnId", "dbo.Yarns");
            DropForeignKey("dbo.Fabrics", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Fabrics", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.Fabrics", "LocationsId", "dbo.Locations");
            DropForeignKey("dbo.Fabrics", "KnitId", "dbo.Knits");
            DropForeignKey("dbo.Fabrics", "FactoryId", "dbo.Factories");
            DropForeignKey("dbo.Fabrics", "ConstructionId", "dbo.Constructions");
            DropForeignKey("dbo.Fabrics", "ColourId", "dbo.Colours");
            DropIndex("dbo.Fabrics", new[] { "FactoryId" });
            DropIndex("dbo.Fabrics", new[] { "ColourId" });
            DropIndex("dbo.Fabrics", new[] { "StructureId" });
            DropIndex("dbo.Fabrics", new[] { "KnitId" });
            DropIndex("dbo.Fabrics", new[] { "LocationsId" });
            DropIndex("dbo.Fabrics", new[] { "YarnId" });
            DropIndex("dbo.Fabrics", new[] { "ConstructionId" });
            DropIndex("dbo.Fabrics", new[] { "SupplierId" });
            DropTable("dbo.Fabrics");
        }
    }
}
