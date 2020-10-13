using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CMFLMS.Models;
using System.Data.SqlClient;
using System.Data;

namespace CMFLMS
{
    public class UserInformation
    {
        public string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public int UserFactoryId = Convert.ToInt32(HttpContext.Current.Session["Factory"].ToString());
        public void UserInfo()
        {
            DataSet DatFac = new DataSet();
            DataSet DatFacId = new DataSet();
            Common ComFac = new Common();

            var name = HttpContext.Current.Session["username"].ToString();
          
            DatFac = ComFac.ReturnDataset("SELECT UserName, FactoryId FROM UsersWithFactories WHERE UserName ='" + HttpContext.Current.Session["username"].ToString() + "'");//HttpContext.Current.
            if (DatFac.Tables[0].Rows.Count > 0)
            {
                var fac = DatFac.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                DatFacId = ComFac.ReturnDataset("SELECT FactoryId FROM Factories WHERE FactoryName ='" + fac + "'");
            }

            if (DatFacId.Tables[0].Rows.Count > 0)
            {
                UserFactoryId = Convert.ToInt32(DatFacId.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
            }
        
        }

    }
}