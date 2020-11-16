using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class SymDataSet : System.Web.UI.Page
{
    int auto_id = 0;
    string auto_string = null;

    int count1 = 0;

    DataSet dst1;
    DataTable dt1;
    string Qry1 = null, Qry2 = null, Qry3 = null;
    string SubjCode = null, SubjName = null;


    md5_des md1 = new md5_des();


    string annual = null, jan_feb = null, mar_may = null, jun_sep = null, oct_dec = null;

    string ownerID = null, Disease = null, Type = null, Symptom = null, Lunch = null, Snack = null, Dinner = null, FoodNotRecommended = null, disease = null;

    common_source cls1 = new common_source();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

        try
        {
            string localPath = null;

            cls1.insert_update_delete("delete from TblDatasetSym");

            GC.Collect();
            localPath = "TEMP_DOC\\" + StudentFile.PostedFile.FileName.ToString();
            if (System.IO.File.Exists(localPath))
            {
                System.IO.File.Delete(localPath);
            }
            StudentFile.SaveAs(Server.MapPath(localPath));

            string xlsFileName = "TEMP_DOC\\" + StudentFile.FileName.ToString();

            //OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("example.xls") + ";Extended Properties=Excel 8.0");
            OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(localPath) + ";Extended Properties=Excel 8.0");

            //Server.MapPath(" +   + ") + ";Extended Properties=Excel 8.0");//OledbConnection and 
            // connectionstring to connect to the Excel Sheet

            try
            {

                //Qry2 = "select * from TblServerKeyInfo where OwnerID='" + Session["UserName"] + "'";
                //if (!(cls1.record_availability(Qry2)))
                //{

                    //After connecting to the Excel sheet here we are selecting the data 
                    //using select statement from the Excel sheet
                    OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
                    oconn.Open();  //Here [Sheet1$] is the name of the sheet 
                    //in the Excel file where the data is present
                    OleDbDataReader odr = ocmd.ExecuteReader();


                    while (odr.Read())
                    {
                        Disease = Convert.ToString(valid(odr, 0));
                        Type = Convert.ToString(valid(odr, 1));
                        Symptom = Convert.ToString(valid(odr, 2));



                        Qry1 = "insert into TblDataSetSym values ('"+Session["UserName"]+"','" + Disease + "','" + Type + "','" + Symptom + "')";
                        cls1.insert_update_delete(Qry1);

                        


                    }
                    oconn.Close();


                //    Qry1 = "insert into TblServerKeyInfo values ('" + Session["UserName"] + "','Y','NONE','NONE','NONE','NONE')";
                //    cls1.insert_update_delete(Qry1);
                //}
                //else
                //{
                //    cls1.MessageBox("Sorry!Every Owner Maintains single Dataset Only", this);
                //}
            }
            catch (DataException ee)
            {
                lblmsg.Text = ee.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                //System.IO.File.Delete(Server.MapPath(localPath));
                lblmsg.Text = "Data Inserted Sucessfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected string valid(OleDbDataReader myreader, int stval)//if any columns are 
    //found null then they are replaced by zero
    {
        object val = myreader[stval];
        if (val != DBNull.Value)
            return val.ToString();
        else
            return Convert.ToString(0);
    }

   
}