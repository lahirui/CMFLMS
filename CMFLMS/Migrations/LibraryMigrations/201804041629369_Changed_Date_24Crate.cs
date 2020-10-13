namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_Date_24Crate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "AddedDate", c => c.String());
            AlterColumn("dbo.Fabrics", "AddedDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fabrics", "AddedDate", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "AddedDate", c => c.String(nullable: false));
        }
    }
}
