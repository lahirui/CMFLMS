namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersWithFactory_Maping_Table_Added_Date_20Crate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersWithFactories", "InsertedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersWithFactories", "InsertedDate");
        }
    }
}
