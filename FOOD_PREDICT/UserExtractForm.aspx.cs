using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserExtractForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        username.Text = Convert.ToString(Session["DR_UserName"]);
    }
}