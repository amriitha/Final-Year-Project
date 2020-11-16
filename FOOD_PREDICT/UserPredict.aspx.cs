using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UserPredict : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null;

    DataSet dst1 = null, dst2 = null;
    DataTable dt1 = null, dt2 = null;

    string PreditKeyword;
    String PatientName = null, Symptom = null, Hospital = null, Gender = null, DOB = null, Address = null, MobileNo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {
                cls1.Combo_Bind(CboDiease, "select * from TblCateEntry", "CateName");
            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        try
        {
            int PatID = 0;

            cls1.insert_update_delete("delete from TempPredictResult");

            dst1 = cls1.bnd("select * from TblDataSetSym where Disease='" + CboDiease.SelectedItem.Text + "'");
            dt1 = dst1.Tables[0];
            foreach (DataRow dr1 in dt1.Rows)
            {
                //PreditKeyword = Convert.ToString(dr1["Symptom"]);

                PreditKeyword = Convert.ToString(dr1["Symptom"]);


                Qry1 = "select * from TblPatientEntry where Symtoms like '%" + PreditKeyword + "%'";
                if (cls1.record_availability(Qry1))
                {
                    dst2 = cls1.bnd(Qry1);
                    dt2 = dst2.Tables[0];
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        PatID = Convert.ToInt32(dr2["RecID"]);
                        PatientName = Convert.ToString(dr2["PatientName"]);
                        Symptom = Convert.ToString(dr2["Symtoms"]);
                        Hospital = Convert.ToString(dr2["Age"]);
                        Gender = Convert.ToString(dr2["Gender"]);
                        DOB = Convert.ToString(dr2["DOB"]);
                        Address = Convert.ToString(dr2["City"]);
                        MobileNo = Convert.ToString(dr2["MobileNo"]);

                        if (!(cls1.record_availability("Select * from TempPredictResult where PatID=" + PatID + "")))
                        {
                            Qry1 = "insert into TempPredictResult values (" + PatID + ",'" + PatientName + "','" + Symptom + "','" + Hospital + "','" + Gender + "','" + DOB + "','" + Address + "','" + MobileNo + "')";
                            cls1.insert_update_delete(Qry1);
                        }
                    }
                }
            }



            Qry1 = "select * from TempPredictResult";
            if (cls1.record_availability(Qry1))
            {
                DataPreList.Visible = true;
                cls1.DataList_Bind(DataPreList, Qry1);
            }
            else
            {
                DataPreList.Visible = false;
                cls1.MessageBox("No Record", this);

            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }

}
