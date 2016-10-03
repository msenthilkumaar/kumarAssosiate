using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Login : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnSumit_Click(object sender, EventArgs e)
    {
        if (txtUser.Text.ToLower() != "admin")
        {
            DataTable dtUser = db.ExecuteTable("select * from MembersMaster where EmailID='@emailid' and MobileNUmber='@password' and isactive=1 ");
            if (dtUser.Rows.Count == 1)
            {
                if (Convert.ToString(dtUser.Rows[0]["groupid"]) == "1")
                {
                    Session["sessUser"] = Convert.ToString(dtUser.Rows[0]["Name"]);
                    Session["sessID"] = Convert.ToString(dtUser.Rows[0]["rid"]);
                    Response.Redirect("userhome.aspx");
                }
                if (Convert.ToString(dtUser.Rows[0]["groupid"]) == "2")
                {
                    Session["sessUser"] = Convert.ToString(dtUser.Rows[0]["Name"]);
                    Session["sessID"] = Convert.ToString(dtUser.Rows[0]["rid"]);
                    Response.Redirect("WelcomeAdmin.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid Username and Password";
            }
           // Response.Redirect("welcome.aspx");
        }
        else
        {
            if(txtpass.Text=="admin321")
                Response.Redirect("AdminHome.aspx");
            else
                lblMessage.Text = "Invalid Password";
        }
    }
}