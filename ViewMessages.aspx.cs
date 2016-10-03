using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ViewMessages : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            try
            {
                DataTable dt = db.ExecuteTable("SELECT B.Name,A.[Messages],A.[msgDate] FROM [MsgtoAdmin] A inner join MembersMaster B on b.rid=A.userid and B.isActive=1");
                GVMessages.DataSource = dt;
                GVMessages.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
    }
}