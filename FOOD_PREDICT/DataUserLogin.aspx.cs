using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataUserLogin : System.Web.UI.Page
{
    string Qry1 = null;
    common_source cls1 = new common_source();


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Qry1 = "select * from DR_Register where login1='" + TxtLogin1.Text + "' and pass1='" + TxtPass1.Text + "'";
            if (cls1.record_availability(Qry1))
            {
                Session["DR_UserName"] = TxtLogin1.Text;
                Session["DR_UserType"] = cls1.return_single_string("select usertype from DR_Register where login1='" + TxtLogin1.Text + "'");
                Response.Redirect("UserExtractForm.aspx");
                     

            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}