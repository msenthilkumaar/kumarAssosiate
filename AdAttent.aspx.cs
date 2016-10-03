using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdAttent : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCompo();
        }
    }
    private void loadCompo()
    {
        DataTable dt1 = db.ExecuteTable("select * from GroupsName where active=1 and adminId='" + Convert.ToString(Session["sessID"]) + "'"); // rid in (select distinct groupid from UserGroupMaping where userid=" + Convert.ToString(Session["sessID"]) + ")");
        ddlGroup.DataSource = dt1;
        ddlGroup.DataTextField = "GroupName";
        ddlGroup.DataValueField = "rid";
        ddlGroup.DataBind();
        ddlGroup.SelectedIndex = 0;

        ddlGroup_SelectedIndexChanged(this, EventArgs.Empty);
    }
    private void loadGrids(string eventID)
    {
        DataTable dt = db.ExecuteTable("SELECT [rid],[Name] ,[MobileNumber] FROM MembersMaster where [isActive] =1 and rid IN (select userid from UserGroupMaping where groupid='" + ddlGroup.SelectedValue + "' ) and rid NOT IN (select userid from Attendence where event_id=" + eventID + ")");
        GVMembers.DataSource = dt;
        GVMembers.DataBind();

        DataTable dt1 = db.ExecuteTable("SELECT [rid] ID,[Name] ,[MobileNumber] FROM MembersMaster where [isActive] =1 and rid IN (select userid from Attendence where event_id=" + eventID + " and present=1)");
        GVPresent.DataSource = dt1;
        GVPresent.DataBind();

        DataTable dt2 = db.ExecuteTable("SELECT [rid] ID,[Name] ,[MobileNumber] FROM MembersMaster where [isActive] =1 and rid IN (select userid from Attendence where event_id=" + eventID + " and present=0)");
        GVApsent.DataSource = dt2;
        GVApsent.DataBind();
    }
    protected void ddlEvent_SelectedIndexChanged1(object sender, Telerik.Web.UI.DropDownListEventArgs e)
    {
        loadGrids(ddlEvent.SelectedValue);
    }
    protected void btnPresent_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GVMembers.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (chkRow.Checked)
                {
                    string strMemberID = row.Cells[0].Text;
                    Updaterec(strMemberID, ddlEvent.SelectedValue, 1);
                }
            }
        }
        loadGrids(ddlEvent.SelectedValue);
    }

    private void Updaterec(string strUser, string eventid, int boolPresent)
    {
        db.ExecuteTable("insert into Attendence values(" + strUser + "," + eventid + "," + boolPresent + ")");
    }
    protected void btnAbsent_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GVMembers.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (chkRow.Checked)
                {
                    string strMemberID = row.Cells[0].Text;
                    Updaterec(strMemberID, ddlEvent.SelectedValue, 0);
                }
            }
        }
        loadGrids(ddlEvent.SelectedValue);
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = db.ExecuteTable("select d_rid,d_date,D_Time from event where D_active=1 and Event_UserGrp='" + ddlGroup.SelectedValue + "'");
        ddlEvent.DataSource = dt;

        //for (int count = 0; count < dt.Rows.Count; count++)
        //{
        //    dt.Rows[count]["d_date"] = DateTime.Parse(Convert.ToDateTime(dt.Rows[count]["d_date"]).ToString("dd/MM/yyyy") + "-" + Convert.ToString(dt.Rows[count]["D_Time"]));
        //}


        ddlEvent.DataValueField = "d_rid";
        ddlEvent.DataTextField = "D_Time"; // +" - " + "D_Time";
        ddlEvent.DataBind();
    }
}