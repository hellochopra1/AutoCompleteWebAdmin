using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace AutoCompleteWebAdmin
{
    public partial class ProxyMaster : Telerik.Web.UI.RadAjaxPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PerfectId"] == null)
                Response.Redirect("Login.aspx");
            Master.IPMasterLin.Attributes.Add("class", "start active open");
        }

        protected void radGridIP_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            SqlCommand oCommand = new SqlCommand();

            radGridIP.DataSource = BaseDAO.GetDataDataset(oCommand, "GetAllProxies");
        }

        public DataSet GetAllCountries()
        {
            //GetCompanyForDropDown
            SqlCommand oCommand = new SqlCommand();
            return BaseDAO.GetDataDataset(oCommand, "GetAllCountries"); ;
        }

        protected void radGridIP_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    var Id = (Int64)item.GetDataKeyValue("Id");
                    SqlCommand oCommand = new SqlCommand();
                    var txtProxy = item.FindControl("txtProxy") as RadTextBox;
                    var ddlCountry = item.FindControl("ddlCountry") as RadComboBox;
                    oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("ProxyIP", txtProxy.Text);
                    oCommand.Parameters.AddWithValue("ProxyLocation", ddlCountry.SelectedValue);
                    oCommand.Parameters.AddWithValue("Id", Id);

                    BaseDAO.GetExecuteScalar(oCommand, "UpdateProxies");
                }
            }
            catch
            { }
        }

        protected void radGridIP_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    GridEditableItem item = (GridEditableItem)e.Item;

                    if (item != null)
                    {
                        var Id = (Int64)item.GetDataKeyValue("Id");
                        SqlCommand oCommand = new SqlCommand();
                        oCommand.Parameters.AddWithValue("Id", Id);
                        DataSet ds = BaseDAO.GetDataDataset(oCommand, "GetProxyByProxyid");
                        var txtProxy = item.FindControl("txtProxy") as RadTextBox;
                        var ddlCountry = item.FindControl("ddlCountry") as RadComboBox;

                        ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["ProxyIP"].ToString();
                        txtProxy.Text = ds.Tables[0].Rows[0]["ProxyIP"].ToString();
                    }
                }
            }
            catch
            {

            }
        }

        protected void radGridIP_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    SqlCommand oCommand = new SqlCommand();
                    var ddlCountry = item.FindControl("ddlCountry") as RadComboBox;
                    var txtProxy = item.FindControl("txtProxy") as RadTextBox;
                    oCommand.Parameters.AddWithValue("ProxyIP", txtProxy.Text);
                    oCommand.Parameters.AddWithValue("ProxyLocation", ddlCountry.SelectedValue);

                    BaseDAO.GetExecuteScalar(oCommand, "InsertProxies");
                }
            }
            catch
            { }
        }

        protected void radGridIP_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    var Id = (Int64)item.GetDataKeyValue("Id");
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("Id", Id);
                    BaseDAO.GetExecuteScalar(oCommand, "DeleteProxies");
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
                oCommand.Parameters.AddWithValue("ProxyIP", ds.Tables[0].Rows[i][0].ToString());
                oCommand.Parameters.AddWithValue("ProxyLocation", ddlCountryOut.SelectedValue);

                BaseDAO.GetExecuteScalar(oCommand, "InsertProxies");
            }
            radGridIP.Rebind();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            foreach (GridDataItem item in radGridIP.SelectedItems)
            {
                if (item.Selected)
                {
                    // Access data key
                    string strID = item.GetDataKeyValue("Id").ToString();
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("Id", strID);
                    BaseDAO.GetExecuteScalar(oCommand, "DeleteProxies");
                    // delete logic comes here
                }
            }
            radGridIP.Rebind();
        }
    }
}