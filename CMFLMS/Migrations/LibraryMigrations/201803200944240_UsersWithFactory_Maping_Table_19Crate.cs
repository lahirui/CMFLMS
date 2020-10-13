namespace CMFLMS.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersWithFactory_Maping_Table_19Crate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersWithFactories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FactoryId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsersWithFactories");
        }
    }
}
