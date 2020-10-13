using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMFLMS.Data;
using CMFLMS.Models.Library;
using PagedList;
using PagedList.Mvc;
using CMFLMS.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace CMFLMS.Controllers
{
    public class FabricsController : Controller
    {
        private LibraryContext db = new LibraryContext();
        private ApplicationDbContext AppDb = new ApplicationDbContext();
        ApplicationUser appus = new ApplicationUser();
        Common ComFabricSample = new Common();
        DataSet DatFabricSample = new DataSet();
        DataSet DatTotFab = new DataSet();
        DataSet DatOtherFacFabSam = new DataSet();
        DataSet DatTotOtherFac = new DataSet();
        Fabrics fab = new Fabrics();
        DataSet DsFAB = new DataSet();
        Common ComFabSam = new Common();
        // GET: Fabrics
        public ActionResult FabricError()
        {
            return View();
        }
       
        public ActionResult Report()
        {
            var fabrics=(dynamic)null;
            if (User.IsInRole("MainAdmin"))
            {
                fabrics = db.fabrics.Include(f => f.Colours).Include(f => f.Constructions).Include(f => f.Knits).Include(f => f.Locationss).Include(f => f.Structures).Include(f => f.Suppliers).Include(f => f.Yarns).Include(f => f.Factories).Include(f => f.FabCats).OrderBy(f => f.FabricId);
            }
            else
            {
                DataSet Users = new DataSet();
                string FactoryName;
                Users = ComFabricSample.ReturnDataset("SELECT UserName, FactoryId FROM AspNetUsers WHERE UserName ='" + Common.UserName + "'");
                FactoryName = Users.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                DataSet FactoryId2 = new DataSet();
                int FacId2;
                FactoryId2 = ComFabricSample.ReturnDataset("SELECT FactoryId, FactoryName FROM Factories WHERE FactoryName='" + FactoryName + "'");
                FacId2 = Convert.ToInt32(FactoryId2.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                fabrics = db.fabrics.Include(f => f.Colours).Include(f => f.Constructions).Include(f => f.Knits).Include(f => f.Locationss).Include(f => f.Structures).Include(f => f.Suppliers).Include(f => f.Yarns).Include(f => f.Factories).Include(f => f.FabCats).Where(f=>f.FactoryId== FacId2).OrderBy(f => f.FabricId);//

            }
            
            using (var con = new LibraryContext())
            {
                ViewBag.count = con.fabrics.ToList().Count();
            }
            return View(fabrics);
        }
        public ActionResult MainAdminView()
        {
            var fabrics = db.fabrics.Include(f => f.Colours).Include(f => f.Constructions).Include(f => f.Knits).Include(f => f.Locationss).Include(f => f.Structures).Include(f => f.Suppliers).Include(f => f.Yarns).Include(f => f.Factories).Include(f => f.FabCats).OrderBy(f => f.FabricsId);//
            try
            {
                using (var con = new LibraryContext())
                {
                    ViewBag.count = con.fabrics.ToList().Count();
                }   
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                ComFabSam.exception = Convert.ToString(ex);
                ComFabSam.user = Common.UserName;
                //ComFabSam.user = Session["username"].ToString();
                ComFabSam.MailSend();
                RedirectToAction("FabricError");
                //throw;
            }
            return View(fabrics.ToList());
        }
        public ActionResult Index()
        {
           
                var fabrics = db.fabrics.Include(f => f.Colours).Include(f => f.Constructions).Include(f => f.Knits).Include(f => f.Locationss).Include(f => f.Structures).Include(f => f.Suppliers).Include(f => f.Yarns).Include(f => f.Factories).Include(f => f.FabCats).Include(f=>f.FinCategory).OrderBy(f => f.FabricsId);//

            try
            {
                //var name = Common.UserName;
                var name = Session["username"].ToString();
                using (var con = new LibraryContext())
                {
                    ViewBag.count = con.fabrics.ToList().Count();
                }

                DatFabricSample = ComFabricSample.ReturnDataset("SELECT UserName, FactoryId FROM UsersWithFactories WHERE UserName ='" + name + "'");
                if (DatFabricSample.Tables[0].Rows.Count > 0)
                {
                    ViewBag.FactoryName = DatFabricSample.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                }

                DatTotFab = ComFabricSample.ReturnDataset("SELECT * FROM Fabrics INNER JOIN Factories ON Fabrics.FactoryId = Factories.FactoryId WHERE Factories.FactoryName= '" + Convert.ToString(ViewBag.FactoryName) + "'");
                ViewBag.TotFactoryFabric = DatTotFab.Tables[0].Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                ComFabSam.exception = Convert.ToString(ex);
                ComFabSam.user = Common.UserName;
                //ComFabSam.user = Session["username"].ToString();
                ComFabSam.MailSend();
                RedirectToAction("FabricError");
                //throw;
            }
                return View(fabrics.ToList());
 
        }
        //////Get : Fabrics of other Factories
        public ActionResult OtherFactoryDetails(int? page)
        {
            var fabrics = db.fabrics.Include(f => f.Colours).Include(f => f.Constructions).Include(f => f.Knits).Include(f => f.Locationss).Include(f => f.Structures).Include(f => f.Suppliers).Include(f => f.Yarns).Include(f => f.Factories).Include(f => f.FabCats).OrderBy(f => f.FabricsId);//
            var secondUser = Common.UserName;
            //var secondUser = Session["username"].ToString();
            using (var con = new LibraryContext())
            {
                ViewBag.Totcount = con.fabrics.ToList().Count();
            }
            DatOtherFacFabSam = ComFabricSample.ReturnDataset("SELECT UserName, FactoryId FROM UsersWithFactories WHERE UserName ='" + secondUser + "'");
            if (DatOtherFacFabSam.Tables[0].Rows.Count > 0)
            {
                ViewBag.OtherFacFab = DatOtherFacFabSam.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
            }
            DatTotOtherFac = ComFabricSample.ReturnDataset("SELECT * FROM Fabrics INNER JOIN Factories ON Fabrics.FactoryId = Factories.FactoryId WHERE Factories.FactoryName != '" + Convert.ToString(ViewBag.OtherFacFab) + "'");
            ViewBag.OtherFactories = DatTotOtherFac.Tables[0].Rows.Count.ToString();
            return View(fabrics.ToList().ToPagedList(page ?? 1, 500));
        }

        // GET: Fabrics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabrics fabrics = db.fabrics.Find(id);
            if (fabrics == null)
            {
                return HttpNotFound();
            }
            return View(fabrics);
        }
        public ActionResult Exist()
        {
            return View();
        }
        public ActionResult NoFactory()
        {
            return View();
        }
        public ActionResult CompositionSelected()
        {
            return View();
        }
        public ActionResult CompositionExceeded()
        {
            return View();
        }
        public ActionResult NoCompositionEntered()
        {
            return View();
        }
        // GET: Fabrics/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            try
            {
                ViewBag.ColourId = new SelectList(db.colours.OrderBy(c => c.ColourName), "ColourId", "ColourName");
                ViewBag.ConstructionId = new SelectList(db.constructions.OrderBy(c => c.ConstructionType), "ConstructionId", "ConstructionType");
                ViewBag.FactoryId = new SelectList(db.factories, "FactoryId", "FactoryName");
                ViewBag.KnitId = new SelectList(db.knits.OrderBy(k => k.KnitType), "KnitId", "KnitType");
                ViewBag.LocationsId = new SelectList(db.locationss.OrderBy(l => l.LocationName), "LocationsId", "LocationName");
                ViewBag.StructureId = new SelectList(db.structures.OrderBy(s => s.StructureValue), "StructureId", "StructureValue");
                ViewBag.SupplierId = new SelectList(db.suppliers.OrderBy(s => s.SupplierName), "SupplierId", "SupplierName");
                ViewBag.YarnId = new SelectList(db.yarns.OrderBy(y => y.YarnCount), "YarnId", "YarnCount"); 
                ViewBag.FinCatId = new SelectList(db.finishingCato.OrderBy(f=>f.FinishCatoId), "FinishCatoId", "FinishCat");
                ViewBag.FabCatoId = new SelectList(db.fabcatos.OrderBy(f => f.FabricCat), "FabCatoId", "FabricCat");
                ViewBag.Compositions = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions2 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions3 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions4 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions5 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");


                if ((User.IsInRole("MainAdmin"))||(User.IsInRole("SuperAdmin")))
                {
                    ViewBag.FacList = new SelectList(db.factories.OrderBy(f => f.FactoryName), "FactoryName", "FactoryName");
                }
                else
                {
                    DataSet DSUser = new DataSet();
                    DataSet DSFac = new DataSet();
                    Common ComFAb = new Common();
                    var UserName = Common.UserName;
                    //var UserName = Session["username"].ToString();
                    var FacName = "";
                    DSUser = ComFAb.ReturnDataset("SELECT Email, UserName, FactoryId FROM AspNetUsers WHERE UserName ='" + UserName + "'");
                    if (DSUser.Tables[0].Rows.Count > 0)
                    {
                        FacName = DSUser.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                    }
                    DSFac = ComFAb.ReturnDataset("SELECT FactoryId, FactoryName FROM Factories WHERE FactoryName = '" + FacName + "'");
                    var Factorynewid = "";
                    if (DSFac.Tables[0].Rows.Count > 0)
                    {
                        Factorynewid = DSFac.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
                    }
                    ViewBag.Factorynewid = Factorynewid;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                //throw;
            }
           
            return View();
        }
        
        // POST: Fabrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FabricsId,FabricId,SupplierId,Compisition1,Compisition2,Compisition3,Compisition4,Compisition5,Quality,ConstructionId,YarnId,WidthInches,WidthCm,AddedDate,Weight,Price,LocationsId,KnitId,StructureId,ColourId,FactoryId,FabCatoId,Remarks,FinishCatoId")] Fabrics fabrics)
            {

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            try
            {
                if (ModelState.IsValid)
                {
                    string StrComp1 = fabrics.Compisition1;
                    string StrComp2 = fabrics.Compisition2;
                    string StrComp3 = fabrics.Compisition3;
                    string StrComp4 = fabrics.Compisition4;
                    string StrComp5 = fabrics.Compisition5;
                    double Com1;
                    double Com2;
                    double Com3;
                    double Com4;
                    double Com5;
                    Double.TryParse(StrComp1, out Com1);
                    Double.TryParse(StrComp2, out Com2);
                    Double.TryParse(StrComp3, out Com3);
                    Double.TryParse(StrComp4, out Com4);
                    Double.TryParse(StrComp5, out Com5);
                    double TotCom = Com1 + Com2 + Com3 + Com4 + Com5;


                    if (TotCom <= 0)
                    {
                        return RedirectToAction("NoCompositionEntered"); //
                    }
                    else if ((TotCom > 100 && TotCom < 200) || TotCom < 100)
                    {
                        return RedirectToAction("CompositionExceeded");
                    }
                    else if (TotCom == 100 || TotCom == 200)
                    {
                        var FabHave = "";
                        var input = fabrics.FabricId;

                        DsFAB = ComFabSam.ReturnDataset("SELECT DISTINCT FabricId FROM Fabrics WHERE FabricId LIKE '%" + input + "%'");
                        if (DsFAB.Tables[0].Rows.Count > 0)
                        {
                            FabHave = DsFAB.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
                            if (string.Equals(FabHave, input, StringComparison.CurrentCultureIgnoreCase))
                            {
                                return RedirectToAction("Exist");
                            }
                        }

                        if (User.IsInRole("MainAdmin") || (User.IsInRole("SuperAdmin")))
                        {
                            ViewBag.FacList = new SelectList(db.factories.OrderBy(f => f.FactoryName), "FactoryName", "FactoryName");
                            string FacId = Request.Form["FactoryName"].ToString();
                            DataSet DatUserMainFacId = new DataSet();
                            var UserMainSelectedFacId = "";
                            if (FacId == null || FacId == "")
                            {
                                return RedirectToAction("NoFactory");
                            }
                            else
                            {
                                DatUserMainFacId = ComFabSam.ReturnDataset("SELECT FactoryId, FactoryName FROM Factories WHERE FactoryName='" + FacId + "' ");
                                if (DatUserMainFacId.Tables[0].Rows.Count > 0)
                                {
                                    UserMainSelectedFacId = DatUserMainFacId.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
                                }
                                fabrics.FactoryId = Convert.ToInt32(UserMainSelectedFacId);
                            }
                        }

                        var composit1 = Request.Form["CompositionName1"].ToString();
                        var composit2 = Request.Form["CompositionName2"].ToString();
                        var composit3 = Request.Form["CompositionName3"].ToString();
                        var composit4 = Request.Form["CompositionName4"].ToString();
                        var composit5 = Request.Form["CompositionName5"].ToString();
                        if ((composit1 == composit2 && composit1 != "" && composit2 != "") || (composit1 == composit3 && composit3 != "") || (composit1 == composit4 && composit4 != "") || (composit1 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }
                        if ((composit2 == composit1 && composit2 != "" && composit1 != "") || (composit2 == composit3 && composit3 != "") || (composit2 == composit4 && composit4 != "") || (composit2 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }
                        if ((composit3 == composit1 && composit3 != "" && composit1 != "") || (composit3 == composit2 && composit2 != "") || (composit3 == composit4 && composit4 != "") || (composit2 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }
                        if ((composit4 == composit1 && composit4 != "" && composit1 != "") || (composit4 == composit2 && composit2 != "") || (composit4 == composit3 && composit3 != "") || (composit4 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");

                        }
                        if ((composit5 == composit1 && composit5 != "" && composit1 != "") || (composit5 == composit2 && composit2 != "") || (composit5 == composit3 && composit3 != "") || (composit5 == composit4 && composit4 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }


                        if (composit1 == "" || composit1 == "N/A" || composit1 == "n/a" || fabrics.Compisition1 == null || fabrics.Compisition1 == "0")
                        {
                            fabrics.Compisition1 = "N/A";
                        }
                        else
                        {
                            fabrics.Compisition1 = composit1 + " " + "-" + " " + fabrics.Compisition1 + "%";
                        }
                        if (composit2 == "" || composit2 == "N/A" || composit2 == "n/a" || fabrics.Compisition2 == null || fabrics.Compisition2 == "0")
                        {
                            fabrics.Compisition2 = "N/A";
                        }
                        else
                        {
                            fabrics.Compisition2 = composit2 + " " + "-" + " " + fabrics.Compisition2 + "%";
                        }
                        if (composit3 == "" || composit3 == "N/A" || composit3 == "n/a" || fabrics.Compisition3 == null || fabrics.Compisition3 == "0")
                        {
                            fabrics.Compisition3 = "N/A";
                        }
                        else
                        {
                            fabrics.Compisition3 = composit3 + " " + "-" + " " + fabrics.Compisition3 + "%";
                        }
                        if (composit4 == "" || composit4 == "N/A" || composit4 == "n/a" || fabrics.Compisition4 == null || fabrics.Compisition4 == "0")
                        {
                            fabrics.Compisition4 = "N/A";
                        }
                        else
                        {
                            fabrics.Compisition4 = composit4 + " " + "-" + " " + fabrics.Compisition4 + "%";
                        }
                        if (composit5 == "" || composit5 == "N/A" || composit5 == "n/a" || fabrics.Compisition5 == null || fabrics.Compisition5 == "0")
                        {
                            fabrics.Compisition5 = "N/A";
                        }
                        else
                        {
                            fabrics.Compisition5 = composit5 + " " + "-" + " " + fabrics.Compisition5 + "%";
                        }


                        db.fabrics.Add(fabrics);
                        db.SaveChanges();
                        if (User.IsInRole("MainAdmin"))
                        {
                            return RedirectToAction("MainAdminView");
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }

                ViewBag.ColourId = new SelectList(db.colours.OrderBy(c => c.ColourName), "ColourId", "ColourName", fabrics.ColourId);
                ViewBag.ConstructionId = new SelectList(db.constructions.OrderBy(c => c.ConstructionType), "ConstructionId", "ConstructionType", fabrics.ConstructionId);
                ViewBag.FactoryId = new SelectList(db.factories, "FactoryId", "FactoryName", fabrics.FactoryId);
                ViewBag.KnitId = new SelectList(db.knits.OrderBy(k => k.KnitType), "KnitId", "KnitType", fabrics.KnitId);
                ViewBag.LocationsId = new SelectList(db.locationss.OrderBy(l => l.LocationName), "LocationsId", "LocationName", fabrics.LocationsId);
                ViewBag.StructureId = new SelectList(db.structures.OrderBy(s => s.StructureValue), "StructureId", "StructureValue", fabrics.StructureId);
                ViewBag.SupplierId = new SelectList(db.suppliers.OrderBy(s => s.SupplierName), "SupplierId", "SupplierName", fabrics.SupplierId);
                ViewBag.YarnId = new SelectList(db.yarns.OrderBy(y => y.YarnCount), "YarnId", "YarnCount", fabrics.YarnId);
                ViewBag.FabCatoId = new SelectList(db.fabcatos.OrderBy(f => f.FabricCat), "FabCatId", "FabricCat", fabrics.FabCatoId);
                ViewBag.FinCatId = new SelectList(db.finishingCato.OrderBy(f => f.FinishCatoId), "FinishCatoId", "FinishCat");
                ViewBag.Compositions = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionId", "CompositionName");
                ViewBag.Compositions2 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions3 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions4 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions5 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                ComFabSam.exception= Convert.ToString(ex);
                ComFabSam.user = Common.UserName;
                //ComFabSam.user = Session["username"].ToString();
                ComFabSam.MailSend();
                RedirectToAction("FabricError");
            }

            return View(fabrics);

        }

        // GET: Fabrics/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            DataSet DSUser = new DataSet();
            DataSet DSFac = new DataSet();
            Common ComFAb = new Common();

           
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Fabrics fabrics = db.fabrics.Find(id);
            try
            {
                if (fabrics == null)
                {
                    return HttpNotFound();
                }

                //if (User.IsInRole("MainAdmin"))
                //{
                //    ViewBag.FacList = new SelectList(db.factories.OrderBy(f=>f.FactoryName), "FactoryName", "FactoryName");
                //    DataSet ReturnedFac = new DataSet();
                //    Common ComRetFac = new Common();
                //    ReturnedFac = ComRetFac.ReturnDataset("SELECT  Fabrics.FabricId, Fabrics.FactoryId, Factories.FactoryName  FROM Fabrics INNER JOIN Factories ON  Fabrics.FactoryId = Factories.FactoryId WHERE Fabrics.FabricsId ='" + fabrics.FabricsId + "'");
                //    var FabricFactoryName = "";
                //    if (ReturnedFac.Tables[0].Rows.Count > 0) {
                //        FabricFactoryName = ReturnedFac.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                //    }
                //    ViewBag.FabricFac = FabricFactoryName;
                //}
                ViewBag.ColourId = new SelectList(db.colours.OrderBy(c => c.ColourName), "ColourId", "ColourName", fabrics.ColourId);
                ViewBag.ConstructionId = new SelectList(db.constructions.OrderBy(c => c.ConstructionType), "ConstructionId", "ConstructionType", fabrics.ConstructionId);
                ViewBag.FactoryId = new SelectList(db.factories, "FactoryId", "FactoryName", fabrics.FactoryId);
                ViewBag.KnitId = new SelectList(db.knits.OrderBy(k => k.KnitType), "KnitId", "KnitType", fabrics.KnitId);
                ViewBag.LocationsId = new SelectList(db.locationss.OrderBy(l => l.LocationName), "LocationsId", "LocationName", fabrics.LocationsId);
                ViewBag.StructureId = new SelectList(db.structures.OrderBy(s => s.StructureValue), "StructureId", "StructureValue", fabrics.StructureId);
                ViewBag.SupplierId = new SelectList(db.suppliers.OrderBy(s => s.SupplierName), "SupplierId", "SupplierName", fabrics.SupplierId);
                ViewBag.YarnId = new SelectList(db.yarns.OrderBy(y => y.YarnCount), "YarnId", "YarnCount", fabrics.YarnId);
                ViewBag.FabCatoId = new SelectList(db.fabcatos.OrderBy(f => f.FabricCat), "FabCatoId", "FabricCat", fabrics.FabCatoId);
                ViewBag.FinCatId = new SelectList(db.finishingCato.OrderBy(f => f.FinishCatoId), "FinishCatoId", "FinishCat");
                ViewBag.Compositions = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions2 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions3 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions4 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions5 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                //if (User.IsInRole("MainAdmin"))
                //{
                //    Fabrics fab = new Fabrics();
                //    var facId = "";
                //    // fab.FactoryId = fab.FactoryId;
                //    ViewBag.Factorynewid = fab.FactoryId;
                //    DSFac = ComFAb.ReturnDataset("SELECT FabricsId, FactoryId FROM Fabrics WHERE FabricsId ='" + fab.FabricId + "' ");
                //    if (DSFac.Tables[0].Rows.Count > 0)
                //    {
                //        facId = DSFac.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                //    }
                //    ViewBag.Factorynewid = facId;
                //}
                //if (User.IsInRole("MainAdmin")==false)
                //{

                //    var UserName = Session["username"].ToString();
                //    var FacName = "";
                //    DSUser = ComFAb.ReturnDataset("SELECT Email, UserName, FactoryId FROM AspNetUsers WHERE UserName ='" + UserName + "'");
                //    if (DSUser.Tables[0].Rows.Count > 0)
                //    {
                //        FacName = DSUser.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                //    }
                //    DSFac = ComFAb.ReturnDataset("SELECT FactoryId, FactoryName FROM Factories WHERE FactoryName = '" + FacName + "'");
                //    var Factorynewid = "";
                //    if (DSFac.Tables[0].Rows.Count > 0)
                //    {
                //        Factorynewid = DSFac.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
                //    }
                //    ViewBag.Factorynewid = Factorynewid;
                //}
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                ComFabSam.exception = Convert.ToString(ex);
                ComFabSam.user = Common.UserName;
                //ComFabSam.user = Session["username"].ToString();
                ComFabSam.MailSend();
                RedirectToAction("FabricError");
                //throw;
            }
            return View(fabrics);
        }

        // POST: Fabrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FabricsId,FabricId,SupplierId,Compisition1,Compisition2,Compisition3,Compisition4,Compisition5,Quality,ConstructionId,YarnId,WidthInches,WidthCm,AddedDate,Weight,Price,LocationsId,KnitId,StructureId,ColourId,FactoryId,Fac,FabCatoId,FinishCatoId,Remarks")] Fabrics fabrics)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            try
            {
                if (ModelState.IsValid)
                {
                    string StrComp1 = fabrics.Compisition1;
                    string StrComp2 = fabrics.Compisition2;
                    string StrComp3 = fabrics.Compisition3;
                    string StrComp4 = fabrics.Compisition4;
                    string StrComp5 = fabrics.Compisition5;
                    double Com1;
                    double Com2;
                    double Com3;
                    double Com4;
                    double Com5;
                    Double.TryParse(StrComp1, out Com1);//converting string compositions to Double
                    Double.TryParse(StrComp2, out Com2);
                    Double.TryParse(StrComp3, out Com3);
                    Double.TryParse(StrComp4, out Com4);
                    Double.TryParse(StrComp5, out Com5);
                    double TotCom = Com1 + Com2 + Com3 + Com4 + Com5;// checks values in composition textboxes

                    DataSet DatCompo = new DataSet();
                    Common ComCompo = new Common();
                    var RetCom1 = "";
                    var RetCom2 = "";
                    var RetCom3 = "";
                    var RetCom4 = "";
                    var RetCom5 = "";
                    //Return compositions already saved in DB
                    DatCompo = ComCompo.ReturnDataset("SELECT FabricId,Compisition1,Compisition2,Compisition3,Compisition4,Compisition5 FROM Fabrics WHERE FabricId = '" + fabrics.FabricId + "'");
                    if (DatCompo.Tables[0].Rows.Count > 0)
                    {
                        RetCom1 = DatCompo.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                        RetCom2 = DatCompo.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                        RetCom3 = DatCompo.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
                        RetCom4 = DatCompo.Tables[0].Rows[0].ItemArray.GetValue(4).ToString();
                        RetCom5 = DatCompo.Tables[0].Rows[0].ItemArray.GetValue(5).ToString();
                    }
                    //Below code returns all the numbers in a string
                    //var checkCompoPresentage1 = string.Join(string.Empty, Regex.Matches(RetCom1, @"\d+").OfType<Match>().Select(comp1 => comp1.Value));

                    var checkCompoPresentage1 = Regex.Match(RetCom1, @"\d+").Value;//Returns all the numbers in the string
                    double CheckCompoPreStr1;
                    Double.TryParse(checkCompoPresentage1, out CheckCompoPreStr1);

                    var checkCompoPresentage2 = Regex.Match(RetCom2, @"\d+").Value;//Returns the numbers which appear first in a string
                    double CheckCompoPreStr2;
                    Double.TryParse(checkCompoPresentage2, out CheckCompoPreStr2);

                    var checkCompoPresentage3 = Regex.Match(RetCom3, @"\d+").Value;
                    double CheckCompoPreStr3;
                    Double.TryParse(checkCompoPresentage3, out CheckCompoPreStr3);

                    var checkCompoPresentage4 = Regex.Match(RetCom4, @"\d+").Value;
                    double CheckCompoPreStr4;
                    Double.TryParse(checkCompoPresentage4, out CheckCompoPreStr4);

                    var checkCompoPresentage5 = Regex.Match(RetCom5, @"\d+").Value;
                    double CheckCompoPreStr5;
                    Double.TryParse(checkCompoPresentage5, out CheckCompoPreStr5);

                    double CheckedCompoPresentage = CheckCompoPreStr1 + CheckCompoPreStr2 + CheckCompoPreStr3 + CheckCompoPreStr4 + CheckCompoPreStr5;

                    var ToatlAfterEdit = TotCom + CheckedCompoPresentage;
                    //if (ToatlAfterEdit > 100 || ToatlAfterEdit < 100)
                    //{
                    //    return RedirectToAction("CompositionExceeded");
                    //}
                    if (CheckedCompoPresentage <= 0)
                    {
                        return RedirectToAction("NoCompositionEntered");
                    }

                    if (CheckedCompoPresentage > 100 || CheckedCompoPresentage < 0 || TotCom > 100)//TotCom<0|| 
                    {
                        return RedirectToAction("CompositionExceeded");
                    }
                    else
                    {
                        //if (User.IsInRole("MainAdmin"))
                        //{
                        //    ViewBag.FacList = new SelectList(db.factories.OrderBy(f => f.FactoryName), "FactoryName", "FactoryName");
                        //    string FacId = Request.Form["FactoryName"].ToString();
                        //    DataSet DatUserMainFacId = new DataSet();
                        //    var UserMainSelectedFacId = "";
                        //    DatUserMainFacId = ComFabSam.ReturnDataset("SELECT FactoryId, FactoryName FROM Factories WHERE FactoryName='" + FacId + "' ");
                        //    if (DatUserMainFacId.Tables[0].Rows.Count > 0)
                        //    {
                        //        UserMainSelectedFacId = DatUserMainFacId.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
                        //    }
                        //    fabrics.FactoryId = Convert.ToInt32(UserMainSelectedFacId);
                        //   // DatUserMainFacId = ComFabSam.ReturnDataset("SELECT  Fabrics.FabricId, Fabrics.FactoryId, Factories.FactoryName  FROM Fabrics INNER JOIN Factories ON  Fabrics.FactoryId = Factories.FactoryId WHERE ");
                        //}


                        var composit1 = Request.Form["CompositionName1"].ToString();//Return Compositions in Composition Dropdowns
                        var composit2 = Request.Form["CompositionName2"].ToString();
                        var composit3 = Request.Form["CompositionName3"].ToString();
                        var composit4 = Request.Form["CompositionName4"].ToString();
                        var composit5 = Request.Form["CompositionName5"].ToString();

                        if ((composit1 == composit2 && composit1 != "" && composit2 != "") || (composit1 == composit3 && composit3 != "") || (composit1 == composit4 && composit4 != "") || (composit1 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }
                        if ((composit2 == composit1 && composit2 != "" && composit1 != "") || (composit2 == composit3 && composit3 != "") || (composit2 == composit4 && composit4 != "") || (composit2 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }
                        if ((composit3 == composit1 && composit3 != "" && composit1 != "") || (composit3 == composit2 && composit2 != "") || (composit3 == composit4 && composit4 != "") || (composit2 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }
                        if ((composit4 == composit1 && composit4 != "" && composit1 != "") || (composit4 == composit2 && composit2 != "") || (composit4 == composit3 && composit3 != "") || (composit4 == composit5 && composit5 != ""))
                        {
                            return RedirectToAction("CompositionSelected");

                        }
                        if ((composit5 == composit1 && composit5 != "" && composit1 != "") || (composit5 == composit2 && composit2 != "") || (composit5 == composit3 && composit3 != "") || (composit5 == composit4 && composit4 != ""))
                        {
                            return RedirectToAction("CompositionSelected");
                        }

                        if (composit1 == "" || composit1 == "N/A" || composit1 == "n/a" || fabrics.Compisition1 == null || fabrics.Compisition1 == "0")
                        {
                            fabrics.Compisition1 = RetCom1;
                        }
                        else
                        {
                            fabrics.Compisition1 = composit1 + " " + "-" + " " + fabrics.Compisition1 + "%";
                        }
                        if (composit2 == "" || composit2 == "N/A" || composit2 == "n/a" || fabrics.Compisition2 == null || fabrics.Compisition2 == "0")
                        {
                            fabrics.Compisition2 = RetCom2;
                        }
                        else
                        {
                            fabrics.Compisition2 = composit2 + " " + "-" + " " + fabrics.Compisition2 + "%";
                        }
                        if (composit3 == "" || composit3 == "N/A" || composit3 == "n/a" || fabrics.Compisition3 == null || fabrics.Compisition3 == "0")
                        {
                            fabrics.Compisition3 = RetCom3;
                        }
                        else
                        {
                            fabrics.Compisition3 = composit3 + " " + "-" + " " + fabrics.Compisition3 + "%";
                        }
                        if (composit4 == "" || composit4 == "N/A" || composit4 == "n/a" || fabrics.Compisition4 == null || fabrics.Compisition4 == "0")
                        {
                            fabrics.Compisition4 = RetCom4;
                        }
                        else
                        {
                            fabrics.Compisition4 = composit4 + " " + "-" + " " + fabrics.Compisition4 + "%";
                        }
                        if (composit5 == "" || composit5 == "N/A" || composit5 == "n/a" || fabrics.Compisition5 == null || fabrics.Compisition5 == "0")
                        {
                            fabrics.Compisition5 = RetCom5;
                        }
                        else
                        {
                            fabrics.Compisition5 = composit5 + " " + "-" + " " + fabrics.Compisition5 + "%";
                        }
                        if (User.IsInRole("MainAdmin"))
                        {
                            DataSet DSFac = new DataSet();
                            Common ComFAb = new Common();
                            Fabrics fab = new Fabrics();
                            var facId = "";
                            ViewBag.Factorynewid = fab.FactoryId;
                            DSFac = ComFAb.ReturnDataset("SELECT FabricsId, FactoryId FROM Fabrics WHERE FabricsId ='" + fab.FabricId + "' ");
                            if (DSFac.Tables[0].Rows.Count > 0)
                            {
                                facId = DSFac.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                            }
                            ViewBag.Factorynewid = facId;//Assign factory ID
                        }

                        db.Entry(fabrics).State = EntityState.Modified;
                        db.SaveChanges();
                        if (User.IsInRole("MainAdmin"))
                        {
                            return RedirectToAction("MainAdminView");
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                ViewBag.ColourId = new SelectList(db.colours.OrderBy(c => c.ColourName), "ColourId", "ColourName", fabrics.ColourId);
                ViewBag.ConstructionId = new SelectList(db.constructions.OrderBy(c => c.ConstructionType), "ConstructionId", "ConstructionType", fabrics.ConstructionId);
                ViewBag.FactoryId = new SelectList(db.factories, "FactoryId", "FactoryName", fabrics.FactoryId);
                ViewBag.KnitId = new SelectList(db.knits.OrderBy(k => k.KnitType), "KnitId", "KnitType", fabrics.KnitId);
                ViewBag.LocationsId = new SelectList(db.locationss.OrderBy(l => l.LocationName), "LocationsId", "LocationName", fabrics.LocationsId);
                ViewBag.StructureId = new SelectList(db.structures.OrderBy(s => s.StructureValue), "StructureId", "StructureValue", fabrics.StructureId);
                ViewBag.SupplierId = new SelectList(db.suppliers.OrderBy(s => s.SupplierName), "SupplierId", "SupplierName", fabrics.SupplierId);
                ViewBag.YarnId = new SelectList(db.yarns.OrderBy(y => y.YarnCount), "YarnId", "YarnCount", fabrics.YarnId);
                ViewBag.FabCatoId = new SelectList(db.fabcatos.OrderBy(f => f.FabricCat), "FabCatoId", "FabricCat", fabrics.FabCatoId);
                ViewBag.FinCatId = new SelectList(db.finishingCato.OrderBy(f => f.FinishCatoId), "FinishCatoId", "FinishCat",fabrics.FinishCatoId);
                ViewBag.Compositions = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionId", "CompositionName");
                ViewBag.Compositions2 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions3 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions4 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
                ViewBag.Compositions5 = new SelectList(db.compositions.OrderBy(c => c.CompositionName), "CompositionName", "CompositionName");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                ComFabSam.exception = Convert.ToString(ex);
                ComFabSam.user = Common.UserName;
                //ComFabSam.user = Session["username"].ToString();
                ComFabSam.MailSend();
                RedirectToAction("FabricError");
                //throw;
            }
            return View(fabrics);
        }

        // GET: Fabrics/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Fabrics fabrics = db.fabrics.Find(id);
            try
            {
                if (fabrics == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                ComFabSam.exception = Convert.ToString(ex);
                ComFabSam.user = Common.UserName;
                //ComFabSam.user = Session["username"].ToString();
                ComFabSam.MailSend();
                RedirectToAction("FabricError");
                //throw;
            }
            return View(fabrics);
        }

        // POST: Fabrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fabrics fabrics = db.fabrics.Find(id);
            try
            {
                db.fabrics.Remove(fabrics);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                ComFabSam.exception = Convert.ToString(ex);
                ComFabSam.user = Common.UserName;
                //ComFabSam.user = Session["username"].ToString();
                ComFabSam.MailSend();
                RedirectToAction("FabricError");
                //throw;
            }
            if (User.IsInRole("MainAdmin"))
            {
                return RedirectToAction("MainAdminView");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void MailSend()
        {

        }
    }
}
