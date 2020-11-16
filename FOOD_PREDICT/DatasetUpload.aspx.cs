using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

public partial class DatasetUpload : System.Web.UI.Page
{


    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
    SqlCommand cmd = default(SqlCommand);
    SqlDataAdapter ad = default(SqlDataAdapter);
    DataSet ds = default(DataSet);
    SqlDataReader rd = default(SqlDataReader);

    int auto_id = 0;
    string auto_string = null;

    int count1 = 0;

    DataSet dst1;
    DataTable dt1;
    string Qry1 = null, Qry2 = null, Qry3 = null;
    string SubjCode = null, SubjName = null;


    md5_des md1 = new md5_des();


    string annual = null, jan_feb = null, mar_may = null, jun_sep = null, oct_dec = null;

    string ownerID = null ,Disease = null, Type = null, BreakFast = null, Lunch = null, Snack = null, Dinner = null, FoodNotRecommended = null, disease = null;


    String food = null, age_from = null, age_to = null, sugar_fp_from = null, sugar_fp_to = null, sugar_af_from = null, sugar_af_to = null;
    String BP_Min_from = null, BP_Min_to = null, BP_Max_from = null, BP_Max_to = null;


    common_source cls1 = new common_source();
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

        try
        {
            string localPath = null;

            cls1.insert_update_delete("delete from tblfooddataset");

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


                    //After connecting to the Excel sheet here we are selecting the data 
                    //using select statement from the Excel sheet
                    OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
                    oconn.Open();  //Here [Sheet1$] is the name of the sheet 
                    //in the Excel file where the data is present
                    OleDbDataReader odr = ocmd.ExecuteReader();


                    while (odr.Read())
                    {
                       Disease = Convert.ToString(valid(odr, 0));
                       food = Convert.ToString(valid(odr, 1));
                        age_from = Convert.ToString(valid(odr, 2));
                        sugar_fp_from = Convert.ToString(valid(odr, 3));
                        sugar_af_from = Convert.ToString(valid(odr, 4));
                        BP_Min_from = Convert.ToString(valid(odr, 5));
                        BP_Max_from = Convert.ToString(valid(odr, 6));

                        if (Disease != "")
                        {


                            cmd = new SqlCommand("insert into TblFoodDataset (disease,food,age1,sugar_fp,sugar_af,bp_min,bp_max) values (@disease,@food,@age1,@sugar_fp,@sugar_af,@bp_min,@bp_max)", cn);
                            //cmd.CommandText = @"insert into TblFoodDataset (disease,food,age_from,age_to,sugar_fp_from,sugar_fp_to,sugar_af_from,sugar_af_to,bp_min_from,bp_min_to,bp_max_from,bp_max_to) values (@disease,@food,@age_from,@age_to,@sugar_fp_from,@sugar_fp_to,@sugar_af_from,@sugar_af_to,@bp_min_from,@bp_min_to,@bp_max_from,@bp_max_to)"; 
                            cmd.Parameters.AddWithValue("@disease", Disease);
                            cmd.Parameters.AddWithValue("@food", food);
                            cmd.Parameters.AddWithValue("@age1", age_from);
                            cmd.Parameters.AddWithValue("@sugar_fp", sugar_fp_from);
                            cmd.Parameters.AddWithValue("@sugar_af", sugar_af_from);
                            cmd.Parameters.AddWithValue("@bp_min", BP_Min_from);
                            cmd.Parameters.AddWithValue("@bp_max", BP_Max_from);
                            if (cn.State == ConnectionState.Open)
                            {
                                cn.Close();
                            }
                            cn.Open();
                            cmd.ExecuteNonQuery();

                            //Qry1 = "insert into TblFoodDataset (disease,food,age_from,age_to,sugar_fp_from,sugar_fp_to,sugar_af_from,sugar_af_to,bp_min_from,bp_min_to,bp_max_from,bp_max_to)  values ('" + Disease + "','" + age_from + "','" + age_to + "','" + sugar_fp_from + "','" + sugar_fp_to + "','" + sugar_af_from + "','" + sugar_af_to + "','" + BP_Min_from + "','" + BP_Min_to + "','" + BP_Max_from + "','" + BP_Max_to + "')";

                        }
                        //cls1.insert_update_delete(Qry1);
                        //insertData(RegNo, StuName, DeptName, Course, AcadYear, Issues, ContactNo, FatherName, Gender);
                    }
                    oconn.Close();
            }
            catch (DataException ee)
            {

                lblmsg.Text = ee.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                cn.Close();
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

    public void insertData(string RegNo, string StuName, string DeptName, string Course, string AcadYear, string Issues, string ContactNo, string FatherName, string Gender)
    {

        Qry1 = "insert into TblStuDataset values ('" + RegNo + "','" + StuName + "','" + DeptName + "','" + Course + "','" + AcadYear + "','" + Issues + "','" + ContactNo + "','" + FatherName + "','" + Gender + "')";
        cls1.insert_update_delete(Qry1);

    }
}