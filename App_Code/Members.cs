using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for Members
/// </summary>
public class Members
{
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
	public Members()
	{
        sqlCon = new SqlConnection(ConnectionString);
	}
    public Int64 intRID { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string email { get; set; }
    public string MobileNum { get; set; }
    public DateTime DOB { get; set; }
    public bool isactive { get; set; }
    public string address { get; set; }
    public Int16 Groupid { get; set; }
    public string InsertMembers()
    {
        bool isInTran = false;
        string retVal = "";
        try
        {

            #region "Setup Connection and Transaction..."
            dbCon = sqlCon;
            dbCon.Open();
            dbTrn = dbCon.BeginTransaction(IsolationLevel.ReadCommitted);
            isInTran = true;
            #endregion
            #region "Add Division..."
            dbCom = new SqlCommand("INS_Members", dbCon, dbTrn);
            dbCom.CommandType = CommandType.StoredProcedure;

            dbCom.Parameters.Add(new SqlParameter("@rid", intRID));
            dbCom.Parameters.Add(new SqlParameter("@name", Name));
            dbCom.Parameters.Add(new SqlParameter("@gender", Gender));
            dbCom.Parameters.Add(new SqlParameter("@email", email));
            dbCom.Parameters.Add(new SqlParameter("@mobileNum", MobileNum));
            dbCom.Parameters.Add(new SqlParameter("@dob", DOB.ToString("yyyy-MM-dd")));
            dbCom.Parameters.Add(new SqlParameter("@isactive", isactive));
            dbCom.Parameters.Add(new SqlParameter("@address", address));
            dbCom.Parameters.Add(new SqlParameter("@Groupid", Groupid));

            retVal = dbCom.ExecuteScalar().ToString();
            dbCom.Parameters.Clear();
            dbCom.Cancel();
            dbCom.Dispose();

            #endregion
            dbTrn.Commit();
            return retVal;
        }
        catch (Exception ex)
        {
            if (isInTran)
                dbTrn.Rollback();
            retVal = "Err : " + ex.Message.ToString();
            throw ex;
        }
        finally
        {
            if (dbCom != null)
                dbCom.Dispose();

            if (dbCon != null)
                dbCon.Dispose();

            dbCom = null;
            dbCon = null;
        }
    }

}