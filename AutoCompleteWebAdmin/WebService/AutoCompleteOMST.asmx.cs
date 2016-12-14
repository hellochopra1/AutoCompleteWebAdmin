using AutoCompleteWebAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

public static class CollectionExtensions
{

    private static Random random = new Random();

    public static IEnumerable<T> OrderRandomly<T>(this IEnumerable<T> collection)
    {

        // Order items randomly

        List<T> randomly = new List<T>(collection);

        while (randomly.Count > 0)
        {

            Int32 index = random.Next(randomly.Count);

            yield return randomly[index];

            randomly.RemoveAt(index);

        }

    } // OrderRandomly

}

/// <summary>
/// Summary description for AutoCompleteOMST
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AutoCompleteOMST : System.Web.Services.WebService
{
    int Count = 0;
    [WebMethod]
    public DataSet SelectTopKeyword(int Id, bool IsTesting,bool IsBing)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("ProxyLocation", Id);
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        oCommand.Parameters.AddWithValue("IsBing", IsBing);
        DataSet ds = new DataSet();
        DataTable dataTable = BaseDAO.GetDataTable(oCommand, "SelectTopKeyword");
        DataTable dt = CollectionExtensions.OrderRandomly(dataTable.AsEnumerable()).CopyToDataTable();
        if (dt.Rows.Count > 0)
        {
            ds.Tables.Add(dt);
        }
        return ds;
    }

    [WebMethod]
    public DataSet SelectTopKeywordWithNewInstruction(int Id, bool IsTesting, bool IsBing)
    {
        var oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("ProxyLocation", Id);
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        oCommand.Parameters.AddWithValue("IsBing", IsBing);
        var ds = new DataSet();
        var dataTable = BaseDAO.GetDataTable(oCommand, "SelectTopKeyword");
        var dt = CollectionExtensions.OrderRandomly(dataTable.AsEnumerable()).CopyToDataTable();
        if (dt.Rows.Count > 0)
        {
            ds.Tables.Add(dt);
        }
        return ds;
    }

    [WebMethod]
    public DataSet ResetSearchCounter(bool IsTesting)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        return BaseDAO.GetDataDataset(oCommand, "ResetSearchCounter");
    }

    [WebMethod]
    public DataSet GetSettingsForGoogleAndBing(int id)
    {
        var oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", id);
        return BaseDAO.GetDataDataset(oCommand, "GetSettingsForGoogleAndBing");
    }

    [WebMethod]
    public DataSet ResetSearchCounterForHoldKeywords(bool IsTesting)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        return BaseDAO.GetDataDataset(oCommand, "ResetSearchCounterForHoldKeywords");
    }

    [WebMethod]
    public List<GetCountClass> GetTotalCountForKeywords(bool IsTesting)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("IsTesting", IsTesting);
        DataSet ds = BaseDAO.GetDataDataset(oCommand, "GetTotalCountForKeywords");
        List<GetCountClass> objList = new List<GetCountClass>();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            GetCountClass obj = new GetCountClass();
            obj.Count =Convert.ToInt32(ds.Tables[0].Rows[i]["TotalCount"]);
            objList.Add(obj);
        }
        return objList;
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
    public void LockDownKeyword(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "LockDownKeyword");
    }

    [WebMethod]
    public void LockDownProxy(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "LockDownProxy");
    }

    [WebMethod]
    public void ReleaseKeyword(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "ReleaseKeyword");
    }

    [WebMethod]
    public void ReleaseProxy(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "ReleaseProxy");
    }

    [WebMethod]
    public void IncreaseSearchCounter(int Id)
    {
        SqlCommand oCommand = new SqlCommand();
        oCommand.Parameters.AddWithValue("Id", Id);
        BaseDAO.GetExecuteScalar(oCommand, "IncreaseSearchCounter");
    }

}

