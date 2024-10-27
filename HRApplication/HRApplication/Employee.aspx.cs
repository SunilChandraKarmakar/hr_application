﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

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

        protected void OnUpdateEmployee(object sender, EventArgs e)
        {
            // Update command
            var updateEmployee = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Division = @Division, Building = @Building, Room = @Room WHERE Id = @Id";

            // Create command
            var sqlCommand = new SqlCommand(updateEmployee, _sqlConnection);

            // Add parameters with TextBox text values
            sqlCommand.Parameters.AddWithValue("@Id", int.Parse(id.Text));
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
                    "alert('Successfully Updated.');", true);

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

        protected void OnDeleteEmployee(object sender, EventArgs e)
        {
            // Update command
            var updateEmployee = "Delete Employee WHERE Id = @Id";

            // Create command
            var sqlCommand = new SqlCommand(updateEmployee, _sqlConnection);

            // Add parameters with TextBox text values
            sqlCommand.Parameters.AddWithValue("@Id", int.Parse(id.Text));

            try
            {
                // Open the connection
                _sqlConnection.Open();

                // Run query
                sqlCommand.ExecuteNonQuery();

                // Show success message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "alert('Successfully Delete.');", true);

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

        protected void OnSearchEmployee(object sender, EventArgs e)
        {
            var sqlCommand = new SqlCommand();

            int employeeId = id.Text == "" ? 0 : int.Parse(id.Text);

            if (employeeId != 0)
                sqlCommand = new SqlCommand("SELECT * FROM Employee WHERE Id = '" + int.Parse(id.Text) + "'", _sqlConnection);
            else
                sqlCommand = new SqlCommand("SELECT * FROM Employee", _sqlConnection);

            var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            employeeGridView.DataSource = dataTable;
            employeeGridView.DataBind();
        }
    }
}