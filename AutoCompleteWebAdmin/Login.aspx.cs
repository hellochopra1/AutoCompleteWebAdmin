using AutoCompleteWebAdmin.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoCompleteWebAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AutoCompleteOMST sd = new AutoCompleteOMST();
            //sd.SelectTopKeyword(2);

            //MyWCFService se = new MyWCFService();
            //string asd = se.DoWork();

            //Service1 s = new Service1();
            //MySoapHeader header = new MySoapHeader();
            //header.UserName = "silanliu";
            //header.Password = "thepassword";
            //s.mSoapHeader = header;
            //string ads = s.HelloWorld();
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

         
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand oCommand = new SqlCommand();
            oCommand.Parameters.AddWithValue("Username", txtLogin.Value);
            oCommand.Parameters.AddWithValue("Password", txtPassword.Value);
            DataSet ds = BaseDAO.GetDataDataset(oCommand, "GetAdminLogin");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["UserName"] = ds.Tables[0].Rows[0]["Username"].ToString();
                Session["PerfectId"] = ds.Tables[0].Rows[0]["Id"].ToString();
                Response.Redirect("KeywordMasterForTesting.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "loginfail();", true);
            }

            //UserLoginBO oUser = new UserLoginBO();
            //oUser.username = txtUserName.Text;
            //LoginBL.GetLoginCheck(oUser);
            //if (oUser.password == txtPassword.Text)
            //{
            //    Session["username"] = oUser.username;
            //    Response.Redirect("Index.aspx");
            //}
            //else
            //{
            //    Label1.Visible = true;
            //    Label1.Text = "Please Check UserName and Password";
            //}
        }
    }
}