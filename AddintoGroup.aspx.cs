using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class AddintoGroup : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCompo();
        }
    }
    public void FillCompo()
    {
        //DataTable dt = db.ExecuteTable("select * from UserGroup where isactive=1");
        //ddlUserGroup.DataSource = dt;
        //ddlUserGroup.DataTextField = "UserGroup";
        //ddlUserGroup.DataValueField = "rid";
        //ddlUserGroup.DataBind();
        //ddlUserGroup.SelectedIndex = 0;

        DataTable dt1 = db.ExecuteTable("select * from GroupsName where active=1");
        ddlGroup.DataSource = dt1;
        ddlGroup.DataTextField = "GroupName";
        ddlGroup.DataValueField = "rid";
        ddlGroup.DataBind();
        ddlGroup.SelectedIndex = 0;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in radTOBE.MasterTableView.Items)
        {
            CheckBox CheckBox1 = item.FindControl("chkAdd") as CheckBox;
            if (CheckBox1 != null && CheckBox1.Checked)
            {
                
                string strGroupid= ddlGroup.SelectedValue;
                string userID = item["rid"].Text; ;
                db.ExecuteTable("Insert into UserGroupMaping values("+userID+","+strGroupid+")");
               
            }
        }
        ddlGroup_SelectedIndexChanged(this, EventArgs.Empty);
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in radAdded.MasterTableView.Items)
        {
            CheckBox CheckBox1 = item.FindControl("ChkRemove") as CheckBox;
            if (CheckBox1 != null && CheckBox1.Checked)
            {

                string strGroupid = ddlGroup.SelectedValue;
                string userID = item["rid"].Text; ;
                db.ExecuteTable("delete from UserGroupMaping where userid=" + userID + " and groupid=" + strGroupid);
                
            }
        }
        ddlGroup_SelectedIndexChanged(this, EventArgs.Empty);
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt1 = db.ExecuteTable("select rid,Name,MobileNumber from MembersMaster where isactive=1 and rid in(select userid from usergroupmaping where groupid="+ ddlGroup.SelectedValue +")");
        radAdded.DataSource = dt1;
        radAdded.DataBind();

        DataTable dt2 = db.ExecuteTable("select rid,Name,MobileNumber from MembersMaster where isactive=1 and rid not in(select userid from usergroupmaping where groupid=" + ddlGroup.SelectedValue + ")");
        radTOBE.DataSource = dt2;
        radTOBE.DataBind();

    }
}