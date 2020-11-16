using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatLogin : System.Web.UI.Page
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

            if (cls1.record_availability("select * from TblpatRegister where mail1='" + TxtLogin1.Text + "' and pass1='" + TxtPass1.Text + "'"))
            {
                Session["UserName"] = TxtLogin1.Text;
                Session["UserType"] = "PATIENT";
                Response.Redirect("Patient_Dashboard.aspx");
            }
            else
            {
                cls1.MessageBox("Invalid Login ID & Password",this);
            }

        }
        catch(Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
       
    }
}