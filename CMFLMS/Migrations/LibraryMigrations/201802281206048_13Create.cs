namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13Create : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fabrics", "AddedDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fabrics", "AddedDate", c => c.String(nullable: false));
        }
    }
}
