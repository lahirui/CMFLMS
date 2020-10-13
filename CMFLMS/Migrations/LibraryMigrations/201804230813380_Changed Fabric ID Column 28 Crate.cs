namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFabricIDColumn28Crate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Fabrics");
            AlterColumn("dbo.Fabrics", "FabricsId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Fabrics", "FabricId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Fabrics", "FabricsId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Fabrics");
            AlterColumn("dbo.Fabrics", "FabricId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Fabrics", "FabricsId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Fabrics", new[] { "FabricsId", "FabricId" });
        }
    }
}
