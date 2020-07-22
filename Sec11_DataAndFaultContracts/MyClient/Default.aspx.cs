using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

        Response.Write("<br>");

        Response.Write(serviceClient.DivInt(12, 2));

        Response.Write("<br>");

        try
        {
            // 예외 발생시에 WCF는 기본적으로 어떠한 예외인지 표시하지 않는다.

            // Service에서 App.config 옵션에 includeExceptionDetailInFaults를 주면 표시한다
            Response.Write(serviceClient.DivInt(12, 0));
        }
        catch (FaultException ex)
        {
            Response.Write(ex.Message);
        }

        Response.Write("<br>");

        try
        {
            // 예외 발생시에 WCF는 기본적으로 어떠한 예외인지 표시하지 않는다.

            // Service에서 App.config 옵션에 includeExceptionDetailInFaults를 주면 표시한다
            Response.Write(serviceClient.DivInt2(12, 0));
        }
        // Strongly typed exception handling
        catch (FaultException<DivFault> ex)
        {
            Response.Write(ex.Detail.Message);
            Response.Write(ex.Detail.OperationMessage);
        }
    }
}