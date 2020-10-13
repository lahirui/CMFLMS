namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fabric_Two_Primary_Keys_18Crate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Fabrics");
            AlterColumn("dbo.Fabrics", "FabricsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Fabrics", "FabricId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Fabrics", new[] { "FabricsId", "FabricId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Fabrics");
            AlterColumn("dbo.Fabrics", "FabricId", c => c.String(nullable: false));
            AlterColumn("dbo.Fabrics", "FabricsId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Fabrics", "FabricsId");
        }
    }
}
