using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PatientEntry : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null, Qry2 = null;

    int auto_id = 0;
    string auto_string = null;
    string uploadPath = null, uploadPath1 = null;
    string ServerURL = null, ServerURL1 = null;

    DataSet dst1 = null;
    DataTable dt1 = null;

    int RecID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {
                PackListBind();
               
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    public void PackListBind()
    {
        try
        {
            Qry1 = "select * from TblPatientEntry";
            if (cls1.record_availability(Qry1))
            {
                PackList.Visible = true;
                dst1 = cls1.bnd("select * from TblPatientEntry");
                PackList.DataSource = dst1;
                PackList.DataBind();
            }
            else
            {
                PackList.Visible = false;
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void PackList_RowEditing(object sender, GridViewEditEventArgs e)
    {

        if (IsPostBack)
        {
            RecID = Convert.ToInt32(PackList.DataKeys[e.NewEditIndex].Value.ToString());
            Session["PackRecID"] = RecID;
            PackList.EditIndex = e.NewEditIndex;
            //cls1.MessageBox("Record ID:" + RecID, this);
            PanelMaster.Visible = false;
            PanelPriceTagAdd.Visible = true;
            dst1 = cls1.bnd("select * from TblPatientEntry where RecID=" + RecID + "");
            dt1 = dst1.Tables[0];

            foreach (DataRow dr1 in dt1.Rows)
            {
               // TxtName.Text = Convert.ToString(dr1["CateName"]);
            }

            //TxtPriceItem.Text = packProdName;
            //TxtPriceAmount.Text = Convert.ToString(Amount);
            btnInsertPack.Text = "UPDATE RECORD";
        }

    }
    protected void rowup(object sender, GridViewUpdateEventArgs e)
    {
        PackList.EditIndex = -1;
    }
    protected void rowdel(object sender, GridViewCancelEditEventArgs e)
    {
        PackList.EditIndex = -1;
    }

    protected void PackList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        RecID = Convert.ToInt32(PackList.DataKeys[e.RowIndex].Value.ToString());
        Session["PackRecID"] = RecID;

        Qry1 = "Delete from TblPatientEntry where RecID=" + Convert.ToInt32(PackList.DataKeys[e.RowIndex].Value.ToString()) + "";
        cls1.insert_update_delete(Qry1);
        PackListBind();

    }


    protected void PackList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PackList.PageIndex = e.NewPageIndex;
        PackListBind();
    }




    protected void PackList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnAddPack_Click(object sender, EventArgs e)
    {
        try
        {
            PanelMaster.Visible = false;
            PanelPriceTagAdd.Visible = true;
            btnInsertPack.Text = "INSERT RECORD";
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }
    protected void btnInsertPack_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnInsertPack.Text == "INSERT RECORD")
            {
                Qry2 = "insert into TblPatientEntry values ('" + txt_patname.Text + "','" + TxtSymptom.Text + "','" + txt_hosp.Text + "','" + cbogen.SelectedItem.Text + "','" + txt_dob.Text + "','" + txt_add.Text + "','" + txt_cty.Text + "','" + txt_state.Text + "','" + txt_pin.Text + "','" + txt_mob.Text + "')";

                cls1.insert_update_delete(Qry2);
                cls1.Clear(this);
                cls1.MessageBox("New Record Inserted!!", this);
            }
            else if (btnInsertPack.Text == "UPDATE RECORD")
            {

                //Qry1 = "update TblSymtom set CateName='" + Catename.SelectedItem.Text + "', Symtoms='" + TxtName.Text + "' where RecID=" + Convert.ToInt32(Session["PackRecID"]) + "";
                ////ServiceType='" + TxtServiceType.Text + "',ServiceAmt=" + Convert.ToDecimal(TxtServiceAmount.Text) + " where RecID=" + Convert.ToInt32(Session["PackRecID"]) + "";
                //cls1.insert_update_delete(Qry1);
                //cls1.Clear(this);
                //PackListBind();
                //cls1.MessageBox("Record Update!!", this);
                //PanelMaster.Visible = true;
                //PanelPriceTagAdd.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }
    protected void btnAddPackBack_Click(object sender, EventArgs e)
    {
        try
        {
            PackListBind();
            PanelPriceTagAdd.Visible = false;
            PanelMaster.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}