using System;

using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace CMFLMS.Reports
{
    public partial class FabricReport : System.Web.UI.Page
    {
        Common FabRe = new Common();
        DataSet Fac = new DataSet();
      //  string FactoryPara="All Factories";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Fac = FabRe.ReturnDataset("SELECT FactoryId, FactoryName FROM Factories");
                ddlFactory.DataValueField = "FactoryId";
                ddlFactory.DataTextField = "FactoryName";
                ddlFactory.DataSource = Fac.Tables[0];
                ddlFactory.DataBind();
                ddlFactory.Items.Insert(0, "ALL");
            }
            //try
            //{
                //if (User.IsInRole("MainAdmin"))
                //{
                //    string FabricData = "SELECT dbo.Fabrics.FabricId, dbo.Suppliers.SupplierName AS Supplier, dbo.Fabrics.Quality, dbo.Fabrics.Compisition1, dbo.Fabrics.Compisition2, dbo.Fabrics.Compisition3, dbo.Fabrics.Compisition4, dbo.Fabrics.Compisition5, " +
                //          "dbo.Constructions.ConstructionType AS Construction, dbo.Yarns.YarnCount, dbo.Fabrics.WidthInches, dbo.Fabrics.WidthCm, dbo.Fabrics.AddedDate, dbo.Fabrics.Weight, dbo.Fabrics.Price, dbo.Locations.LocationName AS Location, " +
                //          "dbo.Knits.KnitType AS Knit, dbo.Structures.StructureValue AS Structure, dbo.Colours.ColourName AS Colour, dbo.Factories.FactoryName AS Factory, dbo.FabCatoes.FabricCat AS FabricCategory, dbo.Fabrics.Remarks " +
                //          "FROM     dbo.Colours INNER JOIN " +
                //          "dbo.Fabrics ON dbo.Colours.ColourId = dbo.Fabrics.ColourId INNER JOIN " +
                //          "dbo.Constructions ON dbo.Fabrics.ConstructionId = dbo.Constructions.ConstructionId INNER JOIN " +
                //          "dbo.FabCatoes ON dbo.Fabrics.FabCatoId = dbo.FabCatoes.FabCatoId INNER JOIN " +
                //          "dbo.Factories ON dbo.Fabrics.FactoryId = dbo.Factories.FactoryId INNER JOIN " +
                //          "dbo.Knits ON dbo.Fabrics.KnitId = dbo.Knits.KnitId INNER JOIN " +
                //          "dbo.Locations ON dbo.Fabrics.LocationsId = dbo.Locations.LocationsId INNER JOIN " +
                //          "dbo.Structures ON dbo.Fabrics.StructureId = dbo.Structures.StructureId INNER JOIN " +
                //          "dbo.Suppliers ON dbo.Fabrics.SupplierId = dbo.Suppliers.SupplierId INNER JOIN " +
                //          "dbo.Yarns ON dbo.Fabrics.YarnId = dbo.Yarns.YarnId";

                //    rvFabrics.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //    rvFabrics.LocalReport.ReportPath = Server.MapPath("/Reports/FabricReportWizard.rdlc");
                //    FabricReportDS fabricListData = GetFabricData(FabricData);
                //    ReportDataSource RptSource = new ReportDataSource("FabricReportDS", fabricListData.Tables[0]);
                //    rvFabrics.LocalReport.DataSources.Clear();
                //    rvFabrics.LocalReport.DataSources.Add(RptSource);

                //    ReportParameter Factory = new ReportParameter("FactoryName", FactoryPara);
                //    this.rvFabrics.LocalReport.SetParameters(new ReportParameter[] { Factory });
                //}
                //else
                //{
                //    var name = Common.UserName;
                //    //var name = Session["username"].ToString();

                //    Fac = FabRe.ReturnDataset("SELECT UserName, FactoryId FROM UsersWithFactories WHERE UserName ='" + name + "'");
                //    if (Fac.Tables[0].Rows.Count > 0)
                //    {
                //        FactoryPara = Fac.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                //    }

                //    string FabricData = "SELECT dbo.Fabrics.FabricId, dbo.Suppliers.SupplierName AS Supplier, dbo.Fabrics.Quality, dbo.Fabrics.Compisition1, dbo.Fabrics.Compisition2, dbo.Fabrics.Compisition3, dbo.Fabrics.Compisition4, dbo.Fabrics.Compisition5, " +
                //          "dbo.Constructions.ConstructionType AS Construction, dbo.Yarns.YarnCount, dbo.Fabrics.WidthInches, dbo.Fabrics.WidthCm, dbo.Fabrics.AddedDate, dbo.Fabrics.Weight, dbo.Fabrics.Price, dbo.Locations.LocationName AS Location, " +
                //          "dbo.Knits.KnitType AS Knit, dbo.Structures.StructureValue AS Structure, dbo.Colours.ColourName AS Colour, dbo.Factories.FactoryName AS Factory, dbo.FabCatoes.FabricCat AS FabricCategory, dbo.Fabrics.Remarks " +
                //          "FROM     dbo.Colours INNER JOIN " +
                //          "dbo.Fabrics ON dbo.Colours.ColourId = dbo.Fabrics.ColourId INNER JOIN " +
                //          "dbo.Constructions ON dbo.Fabrics.ConstructionId = dbo.Constructions.ConstructionId INNER JOIN " +
                //          "dbo.FabCatoes ON dbo.Fabrics.FabCatoId = dbo.FabCatoes.FabCatoId INNER JOIN " +
                //          "dbo.Factories ON dbo.Fabrics.FactoryId = dbo.Factories.FactoryId INNER JOIN " +
                //          "dbo.Knits ON dbo.Fabrics.KnitId = dbo.Knits.KnitId INNER JOIN " +
                //          "dbo.Locations ON dbo.Fabrics.LocationsId = dbo.Locations.LocationsId INNER JOIN " +
                //          "dbo.Structures ON dbo.Fabrics.StructureId = dbo.Structures.StructureId INNER JOIN " +
                //          "dbo.Suppliers ON dbo.Fabrics.SupplierId = dbo.Suppliers.SupplierId INNER JOIN " +
                //          "dbo.Yarns ON dbo.Fabrics.YarnId = dbo.Yarns.YarnId " +
                //          "WHERE dbo.Factories.FactoryName = '" + FactoryPara + "'";
                //    rvFabrics.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //    rvFabrics.LocalReport.ReportPath = Server.MapPath("/Reports/FabricReportWizard.rdlc");
                //    FabricReportDS fabricListData = GetFabricData(FabricData);
                //    ReportDataSource RptSource = new ReportDataSource("FabricReportDS", fabricListData.Tables[0]);
                //    rvFabrics.LocalReport.DataSources.Clear();
                //    rvFabrics.LocalReport.DataSources.Add(RptSource);

                //    ReportParameter Factory = new ReportParameter("FactoryName", FactoryPara);
                //    this.rvFabrics.LocalReport.SetParameters(new ReportParameter[] { Factory });
                //}
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('Error: Please Try Again or Inform the System Administrator')</script>");
                
            //}
        }
        private FabricReportDS GetFabricData(string FabricData)
        {
            string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            if ((con.ToLower().StartsWith("metadata=")))
            {
                EntityConnectionStringBuilder RefineCon = new EntityConnectionStringBuilder(con);
                con = RefineCon.ProviderConnectionString;
            }
            string fabCon = con;
            SqlCommand cmd = new SqlCommand(FabricData);
            using (SqlConnection sqlCon = new SqlConnection(fabCon))
            {
                using (SqlDataAdapter adap = new SqlDataAdapter())
                {
                    cmd.Connection = sqlCon;
                    adap.SelectCommand = cmd;
                    using (FabricReportDS fabricData = new FabricReportDS())
                    {
                        adap.Fill(fabricData, "FabricReportDS");
                        return fabricData;

                    }
                }
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(ddlFactory.SelectedValue) >= 0)
                //{
                    string FabricData;
                    string FactoryPara = ddlFactory.SelectedItem.Text;
                    string FactoryId = ddlFactory.SelectedValue;
                    //  string FabricData = "SELECT dbo.Fabrics.FabricId, dbo.Suppliers.SupplierName AS Supplier, dbo.Fabrics.Quality, dbo.Fabrics.Compisition1, dbo.Fabrics.Compisition2, dbo.Fabrics.Compisition3, dbo.Fabrics.Compisition4, dbo.Fabrics.Compisition5, " +
                    //"dbo.Constructions.ConstructionType AS Construction, dbo.Yarns.YarnCount, dbo.Fabrics.WidthInches, dbo.Fabrics.WidthCm, dbo.Fabrics.AddedDate, dbo.Fabrics.Weight, dbo.Fabrics.Price, dbo.Locations.LocationName AS Location, " +
                    //"dbo.Knits.KnitType AS Knit, dbo.Structures.StructureValue AS Structure, dbo.Colours.ColourName AS Colour, dbo.Factories.FactoryName AS Factory, dbo.FabCatoes.FabricCat AS FabricCategory, dbo.Fabrics.Remarks, " +
                    //"dbo.FinishCatoes.FinishCat AS FinishingCategory " +
                    //"FROM     dbo.Colours INNER JOIN " +
                    //"dbo.Fabrics ON dbo.Colours.ColourId = dbo.Fabrics.ColourId INNER JOIN " +
                    //"dbo.Constructions ON dbo.Fabrics.ConstructionId = dbo.Constructions.ConstructionId INNER JOIN " +
                    //"dbo.FabCatoes ON dbo.Fabrics.FabCatoId = dbo.FabCatoes.FabCatoId INNER JOIN " +
                    //"dbo.Factories ON dbo.Fabrics.FactoryId = dbo.Factories.FactoryId INNER JOIN " +
                    //"dbo.Knits ON dbo.Fabrics.KnitId = dbo.Knits.KnitId INNER JOIN " +
                    //"dbo.Locations ON dbo.Fabrics.LocationsId = dbo.Locations.LocationsId INNER JOIN " +
                    //"dbo.Structures ON dbo.Fabrics.StructureId = dbo.Structures.StructureId INNER JOIN " +
                    //"dbo.Suppliers ON dbo.Fabrics.SupplierId = dbo.Suppliers.SupplierId INNER JOIN " +
                    //"dbo.Yarns ON dbo.Fabrics.YarnId = dbo.Yarns.YarnId INNER JOIN " +
                    //"dbo.FinishCatoes ON dbo.Fabrics.FinishCatoId = dbo.FinishCatoes.FinishCatoId " +
                    //"WHERE(dbo.Factories.FactoryId = '" + ddlFactory.SelectedValue + "')";
                    if (FactoryId != "ALL")
                    {
                        FabricData = "SELECT dbo.Fabrics.FabricId, dbo.Suppliers.SupplierName AS Supplier, dbo.Fabrics.Quality, dbo.Fabrics.Compisition1, dbo.Fabrics.Compisition2, dbo.Fabrics.Compisition3, dbo.Fabrics.Compisition4, dbo.Fabrics.Compisition5, " +
                                                      "dbo.Constructions.ConstructionType AS Construction, dbo.Yarns.YarnCount, dbo.Fabrics.WidthInches, dbo.Fabrics.WidthCm, dbo.Fabrics.AddedDate, dbo.Fabrics.Weight, dbo.Fabrics.Price, dbo.Locations.LocationName AS Location,  " +
                                                      "dbo.Knits.KnitType AS Knit, dbo.Structures.StructureValue AS Structure, dbo.Colours.ColourName AS Colour, dbo.Factories.FactoryName AS Factory, dbo.FabCatoes.FabricCat AS FabricCategory, dbo.Fabrics.Remarks, " +
                                                      "dbo.FinishCatoes.FinishCat AS FinishingCategory, dbo.Fabrics.SourcingRoute, dbo.Fabrics.LeadTime, dbo.Fabrics.SustainableProduct, dbo.Fabrics.YarnGuage, dbo.SourcingTypes.SourcingTypeName, " +
                                                      "dbo.ProductCatagories.ProductCatagoryName " +
                                    "FROM     dbo.Colours INNER JOIN " +
                                                      "dbo.Fabrics ON dbo.Colours.ColourId = dbo.Fabrics.ColourId INNER JOIN " +
                                                      "dbo.Constructions ON dbo.Fabrics.ConstructionId = dbo.Constructions.ConstructionId INNER JOIN " +
                                                      "dbo.FabCatoes ON dbo.Fabrics.FabCatoId = dbo.FabCatoes.FabCatoId INNER JOIN " +
                                                      "dbo.Factories ON dbo.Fabrics.FactoryId = dbo.Factories.FactoryId INNER JOIN " +
                                                      "dbo.Knits ON dbo.Fabrics.KnitId = dbo.Knits.KnitId INNER JOIN " +
                                                      "dbo.Locations ON dbo.Fabrics.LocationsId = dbo.Locations.LocationsId INNER JOIN " +
                                                      "dbo.Structures ON dbo.Fabrics.StructureId = dbo.Structures.StructureId INNER JOIN " +
                                                      "dbo.Suppliers ON dbo.Fabrics.SupplierId = dbo.Suppliers.SupplierId INNER JOIN " +
                                                      "dbo.Yarns ON dbo.Fabrics.YarnId = dbo.Yarns.YarnId INNER JOIN " +
                                                      "dbo.FinishCatoes ON dbo.Fabrics.FinishCatoId = dbo.FinishCatoes.FinishCatoId INNER JOIN " +
                                                      "dbo.ProductCatagories ON dbo.Fabrics.ProductCatagoryId = dbo.ProductCatagories.ProductCatagoryId INNER JOIN " +
                                                      "dbo.SourcingTypes ON dbo.Fabrics.SourcingTypeId = dbo.SourcingTypes.SourcingTypeId " +
                                    "WHERE  (dbo.Factories.FactoryId = '" + FactoryId + "') AND (dbo.Fabrics.IsDeleted = 0) " +
                                    "ORDER BY dbo.Fabrics.FabricId";
                    }
                    else
                    {
                        FabricData = "SELECT dbo.Fabrics.FabricId, dbo.Suppliers.SupplierName AS Supplier, dbo.Fabrics.Quality, dbo.Fabrics.Compisition1, dbo.Fabrics.Compisition2, dbo.Fabrics.Compisition3, dbo.Fabrics.Compisition4, dbo.Fabrics.Compisition5, " +
                                                      "dbo.Constructions.ConstructionType AS Construction, dbo.Yarns.YarnCount, dbo.Fabrics.WidthInches, dbo.Fabrics.WidthCm, dbo.Fabrics.AddedDate, dbo.Fabrics.Weight, dbo.Fabrics.Price, dbo.Locations.LocationName AS Location,  " +
                                                      "dbo.Knits.KnitType AS Knit, dbo.Structures.StructureValue AS Structure, dbo.Colours.ColourName AS Colour, dbo.Factories.FactoryName AS Factory, dbo.FabCatoes.FabricCat AS FabricCategory, dbo.Fabrics.Remarks, " +
                                                      "dbo.FinishCatoes.FinishCat AS FinishingCategory, dbo.Fabrics.SourcingRoute, dbo.Fabrics.LeadTime, dbo.Fabrics.SustainableProduct, dbo.Fabrics.YarnGuage, dbo.SourcingTypes.SourcingTypeName, " +
                                                      "dbo.ProductCatagories.ProductCatagoryName " +
                                    "FROM     dbo.Colours INNER JOIN " +
                                                      "dbo.Fabrics ON dbo.Colours.ColourId = dbo.Fabrics.ColourId INNER JOIN " +
                                                      "dbo.Constructions ON dbo.Fabrics.ConstructionId = dbo.Constructions.ConstructionId INNER JOIN " +
                                                      "dbo.FabCatoes ON dbo.Fabrics.FabCatoId = dbo.FabCatoes.FabCatoId INNER JOIN " +
                                                      "dbo.Factories ON dbo.Fabrics.FactoryId = dbo.Factories.FactoryId INNER JOIN " +
                                                      "dbo.Knits ON dbo.Fabrics.KnitId = dbo.Knits.KnitId INNER JOIN " +
                                                      "dbo.Locations ON dbo.Fabrics.LocationsId = dbo.Locations.LocationsId INNER JOIN " +
                                                      "dbo.Structures ON dbo.Fabrics.StructureId = dbo.Structures.StructureId INNER JOIN " +
                                                      "dbo.Suppliers ON dbo.Fabrics.SupplierId = dbo.Suppliers.SupplierId INNER JOIN " +
                                                      "dbo.Yarns ON dbo.Fabrics.YarnId = dbo.Yarns.YarnId INNER JOIN " +
                                                      "dbo.FinishCatoes ON dbo.Fabrics.FinishCatoId = dbo.FinishCatoes.FinishCatoId INNER JOIN " +
                                                      "dbo.ProductCatagories ON dbo.Fabrics.ProductCatagoryId = dbo.ProductCatagories.ProductCatagoryId INNER JOIN " +
                                                      "dbo.SourcingTypes ON dbo.Fabrics.SourcingTypeId = dbo.SourcingTypes.SourcingTypeId " +
                                    "WHERE (dbo.Fabrics.IsDeleted = 0) " +
                                    "ORDER BY dbo.Fabrics.FabricId";
                    }
                   
                    rvFabrics.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    rvFabrics.LocalReport.ReportPath = Server.MapPath("/Reports/FabricReportWizard.rdlc");
                    FabricReportDS fabricListData = GetFabricData(FabricData);
                    ReportDataSource RptSource = new ReportDataSource("FabricReportDS", fabricListData.Tables[0]);
                    rvFabrics.LocalReport.DataSources.Clear();
                    rvFabrics.LocalReport.DataSources.Add(RptSource);

                    ReportParameter Factory = new ReportParameter("FactoryName", FactoryPara);
                    this.rvFabrics.LocalReport.SetParameters(new ReportParameter[] { Factory });
                //}
                //else
                //{
                //    lblMessage.InnerText = "Select a Factory";
                //}
            }
            catch (Exception ex)
            {
                lblMessage.InnerText = ex.Message.ToString();
            }
        }

        protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.InnerText = "";
        }
    }
}