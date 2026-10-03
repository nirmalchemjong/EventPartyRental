using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EventPartyRental
{
    public partial class Form1 : Form
    {
        //  LocalDB Connection
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentalDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            LoadInventory(); //  loads the test data when the app starts
        }

        // Retrieves data from SQL 
        private void LoadInventory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Inventory", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvInventory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Exception handling 
                MessageBox.Show("Database Connection Error: " + ex.Message);
            }
        }

        // Inserts the text box inputs into the SQL Customers table
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // Basic validation to ensure the name is not blank
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a customer name.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Customers (Name, Phone, Email) VALUES (@Name, @Phone, @Email)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Customer successfully added!");

                // Clear the text boxes for the next entry
                txtName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //  EXCEPTION HANDLING
            try
            {
                
                RentalItem testItem = new ElectronicItem(3, "PA System", 50.00m);

               
                int rentalDays = 2;
                decimal totalFee = testItem.CalculateRentalFee(rentalDays);

                MessageBox.Show($"Item: {testItem.Name}\nTotal for {rentalDays} days: ${totalFee}",
                                "Fee Calculation Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during calculation: " + ex.Message, "Error");
            }
        }
    }
}