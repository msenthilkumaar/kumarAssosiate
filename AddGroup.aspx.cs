using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddGroup : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDetails();
        }
    }
    public void LoadDetails()
    {
        DataTable dt = db.ExecuteTable("SELECT rid 'ID',Groupname 'Group Name' FROM GroupsName ");
        GVGroupname.DataSource = dt;
        GVGroupname.DataBind();
        lblRID.Text = "0";

        DataTable dtadmin = db.ExecuteTable("select rid,name from MembersMaster where Groupid=2");
        ddlAdmin.DataSource = dtadmin;
        ddlAdmin.DataTextField = "name";
        ddlAdmin.DataValueField = "rid";
        ddlAdmin.DataBind();
        ddlAdmin.SelectedIndex = 0;
    }
    protected void GVGroupname_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='pointer';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this.GVGroupname, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void GVGroupname_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = GVGroupname.Rows[GVGroupname.SelectedIndex].Cells[0].Text;
        DataTable dt = db.ExecuteTable("select * from GroupsName where rid="+strrid);
        if (dt.Rows.Count != 0)
        {
            txtUserName.Text = Convert.ToString(dt.Rows[0]["Groupname"]);
            CheckBox1.Checked = Convert.ToBoolean(dt.Rows[0]["active"]);
            lblRID.Text = Convert.ToString(dt.Rows[0]["rid"]);
            ddlAdmin.SelectedValue = Convert.ToString(dt.Rows[0]["adminId"]);
        }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtt = db.ExecuteTable("select * from GroupsName where rid=" + lblRID.Text);
            if (dtt.Rows.Count == 0)
            {
                db.ExecuteTable("Insert into GroupsName values('" + Convert.ToString(txtUserName.Text) + "'," + Convert.ToByte(CheckBox1.Checked) + ",'" + ddlAdmin.SelectedValue + "')");
                lblMessage.Text = "Records Inserted";
            }
            else
            {
                db.ExecuteTable("Update GroupsName set adminId='" + ddlAdmin.SelectedValue + "', Groupname='" + Convert.ToString(txtUserName.Text) + "',active=" + Convert.ToByte(CheckBox1.Checked) + " where rid=" + lblRID.Text);
                lblMessage.Text = "Records Updated";
                lblRID.Text = "";
            }
            LoadDetails();
            btnSave.Enabled = false;
        }
        catch (Exception ex)
        {
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        lblRID.Text = "0";
        CheckBox1.Checked = false;
        btnSave.Enabled = true;
    }
}