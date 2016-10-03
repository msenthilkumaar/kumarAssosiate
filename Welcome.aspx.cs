using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Welcome : Telerik.Web.UI.RadAjaxPage 
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
            string strQuery = "select D_rid,D_date,D_Time from Event Where D_active=1 and Event_Month='" + i.ToString() + "'";
            DataTable dt = db.ExecuteTable(strQuery);
            if (dt.Rows.Count == 0)
                dt = new DataTable();
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
    public void CommonEvent(object sender, GridViewRowEventArgs e, Control cntrl)
    {
        e.Row.Cells[0].Visible = false;
       
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Text = "Date";
            e.Row.Cells[2].Text = "Time";
            // e.Row.Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='pointer';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(cntrl, "Select$" + e.Row.RowIndex.ToString()));

            DateTime dtchk = Convert.ToDateTime(e.Row.Cells[1].Text);
            if (DateTime.Now <= dtchk)
            {
                e.Row.Cells[1].Text = dtchk.ToString("dd/MM/yyy");

            }
            else
            {
                e.Row.Cells[1].Text = dtchk.ToString("dd/MM/yyy");
                e.Row.BackColor = Color.FromName("#E6E6E6");
                e.Row.ForeColor = Color.Red;
            }
        }
    }
    protected void G1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G1);
    }
  
    
    private void showDetails(string strID )
    {
        DataTable dt= db.ExecuteTable("select * from Event where D_rid=" + strID);
        if (dt.Rows.Count != 0)
        {
            string strString = string.Empty;
            strString = "Event Date : " + Convert.ToDateTime(dt.Rows[0]["D_Date"]).ToString("dd/MM/yyyy") + " / " + Convert.ToString(dt.Rows[0]["D_Day"]);
            strString += " <br /> Event Time : " + Convert.ToString(dt.Rows[0]["D_Time"]);
            strString += " <br /> Place : " + Convert.ToString(dt.Rows[0]["Place"]);
            strString += " <br /> Remarks : " + Convert.ToString(dt.Rows[0]["Remarks"]);
            RadWindowManager1.RadAlert(strString , 330, 200, "Event Details", "", "testt");
        }
       
    }
    protected void G1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G1.Rows[G1.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G10_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G10.Rows[G10.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G2);
    }
    protected void G2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G2.Rows[G2.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G3);
    }
    protected void G4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G4);
    }
    protected void G5_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G5);
    }
    protected void G6_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G6);
    }
    protected void G7_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G7);
    }
    protected void G8_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G8);
    }
    protected void G9_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G9);
    }
    protected void G10_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G10);
    }
    protected void G11_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G11);
    }
    protected void G12_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G12);
    }
    protected void G3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G3.Rows[G3.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G4_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G4.Rows[G4.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G5_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G5.Rows[G5.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G6_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G6.Rows[G6.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G7_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G7.Rows[G7.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G8_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G8.Rows[G8.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G9_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G9.Rows[G9.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G11_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G11.Rows[G11.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G12_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strrid = G12.Rows[G12.SelectedIndex].Cells[0].Text;
        showDetails(strrid);
    }
    protected void G2_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        CommonEvent(sender, e, G2);
    }
}