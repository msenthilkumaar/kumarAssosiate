using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;


/// <summary>
/// Summary description for EventMaster
/// </summary>
public class EventMaster 
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
	public EventMaster()
	{
        sqlCon = new SqlConnection(ConnectionString);
	}

    public Int64 D_rid { get; set; }
    public string D_Date { get; set; }
    public string D_Time { get; set; }
    public string D_Day { get; set; }
    public bool D_active { get; set; }
    public string Place { get; set; }
    public Int32 GroupId { get; set; }
    public Int32 CreatedBY { get; set; }
    public string D_Time1 { get; set; }
    public string Remarks { get; set; }
    public string Event_Group { get; set; }
    public string Event_Month{get;set;}
    public string InsertEvents()
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
            dbCom = new SqlCommand("INS_Event", dbCon, dbTrn);
            dbCom.CommandType = CommandType.StoredProcedure;

            dbCom.Parameters.Add(new SqlParameter("@rid", D_rid));
            dbCom.Parameters.Add(new SqlParameter("@Edate", D_Date));
            dbCom.Parameters.Add(new SqlParameter("@Etime", D_Time));
            dbCom.Parameters.Add(new SqlParameter("@Eday", D_Day));
            dbCom.Parameters.Add(new SqlParameter("@EStatus", D_active));
            dbCom.Parameters.Add(new SqlParameter("@EPlace", Place));
            dbCom.Parameters.Add(new SqlParameter("@Remarks", Remarks));
            dbCom.Parameters.Add(new SqlParameter("@Event_Group", Event_Group));
            dbCom.Parameters.Add(new SqlParameter("@Event_Month", Event_Month));
            dbCom.Parameters.Add(new SqlParameter("@Event_UserGrp", GroupId));
            dbCom.Parameters.Add(new SqlParameter("@Createdby", CreatedBY));
            dbCom.Parameters.Add(new SqlParameter("@Etime1", D_Time1));

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