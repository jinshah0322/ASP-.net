using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEmployeeProject(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeProject.aspx");
        }

        protected void btnProjects(object sender, EventArgs e)
        {
            Response.Redirect("Projects.aspx");
        }

        protected void btnSalaries(object sender, EventArgs e)
        {
            Response.Redirect("Salaries.aspx");
        }

        protected void btnEmployees(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        protected void btnDepartments(object sender, EventArgs e)
        {
            Response.Redirect("Department.aspx");
        }
    }
}