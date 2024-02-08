using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement
{
    public partial class Salaries : System.Web.UI.Page
    {
        static DataTable dtEmployeelist=new DataTable ();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindEmployeeDropdown();
            }
        }

        protected void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM Salaries";
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

        private void BindEmployeeDropdown()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string com = "select -1 as EmployeeID, '--select--' as name union all select EmployeeID,CONCAT(FirstName,' ',LastName) as name from Employees";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlEmployeeID.DataSource = dt;
            ddlEmployeeID.DataTextField = "Name";
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataBind();
            dtEmployeelist = dt;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string Employee_ID = ddlEmployeeID.SelectedValue;   
            double amount = Convert.ToDouble(Amount.Text);
            string Salarytype = ddlSalaryType.SelectedValue;
            double bonus = Convert.ToDouble(Bonus.Text);
            double Final_Salary = Convert.ToDouble(FinalSalary.Text);

            ddlEmployeeID.SelectedIndex = -1;
            Amount.Text = "";
            ddlSalaryType.SelectedIndex = -1;
            Bonus.Text = "";
            FinalSalary.Text = ""; 

            string query = "INSERT INTO Salaries VALUES(@Employee_ID, @amount,  @Salarytype,@bonus,@Final_Salary)";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Employee_ID", Employee_ID);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@Salarytype", Salarytype);
                    cmd.Parameters.AddWithValue("@bonus", bonus);
                    cmd.Parameters.AddWithValue("@Final_Salary", Final_Salary);
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
            int SalaryID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            double Amount = Convert.ToDouble((row.FindControl("txtAmount") as TextBox).Text);
            string SalaryType = (row.FindControl("txtddlSalaryType") as DropDownList).SelectedValue;
            double Bonus = Convert.ToDouble((row.FindControl("txtBonus") as TextBox).Text);
            double FinalSalary = Convert.ToDouble((row.FindControl("txtAmount") as TextBox).Text);
            string EmployeeID = (row.FindControl("ddlEmployeeIDEdit") as DropDownList).SelectedValue;

            string query = "UPDATE Salaries SET EmployeeID=@EmployeeID,Amount=@Amount, SalaryType=@SalaryType, Bonus=@Bonus, FinalSalary=@FinalSalary where SalaryID=@SalaryID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@SalaryID", SalaryID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@SalaryType", SalaryType);
                    cmd.Parameters.AddWithValue("@Bonus", Bonus);
                    cmd.Parameters.AddWithValue("@FinalSalary", FinalSalary);

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
            int SalaryID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Salaries WHERE SalaryID=@SalaryID";
            string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SalaryID", SalaryID);
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
                    DropDownList ddlEmployeeID = (DropDownList)e.Row.FindControl("ddlEmployeeIDEdit");


                    ddlEmployeeID.DataSource = dtEmployeelist;
                    ddlEmployeeID.DataTextField = "Name";
                    ddlEmployeeID.DataValueField = "EmployeeID";
                    ddlEmployeeID.DataBind();
                    
                    string currentEmployeeID = (e.Row.DataItem as DataRowView)["EmployeeID"].ToString();
                    ddlEmployeeID.SelectedValue = currentEmployeeID;

                    DropDownList txtddlSalaryTypeEdit = (DropDownList)e.Row.FindControl("txtddlSalaryType");
                    string currentSalaryType = (e.Row.DataItem as DataRowView)["SalaryType"].ToString();
                    txtddlSalaryTypeEdit.SelectedValue = currentSalaryType;
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