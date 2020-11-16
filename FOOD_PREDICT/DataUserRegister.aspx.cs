using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataUserRegister : System.Web.UI.Page
{
    common_source cls1 = new common_source();
    string Qry1 = null, Qry2 = null;


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            Qry1 = "select * from DR_Register where login1='" + TxtLogin1.Text + "'";
            if (!(cls1.record_availability(Qry1)))
            {
                Qry1 = "insert into DR_Register values ('" + TxtFirstName.Text + "','" + TxtLastName.Text + "','" + TxtEMail.Text + "','" + TxtMobileNo.Text + "','" + CboUsertype.SelectedItem.Text + "','" + TxtLogin1.Text + "','" + TxtPass1.Text + "')";
                cls1.insert_update_delete(Qry1);
                cls1.Clear(this);
                CboUsertype.SelectedIndex = -1;
                cls1.MessageBox("Successfully Registered!!", this);

            }
            else
            {
                cls1.MessageBox("Sorry! Login ID Already Exists", this);

            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}