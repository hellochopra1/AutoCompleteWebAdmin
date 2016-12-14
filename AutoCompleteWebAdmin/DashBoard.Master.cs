using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

namespace CraiglistWeb
{
    public partial class DashBoard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lbOnline.Text = Convert.ToString(Session["Username"]);
            }
            
        }

        public System.Web.UI.HtmlControls.HtmlGenericControl CompanyMasterLin
        {
            get { return CompanyMaster; }
            set { CompanyMaster = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl KeywordMaster
        {
            get { return dashboard; }
            set { dashboard = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl KeywordMasterTesting
        {
            get { return dashboard1; }
            set { dashboard1 = value; }
        }

        public System.Web.UI.HtmlControls.HtmlGenericControl GoogleSettings
        {
            get { return googleSettings; }
            set { googleSettings = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl BingSettings
        {
            get { return bingSettings; }
            set { bingSettings = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl YoutubeMasterTesting
        {
            get { return youtube; }
            set { youtube = value; }
        }
        public System.Web.UI.HtmlControls.HtmlGenericControl IPMasterLin
        {
            get { return IPMaster; }
            set { IPMaster = value; }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["PerfectId"] = null;
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}