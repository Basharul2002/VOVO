using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public partial class RouteUpdate : UserControl
    {
        private string employeeID;

        private string from, to, fromId, toId;
        private bool update, delete;
        public RouteUpdate()
        {
            InitializeComponent();
            DataLoad();
        }


        public RouteUpdate(string employeeID, bool update = false, bool delete = true) : this()
        {
            this.employeeID = employeeID;
            this.update = update;
            this.delete = delete;

            if(update)
            {
                update_button.Text = "Update";
                return;
            }

            update_button.Text = "Delete";

        }




        private void DataLoad()
        {
            try
            {
                DataTable dataTable;
                DataBase dataBase = new DataBase();

                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = @"SELECT
                                    RI.ID AS [Route ID],
                                    BP.[Point Name] AS [From],
                                    AP.[Point Name] AS [To]
                                FROM
                                    [Route Information] AS RI
                                JOIN
                                    [Boarding Points Information] AS BP ON RI.[ID] = BP.[Route ID]
                                JOIN
                                    [Arrival Points Information] AS AP ON RI.[ID] = AP.[Route ID]";

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);

                        // You don't need to create a new DataTable instance here
                        dataTable = dataSet.Tables[0];
                    }

                    connection.Close();
                }

                data_grid_view.AutoGenerateColumns = false;
                data_grid_view.DataSource = dataTable;

                // Refresh the DataGridView to display the data
                data_grid_view.Refresh();

                // Clear any selection in the DataGridView
                data_grid_view.ClearSelection();
            }


            catch (Exception ex)
            {
                MessageBox.Show("Class name is Quiz function name is LoadData and exception: " + ex.Message);
            }
        }

        private void data_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataShow(data_grid_view.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }




































































        private void DataShow(string routeID)
        {
            try
            {
                DataBase dataBase = new DataBase();

                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = $@"SELECT
                                    RI.ID AS [RouteID],
                                    BP.ID AS [FromID],
                                    BP.[Point Name] AS [From],
                                    BP.ID AS [ToID],
                                    AP.[Point Name] AS [To]
                                FROM
                                    [Route Information] AS RI
                                JOIN
                                    [Boarding Points Information] AS BP ON RI.[ID] = BP.[Route ID]
                                JOIN
                                    [Arrival Points Information] AS AP ON RI.[ID] = AP.[Route ID] 
                                WHERE RI.ID = '{routeID}'";

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                route_id_tb.Text = reader["RouteID"].ToString();
                                from = reader["From"].ToString();
                                fromId = reader["FromID"].ToString();
                                to = reader["To"].ToString();
                                toId = reader["ToID"].ToString();
                                DataShow();
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DataShow()
        {
            from_tb.Text = from;
            to_tb.Text = to;
        }


        private void update_button_Click(object sender, EventArgs e)
        {
            if(update)
            {
                if (from_tb.Text == to_tb.Text)
                {
                    MessageBox.Show("Error1");
                    return;
                }

                if (string.IsNullOrWhiteSpace(from_tb.Text) || string.IsNullOrWhiteSpace(to_tb.Text))
                {
                    MessageBox.Show("Error2");
                    return;
                }

                if (from_tb.Text == from && to == to_tb.Text)
                {
                    MessageBox.Show("Something is wrong");
                    return;
                }


                UpdateData();
                return;
            }
            
            if(delete)
            {
                string query = $@"DELETE FROM [Boarding Points Information] WHERE [Route ID] = '{route_id_tb.Text}'";
                UpdatingData(query);
                query = string.Empty;

                query = $@"DELETE FROM [Arrival Points Information] WHERE [Route ID] = '{route_id_tb.Text}'";
                UpdatingData(query);
                query = string.Empty;

                query = $@"DELETE FROM [Route Information] WHERE ID = '{route_id_tb.Text}'";
                if (UpdatingData(query))
                {
                    MessageBox.Show("Data Deleted Successfully");
                    DataLoad();
                }

            }

        }


        private void UpdateData()
        {
            string query = $@"UPDATE [Boarding Points Information] SET [Point Name] = '{from_tb.Text}' WHERE ID = '{fromId}'";
            UpdatingData(query);
            query = string.Empty;
            query = $@"UPDATE [Arrival Points Information] SET [Point Name] = '{to_tb.Text}' WHERE ID = {toId}";
            bool flag = UpdatingData(query);
            if (flag)
                MessageBox.Show("Update Successful");

            DataLoad();

        }

        private bool UpdatingData(string query)
        {
            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }


   

}
