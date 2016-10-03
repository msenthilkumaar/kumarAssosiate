using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class Home : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEvents();
        }
    }

    public void LoadEvents()
    {
        for (int i = 1; i <= 12; i++)
        {
            string strQuery = "select D_date,D_Time from Event Where D_active=1 and Event_Month='"+i.ToString()+"'";
            DataTable dt= db.ExecuteTable(strQuery);
            if (i == 1)
            {
                G1.DataSource = dt;
                G1.DataBind();
            }
            if (i == 2)
            {
                G2.DataSource = dt;
                G2.DataBind();
            }
            if (i == 3)
            {
                G3.DataSource = dt;
                G3.DataBind();
            }
            if (i == 4)
            {
                G4.DataSource = dt;
                G4.DataBind();
            }
            if (i == 5)
            {
                G5.DataSource = dt;
                G5.DataBind();
            }
            if (i == 6)
            {
                G6.DataSource = dt;
                G6.DataBind();
            }
            if (i == 7)
            {
                G7.DataSource = dt;
                G7.DataBind();
            }
            if (i == 8)
            {
                G8.DataSource = dt;
                G8.DataBind();
            }
            if (i == 9)
            {
                G9.DataSource = dt;
                G9.DataBind();
            }
            if (i == 10)
            {
                G10.DataSource = dt;
                G10.DataBind();
            }
            if (i == 11)
            {
                G11.DataSource = dt;
                G11.DataBind();
            }
            if (i == 12)
            {
                G12.DataSource = dt;
                G12.DataBind();
            }
          
           // grid(str);
           // GridView str = new GridView();

        }
    }
    public void grid(GridView str)
    {

    }
    protected void G1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "Date";
            e.Row.Cells[1].Text = "Time";
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dtchk = Convert.ToDateTime(e.Row.Cells[0].Text);
            if (DateTime.Now <= dtchk)
            {
                e.Row.Cells[0].Text = dtchk.ToString("dd/MM/yyy");
               
            }
            else
            {
                e.Row.Cells[0].Text = dtchk.ToString("dd/MM/yyy");
                e.Row.BackColor = Color.FromName("#E6E6E6");
                e.Row.ForeColor = Color.Red;
            }
        }
    }
    protected void G1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }
}