using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Data.SqlClient;

/// <summary>
/// Summary description for BaseDB
/// </summary>
public class BaseDAO
{
    public BaseDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //This function is used to make connection with database Sql Server.
    internal static SqlConnection GetConnection()
    {
        SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        return oConn;
    }

    //This function accepts the sqlcommand and procedure name to run. After running it returns DataTable back.
    internal static DataTable GetDataTable(SqlCommand oCommand, string sprocName)
    {
        SqlConnection oConn = GetConnection();
        DataTable oTable = new DataTable();
        oCommand.Connection = oConn;
        oCommand.CommandText = sprocName;
        oCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        try
        {
            oAdapter.Fill(oTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        return oTable;
    }

    //This function accepts the sqlcommand and procedure name to run. After running it returns DataView back.
    internal static DataView GetDataView(SqlCommand oCommand, string sprocName)//Accepts sqlcommand and procedure name as parameters and makes connection with database to bring required data and returns dataview
    {
        SqlConnection oConn = GetConnection();
        DataTable oTable = new DataTable();
        DataView oView;
        oCommand.Connection = oConn;
        oCommand.CommandText = sprocName;
        oCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        try
        {
            oAdapter.Fill(oTable);
            oView = new DataView(oTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        return oView;
    }

    public static void SaveData(SqlCommand oCommand, string sprocName)
    {
        try
        {
            SqlConnection oConn = GetConnection();
            oConn.Open();
            oCommand.Connection = oConn;
            oCommand.CommandText = sprocName;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.ExecuteNonQuery();

            oConn.Close();
        }
        catch (Exception e)
        {
            throw e;
        }

    }


    internal static DataSet GetDataDataset(SqlCommand oCommand, string sprocName)//Accepts sqlcommand and procedure name as parameters and makes connection with database to bring required data and returns dataset
    {

        SqlConnection oConn = GetConnection();

        if (oConn.State == ConnectionState.Closed)
            oConn.Open();
        oCommand.Connection = oConn;

        DataSet oDataSet = new DataSet();

        oCommand.CommandText = sprocName;
        oCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        try
        {
            oAdapter.Fill(oDataSet);
            oConn.Dispose();

        }
        catch (Exception e)
        {
            throw e;
        }
        return oDataSet;
    }

    public static SqlDataReader GetDataReader(SqlCommand oCommand, string sprocName)//Accepts sqlcommand and procedure name as parameters and makes connection with database to bring required data and returns dataset
    {
        SqlConnection oConn = GetConnection();
        if (oConn.State == ConnectionState.Closed)
            oConn.Open();
        oCommand.Connection = oConn;
        oCommand.CommandText = sprocName;
        oCommand.CommandType = CommandType.StoredProcedure;
        SqlDataReader oSqlDataReader = oCommand.ExecuteReader();


        return oSqlDataReader;
    }

    public static object GetExecuteScalar(SqlCommand oCommand, string sprocName)
    {
        SqlConnection oConn = GetConnection();
        if (oConn.State == ConnectionState.Closed)
            oConn.Open();
        oCommand.Connection = oConn;
        oCommand.CommandText = sprocName;
        oCommand.CommandType = CommandType.StoredProcedure;
        object obj = oCommand.ExecuteScalar();
        oConn.Close();
        return obj;

    }

    public static int SaveEmpData(SqlCommand oCommand, string sprocName)
    {

        SqlConnection oConnection = GetConnection();
        if (oConnection.State == ConnectionState.Closed)
            oConnection.Open();
        oCommand.Connection = oConnection;
        oCommand.CommandText = sprocName;
        oCommand.CommandType = CommandType.StoredProcedure;

        return (int)oCommand.ExecuteScalar();


    }

}




