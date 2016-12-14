using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoCompleteWebAdmin
{
    public partial class GoogleSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PerfectId"] == null)
                Response.Redirect("Login.aspx");
            Master.GoogleSettings.Attributes.Add("class", "start active open");
            if (!IsPostBack)
            {
                var oCommand = new SqlCommand();
                oCommand.Parameters.AddWithValue("Id", 1);
                var data = BaseDAO.GetDataDataset(oCommand, "GetSettingsForGoogleAndBing");
                if (data.Tables[0].Rows.Count <= 0)
                    return;

                txtHomePageWait.Text = data.Tables[0].Rows[0]["HomeWait"].ToString();
                txtBrowserChange.Text = data.Tables[0].Rows[0]["NumberOfBrowserChange"].ToString();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var oCommand = new SqlCommand();
            oCommand.Parameters.AddWithValue("Id", 1);
            oCommand.Parameters.AddWithValue("HomeWait", txtHomePageWait.Text);
            oCommand.Parameters.AddWithValue("NumberOfBrowserChange", txtBrowserChange.Text);
            BaseDAO.GetExecuteScalar(oCommand, "UpdateSettingsTable");
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Settings Updated SuccessFully');", true);
        }
    }
}