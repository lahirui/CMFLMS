namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Samples",
                c => new
                    {
                        SamplesId = c.Int(nullable: false, identity: true),
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
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.SamplesId)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.Constructions", t => t.ConstructionId, cascadeDelete: true)
                .ForeignKey("dbo.Knits", t => t.KnitId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationsId, cascadeDelete: true)
                .ForeignKey("dbo.Structures", t => t.StructureId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Yarns", t => t.YarnId, cascadeDelete: true)
                .ForeignKey("dbo.Factories", t => t.FactoryId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.ConstructionId)
                .Index(t => t.YarnId)
                .Index(t => t.LocationsId)
                .Index(t => t.KnitId)
                .Index(t => t.StructureId)
                .Index(t => t.ColourId)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        ColourId = c.Int(nullable: false, identity: true),
                        ColourName = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ColourId);
            
            CreateTable(
                "dbo.Constructions",
                c => new
                    {
                        ConstructionId = c.Int(nullable: false, identity: true),
                        ConstructionType = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ConstructionId);
            
            CreateTable(
                "dbo.Knits",
                c => new
                    {
                        KnitId = c.Int(nullable: false, identity: true),
                        KnitType = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.KnitId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationsId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.LocationsId);
            
            CreateTable(
                "dbo.Structures",
                c => new
                    {
                        StructureId = c.Int(nullable: false, identity: true),
                        StructureValue = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.StructureId);
            
            CreateTable(
                "dbo.Yarns",
                c => new
                    {
                        YarnId = c.Int(nullable: false, identity: true),
                        YarnCount = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.YarnId);
            
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        FactoryId = c.Int(nullable: false, identity: true),
                        FactoryName = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.FactoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samples", "FactoryId", "dbo.Factories");
            DropForeignKey("dbo.Samples", "YarnId", "dbo.Yarns");
            DropForeignKey("dbo.Samples", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Samples", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.Samples", "LocationsId", "dbo.Locations");
            DropForeignKey("dbo.Samples", "KnitId", "dbo.Knits");
            DropForeignKey("dbo.Samples", "ConstructionId", "dbo.Constructions");
            DropForeignKey("dbo.Samples", "ColourId", "dbo.Colours");
            DropIndex("dbo.Samples", new[] { "FactoryId" });
            DropIndex("dbo.Samples", new[] { "ColourId" });
            DropIndex("dbo.Samples", new[] { "StructureId" });
            DropIndex("dbo.Samples", new[] { "KnitId" });
            DropIndex("dbo.Samples", new[] { "LocationsId" });
            DropIndex("dbo.Samples", new[] { "YarnId" });
            DropIndex("dbo.Samples", new[] { "ConstructionId" });
            DropIndex("dbo.Samples", new[] { "SupplierId" });
            DropTable("dbo.Factories");
            DropTable("dbo.Yarns");
            DropTable("dbo.Structures");
            DropTable("dbo.Locations");
            DropTable("dbo.Knits");
            DropTable("dbo.Constructions");
            DropTable("dbo.Colours");
            DropTable("dbo.Samples");
        }
    }
}
