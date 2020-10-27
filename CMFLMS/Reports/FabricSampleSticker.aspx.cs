using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMFLMS.Reports
{
    public partial class FabricSampleSticker : System.Web.UI.Page
    {
        Common FabRe = new Common();
        DataSet Fac = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Fac = FabRe.ReturnDataset("SELECT DISTINCT dbo.Fabrics.FabricsId,dbo.Fabrics.FabricId FROM     dbo.Fabrics WHERE(dbo.Fabrics.IsDeleted = 0) ORDER BY dbo.Fabrics.FabricId");
                ddlFabricId.DataValueField = "FabricsId";
                ddlFabricId.DataTextField = "FabricId";
                ddlFabricId.DataSource = Fac.Tables[0];
                ddlFabricId.DataBind();
            }
        }

        private FabricSticker GetFabricStickerData(string FabricData)
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
                    using (FabricSticker fabricData = new FabricSticker())
                    {
                        adap.Fill(fabricData, "FabricSticker");
                        return fabricData;

                    }
                }
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                
                string FabricData;
                string FactoryPara = ddlFabricId.SelectedItem.Text;
                int id = Convert.ToInt32(ddlFabricId.SelectedValue);


                FabricData = "SELECT dbo.Fabrics.FabricId, dbo.Fabrics.Quality, (dbo.Fabrics.Compisition1+' | '+ dbo.Fabrics.Compisition2+' | '+ dbo.Fabrics.Compisition3+' | '+ dbo.Fabrics.Compisition4) AS Composition, dbo.Suppliers.SupplierName AS Supplier, dbo.Colours.ColourName AS Colour, " +
                                                  "dbo.Constructions.ConstructionType AS Construction, dbo.Yarns.YarnCount AS Yarn, dbo.Fabrics.WidthInches, dbo.Fabrics.WidthCm, dbo.Fabrics.Weight, dbo.Fabrics.Price, dbo.Fabrics.AddedDate, dbo.Locations.LocationName AS Location, dbo.Knits.KnitType AS Knit, " +
                                                  "dbo.Structures.StructureValue AS Structure, dbo.Factories.FactoryName AS Factory, dbo.FabCatoes.FabricCat AS FabricCatagory, dbo.Fabrics.Remarks, dbo.FinishCatoes.FinishCat AS FinishingCatagory, dbo.Fabrics.SourcingRoute, dbo.SourcingTypes.SourcingTypeName AS SourcingType, dbo.Fabrics.LeadTime, " +
                                                  "dbo.Fabrics.SustainableProduct, dbo.Fabrics.YarnGuage, dbo.ProductCatagories.ProductCatagoryName AS ProductCatagory " +
                                "FROM     dbo.Fabrics INNER JOIN " +
                                                  "dbo.Suppliers ON dbo.Fabrics.SupplierId = dbo.Suppliers.SupplierId INNER JOIN " +
                                                  "dbo.Colours ON dbo.Fabrics.ColourId = dbo.Colours.ColourId INNER JOIN " +
                                                  "dbo.Constructions ON dbo.Fabrics.ConstructionId = dbo.Constructions.ConstructionId INNER JOIN " +
                                                  "dbo.Yarns ON dbo.Fabrics.YarnId = dbo.Yarns.YarnId INNER JOIN " +
                                                  "dbo.Locations ON dbo.Fabrics.LocationsId = dbo.Locations.LocationsId INNER JOIN " +
                                                  "dbo.Knits ON dbo.Fabrics.KnitId = dbo.Knits.KnitId INNER JOIN " +
                                                  "dbo.Structures ON dbo.Fabrics.StructureId = dbo.Structures.StructureId INNER JOIN " +
                                                  "dbo.Factories ON dbo.Fabrics.FactoryId = dbo.Factories.FactoryId INNER JOIN " +
                                                  "dbo.FabCatoes ON dbo.Fabrics.FabCatoId = dbo.FabCatoes.FabCatoId INNER JOIN " +
                                                  "dbo.FinishCatoes ON dbo.Fabrics.FinishCatoId = dbo.FinishCatoes.FinishCatoId INNER JOIN " +
                                                  "dbo.SourcingTypes ON dbo.Fabrics.SourcingTypeId = dbo.SourcingTypes.SourcingTypeId INNER JOIN " +
                                                  "dbo.ProductCatagories ON dbo.Fabrics.ProductCatagoryId = dbo.ProductCatagories.ProductCatagoryId " +
                               "WHERE(dbo.Fabrics.IsDeleted = 0) AND(dbo.Fabrics.FabricsId = " + id + ")";
                

                rvFabrics.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                rvFabrics.LocalReport.ReportPath = Server.MapPath("/Reports/FabricSticker.rdlc");
                FabricSticker fabricListData = GetFabricStickerData(FabricData);
                ReportDataSource RptSource = new ReportDataSource("FabricSticker", fabricListData.Tables[0]);
                rvFabrics.LocalReport.DataSources.Clear();
                rvFabrics.LocalReport.DataSources.Add(RptSource);

                //ReportParameter Factory = new ReportParameter("FactoryName", FactoryPara);
                //this.rvFabrics.LocalReport.SetParameters(new ReportParameter[] { Factory });
         
            }
            catch (Exception ex)
            {
                lblMessage.InnerText = ex.Message.ToString();
            }
        }
    }
}