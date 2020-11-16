using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogOut : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {
                Session["UserName"] = "";
                Session["UserType"] = "";
                Response.Redirect("Default.aspx");
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }
}