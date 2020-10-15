using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace CMFLMS
{
    public class Common
    {
        public SqlConnection conSQL = new SqlConnection();
        public SqlTransaction sqlTxn;
        public string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public string exception;
        public string user;
        public string errorMessage;
        //public static string UserName;
        public bool ConnectDB()
        {
            if (string.IsNullOrEmpty(conSQL.ConnectionString))
            {
                conSQL.ConnectionString = constr;
            }
            if (conSQL.State == ConnectionState.Closed)
            {
                conSQL.Open();
            }
            return true;
        }

        public bool DisconnectDB()
        {
            if (conSQL.State == ConnectionState.Open)
            {
                if (sqlTxn == null)
                {
                    conSQL.Close();
                }
            }
            return true;
        }

        public DataSet ReturnDataset(string strSqlCommand)
        {
            SqlCommand sqlcmd = default(SqlCommand);
            SqlDataAdapter daCommon = new SqlDataAdapter();
            DataSet dsCommon = new DataSet();

            ConnectDB();
            sqlcmd = new SqlCommand(strSqlCommand, conSQL);
            daCommon.SelectCommand = sqlcmd;
            daCommon.Fill(dsCommon, "MySqlTable");
            DisconnectDB();

            return dsCommon;
        }
        public void MailSend()
        {
            string To = "lahirui@sl.crystal-martin.com";
            string From = "slit.helpdesk@sl.crystal-martin.com";
            string Subject = "ERROR IN: " + user;
            string MessageBody = exception;
            MailMessage msg = new MailMessage(From, To, Subject, MessageBody);
            msg.IsBodyHtml = true;
            SmtpClient clnt = new SmtpClient("outlook.sl.crystalmartin.local", 25);
            clnt.EnableSsl = false;
            clnt.Credentials = new System.Net.NetworkCredential("slit.helpdesk@sl.crystal-martin.com", "Slit@3333");
            clnt.Send(msg);
        }
    }
}