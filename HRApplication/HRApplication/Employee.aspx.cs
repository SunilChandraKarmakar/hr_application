using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRApplication
{
    public partial class Employee : System.Web.UI.Page
    {
        // Get connection string
        private SqlConnection _sqlConnection = new SqlConnection("Data Source=DESKTOP-I6ENAU2\\SQLEXPRESS;Initial Catalog=HRAppDb;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                GetEmployees();
        }

        protected void OnSaveEmployee(object sender, EventArgs e)
        {
            // Insert command
            var insertEmployee = "INSERT INTO Employee VALUES(@FirstName, @LastName, @Division, @Building, @Room)";

            // Create command
            var sqlCommand = new SqlCommand(insertEmployee, _sqlConnection);

            // Add parameters with TextBox text values
            sqlCommand.Parameters.AddWithValue("@FirstName", firstName.Text);
            sqlCommand.Parameters.AddWithValue("@LastName", lastName.Text);
            sqlCommand.Parameters.AddWithValue("@Division", division.Text);
            sqlCommand.Parameters.AddWithValue("@Building", building.Text);
            sqlCommand.Parameters.AddWithValue("@Room", room.Text);

            try
            {
                // Open the connection
                _sqlConnection.Open();

                // Run query
                sqlCommand.ExecuteNonQuery();

                // Show success message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "alert('Successfully Saved.');", true);

                GetEmployees();
            }
            catch (Exception ex)
            {
                // Handle or log exception
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                // Connection is closed
                _sqlConnection.Close();
            }

        }

        private void GetEmployees()
        {
            var sqlCommand = new SqlCommand("SELECT * FROM Employee", _sqlConnection);
            var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            employeeGridView.DataSource = dataTable;
            employeeGridView.DataBind();
        }
    }
}