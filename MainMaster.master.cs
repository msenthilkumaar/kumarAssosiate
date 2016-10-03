using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MainMaster : System.Web.UI.MasterPage
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["sessUser"] != null)
            //   // lblUser.Text = Convert.ToString(Session["sessUser"]);
            //else
            //    Response.Redirect("Login.aspx");
        }
    }
   
}
