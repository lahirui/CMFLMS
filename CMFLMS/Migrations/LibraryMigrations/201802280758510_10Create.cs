namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10Create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Samples", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.Samples", "ConstructionId", "dbo.Constructions");
            DropForeignKey("dbo.Samples", "KnitId", "dbo.Knits");
            DropForeignKey("dbo.Samples", "LocationsId", "dbo.Locations");
            DropForeignKey("dbo.Samples", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.Samples", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Samples", "YarnId", "dbo.Yarns");
            DropIndex("dbo.Samples", new[] { "SupplierId" });
            DropIndex("dbo.Samples", new[] { "ConstructionId" });
            DropIndex("dbo.Samples", new[] { "YarnId" });
            DropIndex("dbo.Samples", new[] { "LocationsId" });
            DropIndex("dbo.Samples", new[] { "KnitId" });
            DropIndex("dbo.Samples", new[] { "StructureId" });
            DropIndex("dbo.Samples", new[] { "ColourId" });
            DropTable("dbo.Samples");
        }
        
        public override void Down()
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
                        Fac = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.SamplesId);
            
            CreateIndex("dbo.Samples", "ColourId");
            CreateIndex("dbo.Samples", "StructureId");
            CreateIndex("dbo.Samples", "KnitId");
            CreateIndex("dbo.Samples", "LocationsId");
            CreateIndex("dbo.Samples", "YarnId");
            CreateIndex("dbo.Samples", "ConstructionId");
            CreateIndex("dbo.Samples", "SupplierId");
            AddForeignKey("dbo.Samples", "YarnId", "dbo.Yarns", "YarnId", cascadeDelete: true);
            AddForeignKey("dbo.Samples", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
            AddForeignKey("dbo.Samples", "StructureId", "dbo.Structures", "StructureId", cascadeDelete: true);
            AddForeignKey("dbo.Samples", "LocationsId", "dbo.Locations", "LocationsId", cascadeDelete: true);
            AddForeignKey("dbo.Samples", "KnitId", "dbo.Knits", "KnitId", cascadeDelete: true);
            AddForeignKey("dbo.Samples", "ConstructionId", "dbo.Constructions", "ConstructionId", cascadeDelete: true);
            AddForeignKey("dbo.Samples", "ColourId", "dbo.Colours", "ColourId", cascadeDelete: true);
        }
    }
}
