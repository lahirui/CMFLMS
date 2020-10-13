using CMFLMS.Models.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMFLMS.Data
{
    public class DummyData
    {
        public static List<Category> getCategories()
        {
            List<Category> category = new List<Category>()
            {
                new Category() { CategoryId=1, CategoryName="Local", Remarks="TestCat" },
                new Category() { CategoryId=2, CategoryName="Inter", Remarks="TestCat" },
                new Category() { CategoryId=3, CategoryName="Other", Remarks="TestCat" },
            };
            return category;
        }
      
        public static List<Colour> getColours()
        {
            List<Colour> colour = new List<Colour>()
            {
                new Colour() { ColourId=1, ColourName="Col1", Remarks="TesCol1" },
                new Colour() { ColourId=2, ColourName="Col2", Remarks="TesCol2" },
                new Colour() { ColourId=3, ColourName="Col3", Remarks="TesCol3" },
            };
            return colour;
        }
        public static List<Construction> getConstructions()
        {
            List<Construction> construction = new List<Construction>()
            {
                new Construction() { ConstructionId=1, ConstructionType="Cons1", Remarks="TesCon1" },
                new Construction() { ConstructionId=2, ConstructionType="Cons2", Remarks="TesCon2" },
                new Construction() { ConstructionId=3, ConstructionType="Cons3", Remarks="TesCon3" },
            };
            return construction;
        }
        public static List<Factory> getFactory()
        {
            List<Factory> factories = new List<Factory>()
            {
                new Factory() { FactoryId=1, FactoryName="CME", Remarks="TesFac1" },
                new Factory() { FactoryId=2, FactoryName="CMW", Remarks="TesFac2" },
                new Factory() { FactoryId=3, FactoryName="CMG", Remarks="TesFac3" },
            };
            return factories;
        }
        public static List<Knit> getKnit()
        {
            List<Knit> knits = new List<Knit>()
            {
                new Knit() { KnitId=1, KnitType="Kni1", Remarks="TesKni1" },
                new Knit() { KnitId=2, KnitType="Kni2", Remarks="TesKni2" },
                new Knit() { KnitId=3, KnitType="Kni3", Remarks="TesKni3" },
            };
            return knits;
        }
        public static List<Locations> getLocation()
        {
            List<Locations> locations = new List<Locations>()
            {
                new Locations() { LocationsId=1, LocationName="Loc1", Remarks="TesLoc1" },
                new Locations() { LocationsId=2, LocationName="Loc2", Remarks="TesLoc2" },
                new Locations() { LocationsId=3, LocationName="Loc3", Remarks="TesLoc3" },
            };
            return locations;
        }
        public static List<Structure> getStructure()
        {
            List<Structure> structures = new List<Structure>()
            {
                new Structure() { StructureId=1, StructureValue="Str1", Remarks="TesStr1" },
                new Structure() { StructureId=2, StructureValue="Str2", Remarks="TesStr2" },
                new Structure() { StructureId=3, StructureValue="Str3", Remarks="TesStr3" },
            };
            return structures;
        }
        public static List<Yarn> getYarns()
        {
            List<Yarn> yarns = new List<Yarn>()
            {
                new Yarn() { YarnId=1, YarnCount="Yar1", Remarks="TesYar1" },
                new Yarn() { YarnId=2, YarnCount="Yar2", Remarks="TesYar2" },
                new Yarn() { YarnId=3, YarnCount="Yar3", Remarks="TesYar3" },
            };
            return yarns;
        }
        public static List<Supplier> getSupplier(LibraryContext context)
        {
            List<Supplier> supplier = new List<Supplier>()
            {
                //new Supplier() {SupplierId=1, SupplierName="Decathlon", ContactPerson="CP", Address="123Test", Telephone=0774569874, Email="a@a.a", AddedDate=DateTime.Now, CategoryId=context.categories.Find(1).CategoryId},
                //new Supplier() {SupplierId=2, SupplierName="Decathlon", ContactPerson="CP", Address="123Test", Telephone=0774569874, Email="a@a.a", AddedDate=DateTime.Now, CategoryId=context.categories.Find(2).CategoryId},
                //new Supplier() {SupplierId=3, SupplierName="Decathlon", ContactPerson="CP", Address="123Test", Telephone=0774569874, Email="a@a.a", AddedDate=DateTime.Now, CategoryId=context.categories.Find(3).CategoryId},
            };
            return supplier;
        }
        public static List<Fabrics> getFabrics(LibraryContext context)
        {
            List<Fabrics> fabrics = new List<Fabrics>()
            {
                // new Fabrics() { FabricsId=1, FabricId="Fab1", SupplierId=context.suppliers.Find(1).SupplierId, Composition=1.2, Quality=10.2, ConstructionId=context.constructions.Find(1).ConstructionId, YarnId=context.yarns.Find(1).YarnId, WidthInches=5, WidthCm=12.7, AddedDate=Convert.ToString(DateTime.Now), Weight=5.8, Price=500.25, LocationsId=context.locationss.Find(1).LocationsId, KnitId=context.knits.Find(1).KnitId, StructureId=context.structures.Find(1).StructureId, ColourId= context.colours.Find(1).ColourId, FactoryId= context.factories.Find(1).FactoryId, Remarks="TesSam1"},
                //new Fabrics() { FabricsId=2, FabricId="Fab2", SupplierId=context.suppliers.Find(2).SupplierId, Composition=1.2, Quality=10.2, ConstructionId=context.constructions.Find(2).ConstructionId, YarnId=context.yarns.Find(2).YarnId, WidthInches=5, WidthCm=12.7, AddedDate=Convert.ToString(DateTime.Now), Weight=5.8, Price=500.25, LocationsId=context.locationss.Find(2).LocationsId, KnitId=context.knits.Find(2).KnitId, StructureId=context.structures.Find(2).StructureId, ColourId= context.colours.Find(2).ColourId, FactoryId= context.factories.Find(2).FactoryId, Fac=1, Remarks="TesSam2"},
                //new Fabrics() { FabricsId=3, FabricId="Fab3", SupplierId=context.suppliers.Find(3).SupplierId, Composition=1.2, Quality=10.2, ConstructionId=context.constructions.Find(3).ConstructionId, YarnId=context.yarns.Find(3).YarnId, WidthInches=5, WidthCm=12.7, AddedDate=Convert.ToString(DateTime.Now), Weight=5.8, Price=500.25, LocationsId=context.locationss.Find(3).LocationsId, KnitId=context.knits.Find(3).KnitId, StructureId=context.structures.Find(3).StructureId, ColourId= context.colours.Find(3).ColourId, FactoryId= context.factories.Find(1).FactoryId, Fac=1, Remarks="TesSam3"},

            };
            return fabrics;
        }
    }
}