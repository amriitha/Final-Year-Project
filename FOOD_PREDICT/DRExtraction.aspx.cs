using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Text;
using System.Text.RegularExpressions;

public partial class DRExtraction : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null;
    String Qry2 = null;
    DataSet dst1 = null;
    DataTable dt1 = null;

    string OwnerID = null;
    string Age = null, Chest_pain = null, Rest_bpress = null, blood_sugar = null, rest_electro = null, max_heart_rate = null, exercise = null, diease = null;

    int RecID = 0;

    md5_des md1 = new md5_des();

    string mobileNo = null, Key1 = null,SecretKey=null;
    string Mess1 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(IsPostBack))
        {
            cls1.Combo_Bind(CboDataOwner, "select * from TblOwnerRegister ", "User1");
        }
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
     protected void DataRequest_Click(object sender, EventArgs e)
    {
        PanelMaster.Visible = true;
         try
         {
             
           if(!(cls1.record_availability("Select * from TblServerKeyDR where  RequesterName='" + Convert.ToString(Session["DR_UserName"])+"'")))
           {
               TxtNoiseValue1.Text=GenerateRandom();


        Qry1 = "Insert into TblServerKeyDR values('" + CboDataOwner.SelectedItem.Text + "','" + Convert.ToString(Session["DR_UserName"]) + "','" + TxtNoiseValue1.Text + "')";
        cls1.insert_update_delete(Qry1);
        mobileNo = cls1.return_single_string("select Mobile1 from DR_Register where login1='" + Session["DR_UserName"] + "'");
        Key1 = cls1.return_single_string("select NoiseID from TblServerKeyDR where RequesterName='" + Session["DR_UserName"] + "'");
        Mess1 = "Your Confidential Key: " + Key1;
        cls1.Dial2SMS(mobileNo, Mess1);
         }
        else if(cls1.record_availability("Select * from TblServerKeyDR where  RequesterName='" + Convert.ToString(Session["DR_UserName"])+"'"))
           
           {
                TxtNoiseValue1.Text=GenerateRandom();


        Qry2 = "Update TblServerKeyDR set  OwnerID='" + CboDataOwner.SelectedItem.Text + "',RequesterName='" + Convert.ToString(Session["DR_UserName"]) + "',NoiseID='" + TxtNoiseValue1.Text + "' where RequesterName='" + Convert.ToString(Session["DR_UserName"]) + "' ";
        cls1.insert_update_delete(Qry2);
        mobileNo = cls1.return_single_string("select Mobile1 from DR_Register where login1='" + Session["DR_UserName"] + "'");
        Key1 = cls1.return_single_string("select NoiseID from TblServerKeyDR where RequesterName='" + Session["DR_UserName"] + "'");
        Mess1 = "Your Confidential Key: " + Key1;
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

             //if(cls1.record_availability("Select * from DR_Register where UserType='Doctor' and login1='" + Convert.ToString(Session["DR_UserName"])+"' "))


             //{
             string orgKey = null;

             Qry1 = "select * from TblServerKeyDR where OwnerID='" + CboDataOwner.SelectedItem.Text + "' and NoiseID='" + TxtKey1.Text + "'";
             if (cls1.record_availability(Qry1))
             {

                 orgKey = cls1.return_single_string("select NoiseID from TblServerKeyInfo where OwnerID='" + CboDataOwner.SelectedItem.Text + "'");

                 cls1.insert_update_delete("delete from TblDummyResult");

                 dst1 = cls1.bnd("select * from TblDataset where OwnerID='" + CboDataOwner.SelectedItem.Text + "'");
                 dt1 = dst1.Tables[0];
                 foreach (DataRow dr1 in dt1.Rows)
                 {
                     RecID = Convert.ToInt32(dr1["RecID"]);

                     OwnerID = Convert.ToString(dr1["OwnerID"]);

                     Age = Convert.ToString(dr1["Age"]);
                     Age = md1.psDecrypt(Age);
                     Age = decrypt_eliminate(orgKey, Age);

                     ////string myText = TxtDecryptMess.Text;
                     //string key1 = "#" + TxtKey1.Text + "#";
                     //Regex badWords = new Regex(key1, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                     ////Regex badWords = new Regex("#123#", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                     //Age = badWords.Replace(Age, string.Empty);

                     Chest_pain = Convert.ToString(dr1["chest_paint"]);
                     Chest_pain = md1.psDecrypt(Chest_pain);
                     Chest_pain = decrypt_eliminate(orgKey, Chest_pain);

                     Rest_bpress = Convert.ToString(dr1["rest_bpress"]);
                     Rest_bpress = md1.psDecrypt(Rest_bpress);
                     Rest_bpress = decrypt_eliminate(orgKey, Rest_bpress);

                     blood_sugar = Convert.ToString(dr1["blood_sugar"]);
                     blood_sugar = md1.psDecrypt(blood_sugar);
                     blood_sugar = decrypt_eliminate(orgKey, blood_sugar);


                     rest_electro = Convert.ToString(dr1["rest_electro"]);
                     rest_electro = md1.psDecrypt(rest_electro);
                     rest_electro = decrypt_eliminate(orgKey, rest_electro);

                     max_heart_rate = Convert.ToString(dr1["max_heart_rate"]);
                     max_heart_rate = md1.psDecrypt(max_heart_rate);
                     max_heart_rate = decrypt_eliminate(orgKey, max_heart_rate);

                     exercise = Convert.ToString(dr1["exercice_angina"]);
                     exercise = md1.psDecrypt(exercise);
                     exercise = decrypt_eliminate(orgKey, exercise);


                     diease = Convert.ToString(dr1["disease"]);
                     diease = md1.psDecrypt(diease);
                     diease = decrypt_eliminate(orgKey, diease);

                     Qry1 = "insert into TblDummyResult values (" + RecID + ",'" + OwnerID + "','" + Age + "','" + Chest_pain + "','" + Rest_bpress + "','" + blood_sugar + "','" + rest_electro + "','" + max_heart_rate + "','" + exercise + "','" + diease + "')";
                     cls1.insert_update_delete(Qry1);

                 }

                 ResultGrid.DataSource = cls1.bnd("select Age,chest_paint,rest_bpress,blood_sugar,rest_electro,max_heart_rate,exercice_angina,disease from TblDummyResult");
                 ResultGrid.DataBind();

             }
             else
             {
                 cls1.MessageBox("Sorry!Invalid User", this);
                 DummyResult.DataSource = cls1.bnd("select Age,chest_paint,rest_bpress,blood_sugar,rest_electro,max_heart_rate,exercice_angina,disease from TblDummyValues");
                 DummyResult.DataBind();
             }

         }
         catch (Exception ex)
         {
             Response.Write(ex.Message.ToString());
         }
     }


     public string decrypt_eliminate(string seckey, string inputstr)
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