using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


/// <summary>
/// Summary description for common_source
/// </summary>
public class common_source
{

    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
    SqlCommand cmd = default(SqlCommand);
    SqlDataAdapter ad = default(SqlDataAdapter);
    DataSet ds = default(DataSet);
    SqlDataReader rd = default(SqlDataReader);
    DataTable dt;
    int col_value = 0;
    int count1 = 0;
    string single_string;
    Boolean flag;

    public void insert_update_delete(string sql)
    {
        cmd = new SqlCommand(sql, cn);
        conn();
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        cmd.Dispose();
    }

    public void conn()
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }

    public Boolean record_availability(string qry)
    {
        conn();
        cn.Open();
        cmd = new SqlCommand(qry, cn);
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
        cn.Close();
        cmd.Dispose();
        rd.Close();
        return flag;
    }

    public DataSet bnd(string qry)
    {
        conn();
        ad = new SqlDataAdapter(qry, cn);
        ds = new DataSet();
        ad.Fill(ds);
        cn.Close();
        return ds;
    }
    public int auto_gen(string field_name)
    {
        ds = new DataSet();
        ad = new SqlDataAdapter("select " + field_name + " from TblAutoGen", cn);
        ad.Fill(ds);
        dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            col_value = Convert.ToInt16(dr[0]);
        }
        ds.Dispose();
        dt.Dispose();
        return col_value;
    }


    public void Clear(Control Parent)
    {
        foreach (Control Child in Parent.Controls)
        {
            if (Child.HasControls())
                Clear(Child);
            else
            {
                if (Child.GetType() == typeof(TextBox))
                    ((TextBox)Child).Text = "";
            }
        }
    }

    public int record_count(string qry)
    {

        //        Connection_State()

        //dst1 = Return_All_Record(Qry)

        //If dst1.Tables(0).Rows(0).IsNull(0) Then
        //    col_value = 0
        //Else

        //    dt1 = dst1.Tables(0)

        //    For Each dr In dt1.Rows
        //        col_value = dr(0)
        //    Next
        //    dst1.Dispose()
        //    dt1.Dispose()

        //End If
        //Return col_value

        conn();
        DataTable dt1;
        DataSet ds1;
        ds1 = new DataSet();
        ds1 = bnd(qry);
        if (ds1.Tables[0].Rows[0].IsNull(0))
        {
            count1 = 0;
        }
        else
        {
            dt1 = ds1.Tables[0];
            foreach (DataRow dr in dt1.Rows)
            {
                count1 = Convert.ToInt32(dr[0]);
            }
        }

        //cn.Open();
        //cmd = new SqlCommand(qry, cn);
        //count1 = Convert.ToInt16(cmd.ExecuteScalar());
        //cn.Close();
        //cmd.Dispose();
        return count1;
    }

    public string return_single_string(string qry)
    {
        conn();
        cn.Open();
        cmd = new SqlCommand(qry, cn);
        single_string = Convert.ToString(cmd.ExecuteScalar());
        return single_string;
    }

    public void Combo_Bind(DropDownList Obj1, string Qry3, string ColName)
    {
        Obj1.DataSource = bnd(Qry3);
        Obj1.DataTextField = ColName;
        Obj1.DataBind();
        Obj1.Items.Insert(0, "--Choose One--");
    }

    public void MessageBox(string msg, Page frmname)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        frmname.Controls.Add(lbl);
    }

    public void DataList_Bind(DataList Obj2, string SQL_Query)
    {
        Obj2.DataSource = bnd(SQL_Query);
        Obj2.DataBind();
    }

    public void AutoGen_Update(string colname, int value)
    {
        string Qry1 = "Update TblAutoGen set " + colname + " = " + value;
        insert_update_delete(Qry1);
    }

    public common_source()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Mail_Transfer(string from1, string pass, string to1, string subj1, string mess1)
    {
        string from = from1; //Replace this with your own correct Gmail Address

        string pass1 = pass;

        string to = to1; //Replace this with the Email Address to whom you want to send the mail

        string subject = subj1;

        string message = mess1;

        MailMessage mail = new MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "CLOUD NOTIFICATON :: MAIL SERVICE", System.Text.Encoding.UTF8);
        mail.Subject = subject;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = message;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, pass1);

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer

        try
        {
            client.Send(mail);
            //lbluse.Text = "Successfully Mail Sent!!";
            //cls1.Clear(this);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
    }


    public void Dial2SMS(string MobileNo, string Message)
    {

        string url = "http://hpsms.dial4sms.com/api/web2sms.php?username=sofsms&password=Admin@14&to=" + MobileNo + "&sender=SOFSMS&message=" + Message;

        WebRequest request = WebRequest.Create(url);
        // If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials;
        // Get the response.
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    }

}
