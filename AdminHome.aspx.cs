using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminHome : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadGroup();
        }
    }

    public void loadGroup()
    {
        try
        {

            SqlDataSource1.SelectCommand = "SELECT [D_rid], [D_Date], CONVERT(datetime,D_Time,120) D_Time, [D_Day], [D_active], [Place], [CreatedDate], [Remarks], [Event_Group], [Event_Month], [Event_UserGrp], [Createdby] , CONVERT(datetime,D_Time2,120) D_Time2 FROM [Event] where D_active=1"; // and Event_UserGrp =" + ddlGroup.SelectedValue;
            SqlDataSource1.DataBind();
            RadScheduler1.DataBind();
        }
        catch (Exception ex)
        {
            lblErrors.Text = ex.Message;
        }
    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //db.ExecuteTable("Insert into MsgtoAdmin values(" + Convert.ToInt32(Session["sessID"]) + ",'" + txtMessage.Text + "'," + DateTime.Now.ToString("yyyy-MM-dd") + ")");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Message Sent ')", true);
            //txtMessage.Text = "";
        }
        catch (Exception ex)
        {
          //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
}