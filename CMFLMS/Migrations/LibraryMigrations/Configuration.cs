namespace CMFLMS.Migrations.LibraryMigrations
{
    using Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMFLMS.Data.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\LibraryMigrations";
        }
        protected override void Seed(CMFLMS.Data.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //context.categories.AddOrUpdate(c => c.CategoryId, DummyData.getCategories().ToArray());
            //context.SaveChanges();

            //context.suppliers.AddOrUpdate(s =>  new { s.SupplierId, s.SupplierName }, DummyData.getSupplier(context).ToArray());
            //context.SaveChanges();

            //context.colours.AddOrUpdate(o => o.ColourId, DummyData.getColours().ToArray());
            //context.SaveChanges();

            //context.constructions.AddOrUpdate(n =>  n.ConstructionId, DummyData.getConstructions().ToArray());
            //context.SaveChanges();

            //context.factories.AddOrUpdate(f => f.FactoryId,  DummyData.getFactory().ToArray());
            //context.SaveChanges();

            //context.knits.AddOrUpdate(k =>  k.KnitId, DummyData.getKnit().ToArray());
            //context.SaveChanges();

            //context.locationss.AddOrUpdate(l => l.LocationsId, DummyData.getLocation().ToArray());
            //context.SaveChanges();

            //context.structures.AddOrUpdate(t => t.StructureId, DummyData.getStructure().ToArray());
            //context.SaveChanges();

            //context.yarns.AddOrUpdate(y => y.YarnId, DummyData.getYarns().ToArray());
            //context.SaveChanges();

            //context.fabrics.AddOrUpdate(a => new { a.FabricsId, a.FabricId }, DummyData.getFabrics(context).ToArray());
            //context.SaveChanges();

        }
    }
}
