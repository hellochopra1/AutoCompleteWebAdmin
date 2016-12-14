using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

 

/// <summary>
/// Summary description for YoutubeService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class YoutubeService : System.Web.Services.WebService
{
    int Count = 0;
    [WebMethod]
    public DataSet SelectTopKeywordYoutube(int Id, bool IsTesting)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("ProxyLocation", Id);
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        DataSet ds = new DataSet();
        DataTable dataTable = BaseDAO.GetDataTable(oCommand, "SelectTopKeywordYoutube");
        DataTable dt = CollectionExtensions.OrderRandomly(dataTable.AsEnumerable()).CopyToDataTable();
        if (dt.Rows.Count > 0)
        {
            ds.Tables.Add(dt);
        }
        return ds;
    }

    [WebMethod]
    public DataSet ResetSearchCounterYoutube(bool IsTesting)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        return BaseDAO.GetDataDataset(oCommand, "ResetSearchCounterYoutube");
    }

    [WebMethod]
    public DataSet ResetSearchCounterForHoldKeywordsYoutube(bool IsTesting)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        return BaseDAO.GetDataDataset(oCommand, "ResetSearchCounterForHoldKeywordsYoutube");
    }


    [WebMethod]
    public DataSet SelectTopProxy(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("ProxyLocation", Id);
        DataSet ds = new DataSet();
        DataTable dataTable = BaseDAO.GetDataTable(oCommand, "SelectTopProxy");
        DataTable dt = CollectionExtensions.OrderRandomly(dataTable.AsEnumerable()).CopyToDataTable();
        if (dt.Rows.Count > 0)
        {
            ds.Tables.Add(dt);
        }
        return ds;
    }

    [WebMethod]
    public void LockDownKeywordYoutube(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "LockDownKeywordYoutube");
    }

    [WebMethod]
    public void LockDownProxy(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "LockDownProxy");
    }

    [WebMethod]
    public void ReleaseKeywordYoutube(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "ReleaseKeywordYoutube");
    }

    [WebMethod]
    public void ReleaseProxy(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "ReleaseProxy");
    }

    [WebMethod]
    public void IncreaseSearchCounterYoutube(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "IncreaseSearchCounterYoutube");
    }
}

