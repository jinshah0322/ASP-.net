using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;

namespace Winform
{
    public partial class Form1 : Form
    {
        public int ID = 0;
        public int EditID = 0;
        public Form1()
        {
            InitializeComponent();
            PopulateStatesComboBox();
        }

        private void PopulateStatesComboBox()
        {
            try
            {
                DataSet ds = sqlGet.getDataset("select * from State", CommandType.Text);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int stateID = Convert.ToInt32(row["stateID"]);
                        string stateName = Convert.ToString(row["stateName"]);
                        cbState.Items.Add(stateName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PopulateCitiesComboBox(string stateName)
        {
            try
            {
                DataSet ds = sqlGet.getDataset($"select * from City where stateID =(select StateID from State where StateName='{stateName}')", CommandType.Text);

                cbCity.Text="";

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string cityName = Convert.ToString(row["cityName"]);
                        cbCity.Items.Add(cityName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void comboBoxStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStateName = Convert.ToString(cbState.Text);
            PopulateCitiesComboBox(selectedStateName);
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter the first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter the last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!radioBtnMale.Checked && !radioBtnFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbState.Text))
            {
                MessageBox.Show("Please select a state.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbCity.Text))
            {
                MessageBox.Show("Please select a city.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter an email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDOB.Value == DateTime.MinValue)
            {
                MessageBox.Show("Please select a date of birth.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Please enter a phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Please enter valid email address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtNumber.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Please enter valid phone number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string gender = radioBtnMale.Checked ? "Male" : "Female";
                string state = cbState.Text;
                string city = cbCity.Text;
                string email = txtEmail.Text;
                DateTime dob = dtpDOB.Value;
                string phoneNumber = txtNumber.Text;
                string interestedTechnologies = "";
                if (cbASP.Checked)
                {
                    interestedTechnologies += "ASP,";
                }
                if (dbSpringBoot.Checked)
                {
                    interestedTechnologies += "Spring Boot,";
                }
                if (cbNodejs.Checked)
                {
                    interestedTechnologies += "Node.js,";
                }
                if (cbPHP.Checked)
                {
                    interestedTechnologies += "PHP,";
                }

                string previousPost = "";
                if (cbStudent.Checked)
                {
                    previousPost += "Student,";
                }
                if (cbIntern.Checked)
                {
                    previousPost += "Intern,";
                }
                if (cbEmployee.Checked)
                {
                    previousPost += "Employee,";
                }

                if (string.IsNullOrWhiteSpace(interestedTechnologies))
                {
                    MessageBox.Show("Please select interested technology", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(previousPost))
                {
                    MessageBox.Show("Please select Your previous post", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlParameter[] parameter = new SqlParameter[12];
                parameter[0] = new SqlParameter("@ID", EditID);
                parameter[1] = new SqlParameter("@FirstName", firstName);
                parameter[2] = new SqlParameter("@LastName", lastName);
                parameter[3] = new SqlParameter("@Gender", gender);
                parameter[4] = new SqlParameter("@State", state);
                parameter[5] = new SqlParameter("@City", city);
                parameter[6] = new SqlParameter("@Email", email);
                parameter[7] = new SqlParameter("@DOB", dob);
                parameter[8] = new SqlParameter("@PhoneNumber", phoneNumber);
                parameter[9] = new SqlParameter("@InterestedTechnology", interestedTechnologies);
                parameter[10] = new SqlParameter("@PreviousPost", previousPost);

                string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
                sqlGet.executeNonQueryRef("INSERT INTO Employee1 (FirstName, LastName, Gender, State, City, Email, DOB, PhoneNumber, InterestedTechnology, PreviousPost)\r\nVALUES (@FirstName, @LastName, @Gender, @State, @City, @Email, @DOB, @PhoneNumber, @InterestedTechnology, @PreviousPost)", ref parameter, CommandType.Text);

                clear();
                BindData();
                btnSave.Text = "Save";
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Update")
            {
                btnSave.Click -= btnUpdate_Click;
                btnSave.Click += btnSave_Click;
                btnSave.Text = "Save";
            }
            clear();
        }

        public void clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            radioBtnMale.Checked = false;
            radioBtnFemale.Checked = false;
            cbState.Text = "";
            cbCity.Text = "";
            txtEmail.Text = "";
            dtpDOB.Value = DateTime.Today;
            txtNumber.Text = "";
            if (cbASP.Checked)
            {
                cbASP.Checked = false;
            }
            if (dbSpringBoot.Checked)
            {
                dbSpringBoot.Checked = false;
            }
            if (cbNodejs.Checked)
            {
                cbNodejs.Checked = false;
            }
            if (cbPHP.Checked)
            {
                cbPHP.Checked = false;
            }
            if (cbStudent.Checked)
            {
                cbStudent.Checked = false;
            }
            if (cbIntern.Checked)
            {
                cbIntern.Checked = false;
            }
            if (cbEmployee.Checked)
            {
                cbEmployee.Checked = false;
            }

        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("Please Select Any Record");
                return;
            }

            sqlGet.executeNonQuery("Delete from Employee1 where EmployeeID=" + ID.ToString(), CommandType.Text);
            BindData();
            clear();
            MessageBox.Show("Record Deleted Successfully");
        }

        public void BindData()
        {
            ID = 0;
            DataSet ds = sqlGet.getDataset("select * from Employee1", CommandType.Text);

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }

            }
            dataGridView1.Columns[0].Visible = false;

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("Please Select Any Record");
                return;
            }

            DataSet ds = sqlGet.getDataset("select * from Employee1 where EmployeeID=" + ID.ToString(), CommandType.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                EditID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                string gender = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                radioBtnMale.Checked = true ? gender == "Male" : false;
                radioBtnFemale.Checked = false ? gender == "Male" : true;
                cbState.Text = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                cbCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                dtpDOB.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]);
                txtNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNumber"]);
                string interestedTechnologies = Convert.ToString(ds.Tables[0].Rows[0]["InterestedTechnology"]);
                string[] tech = interestedTechnologies.Split(',');
                foreach (string t in tech)
                {
                    if (t == "ASP")
                    {
                        cbASP.Checked = true;
                    }
                    if (t == "Spring Boot")
                    {
                        dbSpringBoot.Checked = true;
                    }
                    if (t == "Node.js")
                    {
                        cbNodejs.Checked = true;
                    }
                    if ((t == "PHP"))
                    {
                        cbPHP.Checked = true;
                    }
                }

                string previousPost = Convert.ToString(ds.Tables[0].Rows[0]["PreviousPost"]);
                string[] pp = previousPost.Split(',');
                foreach (string t in pp)
                {
                    if (t == "Student")
                    {
                        cbStudent.Checked = true;
                    }
                    if (t == "Intern")
                    {
                        cbIntern.Checked = true;
                    }
                    if (t == "Employee")
                    {
                        cbEmployee.Checked = true;
                    }
                }
            }
            btnSave.Text = "Update";
            if (btnSave.Text == "Update")
            {
                btnSave.Click -= btnSave_Click;
                btnSave.Click += btnUpdate_Click;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string gender = radioBtnMale.Checked ? "Male" : "Female";
                string state = cbState.Text;
                string city = cbCity.Text;
                string email = txtEmail.Text;
                DateTime dob = dtpDOB.Value;
                string phoneNumber = txtNumber.Text;
                string interestedTechnologies = "";
                if (cbASP.Checked)
                {
                    interestedTechnologies += "ASP,";
                }
                if (dbSpringBoot.Checked)
                {
                    interestedTechnologies += "Spring Boot,";
                }
                if (cbNodejs.Checked)
                {
                    interestedTechnologies += "Node.js,";
                }
                if (cbPHP.Checked)
                {
                    interestedTechnologies += "PHP,";
                }

                string previousPost = "";
                if (cbStudent.Checked)
                {
                    previousPost += "Student,";
                }
                if (cbIntern.Checked)
                {
                    previousPost += "Intern,";
                }
                if (cbEmployee.Checked)
                {
                    previousPost += "Employee,";
                }

                if (string.IsNullOrWhiteSpace(interestedTechnologies))
                {
                    MessageBox.Show("Please select interested technology", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(previousPost))
                {
                    MessageBox.Show("Please select Your previous post", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlParameter[] parameter = new SqlParameter[12];
                parameter[0] = new SqlParameter("@ID", EditID);
                parameter[1] = new SqlParameter("@FirstName", firstName);
                parameter[2] = new SqlParameter("@LastName", lastName);
                parameter[3] = new SqlParameter("@Gender", gender);
                parameter[4] = new SqlParameter("@State", state);
                parameter[5] = new SqlParameter("@City", city);
                parameter[6] = new SqlParameter("@Email", email);
                parameter[7] = new SqlParameter("@DOB", dob);
                parameter[8] = new SqlParameter("@PhoneNumber", phoneNumber);
                parameter[9] = new SqlParameter("@InterestedTechnology", interestedTechnologies);
                parameter[10] = new SqlParameter("@PreviousPost", previousPost);

                string constr = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
                sqlGet.executeNonQueryRef("Update Employee1 set FirstName=@FirstName, LastName=@LastName, Gender=@Gender, State=@State, City=@City, Email=@Email, DOB=@DOB, PhoneNumber=@PhoneNumber, InterestedTechnology=@InterestedTechnology, PreviousPost=@PreviousPost where EmployeeID=" + ID.ToString(), ref parameter, CommandType.Text);

                clear();
                BindData();
                btnSave.Text = "Save";
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Click -= btnUpdate_Click;
                btnSave.Click += btnSave_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            BindData();

        }
    }
}
