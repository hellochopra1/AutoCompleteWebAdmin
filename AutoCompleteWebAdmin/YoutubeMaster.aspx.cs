using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace AutoCompleteWebAdmin
{
    
    public partial class YoutubeMaster : Telerik.Web.UI.RadAjaxPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PerfectId"] == null)
                Response.Redirect("Login.aspx");
            Master.YoutubeMasterTesting.Attributes.Add("class", "start active open");
        }

        protected void radGridKeyword_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    var Id = (int)item.GetDataKeyValue("Id");
                    SqlCommand oCommand = new SqlCommand();
                    var txtKeyword = item.FindControl("txtKeyword") as RadTextBox;
                    var txtLink = item.FindControl("txtLink") as RadTextBox;
                    var txtContact = item.FindControl("txtContact") as RadTextBox;
                    var txtOther = item.FindControl("txtOther") as RadTextBox;
                    var txtLink3 = item.FindControl("txtLink3") as RadTextBox;
                    var txtLink4 = item.FindControl("txtLink4") as RadTextBox;
                    var txtLink5 = item.FindControl("txtLink5") as RadTextBox;
                    var txtLink6 = item.FindControl("txtLink6") as RadTextBox;
                    var txtSearches = item.FindControl("txtSearches") as RadTextBox;
                    var chkActive = item.FindControl("chkActive") as HtmlInputCheckBox;
                    var ddlCompany = item.FindControl("ddlCompany") as RadComboBox;
                    var ddlCountry = item.FindControl("ddlCountry") as RadComboBox;
                    var chkReset = item.FindControl("chkReset") as HtmlInputCheckBox;


                    oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("CompanyId", ddlCompany.SelectedValue);
                    oCommand.Parameters.AddWithValue("ProxyLocation", ddlCountry.SelectedValue);
                    oCommand.Parameters.AddWithValue("Keyword", txtKeyword.Text);
                    oCommand.Parameters.AddWithValue("Link", txtLink.Text);
                    oCommand.Parameters.AddWithValue("Contact", txtContact.Text);
                    oCommand.Parameters.AddWithValue("Other", txtOther.Text);
                    oCommand.Parameters.AddWithValue("Link3", txtLink3.Text);
                    oCommand.Parameters.AddWithValue("Link4", txtLink4.Text);
                    oCommand.Parameters.AddWithValue("Link5", txtLink5.Text);
                    oCommand.Parameters.AddWithValue("Link6", txtLink6.Text);
                    oCommand.Parameters.AddWithValue("Searches", txtSearches.Text);
                    oCommand.Parameters.AddWithValue("Active", chkActive.Checked);
                    oCommand.Parameters.AddWithValue("IsLocked", chkReset.Checked);
                    oCommand.Parameters.AddWithValue("Id", Id);
                    oCommand.Parameters.AddWithValue("IsTesting", true);

                    Int32 id = Convert.ToInt32(BaseDAO.GetExecuteScalar(oCommand, "UpdateKeywordDetailsYoutube"));
                }
            }
            catch
            { }
        }

        public DataSet GetAllCompanies()
        {
            //GetCompanyForDropDown
            SqlCommand oCommand = new SqlCommand();
            return BaseDAO.GetDataDataset(oCommand, "GetCompanyForDropDown"); ;
        }

        public DataSet GetAllCountries()
        {
            //GetCompanyForDropDown
            SqlCommand oCommand = new SqlCommand();
            return BaseDAO.GetDataDataset(oCommand, "GetAllCountries"); ;
        }

        protected void radGridKeyword_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    var Id = (int)item.GetDataKeyValue("Id");
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("Id", Id);
                    BaseDAO.GetExecuteScalar(oCommand, "DeleteKeyWordByIdYoutube");
                }
            }
            catch
            {

            }
        }

        protected void radGridKeyword_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    SqlCommand oCommand = new SqlCommand();
                    var txtKeyword = item.FindControl("txtKeyword") as RadTextBox;
                    var txtLink = item.FindControl("txtLink") as RadTextBox;
                    var txtContact = item.FindControl("txtContact") as RadTextBox;
                    var txtOther = item.FindControl("txtOther") as RadTextBox;
                    var txtLink3 = item.FindControl("txtLink3") as RadTextBox;
                    var txtLink4 = item.FindControl("txtLink4") as RadTextBox;
                    var txtLink5 = item.FindControl("txtLink5") as RadTextBox;
                    var txtLink6 = item.FindControl("txtLink6") as RadTextBox;
                    var txtSearches = item.FindControl("txtSearches") as RadTextBox;
                    var chkActive = item.FindControl("chkActive") as HtmlInputCheckBox;
                    var ddlCompany = item.FindControl("ddlCompany") as RadComboBox;
                    var ddlCountry = item.FindControl("ddlCountry") as RadComboBox;

                    oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("CompanyId", ddlCompany.SelectedValue);
                    oCommand.Parameters.AddWithValue("ProxyLocation", ddlCountry.SelectedValue);
                    oCommand.Parameters.AddWithValue("Keyword", txtKeyword.Text);
                    oCommand.Parameters.AddWithValue("Link", txtLink.Text);
                    oCommand.Parameters.AddWithValue("Contact", txtContact.Text);
                    oCommand.Parameters.AddWithValue("Other", txtOther.Text);
                    oCommand.Parameters.AddWithValue("Link3", txtLink3.Text);
                    oCommand.Parameters.AddWithValue("Link4", txtLink4.Text);
                    oCommand.Parameters.AddWithValue("Link5", txtLink5.Text);
                    oCommand.Parameters.AddWithValue("Link6", txtLink6.Text);
                    oCommand.Parameters.AddWithValue("Searches", txtSearches.Text);
                    oCommand.Parameters.AddWithValue("Active", chkActive.Checked);
                    oCommand.Parameters.AddWithValue("IsTesting", true);

                    Int32 id = Convert.ToInt32(BaseDAO.GetExecuteScalar(oCommand, "InsertKeywordDetailsYoutube"));

                }
            }
            catch
            {

            }
        }

        protected void radGridKeyword_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            SqlCommand oCommand = new SqlCommand();
            oCommand.Parameters.AddWithValue("IsTesting", true);
            radGridKeyword.DataSource = BaseDAO.GetDataDataset(oCommand, "GetAllKeyWordsYoutube");
        }

        protected void radGridKeyword_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    GridEditableItem item = (GridEditableItem)e.Item;

                    if (item != null)
                    {
                        var Id = (int)item.GetDataKeyValue("Id");
                        SqlCommand oCommand = new SqlCommand();
                        oCommand.Parameters.AddWithValue("Id", Id);
                        DataSet ds = BaseDAO.GetDataDataset(oCommand, "GetKeyWordByIdYoutube");
                        var txtKeyword = item.FindControl("txtKeyword") as RadTextBox;
                        var txtLink = item.FindControl("txtLink") as RadTextBox;
                        var txtContact = item.FindControl("txtContact") as RadTextBox;
                        var txtOther = item.FindControl("txtOther") as RadTextBox;
                        var txtLink3 = item.FindControl("txtLink3") as RadTextBox;
                        var txtLink4 = item.FindControl("txtLink4") as RadTextBox;
                        var txtLink5 = item.FindControl("txtLink5") as RadTextBox;
                        var txtLink6 = item.FindControl("txtLink6") as RadTextBox;
                        var ddlCompany = item.FindControl("ddlCompany") as RadComboBox;
                        var txtSearches = item.FindControl("txtSearches") as RadTextBox;
                        var ddlCountry = item.FindControl("ddlCountry") as RadComboBox;

                        var chkActive = item.FindControl("chkActive") as HtmlInputCheckBox;
                        var chkReset = item.FindControl("chkReset") as HtmlInputCheckBox;


                        chkActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Active"]);
                        chkReset.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsLocked"]);
                        txtKeyword.Text = ds.Tables[0].Rows[0]["Keyword"].ToString();
                        txtLink.Text = ds.Tables[0].Rows[0]["Link"].ToString();
                        txtContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                        txtOther.Text = ds.Tables[0].Rows[0]["Other"].ToString();
                        txtLink3.Text = ds.Tables[0].Rows[0]["Link3"].ToString();
                        txtLink4.Text = ds.Tables[0].Rows[0]["Link4"].ToString();
                        txtLink5.Text = ds.Tables[0].Rows[0]["Link5"].ToString();
                        txtLink6.Text = ds.Tables[0].Rows[0]["Link6"].ToString();
                        txtSearches.Text = ds.Tables[0].Rows[0]["Searches"].ToString();
                        ddlCompany.SelectedValue = ds.Tables[0].Rows[0]["CompanyId"].ToString();
                        ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["ProxyLocation"].ToString();

                        //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "AgentTypeFilterChange();", true);

                    }
                }
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            OleDbConnection oledbConn = new OleDbConnection();
            string direct = Server.MapPath("ProxyExcels/" + RadAsyncUpload1.UploadedFiles[0].FileName);
            RadAsyncUpload1.UploadedFiles[0].SaveAs(direct);
            //var direct = RadAsyncUpload1.UploadedFiles[0].FileName;// System.IO.Path.GetFullPath("ProxyAddress.xlsx");//"E:\\Dheeraj\\ProxyAddress.xlsx");
            //Directory.GetDirectoryRoot("E:\\Dheeraj\\ProxyAddress.xlsx");
            // string path = System.IO.Path.GetFullPath(Server.MapPath("~/Temp/eagleridge.xls"));
            if (Path.GetExtension(direct) == ".xls")
            {
                oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + direct + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");

                // oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
            }
            else if (Path.GetExtension(direct) == ".xlsx")
            {
                oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + direct + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
            }
            oledbConn.Open();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();


            cmd.Connection = oledbConn;

            cmd.CommandText = "SELECT * FROM [Sheet1$]";

            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(ds);


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlCommand oCommand = new SqlCommand();

                oCommand = new SqlCommand();
                oCommand.Parameters.AddWithValue("CompanyId", ddlCompanyOut.SelectedValue);
                oCommand.Parameters.AddWithValue("ProxyLocation", ddlCountryOut.SelectedValue);
                oCommand.Parameters.AddWithValue("Keyword", ds.Tables[0].Rows[i]["Keyword"].ToString());
                oCommand.Parameters.AddWithValue("Link", ds.Tables[0].Rows[i]["Link"].ToString());
                oCommand.Parameters.AddWithValue("Contact", ds.Tables[0].Rows[i]["Contact"].ToString());
                oCommand.Parameters.AddWithValue("Other", ds.Tables[0].Rows[i]["Other"].ToString());
                oCommand.Parameters.AddWithValue("Link3", ds.Tables[0].Rows[i]["Link3"].ToString());
                oCommand.Parameters.AddWithValue("Link4", ds.Tables[0].Rows[i]["Link4"].ToString());
                oCommand.Parameters.AddWithValue("Link5", ds.Tables[0].Rows[i]["Link5"].ToString());
                oCommand.Parameters.AddWithValue("Link6", ds.Tables[0].Rows[i]["Link6"].ToString());
                oCommand.Parameters.AddWithValue("Searches", ds.Tables[0].Rows[i]["Searches"].ToString());
                oCommand.Parameters.AddWithValue("Active", true);
                oCommand.Parameters.AddWithValue("IsTesting", true);
                Int32 id = Convert.ToInt32(BaseDAO.GetExecuteScalar(oCommand, "InsertKeywordDetailsYoutube"));
            }
            radGridKeyword.Rebind();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            foreach (GridDataItem item in radGridKeyword.SelectedItems)
            {
                if (item.Selected)
                {
                    // Access data key
                    string strID = item.GetDataKeyValue("Id").ToString();
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("Id", strID);
                    BaseDAO.GetExecuteScalar(oCommand, "DeleteKeyWordByIdYoutube");
                    // delete logic comes here
                }
            }
            radGridKeyword.Rebind();
        }



        protected void btnResetCounter_Click(object sender, EventArgs e)
        {
            YoutubeService webService = new YoutubeService();
            webService.ResetSearchCounterYoutube(true);
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "MessageB();", true);
        }

        protected void btnResetHoldKeywords_Click(object sender, EventArgs e)
        {
            YoutubeService webService = new YoutubeService();
            webService.ResetSearchCounterForHoldKeywordsYoutube(true);
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "MessageB();", true);
        }
    }

}