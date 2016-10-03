using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;

public partial class AddMembers : Telerik.Web.UI.RadAjaxPage 
{
    DbCon db = new DbCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

     private void FillGrid()
    {
        DataTable dt = db.ExecuteTable("select Rid,Name,MobileNUmber Mobile,EMAILID Email,isActive from MembersMaster");
        GVSearch.DataSource = dt;
        GVSearch.DataBind();

        DataTable dt1 = db.ExecuteTable("select * from UserGroup where isactive=1");
        ddlUserGroup.DataSource = dt1;
        ddlUserGroup.DataTextField = "UserGroup";
        ddlUserGroup.DataValueField = "rid";
        ddlUserGroup.DataBind();
        ddlUserGroup.SelectedIndex = 0;


      //  DataTable dt1 = db.ExecuteTable("select Rid,Name,MobileNUmber Mobile,EMAILID Email,isActive from MembersMaster");

    }

     protected void btnAdd_Click(object sender, EventArgs e)
     {
         string retVal = null;
         ArrayList ar = new ArrayList();
         Int64 intRID=0;
         if(lblRID.Text !="")
             intRID = Convert.ToInt64(lblRID.Text);
         string strGen = string.Empty;
         if (RadioButton1.Checked)
             strGen = "Male";
         else if (RadioButton2.Checked)
              strGen = "Female";
         DateTime dateDOB=new DateTime();
         if(txtDOB.Text!="")
             dateDOB=Convert.ToDateTime(txtDOB.Text);
         else
             dateDOB=DateTime.Now;
         Members mem = new Members();
         mem.intRID = intRID;
         mem.Name = Convert.ToString(txtName.Text);
         mem.Gender = strGen;
         mem.email = Convert.ToString(txtEmailid.Text);
         mem.MobileNum = Convert.ToString(txtMobile.Text);
         mem.DOB = dateDOB;
         mem.isactive =Convert.ToBoolean(ChkIsActive.Checked);
         mem.address = Convert.ToString(txtAddress.Text);
         mem.Groupid = Convert.ToInt16(ddlUserGroup.SelectedValue);
         retVal = mem.InsertMembers();
         LBLINSERMSG.Text = retVal;
         btnAdd.Enabled = false;
         FillGrid();

     }
     protected void btnClear_Click(object sender, EventArgs e)
     {
         lblRID.Text = "";
         txtName.Text = "";
         txtAddress.Text = "";
         txtDOB.Text = "";
         txtEmailid.Text = "";
         txtMobile.Text = "";
         RadioButton1.Checked = true;
         ChkIsActive.Checked = true;
         btnAdd.Enabled = true;
         LBLINSERMSG.Text = "";
         ddlUserGroup.SelectedIndex = 0;
     }
     protected void GVSearch_SelectedIndexChanged(object sender, EventArgs e)
     {
         string strrid = GVSearch.Rows[GVSearch.SelectedIndex].Cells[0].Text;
         FillDetails(strrid);
     }
     protected void GVSearch_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='pointer';this.style.backgroundColor='#ffccff';";
             e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
             e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this.GVSearch, "Select$" + e.Row.RowIndex.ToString()));
         }
     }
     private void FillDetails(string strrid)
     {

         DataTable dtEmp = db.ExecuteTable("select * from MembersMaster where rid='" + strrid + "'");
         if (dtEmp.Rows.Count == 1)
         {
             lblRID.Text = strrid;
             txtName.Text = Convert.ToString(dtEmp.Rows[0]["name"]);
             if (Convert.ToString(dtEmp.Rows[0]["Gender"]) == "Male")
             {
                 RadioButton1.Checked = true;
                 RadioButton2.Checked = false;
             }
             else if (Convert.ToString(dtEmp.Rows[0]["Gender"]) == "Female")
             {
                 RadioButton1.Checked = false;
                 RadioButton2.Checked = true;
             }
             lblUserRID.Text = strrid;
             txtEmailid.Text= Convert.ToString(dtEmp.Rows[0]["emailid"]);
             txtMobile.Text = Convert.ToString(dtEmp.Rows[0]["MobileNUmber"]);
             txtDOB.Text = Convert.ToDateTime(dtEmp.Rows[0]["DOB"]).ToString("yyyy-MM-dd");
             ChkIsActive.Checked = Convert.ToBoolean(dtEmp.Rows[0]["isActive"]);
             txtAddress.Text = Convert.ToString(dtEmp.Rows[0]["Address"]);
             LBLINSERMSG.Text = "";
             ddlUserGroup.SelectedValue = Convert.ToString(dtEmp.Rows[0]["Groupid"]);
             btnAdd.Enabled = true;
             loadImage(strrid);
         }
     }
     protected void txtSearch_TextChanged(object sender, EventArgs e)
     {
         //DataTable dt = db.ExecuteTable("select Rid,Name,MobileNUmber Mobile,EMAILID Email,isActive from MembersMaster where MobileNUmber like '%" + txtSearch.Text + "%' or name like '%" + txtSearch.Text + "%'");
         //GVSearch.DataSource = dt;
         //GVSearch.DataBind();
     }
     protected void btnUpload_Click(object sender, EventArgs e)
     {
         try
         {
             if (lblUserRID.Text != "")
             {
                 Stream fs = FileUpload1.PostedFile.InputStream;
                 BinaryReader br = new BinaryReader(fs);
                 byte[] bytes = br.ReadBytes((Int32)fs.Length);
                 string imagePath = Server.MapPath("~/Photos/" + lblUserRID.Text + ".jpg");
                 //Save the Byte Array as File.
                 //string filePath = "~/Files/" + Path.GetFileName(FileUpload1.FileName);
                 File.WriteAllBytes(imagePath, bytes);
                 lblMessage.Text = "File Uploaded";
                 loadImage(lblUserRID.Text);
             }
         }
         catch (Exception ex)
         {
             lblMessage.Text = ex.Message;
         }
     }
     public void loadImage(string strUserid)
     {
         try
         {
             string imagePath = "~/Photos/" + strUserid + ".jpg";
             Image1.ImageUrl = imagePath;
         }
         catch(Exception ex)
         {
             Image1.ImageUrl = "~/Photos/user.png";
             lblMessage.Text = ex.Message;
         }
     }
}