using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SymptomsDataSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Dataset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SymDataSet.aspx");
    }
    protected void symset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReviewSymDataSet.aspx");
    }
}