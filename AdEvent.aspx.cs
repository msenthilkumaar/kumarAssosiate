using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdEvent : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCompo();
            //  loadEvents();
        }
    }
    public void FillCompo()
    {
      //  DataTable dt1 = db.ExecuteTable("select * from GroupsName where active=1 and rid in (select distinct groupid from UserGroupMaping where userid=" + Convert.ToString(Session["sessID"]) + ")");
        DataTable dt1 = db.ExecuteTable("select * from GroupsName where active=1 and adminId='" + Convert.ToString(Session["sessID"]) + "'"); // rid in (select distinct groupid from UserGroupMaping where userid=" + Convert.ToString(Session["sessID"]) + ")");
        ddlGroup.DataSource = dt1;
        ddlGroup.DataTextField = "GroupName";
        ddlGroup.DataValueField = "rid";
        ddlGroup.DataBind();
        ddlGroup.SelectedIndex = 0;
    }


    private void loadEvents()
    {
        DataTable dt = db.ExecuteTable("SELECT D_RID ID,[D_Date] Date ,[D_Day] Day, [D_Time] Time ,[Place] FROM Event where Event_UserGrp=" + ddlGroup.SelectedValue + " and D_active=1 and Event_Group='" + ddlYear.SelectedItem.Text + "' and Event_Month='" + RadDatePicker1.SelectedDate.Value.Month.ToString() + "'");
        GVEvent.DataSource = dt;
        GVEvent.DataBind();


    }
    protected void RadCalendar1_SelectionChanged(object sender, Telerik.Web.UI.Calendar.SelectedDatesEventArgs e)
    {

        //lblDate.Text = RadCalendar1.SelectedDate.ToLongDateString();
        //lblDay.Text = RadCalendar1.SelectedDate.DayOfWeek.ToString();
        //lblRID.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            TimeSpan tsp = RadTimePicker1.SelectedDate.Value.TimeOfDay;
            TimeSpan tsp1 = RadTimePicker2.SelectedDate.Value.TimeOfDay;

            Int64 intRid = 0;
            if (lblRID.Text != "")
                intRid = Convert.ToInt64(lblRID.Text);
            EventMaster evn = new EventMaster();
            evn.D_rid = intRid;
            evn.D_active = true;
            evn.D_Date = Convert.ToDateTime(lblDate.Text).ToString("yyyy-MM-dd");
            evn.D_Day = lblDay.Text;
            evn.D_Time = Convert.ToDateTime(lblDate.Text).Add(tsp).ToString("yyyy-MM-dd HH:mm");
            evn.D_Time1 = Convert.ToDateTime(lblDate.Text).Add(tsp1).ToString("yyyy-MM-dd HH:mm");
            evn.Place = txtPlace.Text;
            evn.GroupId = Convert.ToInt32(ddlGroup.SelectedValue);
            evn.CreatedBY = Convert.ToInt32(Session["sessID"]);
            evn.D_active = chkactive.Checked;
            evn.Remarks = txtMessages.Text;
            evn.Event_Group = ddlYear.SelectedItem.Text;
            evn.Event_Month = RadDatePicker1.SelectedDate.Value.Month.ToString();
            string strMsg = evn.InsertEvents();
            lblMessages.Text = strMsg;
            loadEvents();
        }
        catch (Exception ex)
        {
            lblMessages.Text = ex.Message;
        }
       

    }
    protected void GVEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = GVEvent.Rows[GVEvent.SelectedIndex].Cells[0].Text;
        FillDetails(strrid);
    }
    protected void GVEvent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='pointer';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this.GVEvent, "Select$" + e.Row.RowIndex.ToString()));

            e.Row.Cells[1].Text = Convert.ToDateTime(e.Row.Cells[1].Text).ToString("dd/MM/yyyy");
        }
    }
    private void FillDetails(string strrid)
    {

        DataTable dtEmp = db.ExecuteTable("select * from Event where D_rid='" + strrid + "'");
        if (dtEmp.Rows.Count == 1)
        {
            lblRID.Text = strrid;
            lblDate.Text = Convert.ToDateTime(dtEmp.Rows[0]["D_Date"]).ToString("dddd, MMMM dd, yyyy");
            RadTimePicker1.SelectedDate = DateTime.Parse(Convert.ToString(dtEmp.Rows[0]["D_Time"]));
            RadTimePicker2.SelectedDate = DateTime.Parse(Convert.ToString(dtEmp.Rows[0]["D_Time2"]));
            lblDay.Text = Convert.ToString(dtEmp.Rows[0]["D_Day"]);
            txtPlace.Text = Convert.ToString(dtEmp.Rows[0]["place"]);
            txtMessages.Text = Convert.ToString(dtEmp.Rows[0]["Remarks"]);
            chkactive.Checked = Convert.ToBoolean(dtEmp.Rows[0]["D_active"]);
            RadDatePicker1.SelectedDate = Convert.ToDateTime(dtEmp.Rows[0]["D_Date"]);
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadEvents();
    }
    protected void RadDatePicker1_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {

        lblDate.Text = RadDatePicker1.SelectedDate.Value.ToLongDateString();
        lblDay.Text = RadDatePicker1.SelectedDate.Value.DayOfWeek.ToString();
        lblRID.Text = "";
        txtMessages.Text = "";
        txtPlace.Text = "";
        loadEvents();
    }
}