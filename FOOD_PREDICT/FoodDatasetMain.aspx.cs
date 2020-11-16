using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FoodDatasetMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Dataset_Click(object sender, EventArgs e)
    {
        Response.Redirect("DatasetUpload.aspx");
    }
    protected void Foodset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReviewDataset.aspx");
    }
}