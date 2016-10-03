using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdViewMessage : Telerik.Web.UI.RadAjaxPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DbCon db = new DbCon();
        if (!IsPostBack)
        {
            try
            {
                DataTable dt = db.ExecuteTable("SELECT B.Name,A.[Messages],A.[msgDate] FROM [MsgtoAdmin] A inner join MembersMaster B on b.rid=A.userid and B.isActive=1 and userid in(select distinct userid from UserGroupMaping where Groupid in(select rid from GroupsName where adminId='" + Convert.ToString(Session["sessID"]) + "'))");
                GVMessages.DataSource = dt;
                GVMessages.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
    }
}