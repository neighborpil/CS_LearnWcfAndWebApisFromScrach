using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var serviceClient = new MulServiceClient("BasicHttpBinding_IMulService");

        Response.Write(serviceClient.MulInt(3, 5));

        serviceClient.Save(new Student { StudentId = 123, StudentName = "asdf" });
    }
}