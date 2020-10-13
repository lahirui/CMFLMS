using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMFLMS.Reports
{
    public partial class FabricWebReport : System.Web.UI.Page
    {
        Common ComFab = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataSet DatFab = new DataSet();
                DatFab = ComFab.ReturnDataset("SELECT dbo.Fabrics.FabricId, dbo.Suppliers.SupplierName, dbo.Fabrics.Quality, dbo.Fabrics.Compisition1, dbo.Fabrics.Compisition2, dbo.Fabrics.Compisition3, dbo.Fabrics.Compisition4, dbo.Fabrics.Compisition5, " +
                  "dbo.Constructions.ConstructionType AS Construction, dbo.Yarns.YarnCount, dbo.Fabrics.WidthInches AS Width_Inches, dbo.Fabrics.WidthCm, dbo.Fabrics.Weight, dbo.Fabrics.Price, dbo.Locations.LocationName AS Location, dbo.Knits.KnitType AS Knit, " +
                  "dbo.Structures.StructureValue AS Structure, dbo.Colours.ColourName AS Colour, dbo.Factories.FactoryName AS Factory, dbo.FabCatoes.FabricCat AS FabricCategory, dbo.FinishCatoes.FinishCat AS FinishingCategory, " +
                  "dbo.Fabrics.AddedDate, dbo.Fabrics.Remarks " +
                  "FROM     dbo.Fabrics INNER JOIN " +
                  "dbo.Suppliers ON dbo.Fabrics.SupplierId = dbo.Suppliers.SupplierId INNER JOIN " +
                  "dbo.Yarns ON dbo.Fabrics.YarnId = dbo.Yarns.YarnId INNER JOIN " +
                  "dbo.Structures ON dbo.Fabrics.StructureId = dbo.Structures.StructureId INNER JOIN " +
                  "dbo.Locations ON dbo.Fabrics.LocationsId = dbo.Locations.LocationsId INNER JOIN " +
                  "dbo.Knits ON dbo.Fabrics.KnitId = dbo.Knits.KnitId INNER JOIN " +
                  "dbo.FinishCatoes ON dbo.Fabrics.FinishCatoId = dbo.FinishCatoes.FinishCatoId INNER JOIN " +
                  "dbo.Factories ON dbo.Fabrics.FactoryId = dbo.Factories.FactoryId INNER JOIN " +
                  "dbo.FabCatoes ON dbo.Fabrics.FabCatoId = dbo.FabCatoes.FabCatoId INNER JOIN " +
                  "dbo.Constructions ON dbo.Fabrics.ConstructionId = dbo.Constructions.ConstructionId INNER JOIN " +
                  "dbo.Colours ON dbo.Fabrics.ColourId = dbo.Colours.ColourId " +
                  "ORDER BY dbo.Fabrics.FabricId, Factory");
                gvInfo.DataSource = DatFab.Tables[0];
                gvInfo.DataBind();

            }
        }

        protected void txtFabId_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            (gvInfo.DataSource as DataTable).DefaultView.RowFilter = string.Format("FabricId LIKE '%{0}%'", txtFabId.Text);
        }

        protected void txtWidthInch_TextChanged(object sender, EventArgs e)
        {
            (gvInfo.DataSource as DataTable).DefaultView.RowFilter = string.Format("Width_Inches LIKE '%{0}%'", txtWidthInch.Text);
        }
    }
}