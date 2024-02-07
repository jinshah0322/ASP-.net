using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class Department : System.Web.UI.Page
    {
        static DataTable dtDepartmentlist = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindDepartmentID();
            }
        }

        protected void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM Departments";
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

        protected void BindDepartmentID()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "select -1 as DepartmentID, '--select--' as DepartmentName union all select DepartmentID,DepartmentName from Departments";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DepartmentName.DataSource = dt;
            DepartmentName.DataTextField = "DepartmentName";
            DepartmentName.DataValueField = "DepartmentID";
            DepartmentName.DataBind();
            dtDepartmentlist = dt;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string Department_Name = DepartmentName.SelectedValue;
            string Department_Head = DepartmentHead.Text;
            double budget = Convert.ToDouble(Budget.Text);
            string Creation_Date = CreationDate.SelectedDate.ToString("D");
            bool isActive = DepartmentStatus1.Checked ? true : false;

            DepartmentName.Text = "";
            DepartmentHead.Text = "";
            Budget.Text = "";
            CreationDate.SelectedDate = DateTime.MinValue;
            DepartmentStatus1.Checked = false;

            string query = "INSERT INTO Departments VALUES(@Department_Name, @Department_Head, @budget, @Creation_Date, @isActive)";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Department_Name", Department_Name);
                    cmd.Parameters.AddWithValue("@Department_Head", Department_Head);
                    cmd.Parameters.AddWithValue("@budget", budget);
                    cmd.Parameters.AddWithValue("@Creation_Date", Creation_Date);
                    cmd.Parameters.AddWithValue("@isActive", isActive);
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
            int Department_ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Department_Name = (row.FindControl("txtDepartmentName") as DropDownList).SelectedValue;
            string Department_Head = (row.FindControl("txtDepartmentHead") as TextBox).Text;
            string budget = (row.FindControl("txtBudget") as TextBox).Text;
            string Creation_Date = (row.FindControl("txtCreationDate") as TextBox).Text;
            bool isActive = (row.FindControl("txtDStatus") as CheckBox).Checked;


            string query = "UPDATE Departments SET DepartmentName=@Department_Name, DepartmentHead=@Department_Head, Budget=@budget, CreationDate=@Creation_Date, isActive=@isActive where DepartmentID=@DepartmentID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@DepartmentID", Department_ID);
                    cmd.Parameters.AddWithValue("@Department_Name", Department_Name);
                    cmd.Parameters.AddWithValue("@Department_Head", Department_Head);
                    cmd.Parameters.AddWithValue("@budget", budget);
                    cmd.Parameters.AddWithValue("@Creation_Date", Creation_Date);
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
            int Department_ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Departments WHERE DepartmentID=@DepartmentID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@DepartmentID", Department_ID);
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    DropDownList ddlDepartmentID = (DropDownList)e.Row.FindControl("txtDepartmentName");

                    ddlDepartmentID.DataSource = dtDepartmentlist;
                    ddlDepartmentID.DataTextField = "DepartmentName";
                    ddlDepartmentID.DataValueField = "DepartmentID";
                    ddlDepartmentID.DataBind();

                    string currentEmployeeID = (e.Row.DataItem as DataRowView)["DepartmentID"].ToString();
                    ddlDepartmentID.SelectedValue = currentEmployeeID;


                    TextBox txtCreationDate = (TextBox)e.Row.FindControl("txtCreationDate");
                    string currentCreationDate= (e.Row.DataItem as DataRowView)["CreationDate"].ToString();

                    DateTime creationdate;
                    if (DateTime.TryParse(currentCreationDate, out creationdate))
                    {
                        txtCreationDate.Text = creationdate.ToString("yyyy-MM-dd");
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