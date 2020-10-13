using CMFLMS.Models.Library;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMFLMS.Data
{
    public class LibraryContext :DbContext
    {
        public LibraryContext(): base("DefaultConnection")
        {
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Colour> colours { get; set; }
        public DbSet<Construction> constructions { get; set; }
        public DbSet<Factory> factories { get; set; }
        public DbSet<Knit> knits { get; set; }
        public DbSet<Locations> locationss { get; set; }
        public DbSet<Structure> structures { get; set; }
        public DbSet<Yarn> yarns { get; set; }
        public DbSet<Fabrics> fabrics { get; set; }
        public DbSet<UsersWithFactory> Mapping_UsersWithFactory { get; set; }
        public DbSet<FabCato>fabcatos { get; set; }
        public DbSet<Composition> compositions { get; set; }
        public DbSet<CompositionValues> compositionValues { get; set; }
        public DbSet<FinishCato> finishingCato { get; set; }

        // public System.Data.Entity.DbSet<CMFLMS.Models.Library.FinishingCategory> FinishingCategories { get; set; }
    }
}