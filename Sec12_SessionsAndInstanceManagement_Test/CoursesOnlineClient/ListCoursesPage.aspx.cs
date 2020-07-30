using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class ListCoursesPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Add("client", 0);
            ViewState.Add("total", 0);
        }
    }

    protected void btnNewOrder_Click(object sender, EventArgs e)
    {
        var client = new CoursesOnlineClient("NetTcpBinding_ICoursesOnline");
        var courses = client.ListCourses();
        gvCoursesList.DataSource = courses;
        gvCoursesList.DataBind();

        client.EmptyCoursesTaken();
        gvCoursesTaken.DataBind();

        Session["client"] = client;
    }

    protected void gvCoursesList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var courseTaken = new CourseTaken();
        //courseTaken.CourseId = int.Parse(gvCoursesList.SelectedRow.Cells[1].Text);
        //courseTaken.CourseName = gvCoursesList.SelectedRow.Cells[2].Text;
        //courseTaken.CoursePrice = double.Parse(gvCoursesList.SelectedRow.Cells[3].Text);
        //(Session["client"] as CoursesOnlineClient)?.AddToCoursesTaken(courseTaken);
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        var coursesTaken = (Session["client"] as CoursesOnlineClient)?.ListCoursesTaken();
        gvCoursesTaken.DataSource = coursesTaken;
        gvCoursesTaken.DataBind();
    }

    protected void gvCoursesTaken_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int val = int.Parse(e.Row.Cells[2].Text);
            int total = int.Parse(ViewState["total"].ToString()) + val;
            ViewState["total"] = total;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = ViewState["total"].ToString();
        }
    }

    protected void gvCoursesList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        // 원래는 selectedIndexChanged 이벤트에서 하는 거였는데 안되서 바꿈
        gvCoursesList.EditIndex = -1;
        gvCoursesList.SelectedIndex = e.RowIndex;

        var courseTaken = new CourseTaken();
        courseTaken.CourseId = int.Parse(gvCoursesList.SelectedRow.Cells[1].Text);
        courseTaken.CourseName = gvCoursesList.SelectedRow.Cells[2].Text;
        courseTaken.CoursePrice = double.Parse(gvCoursesList.SelectedRow.Cells[3].Text);
        (Session["client"] as CoursesOnlineClient)?.AddToCoursesTaken(courseTaken);
    }
}