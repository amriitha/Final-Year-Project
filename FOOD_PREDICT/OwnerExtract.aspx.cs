using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Text;
using System.Text.RegularExpressions;


public partial class OwnerExtract : System.Web.UI.Page
{

    common_source cls1 = new common_source();
    string Qry1 = null;
    String Qry2 = null;
    DataSet dst1 = null;
    DataTable dt1 = null;

    string OwnerID=null;
    string Age = null, Chest_pain = null, Rest_bpress = null, blood_sugar = null, rest_electro = null, max_heart_rate = null, exercise = null, diease = null;

    int RecID = 0;

    md5_des md1 = new md5_des();

    string mobileNo = null, Key1 = null;
    string Mess1 = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {
                mobileNo = cls1.return_single_string("select Mobile1 from TblOwnerRegister where User1='" + Session["UserName"] + "'");
                Key1 = cls1.return_single_string("select noiseID from TblServerKeyInfo where OwnerID='" + Session["UserName"] + "'");
                Mess1 ="Your Confidential Key: " + Key1;
                cls1.Dial2SMS(mobileNo, Mess1);
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void btnExtractKey_Click(object sender, EventArgs e)
    {
        try
        {
            Qry1 = "select * from TblServerKeyInfo where OwnerID='" + Session["UserName"] + "' and NoiseID='" + TxtKey1.Text + "'";
            if (cls1.record_availability(Qry1))
            {
                cls1.insert_update_delete("delete from TblDummyResult");

                dst1 = cls1.bnd("select * from TblDataset where OwnerID='" + Session["UserName"] + "'");
                dt1 = dst1.Tables[0];
                foreach (DataRow dr1 in dt1.Rows)
                {
                    RecID = Convert.ToInt32(dr1["RecID"]);

                    OwnerID = Convert.ToString(dr1["OwnerID"]);

                    Age = Convert.ToString(dr1["Age"]);
                    Age = md1.psDecrypt(Age);
                    Age = decrypt_eliminate(TxtKey1.Text, Age);

                    ////string myText = TxtDecryptMess.Text;
                    //string key1 = "#" + TxtKey1.Text + "#";
                    //Regex badWords = new Regex(key1, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    ////Regex badWords = new Regex("#123#", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    //Age = badWords.Replace(Age, string.Empty);

                    Chest_pain = Convert.ToString(dr1["chest_paint"]);
                    Chest_pain = md1.psDecrypt(Chest_pain);
                    Chest_pain = decrypt_eliminate(TxtKey1.Text, Chest_pain);

                    Rest_bpress = Convert.ToString(dr1["rest_bpress"]);
                    Rest_bpress = md1.psDecrypt(Rest_bpress);
                    Rest_bpress = decrypt_eliminate(TxtKey1.Text, Rest_bpress);

                    blood_sugar = Convert.ToString(dr1["blood_sugar"]);
                    blood_sugar = md1.psDecrypt(blood_sugar);
                    blood_sugar = decrypt_eliminate(TxtKey1.Text, blood_sugar);


                    rest_electro = Convert.ToString(dr1["rest_electro"]);
                    rest_electro = md1.psDecrypt(rest_electro);
                    rest_electro = decrypt_eliminate(TxtKey1.Text, rest_electro);

                    max_heart_rate = Convert.ToString(dr1["max_heart_rate"]);
                    max_heart_rate = md1.psDecrypt(max_heart_rate);
                    max_heart_rate = decrypt_eliminate(TxtKey1.Text, max_heart_rate);

                    exercise = Convert.ToString(dr1["exercice_angina"]);
                    exercise = md1.psDecrypt(exercise);
                    exercise = decrypt_eliminate(TxtKey1.Text, exercise);


                    diease = Convert.ToString(dr1["disease"]);
                    diease = md1.psDecrypt(diease);
                    diease = decrypt_eliminate(TxtKey1.Text, diease);

                    Qry1 = "insert into TblDummyResult values (" + RecID + ",'" + OwnerID + "','" + Age + "','" + Chest_pain + "','" + Rest_bpress + "','" + blood_sugar + "','" + rest_electro + "','" + max_heart_rate + "','" + exercise + "','" + diease + "')";
                    cls1.insert_update_delete(Qry1);

                }

                ResultGrid.DataSource = cls1.bnd("select Age,chest_paint,rest_bpress,blood_sugar,rest_electro,max_heart_rate,exercice_angina,disease from TbldummyResult");
                ResultGrid.DataBind();

            }
            else
            {
                cls1.MessageBox("Sorry!Invalid Key", this);
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }


    public string decrypt_eliminate(string seckey,string inputstr)
    {
        string ret_val = null;
        //string myText = TxtDecryptMess.Text;
        string key1 = "#" + seckey + "#";
        Regex badWords = new Regex(key1, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        //Regex badWords = new Regex("#123#", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        ret_val = badWords.Replace(inputstr, string.Empty);
        return ret_val;
    }
}