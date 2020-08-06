using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MEPServiceReference;
using System.ServiceModel;
using System.Data.SqlClient;

public class MEPCallBack:IMEPCallback
{

    public void SendEmailCallBack(string toAddress)
    {
        var con = new SqlConnection("Data Source=thinkpad-pc\\sqlexpress;Initial Catalog=MEPDb;Integrated Security=True");
        var cmd = new SqlCommand("update UserRegistration set EmailSentFlag='Y' where UserEmail=@UserEmail", con);
        cmd.Parameters.AddWithValue("@UserEmail", toAddress.ToString());
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
          
            var context = new InstanceContext(new MEPCallBack());
            MEPClient c = new MEPClient(context);

            var con = new SqlConnection("Data Source=thinkpad-pc\\sqlexpress;Initial Catalog=MEPDb;Integrated Security=True");
            var cmd = new SqlCommand("insert into UserRegistration(UserEmail) values (@UserEmail)", con);
            cmd.Parameters.AddWithValue("@UserEmail", txtUserEmail.Text.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            c.SendEmail(txtUserEmail.Text.ToString());

        }
        catch (FaultException Ex)
        {

            Response.Write(Ex.Message);
        }
    }
}