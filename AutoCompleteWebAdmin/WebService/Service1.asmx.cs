using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace AutoCompleteWebAdmin.WebService
{

    public class MySoapHeader : SoapHeader
    {
        public string UserName;
        public string Password;
    }
 

    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public MySoapHeader mSoapHeader = null;

        [WebMethod]
        [SoapHeader("mSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public string HelloWorld()
        {
            return "User name: " + Context.User.Identity.Name +
                "\nAuthenticated: " + Context.User.Identity.IsAuthenticated.ToString() +
                "\nIn \"Whatever\" role: " + Context.User.IsInRole("Whatever").ToString();
        }
    }
}
