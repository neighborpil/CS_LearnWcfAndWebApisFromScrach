using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 파라미터에 Web.config파일 내의 binding name을 적어줘야 한다.
        var serviceClient = new MultiplicationServiceClient("BasicHttpBinding_MultiplicationService");
        Response.Write(serviceClient.Mul(70, 80).ToString());

        Response.Write("<br>");

        var tcpServiceClient = new MultiplicationServiceClient("NetTcpBinding_MultiplicationService");
        Response.Write(tcpServiceClient.Mul(3, 4));

        Response.Write("<br>");

        Response.Write(serviceClient.Add(1, 3));
    }
}