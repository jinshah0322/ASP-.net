using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class Projects : System.Web.UI.Page
    {
        static DataTable ddlProjectID = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindDDLProjectID();
            }
        }

        protected void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM Projects";
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

        protected void BindDDLProjectID()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "select -1 as ProjectID, '--select--' as ProjectName union all select ProjectID,ProjectName from Projects";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ProjectName.DataSource = dt;
            ProjectName.DataTextField = "ProjectName";
            ProjectName.DataValueField = "ProjectID";
            ProjectName.DataBind();
            ddlProjectID = dt;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string Project_Name = ProjectName.SelectedValue;
            string Project_Manager = ProjectManager.Text;
            double budget = Convert.ToDouble(Budget.Text);
            string Start_Date = StartDate.Text;
            string End_Date = EndDate.Text;
            bool is_Active = Convert.ToBoolean(isActive.SelectedValue)==true?true:false;

            ProjectName.SelectedIndex = -1;
            ProjectManager.Text = "";
            Budget.Text = "";
            StartDate.Text = "";
            EndDate.Text = "";
            isActive.SelectedIndex = -1;

            string query = "INSERT INTO Projects VALUES(@Project_Name, @Project_Manager,  @Start_Date,@End_Date,@budget,@is_Active)";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
                    cmd.Parameters.AddWithValue("@Project_Manager", Project_Manager);
                    cmd.Parameters.AddWithValue("@budget", budget);
                    cmd.Parameters.AddWithValue("@Start_Date", Start_Date);
                    cmd.Parameters.AddWithValue("@End_Date", End_Date);
                    cmd.Parameters.AddWithValue("@is_Active", is_Active);
;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int ProjectID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string ProjectName = (row.FindControl("txtProjectName") as DropDownList).SelectedValue;
            string ProjectManager = (row.FindControl("txtProjectManager") as TextBox).Text;
            double budget = Convert.ToDouble((row.FindControl("txtBudget") as TextBox).Text);
            string StartDate = (row.FindControl("txtStartDate") as TextBox).Text;   
            string EndDate = (row.FindControl("txtEndDate") as TextBox).Text;
            bool isActive = Convert.ToBoolean(((row.FindControl("txtIsActive") as RadioButtonList).SelectedValue)) == true ?true : false;

            string query = "UPDATE Projects SET ProjectName=@ProjectName,ProjectManager=@ProjectManager, Budget=@budget ,StartDate=@StartDate, EndDate=@EndDate, isActive=@isActive where ProjectID=@ProjectID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@ProjectName", ProjectName);
                    cmd.Parameters.AddWithValue("@ProjectManager", ProjectManager);
                    cmd.Parameters.AddWithValue("@budget", budget);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@isActive", isActive);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int ProjectID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Projects WHERE ProjectID=@ProjectID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
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
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    RadioButtonList txtIsActiveEdit = (RadioButtonList)e.Row.FindControl("txtIsActive");

                    string currentIsActive = (e.Row.DataItem as DataRowView)["isActive"].ToString();
                    foreach (ListItem item in txtIsActiveEdit.Items)
                    {
                        if (item.Value == currentIsActive)
                        {
                            item.Selected = true;
                            break;
                        }
                    }

                    TextBox StartDate = (TextBox)e.Row.FindControl("txtStartDate");
                    string currentStartDate = (e.Row.DataItem as DataRowView)["StartDate"].ToString();

                    DateTime sd;
                    if (DateTime.TryParse(currentStartDate, out sd))
                    {
                        StartDate.Text = sd.ToString("yyyy-MM-dd");
                    }

                    TextBox EndDate = (TextBox)e.Row.FindControl("txtEndDate");
                    string currentEndDate = (e.Row.DataItem as DataRowView)["EndDate"].ToString();

                    DateTime ed;
                    if (DateTime.TryParse(currentEndDate, out ed))
                    {
                        EndDate.Text = ed.ToString("yyyy-MM-dd");
                    }


                    DropDownList ddlProjectIDEdit = (DropDownList)e.Row.FindControl("txtProjectName");

                    ddlProjectIDEdit.DataSource = ddlProjectID;
                    ddlProjectIDEdit.DataTextField = "ProjectName";
                    ddlProjectIDEdit.DataValueField = "ProjectID";
                    ddlProjectIDEdit.DataBind();

                    string currentProjectID = (e.Row.DataItem as DataRowView)["ProjectID"].ToString();
                    ddlProjectIDEdit.SelectedValue = currentProjectID;
                }
            }

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