using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DieasePredict : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null, Qry2 = null;

    int auto_id = 0;
    string auto_string = null;
    string uploadPath = null, uploadPath1 = null;
    string ServerURL = null, ServerURL1 = null;

    DataSet dst1 = null;
    DataTable dt1 = null;

    DataSet dst2 = null;
    DataTable dt2 = null;

    int RecID = 0;

    String packBrandName = null, packCategory = null, packProdName = null, packPackSize = null;
    int Amount = 0;

    String diseaseName = null;
    String symptom = null;


    int Count1 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {
                bindRegistered_Symptom();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }
    protected void RegisterList_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    protected void btnResult_Click(object sender, EventArgs e)
    {
        try
        {

            Qry1 = "Delete from TblTmpResult";
            cls1.insert_update_delete(Qry1);

            //Find the Available Disease

            dst1 = cls1.bnd("select distinct(disease) FROM TblDataSetSym");
            dt1 = dst1.Tables[0];
            foreach (DataRow dr1 in dt1.Rows)
            {
                diseaseName = Convert.ToString(dr1["disease"]);
                //symptom = Convert.ToString(dr1["Symptom"]);
                Qry1 = "insert into TblTmpResult (disease) values ('" + diseaseName + "')";
                cls1.insert_update_delete(Qry1);
            }


            //Identify Disease with Registered Symptoms
            dst2 = cls1.bnd("select * from TblPatSymptoms where user1='" + Session["UserName"] + "'");
            dt2 = dst2.Tables[0];
            foreach (DataRow dr2 in dt2.Rows)
            {
                symptom = Convert.ToString(dr2["symptom"]);
                diseaseName = cls1.return_single_string("select Disease from TblDataSetSym where symptom like '%" + symptom + "'");
                Qry1 = "insert into TblTmpResult (disease) values ('" + diseaseName + "')";
             }

            //Finding Maximum Ratio of Disease
            dst1 = cls1.bnd("select * from tblTmpResult");
            dt1 = dst1.Tables[0];
            foreach (DataRow dr1 in dt1.Rows)
            {
                diseaseName = Convert.ToString(dr1["Disease"]);
                Count1 = cls1.record_count("select count(*) from TblPatSymptoms where diease='" + diseaseName + "'");
                Qry2 = "update TblTmpResult set TotCount=" + Count1 + " where Disease='" + diseaseName + "'";
                cls1.insert_update_delete(Qry2);
            }

            lblDisease.Visible = true;
            LblResult.Visible = true;
            LblResult.Text = "RESULT:";
            lblDisease.Text = cls1.return_single_string("select Disease FROM TblTmpResult order by TotCount desc");


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    public void RegisterList_EditCommand(object sender, DataListCommandEventArgs e)
    {
        try
        {
            RecID = Convert.ToInt32(RegisterList.DataKeys[e.Item.ItemIndex]);
            Qry1 = "Delete from TblPatSymptoms where RecID=" + RecID + "";
            cls1.insert_update_delete(Qry1);
            bindRegistered_Symptom();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

}