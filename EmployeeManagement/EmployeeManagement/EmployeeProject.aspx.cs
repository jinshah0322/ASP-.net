    using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class EmployeeProject : System.Web.UI.Page
    {
        static DataTable dtEmployeelist = new DataTable();
        static DataTable dtProjectlist = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindEmployeeDropDown();
                BindProjectDropDown();
            }
        }

        protected void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM EmployeeProject";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        private void BindEmployeeDropDown()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "select -1 as EmployeeID,'--select--' as Name union all Select EmployeeID,CONCAT(FirstName,' ',LastName) as Name from Employees";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            EmployeeID.DataSource = dt;
            EmployeeID.DataTextField = "Name";
            EmployeeID.DataValueField = "EmployeeID";
            EmployeeID.DataBind();
            dtEmployeelist = dt;
        }

        private void BindProjectDropDown()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "select -1 as ProjectID,'--select--' as ProjectName union all Select ProjectID,ProjectName from Projects";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ProjectID.DataSource = dt;
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ProjectID";
            ProjectID.DataBind();
            dtProjectlist = dt;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            int Employee_ID = Convert.ToInt32(EmployeeID.SelectedValue);
            int Project_ID = Convert.ToInt32(ProjectID.SelectedValue);
            string Assignment_Date = AssignmentDate.Text;
            string Hours_Worked = HoursWorked.Text;
            string status = Status.SelectedValue;

            EmployeeID.SelectedIndex = -1;
            ProjectID.SelectedIndex = -1;
            AssignmentDate.Text = "";
            HoursWorked.Text = "";
            Status.SelectedIndex= -1;

            string query = "INSERT INTO EmployeeProject VALUES(@Employee_ID, @Project_ID,  @Assignment_Date,@Hours_Worked,@status)";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Employee_ID", Employee_ID);
                    cmd.Parameters.AddWithValue("@Project_ID", Project_ID);
                    cmd.Parameters.AddWithValue("@Assignment_Date", Assignment_Date);
                    cmd.Parameters.AddWithValue("@Hours_Worked", Hours_Worked);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[5].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            int EPID = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Session["EPID"] = EPID;
            Response.Redirect("EditEmplyeeProject.aspx");
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int EPID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM EmployeeProject WHERE EPID=@EPID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@EPID", EPID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}