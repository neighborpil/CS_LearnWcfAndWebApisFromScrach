using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultipleServiceReference;

public partial class MultipleForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var serviceClient = new MultipleServiceClient("BasicHttpBinding_IMultipleService");
        Response.Write(serviceClient.Multiple(5, 5));

    }
}