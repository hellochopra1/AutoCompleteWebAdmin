using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace AutoCompleteWebAdmin
{
    public partial class CompanyMaster : Telerik.Web.UI.RadAjaxPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PerfectId"] == null)
                Response.Redirect("Login.aspx");
            Master.CompanyMasterLin.Attributes.Add("class", "start active open");
        }

        protected void radGridCompany_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            SqlCommand oCommand = new SqlCommand();

            radGridCompany.DataSource = BaseDAO.GetDataDataset(oCommand, "GetCompanyDetails");
        }

        protected void radGridCompany_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    var Id = (int)item.GetDataKeyValue("Id");
                    SqlCommand oCommand = new SqlCommand();
                    var txtCompanyName = item.FindControl("txtCompanyName") as RadTextBox;
                    var txtAddress = item.FindControl("txtAddress") as RadTextBox;
                    var txtWebsite = item.FindControl("txtWebsite") as RadTextBox;
                    var txtWebMasterLogin = item.FindControl("txtWebMasterLogin") as RadTextBox;
                    var txtWebMasterPass = item.FindControl("txtWebMasterPass") as RadTextBox; 
                    oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("CompanyName", txtCompanyName.Text);
                    oCommand.Parameters.AddWithValue("Address", txtAddress.Text);
                    oCommand.Parameters.AddWithValue("Website", txtWebsite.Text);
                    oCommand.Parameters.AddWithValue("WebMasterLogin", txtWebMasterLogin.Text);
                    oCommand.Parameters.AddWithValue("WebMasterPass", txtWebMasterPass.Text);                   
                    oCommand.Parameters.AddWithValue("Id", Id);

                    Int32 id = Convert.ToInt32(BaseDAO.GetExecuteScalar(oCommand, "UpdateCompanyDetailsById"));
                }
            }
            catch
            { }
        }

        protected void radGridCompany_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
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
                        DataSet ds = BaseDAO.GetDataDataset(oCommand, "GetCompanyDetailsById");
                        var txtCompanyName = item.FindControl("txtCompanyName") as RadTextBox;
                        var txtAddress = item.FindControl("txtAddress") as RadTextBox;
                        var txtWebsite = item.FindControl("txtWebsite") as RadTextBox;
                        var txtWebMasterLogin = item.FindControl("txtWebMasterLogin") as RadTextBox;
                        var txtWebMasterPass = item.FindControl("txtWebMasterPass") as RadTextBox;

                        txtCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        txtWebsite.Text = ds.Tables[0].Rows[0]["WebSite"].ToString();
                        txtWebMasterLogin.Text = ds.Tables[0].Rows[0]["WebMasterLogin"].ToString();
                        txtWebMasterPass.Text = ds.Tables[0].Rows[0]["WebMasterPass"].ToString();
                         
                    }
                }
            }
            catch
            {

            }
        }

        protected void radGridCompany_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                { 
                    SqlCommand oCommand = new SqlCommand();
                    var txtCompanyName = item.FindControl("txtCompanyName") as RadTextBox;
                    var txtAddress = item.FindControl("txtAddress") as RadTextBox;
                    var txtWebsite = item.FindControl("txtWebsite") as RadTextBox;
                    var txtWebMasterLogin = item.FindControl("txtWebMasterLogin") as RadTextBox;
                    var txtWebMasterPass = item.FindControl("txtWebMasterPass") as RadTextBox; 
                    oCommand.Parameters.AddWithValue("CompanyName", txtCompanyName.Text);
                    oCommand.Parameters.AddWithValue("Address", txtAddress.Text);
                    oCommand.Parameters.AddWithValue("Website", txtWebsite.Text);
                    oCommand.Parameters.AddWithValue("WebMasterLogin", txtWebMasterLogin.Text);
                    oCommand.Parameters.AddWithValue("WebMasterPass", txtWebMasterPass.Text);
                     
                    Int32 id = Convert.ToInt32(BaseDAO.GetExecuteScalar(oCommand, "InsertCompanyDetails"));
                }
            }
            catch
            { }
        }

        protected void radGridCompany_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        { 
            try
            {
                var item = e.Item as GridEditableItem;
                if (item != null)
                {
                    var Id = (int)item.GetDataKeyValue("Id");
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Parameters.AddWithValue("Id", Id);
                    BaseDAO.GetExecuteScalar(oCommand, "DeleteCompanyById");
                }
            }
            catch
            {

            }
        }
    }
}