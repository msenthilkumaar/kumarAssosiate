using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for DbCon
/// </summary>
public class DbCon
{
	public DbCon()
	{
        sqlCon = new SqlConnection(ConnectionString);
	}
    private SqlConnection dbCon = null;
    private SqlCommand dbCom = null;
    private SqlTransaction dbTrn = null;

    string pwd = string.Empty;
    string replace = string.Empty;
    public static SqlConnection sqlCon = new SqlConnection();
    public static SqlConnection sqlConPMS = new SqlConnection();


    public static string ConnectionString
    {
        get { return ConfigurationManager.ConnectionStrings["AssoConnString"].ConnectionString; }
    }
    public DataTable ExecuteTable(string query, params SqlParameter[] prArr)
    {
        dbCon = sqlCon;
        dbCon.Open();
        SqlCommand cmd = new SqlCommand(query, dbCon); // CreateClosedCommand(query, prArr);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dbCon.Close();
        return dt;
    }
    public DataTable ExecuteDtSP(string spName, string Req_name)
    {
        dbCon = sqlCon;
        dbCon.Open();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(spName, dbCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@userId", Req_name));
        adapter.SelectCommand = cmd;
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        dbCon.Close();
        return dt;
    }
   
       
    
}