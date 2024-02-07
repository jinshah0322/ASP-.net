using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices.ComTypes;

namespace EmployeeManagement
{
    public partial class EditEmplyeeProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                BindEmployeeDropDown();
                BindProjectDropDown();
            }
        }

        protected void LoadData()
        {
            int EPID = Convert.ToInt32(Session["EPID"]);
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM EmployeeProject WHERE EPID = @EPID";

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EPID", EPID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EmployeeID.SelectedValue = reader["EmployeeID"].ToString();
                        ProjectID.SelectedValue = reader["ProjectID"].ToString();
                        AssignmentDate.Text = Convert.ToDateTime(reader["AssignmentDate"]).ToString("yyyy-MM-dd");
                        HoursWorked.Text = reader["HoursWorked"].ToString();
                        Status.SelectedValue = reader["Status"].ToString();
                    }
                    reader.Close();
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
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int EPID = Convert.ToInt32(Session["EPID"]);
            int Employee_ID = Convert.ToInt32(EmployeeID.SelectedValue);
            int Project_ID = Convert.ToInt32(ProjectID.SelectedValue);
            string Assignment_Date = AssignmentDate.Text;
            string Hours_Worked = HoursWorked.Text;
            string status = Status.SelectedValue;

            string query = "UPDATE EmployeeProject SET EmployeeID=@Employee_ID,ProjectID=@Project_ID, AssignmentDate=@Assignment_Date ,HoursWorked=@Hours_Worked, Status=@status where EPID=@EPID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@EPID", EPID);
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
            Response.Redirect("EmployeeProject.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeProject.aspx");
        }
    }
}