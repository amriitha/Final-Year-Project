using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DietRecommend : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null;
    String Qry2 = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Page.IsPostBack))
            {

                CboDisease.DataSource = cls1.bnd("select distinct(disease) from TblFoodDataset");
                CboDisease.DataTextField = "disease";
                CboDisease.DataBind();
                CboDisease.Items.Insert(0, "Choose");

                CboAge.DataSource = cls1.bnd("select distinct(age1) from TblFoodDataset");
                CboAge.DataTextField = "age1";
                CboAge.DataBind();
                CboAge.Items.Insert(0, "Choose");


                CboFPValue.DataSource = cls1.bnd("select distinct(sugar_fp) from TblFoodDataset");
                CboFPValue.DataTextField = "sugar_fp";
                CboFPValue.DataBind();
                CboFPValue.Items.Insert(0, "Choose");

                CboAFValue.DataSource = cls1.bnd("select distinct(sugar_af) from TblFoodDataset");
                CboAFValue.DataTextField = "sugar_af";
                CboAFValue.DataBind();
                CboAFValue.Items.Insert(0, "Choose");

                CboBPMin.DataSource = cls1.bnd("select distinct(bp_min) from TblFoodDataset");
                CboBPMin.DataTextField = "bp_min";
                CboBPMin.DataBind();
                CboBPMin.Items.Insert(0, "Choose");

                CboBPMax.DataSource = cls1.bnd("select distinct(bp_max) from TblFoodDataset");
                CboBPMax.DataTextField = "bp_max";
                CboBPMax.DataBind();
                CboBPMax.Items.Insert(0, "Choose");

            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }


    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        try
        {

            
            Qry1 = "select food from TblFoodDataset where disease='" + CboDisease.SelectedItem.Text + "' and age1='" + Convert.ToString(CboAge.SelectedItem.Text) + "' and sugar_fp ='" + Convert.ToString(CboFPValue.SelectedItem.Text) + "' and sugar_af='" + Convert.ToString(CboAFValue.SelectedItem.Text) + "' and bp_min='" + Convert.ToString(CboBPMin.SelectedItem.Text) + "' and bp_max ='" + Convert.ToString(CboBPMax.SelectedItem.Text) + "'";
            if (cls1.record_availability(Qry1))
            {
                ResultGrid.Visible = true;
                ResultGrid.DataSource = cls1.bnd(Qry1);
                ResultGrid.DataBind();
            }
            else
            {
                ResultGrid.Visible = false;
                cls1.MessageBox("No Record", this);

            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}