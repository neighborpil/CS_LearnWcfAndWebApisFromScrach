using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessageExchangePatternInWcfLibrary;
using ServiceReference1;
using SqliteController;

public partial class _Default : System.Web.UI.Page
{
    private readonly string _dbFile = "UserRegistrationDB.db";
    protected void Page_Load(object sender, EventArgs e)
    {
        new CreateUserRegistrationDB(_dbFile).CreateDB();
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
		try
		{
            var helper = new SqliteHelper(_dbFile);
            var query = $"inset into user_registration(user_email) values('{txtEmail.Text}')";
            var result = helper.ExecuteNonQuery(query);

            if (result > 0)
            {
                var client = new MessageExchangePatternClient("WSDualHttpBinding_IMessageExchangePattern");
                client.SendEmail(txtEmail.Text);

                GridView1.DataBind();
            }
            else
            {
                ShowMessage("데이터베이스에 입력 할 수 없습니다.");
            }
        }
		catch (Exception ex)
		{
            ShowMessage(ex.Message);
        }
    }

    public void ShowMessage(string message)
    {
        Type cstype = this.GetType();

        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;

        // Check to see if the startup script is already registered.
        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
        {
            cs.RegisterStartupScript(cstype, "PopupScript", message, true);
        }
    }
}