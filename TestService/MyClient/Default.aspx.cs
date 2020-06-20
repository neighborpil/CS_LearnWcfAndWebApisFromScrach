using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyServiceReference;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var client = new MyServiceClient();
        var countries = client.GetAllCountries();
        DropDownList1.DataSource = countries;
        DropDownList1.DataValueField = "CountryId";
        DropDownList1.DataTextField = "CountryName";
        DropDownList1.DataBind();
    }
}