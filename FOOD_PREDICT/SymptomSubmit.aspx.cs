using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SymptomSubmit : System.Web.UI.Page
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

    String packBrandName = null, packCategory = null, packProdName = null, packPackSize = null;
    int Amount = 0;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {
                PackListBind();
                bindRegistered_Symptom();
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
            Qry1 = "select * from TblDataSetSym";
            if (cls1.record_availability(Qry1))
            {
                PackList.Visible = true;
                dst1 = cls1.bnd(Qry1);
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

    public void bindRegistered_Symptom()
    {
        try
        {
            Qry1 = "select * from TblPatSymptoms where user1='" + Session["UserName"] + "'";
            //Response.Write(Qry1);
            RegisterList.DataSource = cls1.bnd(Qry1);
            RegisterList.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }


    protected void PackList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PackList.PageIndex = e.NewPageIndex;
        PackList.EditIndex = -1;
        PackListBind();
    }

    protected void PackList_RowEditing(object sender, GridViewEditEventArgs e)
    {

        String Symptom = null, diease = null, Type1 = null;

        RecID = Convert.ToInt32(PackList.DataKeys[e.NewEditIndex].Value.ToString());
        Session["PackRecID"] = RecID;
        //cls1.MessageBox("Record ID:" + RecID, this);
        
        
        dst1 = cls1.bnd("select * from TblDataSetSym where RecID=" + RecID + "");
        dt1 = dst1.Tables[0];

        foreach (DataRow dr1 in dt1.Rows)
        {
            Symptom = Convert.ToString(dr1["symptom"]);
            diease = Convert.ToString(dr1["disease"]);
            Type1 = Convert.ToString(dr1["Type2"]);

            Qry1 = "select * from TblPatSymptoms where user1='" + Session["UserName"] + "' and Symptom='" + Symptom + "' and diease='" + diease + "'";
            cls1.MessageBox(Qry1, this);
            if (!(cls1.record_availability(Qry1)))
            {
                Qry1 = "insert into TblPatSymptoms (User1,Symptom,Diease,Type) values ('" + Session["UserName"] + "','" + Symptom + "','" + diease + "','" + Type1 + "')";
                cls1.insert_update_delete(Qry1);
                PackList.EditIndex = -1;
                cls1.MessageBox("Registered!", this);
                bindRegistered_Symptom();
            }
            else
            {
                cls1.MessageBox("Sorry!Already Exists", this);
            }
        }

        //TxtPriceItem.Text = packProdName;
        //TxtPriceAmount.Text = Convert.ToString(Amount);
        PackList.EditIndex = -1;
        PackListBind();


    }



    protected void PackList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RegisterList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void RegisterList_EditCommand(object sender, DataListCommandEventArgs e)
    {
        try
        {
            RecID = Convert.ToInt32(RegisterList.DataKeys[e.Item.ItemIndex]);
            Qry1 = "Delete from TblPatSymptoms where RecID=" + RecID + "";
            cls1.insert_update_delete(Qry1);
            bindRegistered_Symptom();
            PackList.EditIndex = -1;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

}