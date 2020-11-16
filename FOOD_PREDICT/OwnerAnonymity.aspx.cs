using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Net.Mail;
using System.Threading;

using System.Net;
using System.Text;


public partial class OwnerAnonymity : System.Web.UI.Page
{

    common_source cls1 = new common_source();
    string Qry1 = null;
    String Qry2 = null;
    DataSet dst1 = null;
    DataTable dt1 = null;

    string Age = null, Chest_pain = null, Rest_bpress = null, blood_sugar = null, rest_electro = null, max_heart_rate = null, exercise = null, diease = null;

    int RecID = 0;

    md5_des md1 = new md5_des();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnNoiseGen_Click(object sender, EventArgs e)
    {
        try
        {

            Qry1 = "select * from TblServerKeyInfo where OwnerID='" + Session["UserName"] + "' and NoiseFlag='NONE'";
            if ((cls1.record_availability(Qry1)))
            {
                cls1.Combo_Bind(CboDataOwner, "select * from TblOwnerRegister where User1='" + Session["UserName"] + "'", "User1");
                PanelMaster.Visible = false;
                PanelNoiseGeneration.Visible = true;
            }
            else
            {
                cls1.MessageBox("Sorry!Noise Generation Process Completed!!", this);
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void btnGenerate1_Click(object sender, EventArgs e)
    {
        try
        {

            dst1 = cls1.bnd("select * from TblDataset where OwnerID='" + Session["UserName"] + "'");
            dt1 = dst1.Tables[0];
            foreach (DataRow dr1 in dt1.Rows)
            {
                RecID = Convert.ToInt32(dr1["RecID"]);

                Age = Convert.ToString(dr1["Age"]);
                Age = data_collapse(Age, TxtNoiseValue.Text);

                Chest_pain = Convert.ToString(dr1["chest_paint"]);
                Chest_pain = data_collapse(Chest_pain, TxtNoiseValue.Text);

                Rest_bpress = Convert.ToString(dr1["rest_bpress"]);
                Rest_bpress = data_collapse(Rest_bpress, TxtNoiseValue.Text);

                blood_sugar = Convert.ToString(dr1["blood_sugar"]);
                blood_sugar = data_collapse(blood_sugar, TxtNoiseValue.Text);

                rest_electro = Convert.ToString(dr1["rest_electro"]);
                rest_electro = data_collapse(rest_electro, TxtNoiseValue.Text);

                max_heart_rate = Convert.ToString(dr1["max_heart_rate"]);
                max_heart_rate = data_collapse(max_heart_rate, TxtNoiseValue.Text);

                exercise = Convert.ToString(dr1["exercice_angina"]);
                exercise = data_collapse(exercise, TxtNoiseValue.Text);

                diease = Convert.ToString(dr1["disease"]);
                diease = data_collapse(diease, TxtNoiseValue.Text);

                Qry1 = "Update TblDataset set Age='" + Age + "',chest_paint='" + Chest_pain + "',rest_bpress='" + Rest_bpress + "',blood_sugar='" + blood_sugar + "',rest_electro='" + rest_electro + "',max_heart_rate='" + max_heart_rate + "',exercice_angina='" + exercise + "',disease='" + diease + "' where RecID=" + RecID + "";
                cls1.insert_update_delete(Qry1);

            }

            Qry2 = "Update TblServerKeyInfo set NoiseID='" + TxtNoiseValue.Text + "',NoiseFlag='Y' where OwnerID='" + Session["UserName"] + "'";
            cls1.insert_update_delete(Qry2);

            cls1.MessageBox("Noise based Anonymity Process Completed!!", this);

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    public string data_collapse(string dbValue, string collapse_value)
    {

            string s = Convert.ToString(dbValue);

            string v = "#" + collapse_value + "#";
            //TxtRandKey.Text = v;
            //StringBuilder sb = new StringBuilder(s.Length * 2);
            StringBuilder sb = new StringBuilder(s.Length * 5);

            foreach (char c in s)
            {
                sb.Append(c);
                //sb.Append('.');
                sb.Append(v);
            }
            string result = sb.ToString();
            return result;

            //TxtCollapse.Text = result;
    }


    protected string GenerateRandom()
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";

        string characters = numbers;
            characters += alphabets + small_alphabets + numbers;
        
        int length = 5;
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        return otp;
    }
    protected void CboDataOwner_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            TxtNoiseValue.Text = GenerateRandom();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void btnBack1_Click(object sender, EventArgs e)
    {
        try
        {
            PanelNoiseGeneration.Visible = false;
            PanelMaster.Visible = true;

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void BtnNoiseResult_Click(object sender, EventArgs e)
    {
        try
        {
            Qry1 = "select * from TblServerKeyInfo where EncryptID='NONE' and EncryptFlag='NONE' and OwnerID='" + Session["UserName"] + "'";
            if (cls1.record_availability(Qry1))
            {
                noise_grid.DataSource = cls1.bnd("select * from TblDataSet where OwnerID='" + Session["userName"] + "'");
                noise_grid.DataBind();
                PanelMaster.Visible = false;
                PanelNoiseResult.Visible = true;

            }
            else
            {
                cls1.MessageBox("Sorry!No Record", this);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void Back2_Click(object sender, EventArgs e)
    {
        try
        {
            PanelNoiseResult.Visible = false;
            PanelMaster.Visible = true;

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }
    protected void btnSensitive_Click(object sender, EventArgs e)
    {
        try
        {

            Qry1 = "select * from TblServerKeyInfo where EncryptID='NONE' and EncryptFlag='NONE' and OwnerID='" + Session["UserName"] + "'";
            if (cls1.record_availability(Qry1))
            {


                dst1 = cls1.bnd("select * from TblDataset where OwnerID='" + Session["UserName"] + "'");
                dt1 = dst1.Tables[0];
                foreach (DataRow dr1 in dt1.Rows)
                {
                    RecID = Convert.ToInt32(dr1["RecID"]);

                    Age = Convert.ToString(dr1["Age"]);
                    Age = md1.psEncrypt(Age);

                    Chest_pain = Convert.ToString(dr1["chest_paint"]);
                    Chest_pain = md1.psEncrypt(Chest_pain);

                    Rest_bpress = Convert.ToString(dr1["rest_bpress"]);
                    Rest_bpress = md1.psEncrypt(Rest_bpress);

                    blood_sugar = Convert.ToString(dr1["blood_sugar"]);
                    blood_sugar = md1.psEncrypt(blood_sugar);

                    rest_electro = Convert.ToString(dr1["rest_electro"]);
                    rest_electro = md1.psEncrypt(rest_electro);

                    max_heart_rate = Convert.ToString(dr1["max_heart_rate"]);
                    max_heart_rate = md1.psEncrypt(max_heart_rate);

                    exercise = Convert.ToString(dr1["exercice_angina"]);
                    exercise = md1.psEncrypt(exercise);

                    diease = Convert.ToString(dr1["disease"]);
                    diease = md1.psEncrypt(diease);

                    Qry1 = "Update TblDataset set Age='" + Age + "',chest_paint='" + Chest_pain + "',rest_bpress='" + Rest_bpress + "',blood_sugar='" + blood_sugar + "',rest_electro='" + rest_electro + "',max_heart_rate='" + max_heart_rate + "',exercice_angina='" + exercise + "',disease='" + diease + "' where RecID=" + RecID + "";
                    cls1.insert_update_delete(Qry1);

                }

                Qry2 = "Update TblServerKeyInfo set EncryptID='" + Session["UserName"] + "',EncryptFlag='Y' where OwnerID='" + Session["UserName"] + "'";
                cls1.insert_update_delete(Qry2);

                cls1.MessageBox("Data based Anonymity Process Completed!!", this);
            }
            else
            {
                cls1.MessageBox("Sorry!Already Data Anonymity Process Exists", this);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void btnSensitiveResult_Click(object sender, EventArgs e)
    {
        try
        {
            Qry1 = "select * from TblServerKeyInfo where EncryptID!='NONE' and EncryptFlag!='NONE' and OwnerID='" + Session["UserName"] + "'";
            if (cls1.record_availability(Qry1))
            {
                SensitiveGrid.DataSource = cls1.bnd("select * from TblDataSet where OwnerID='" + Session["userName"] + "'");
                SensitiveGrid.DataBind();
                PanelMaster.Visible = false;
                PanelSensitiveResult.Visible = true;
            }
            else
            {
                cls1.MessageBox("Sorry!No Record", this);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}