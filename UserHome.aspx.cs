using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
public partial class UserHome : Telerik.Web.UI.RadAjaxPage 
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
        DataTable dt = db.ExecuteTable("select rid,GroupName from GroupsName where rid in(select distinct groupid from UserGroupMaping where userid='" + Convert.ToString(Session["sessID"]) + "')");
        ddlGroup.DataSource = dt;
        ddlGroup.DataTextField = "GroupName";
        ddlGroup.DataValueField = "rid";
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, new ListItem("All", "NA"));
        ddlGroup.SelectedIndex = 0;
        ddlGroup_SelectedIndexChanged(this, EventArgs.Empty);
    }
    protected void RadScheduler1_AppointmentCreated(object sender, Telerik.Web.UI.AppointmentCreatedEventArgs e)
    {
        //Label recurrenceIcon = (Label) e.Container.FindControl("RecurrenceIcon");
        //    if (e.Appointment.RecurrenceState != RecurrenceState.NotRecurring)
        //    {
        //        if (e.Appointment.RecurrenceState == RecurrenceState.Exception)
        //        {
        //            recurrenceIcon.CssClass = "rsAptRecurrenceException";
        //        }
        //        else
        //        {
        //            recurrenceIcon.CssClass = "rsAptRecurrence";
        //        }
        //    }
        //    else
        //    {
        //        recurrenceIcon.Visible = false;
        //    }
 
        //    Resource teacher = e.Appointment.Resources.GetResourceByType("Teacher");
        //    if (teacher != null)
        //    {
        //        e.Appointment.ToolTip = string.Format("You can reach {0} at {1}.", teacher.Text, teacher.Attributes["Phone"]);
 
        //        Label teacherLabel = (Label) e.Container.FindControl("Teacher");
        //        teacherLabel.Text = "Teacher: " + teacher.Text;
        //    }
 
        //    Label students = (Label) e.Container.FindControl("Students");
        //    int studentsCount = 0;
        //    foreach (Resource student in e.Appointment.Resources.GetResourcesByType("Student"))
        //    {
        //        studentsCount++;
        //    }
 
        //    students.Text = studentsCount.ToString() + " student(s)";
        }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlGroup.SelectedValue == "NA")
            {
                SqlDataSource1.SelectCommand = "SELECT [D_rid], [D_Date], CONVERT(datetime,D_Time,120) D_Time, [D_Day], [D_active], [Place], [CreatedDate], [Remarks], [Event_Group], [Event_Month], [Event_UserGrp], [Createdby] , CONVERT(datetime,D_Time2,120) D_Time2 FROM [Event] where D_active=1 and Event_UserGrp in (select distinct groupid from UserGroupMaping where userid='" + Convert.ToString(Session["sessID"]) + "')";
                SqlDataSource1.DataBind();
                RadScheduler1.DataBind();
            }
            else
            {
                SqlDataSource1.SelectCommand = "SELECT [D_rid], [D_Date], CONVERT(datetime,D_Time,120) D_Time, [D_Day], [D_active], [Place], [CreatedDate], [Remarks], [Event_Group], [Event_Month], [Event_UserGrp], [Createdby] , CONVERT(datetime,D_Time2,120) D_Time2 FROM [Event] where D_active=1 and Event_UserGrp =" + ddlGroup.SelectedValue;
                SqlDataSource1.DataBind();
                RadScheduler1.DataBind();
            }
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
            db.ExecuteTable("Insert into MsgtoAdmin values(" + Convert.ToInt32(Session["sessID"]) + ",'"+txtMessage.Text +"',"+DateTime.Now.ToString("yyyy-MM-dd")+")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Message Sent ')", true);
            txtMessage.Text = "";
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ex.Message+"')", true);
        }
    }
}