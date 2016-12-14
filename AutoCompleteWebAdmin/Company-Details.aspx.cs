using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoCompleteWebAdmin
{
    public partial class Company_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
              
            SqlCommand oCommand = new SqlCommand();
            oCommand.Parameters.AddWithValue("Address", txtAddress.Text);
            oCommand.Parameters.AddWithValue("CompanyName", txtCompanyName.Text);
            oCommand.Parameters.AddWithValue("WebSite", txtWebsite.Text);
            oCommand.Parameters.AddWithValue("WebMasterLogin", txtWebmasterUsername.Text);
            oCommand.Parameters.AddWithValue("WebMasterPass", txtWebMasterPassword.Text);
             
                       
            
            Int32 id =Convert.ToInt32( BaseDAO.GetExecuteScalar(oCommand, "InsertCompanyDetails"));
             
        }
    }
}