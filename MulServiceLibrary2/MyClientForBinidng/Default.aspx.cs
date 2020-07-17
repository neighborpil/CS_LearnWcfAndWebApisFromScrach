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
        //var serviceClient = new NewMulServiceClient("BasicHttpBinding_MultiplicationService");
        var serviceClient = new NewMulServiceClient("BasicHttpBinding_INewMulService");
        Response.Write(serviceClient.MulInt(70, 80).ToString());

        Response.Write("<br>");

        Response.Write(serviceClient.MulDouble(80, 80).ToString());

        Response.Write("<br>");

        //var tcpServiceClient = new NewMulServiceClient("NetTcpBinding_MultiplicationService");
        var tcpServiceClient = new MulServiceClient("NetTcpBinding_IMulService");
        Response.Write(tcpServiceClient.MulInt(3, 4));

        Response.Write("<br>");
    }
}