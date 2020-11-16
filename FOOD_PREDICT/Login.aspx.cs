using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            Qry1 = "select * from TblOwnerRegister where User1='" + UserName.Text + "' and Pass1='" + Password.Text + "'";
            if (cls1.record_availability(Qry1))
            {
                Session["UserName"] = UserName.Text;
                Session["UserType"] = "Data Owner";
                Response.Redirect("OwnerMain.aspx");
            }
            else
            {
                cls1.MessageBox("Invalid Login ID & Password", this);
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}
