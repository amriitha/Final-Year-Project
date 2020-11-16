using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ReviewSymDataSet : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null;
    DataSet dst1 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {

                dst1 = cls1.bnd("select Disease,Type2,Symptom from TblDataSetSym where OwnerID='" + Session["UserName"] + "'");
                HealthDataSet.DataSource = dst1;
                HealthDataSet.DataBind();
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void HealthDataSet_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}