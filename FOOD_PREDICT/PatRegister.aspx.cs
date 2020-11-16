using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatRegister : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Qry1 = "select * from TblPatRegister where mail1='" + TxtEMailID.Text + "'";
            if (!(cls1.record_availability(Qry1)))
            {
                Qry1 = "insert into TblPatRegister (fname,lname,mail1,mobile1,pass1) values ('" + TxtFirstName.Text + "','" + TxtLastName.Text + "','" + TxtEMailID.Text + "','" + TxtMobileNo.Text + "','" + TxtPassword.Text + "')";
                cls1.insert_update_delete(Qry1);
                cls1.MessageBox("Successfully Registered", this);
            }
            else
            {
                cls1.MessageBox(TxtEMailID.Text + "Already Exists", this);
            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }


    }
}