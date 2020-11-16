using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : System.Web.UI.Page
{

    common_source cls1 = new common_source();
    string Qry1 = null;

    protected void Page_Load(object sender, EventArgs e)
    {
       // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
      //  FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

      
        //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        //if (String.IsNullOrEmpty(continueUrl))
        //{
        //    continueUrl = "~/";
        //}
        //Response.Redirect(continueUrl);

      


    
    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {

        try
        {

            Qry1 = "insert into TblOwnerRegister values ('" + TxtUserName.Text + "','" + TxtEmail.Text + "','" + TxtPassword.Text + "','" + TxtConfirmPassword.Text + "')";
            cls1.insert_update_delete(Qry1);
            cls1.MessageBox("New Owner Account Created!!", this);
            cls1.Clear(this);

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        
    }
}
