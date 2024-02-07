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
    public partial class Employee : System.Web.UI.Page
    {
        static DataTable dtDepartmentlist = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindStateDropdown();
                BindDepartmentNameDropdown();
            }
        }

        private void BindStateDropdown()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "select -1 as StateId, '--select--' as StateName union all Select * from State";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlState.DataSource = dt;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
        }

        private void BindDepartmentNameDropdown()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "select -1 as DepartmentID, '--select--' as DepartmentName union all select DepartmentID,DepartmentName from Departments";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlDepartmentName.DataSource = dt;
            ddlDepartmentName.DataTextField = "DepartmentName";
            ddlDepartmentName.DataValueField = "DepartmentID";
            ddlDepartmentName.DataBind();
            dtDepartmentlist = dt;
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlState.SelectedValue);
        }

        private void BindCityDropdown(string StateId)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "Select * from City WHERE StateId = " + Convert.ToInt32(StateId);
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlCity.DataSource = dt;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
        }

        protected void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM Employees";
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

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string First_Name = FirstName.Text;
            string Last_Name = LastName.Text;
            string Date_Of_Birth = DOB.Text;
            string Gender = gender.SelectedValue;
            double Salary = Convert.ToDouble(salary.Text);
            string Joining_Date = JoiningDate.Text;
            string Department_Name = ddlDepartmentName.SelectedValue;
            string Interested_Technology="";
            if (asp.Checked)
            {
                Interested_Technology += "asp"+" ";
                asp.Checked=false;
            }
            if (PHP.Checked)
            {
                Interested_Technology += "PHP" + " ";
                PHP.Checked=false;
            }
            if (SpringBoot.Checked)
            {
                Interested_Technology += "SpringBoot" + " ";
                SpringBoot.Checked=false;
            }
            if(Nodejs.Checked)
            {
                Interested_Technology += "Nodejs"+" ";
                Nodejs.Checked = false;
            }
            string state = ddlState.SelectedValue;
            string city = ddlCity.SelectedValue;

            FirstName.Text = "";
            LastName.Text = "";
            gender.SelectedIndex = -1;
            salary.Text = "";
            DOB.Text = "";
            JoiningDate.Text = "";
            ddlDepartmentName.SelectedIndex=-1;

            string query = "INSERT INTO Employees VALUES(@First_Name, @Last_Name,  @Date_Of_Birth,@Gender,@Salary,@Joining_Date,@Department_Name,@Interested_Technology,@state,@city)";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@First_Name", First_Name);
                    cmd.Parameters.AddWithValue("@Last_Name", Last_Name);
                    cmd.Parameters.AddWithValue("@Date_Of_Birth", Date_Of_Birth);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.Parameters.AddWithValue("@Joining_Date", Joining_Date);
                    cmd.Parameters.AddWithValue("@Department_Name", Department_Name);
                    cmd.Parameters.AddWithValue("@Interested_Technology", Interested_Technology);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@city", city);
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
            int EmployeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string First_Name = (row.FindControl("txtFirstName") as TextBox).Text;
            string Last_Name = (row.FindControl("txtLastName") as TextBox).Text;
            string DateOfBirth = (row.FindControl("txtDateOfBirth") as TextBox).Text;
            double Salary = Convert.ToDouble((row.FindControl("txtSalary") as TextBox).Text);
            string JoiningDate = (row.FindControl("txtJoiningDate") as TextBox).Text;
            string gender = (row.FindControl("txtgender") as RadioButtonList).SelectedValue;
            string Department_ID = (row.FindControl("txtDdlDepartmentEdit") as DropDownList).SelectedValue;

            string query = "UPDATE Employees SET FirstName=@First_Name, LastName=@Last_Name, DateOfBirth=@DateOfBirth, Gender=@gender,Salary=@Salary, JoiningDate=@JoiningDate,DepartmentID=@Department_ID where EmployeeID=@Employee_ID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Employee_ID", EmployeeID);
                    cmd.Parameters.AddWithValue("@First_Name", First_Name);
                    cmd.Parameters.AddWithValue("@Last_Name", Last_Name);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.Parameters.AddWithValue("@JoiningDate", JoiningDate);
                    cmd.Parameters.AddWithValue("@Department_ID", Department_ID);

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
            int Employee_ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Employees WHERE EmployeeID=@Employee_ID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Employee_ID", Employee_ID);
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
                (e.Row.Cells[10].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    DropDownList ddlDepartmentID = (DropDownList)e.Row.FindControl("txtDdlDepartmentEdit");

                    ddlDepartmentID.DataSource = dtDepartmentlist;
                    ddlDepartmentID.DataTextField = "DepartmentName";
                    ddlDepartmentID.DataValueField = "DepartmentID";
                    ddlDepartmentID.DataBind();

                    string currentEmployeeID = (e.Row.DataItem as DataRowView)["DepartmentID"].ToString();
                    ddlDepartmentID.SelectedValue = currentEmployeeID;


                    TextBox txtDate = (TextBox)e.Row.FindControl("txtDateOfBirth");
                    string currentDOB = (e.Row.DataItem as DataRowView)["DateOfBirth"].ToString();

                    DateTime dob;
                    if (DateTime.TryParse(currentDOB, out dob))
                    {
                        txtDate.Text = dob.ToString("yyyy-MM-dd");
                    }


                    TextBox txtJoiningDate = (TextBox)e.Row.FindControl("txtJoiningDate");
                    string currentJoiningDate = (e.Row.DataItem as DataRowView)["JoiningDate"].ToString();

                    DateTime joiningdate;
                    if (DateTime.TryParse(currentJoiningDate, out joiningdate))
                    {
                        txtJoiningDate.Text = joiningdate.ToString("yyyy-MM-dd");
                    }


                    RadioButtonList txtgenderEdit = (RadioButtonList)e.Row.FindControl("txtgender");

                    string currentIsActive = (e.Row.DataItem as DataRowView)["Gender"].ToString();
                    foreach (ListItem item in txtgenderEdit.Items)
                    {
                        if (item.Value == currentIsActive)
                        {
                            item.Selected = true;
                            break;
                        }
                    }

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