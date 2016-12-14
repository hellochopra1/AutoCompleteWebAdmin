using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Xml;

namespace AutoCompleteWebAdmin.Classes
{
    public class AuthenticateRequestHttpModule : IHttpModule
    {
        private HttpApplication mHttpApp;

        public void Init(HttpApplication httpApp)
        {
            this.mHttpApp = httpApp;
            mHttpApp.AuthenticateRequest += new EventHandler(OnAuthentication);
        }

        void OnAuthentication(object sender, EventArgs a)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            Stream stream = context.Request.InputStream;

            if (((HttpApplication)sender).Context.Request.ServerVariables["HTTP_SOAPACTION"] == null)
                return;

            long lStreamPosition = stream.Position;
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            stream.Position = lStreamPosition;

            string strUser = doc.GetElementsByTagName("UserName").Item(0).InnerText;
            string strPwd = doc.GetElementsByTagName("Password").Item(0).InnerText;

            if (strUser == "silanliu" && strPwd == "thepassword")
            {
                string[] astrRoles = { "Whatever" };
                GenericIdentity i = new GenericIdentity("Whoever");
                context.User = new GenericPrincipal(i, astrRoles);
            }
        }

        public void Dispose()
        { }
    }
}