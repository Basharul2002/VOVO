using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Data;
using Org.BouncyCastle.Asn1.X509;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.Management;
using System.Drawing;
using Org.BouncyCastle.Utilities.Collections;
using Twilio.TwiML.Voice;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using static iText.IO.Image.Jpeg2000ImageData;

namespace VOVO
{
    public class DataBase
    {
       // Assuming you have a valid connection string
       public string connectionString;

        private void DeleteData(string id, string type)
        {
            try
            {
                bool flag = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();
                    string query = string.Empty;

                    if (type == "Customer")
                    {
                        // Construct the DELETE query
                        query = @"DELETE 
                                   FROM 
                                      [Customer Verify Information] 
                                   WHERE 
                                      [Customer ID] = @ID";

                        // Create the SqlCommand object with the query and connection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", id);

                            // Execute the command to delete the data
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check the number of rows affected to determine if the deletion was successful
                            if (rowsAffected > 0)
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                                CustomMessageBox.Show("No data found matching the delete condition, Table name is Customer Verify Information");
                            }
                        }
                    }

                    string tableName = $"[{type} Information]";
                    
                    query = $@"DELETE 
                               FROM 
                                    {tableName} 
                               WHERE 
                                    ID = @ID";

                    // Create the SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        // Execute the command to delete the data
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check the number of rows affected to determine if the deletion was successful
                        if (rowsAffected > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            CustomMessageBox.Show("No data found matching the delete condition table name is " + tableName);
                        }
                    }


                }

                if (flag)
                    CustomMessageBox.Show("Successfully data deleted", "VOVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is DataBase, function name is DataDelete and exception: " + ex.Message, "Error");
            }
        }
        //
        // For customer
        private void UpdateData(string id, string name, string email, string phoneNumber, string gender, string password, string type)
        {
            string tableName = "[" + type + " Information]";

            if(type == "Customer")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the database connection
                        connection.Open();
                        // Construct the DELETE query
                        string query = $@"UPDATE 
                                            {tableName} 
                                          SET 
                                            Name = @Name, 
                                            Email = @Email, 
                                            [Phone Number] = @PhoneNumber, 
                                            Password = @Password, 
                                            Gender = @Gender 
                                          WHERE 
                                            ID = @ID";

                        // Create the SqlCommand object with the query and connection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@ID", id);
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            command.Parameters.AddWithValue("@Password", password);
                            command.Parameters.AddWithValue("@Gender", gender);

                            // Execute the command to delete the data
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check the number of rows affected to determine if the deletion was successful
                            if (rowsAffected > 0)
                            {
                                CustomMessageBox.Show("Data update successfully");
                            }
                            else
                            {
                                CustomMessageBox.Show("No data found matching the delete condition");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("An error occurred while deleting data: " + ex.Message, "Error");
                }
            }
            
        }

        private CustomDataType_CustomerFound_CustomerIDNameEmailPhoneNumber IsCustomerExists(string input)
        {
            CustomDataType_CustomerFound_CustomerIDNameEmailPhoneNumber customerData = null;

            try
            {
                DataBase dataBase = new DataBase();
                using (SqlConnection connection = new SqlConnection(dataBase.connectionString))
                {
                    string query = string.Empty;
                    SqlParameter[] parameters;

                    Equipment equipment = new Equipment();

                    if (input.Length >= 12 && input.Length <= 14 && equipment.IsNumeric(input.Substring(1, 13)))
                    {
                        query = @"SELECT * 
                                  FROM 
                                     [Customer Information] 
                                  WHERE 
                                     [Country Code] = @CountryCode 
                                     AND 
                                     [Phone Number] = @PhoneNumber 
                                     OR 
                                     [Country Code] LIKE @CountryCodePattern";

                        parameters = new SqlParameter[]
                        {
                            new SqlParameter("@CountryCode", input.Substring(0, 4)),
                            new SqlParameter("@PhoneNumber", input.Substring(4, 10)),
                            new SqlParameter("@CountryCodePattern", "%" + input.Substring(0, 4)), // Add '%' to create a pattern for LIKE
                        };
                    }
                    else if (input.Length == 11 && equipment.IsNumeric(input))
                    {
                        query = @"SELECT * 
                                  FROM 
                                    [Customer Information] 
                                  WHERE 
                                    [Country Code] = @CountryCode 
                                    AND 
                                    [Phone Number] = @PhoneNumber 
                                    OR [Country Code] LIKE @CountryCodePattern";

                        parameters = new SqlParameter[]
                        {
                            new SqlParameter("@CountryCode", input.Substring(0, 1)),
                            new SqlParameter("@PhoneNumber", input.Substring(1, 10)),
                            new SqlParameter("@CountryCodePattern", "%" + input.Substring(0, 1)), // Add '%' to create a pattern for LIKE
                        };
                    }

                    else
                    {
                        query = @"SELECT * 
                                  FROM 
                                    [Customer Information] 
                                  WHERE 
                                    [Email] = @Email";

                        parameters = new SqlParameter[]
                        {
                            new SqlParameter("@Email", input),
                        };
                    }


                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerData = new CustomDataType_CustomerFound_CustomerIDNameEmailPhoneNumber
                                {
                                    Found = true,
                                    ID = reader["ID"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    CountryCode = reader["Country Code"].ToString(),
                                    PhoneNumber = reader["Phone Number"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Exception in [IsCustomerExists] function in database class and excption is: " + ex.Message, "Exception");
            }

            return customerData;
        }

        private int UpdatePassword(string id, string password, string user)
        {
            int returnValue = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tableName = string.Empty;
                    string columnName = string.Empty;

                    switch (user)
                    {
                        case "Customer":
                            tableName = "[Customer Information]";
                            columnName = "ID";
                            break;

                        case "Admin":
                            tableName = "[Admin Login Information]";
                            columnName = "[Admin ID]";
                            break;

                        case "Employee":
                            tableName = "[Employee Login Information]";
                            columnName = "[Employee ID]";
                            break;

                        case "Driver":
                            tableName = "[Driver Login Information]";
                            columnName = "[Driver ID]";
                            break;

                        case "Conductor":
                            tableName = "[Conductor Login Information]";
                            columnName = "[Conductor ID]";
                             break;

                        default:
                            CustomMessageBox.Show("Invalid user type");
                            return -1;
                    }

                    if (!string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(columnName))
                    {
                        // Construct the UPDATE query
                        string query = $@"UPDATE 
                                            {tableName} 
                                          SET 
                                            Password = @Password 
                                          WHERE 
                                            {columnName} = @ID";

                        // Open the database connection
                        connection.Open();

                        // Create the SqlCommand object with the query and connection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", id);
                            command.Parameters.AddWithValue("@Password", password);

                            // Execute the command to update the data
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                CustomMessageBox.Show("Password updated successfully", "VOVO");
                                returnValue = 1;
                            }
                            else
                            {
                                CustomMessageBox.Show("No data found matching the update condition");
                                returnValue = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("An error occurred while updating the password: " + ex.Message, "Error");
                returnValue = -1;
            }

            return returnValue;
        }

        private bool CustomerRegistrationFunction(string id, string name, string email, string countryCode, string phoneNumber, string gender, string password)
        {
            try
            {
                bool emailFlag = EmailCheckExistsCheck(email: email);
                bool phoneNumberFlag = CheckExistingCustomerPhoneNumber(countryCode: countryCode, phoneNumber: phoneNumber);

                if (emailFlag)
                    //MessageBox.Show("This email already registered");
                    return false; // Don't proceed if email or phone number is already registered

                else if (phoneNumberFlag)
                {
                    CustomMessageBox.Show("This phone number already registered");
                    return false; // Don't proceed if phone number is already registered
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string registrationQuery = @"INSERT INTO [Customer Information] (ID, Name, Email, [Country Code], [Phone Number], Gender, [Password], Date, Time) 
                                               VALUES (@ID, @Name, @Email, @CountryCode, @PhoneNumber, @Gender, @Password, @Date, @Time)";

                    Equipment equipment = new Equipment();
                    string currentDate = equipment.TodayDate();

                    using (SqlCommand command = new SqlCommand(registrationQuery, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@CountryCode", countryCode);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(currentDate));
                        command.Parameters.AddWithValue("@Time", equipment.Time());

                        command.ExecuteNonQuery();

                    }

                   CustomMessageBox.Show(name + " your account created successfully", "Successful");
                   return true;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Customer Registration (Database Class): " + ex.Message, "Error");
                return false;
            }
        }

        private int CheckExistingCustomerEmailPhoneNumber(string email = "", string countryCode = "", string phoneNumber = "", bool emailFlag = false, bool phoneNumberFlag = false)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM [Customer Information]";
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (emailFlag)
                {
                    query = $"{query} WHERE Email = @Email";
                    parameters.Add(new SqlParameter("@Email", email));
                }


                if (phoneNumberFlag)
                {
                    query = $"{query} WHERE [Country Code] = @CountryCode AND [Phone Number] = @PhoneNumber";
                    parameters.Add(new SqlParameter("@CountryCode", countryCode));
                    parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
                }


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        command.ExecuteNonQuery();
                        return (int)command.ExecuteScalar(); ; // Returns the count directly
                    }
                }
            }

            catch(Exception ex)
            {
                CustomMessageBox.Show("Class is Database function name is CheckExistingCustomerEmailPhoneNumber: " + ex.Message);
                return -1;
            }
           
        }

        public bool EmailCheckExistsCheck(string email)
        {
            if(CheckExistingCustomerEmailPhoneNumber(email: email, emailFlag: true) >0)
            {
                return true;
            }

            return false;
        }

        public bool EmailUpdate(string id, string email)
        {
            return UpdateCustomerContactInformation(id, email: email, emailUpdate: true);
        }

        public bool PhoneNumberUpdate(string id, string countryCode, string phoneNumber)
        {
            return UpdateCustomerContactInformation(id, countryCode: countryCode, phoneNumber: phoneNumber, phoneNumberUpdate: true);
        }
        private bool UpdateCustomerContactInformation(string id, string email = null, bool emailUpdate = false, string countryCode = null, string phoneNumber = null, bool phoneNumberUpdate = false)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [Customer Information] SET";
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    if(emailUpdate)
                    {
                        query = $"{query} Email = @Email, ";
                        parameters.Add(new SqlParameter("@Email", email));
                    }

                    if (phoneNumberUpdate)
                    {
                        query = $"{query} [Country Code] = @CountryCode, [Phone Number] = @PhoneNumber, "; 
                        parameters.Add(new SqlParameter("@CountryCode", countryCode));  
                        parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
                    }


                    // Remove the trailing comma and space
                    query = query.TrimEnd(',', ' ');
                    query = $"{query} WHERE ID = @ID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                    if(emailUpdate) EmailVerificationUpdate(id, "1");
                    if (phoneNumberUpdate) PhoneNumberVerificationUpdate(id, "1");

                }

                CustomMessageBox.Show("Sccessfully updated your information", "VOVO");
                return true;
            

            }

            catch (Exception ex)
            {
                CustomMessageBox.Show($"CLas name is database function name is UpdateCustomerContactInformation and exception is: {ex.Message}");
                return false;
            }
        }

        public bool CheckExistingCustomerPhoneNumber(string countryCode, string phoneNumber)
        {
            if(CheckExistingCustomerEmailPhoneNumber(countryCode: countryCode, phoneNumber: phoneNumber, phoneNumberFlag: true)>0)
            {
                return true;
            }

            return false;

        }


        private bool CheckExistingCustomer(string query, string paramName, string paramValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(paramName, paramValue);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private string GetLastID(string type)
        {
            string lastID = string.Empty;
            try
            {
                using(SqlConnection  connection = new SqlConnection(connectionString))
                {
                    string query = $@"SELECT 
                                        TOP 1 [ID] 
                                    FROM 
                                        [{type} Information] 
                                    ORDER BY 
                                        [Date] DESC, [Time] DESC";

                    connection.Open();

                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            lastID = reader["ID"].ToString();
                        }
                    }
                }
               // CustomMessageBox.Show(lastID);
                return lastID;
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show($"Class name is Daatbase function name is GetLastID and exception: {ex.Message}");
                return null;
            }

        }

        private string GetLastTicketNumber()
        {
            string lastID = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        TOP 1 [Travel Number] 
                                    FROM 
                                        [Travel Information] 
                                    ORDER BY 
                                        [Date] DESC, [Time] DESC";

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            lastID = reader["Travel Number"].ToString();
                        }
                    }
                }

               // CustomMessageBox.Show(lastID);
                return lastID;
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show($"Class name is DataBase function name is GetLastTicket and exception: {ex.Message}");
                return null;
            }
        }

        private bool BusInfoExists(string busNumber, string chassisNumber, string engineNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    1 
                                FROM 
                                    [Bus Information] 
                                WHERE 
                                    [Bus Number] = @BusNumber 
                                    OR 
                                    [Chassis Number] = @ChassisNumber 
                                    OR 
                                    [Engine Number] = @EngineNumber";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BusNumber", busNumber);
                    command.Parameters.AddWithValue("@ChassisNumber", chassisNumber);
                    command.Parameters.AddWithValue("@EngineNumber", engineNumber);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void SoldTicketStore(string id, byte[] pdf, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO 
                                            [Sold Ticket Information] (ID, PDF, Password)
                                    VALUES
                                        (@ID, @PDF, @Password)";

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@PDF", pdf);
                        command.Parameters.AddWithValue("@Password", password);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show($"Class name is Database function name is SoldTicketStore : {ex.Message}");
            }
        }

        public bool IsBusInfoExists(string busNumber, string chechisNumber, string engineNumber)
        {
            return BusInfoExists(busNumber, chechisNumber, engineNumber);
        }

        private bool CustomerInformationUpdate(string id, string name, Image image, int gender, bool nameUpdate, bool imageUpdate, bool genderUpdate)
        {
            Equipment equipment = new Equipment();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [Customer Information] SET";
                    List<SqlParameter> parametersList = new List<SqlParameter>();

                    int flag = 0;
                    if (nameUpdate)
                    {
                        query = $"{query} Name = @Name, ";
                        parametersList.Add(new SqlParameter("@Name", name));
                        flag++;
                    }
                    if (imageUpdate)
                    {
                        query = $"{query} Picture = @Picture, ";
                        parametersList.Add(new SqlParameter("@Picture", equipment.ConvertImageToByteArray(image)));
                        flag++;
                    }
                    if (genderUpdate)
                    {
                        //CustomMessageBox.Show("gender" + gender + "genderUpdate: " + genderUpdate);
                        query = $"{query} Gender = @Gender, ";
                        parametersList.Add(new SqlParameter("@Gender", gender));
                        flag++;
                    }

            
                    // Remove the trailing comma and space
                    query = query.TrimEnd(',', ' ');

                    query = $"{query} WHERE ID = @ID";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddRange(parametersList.ToArray());
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                CustomMessageBox.Show($"{name} successfully updated your information", "VOVO");
                return true;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Class name is DataBase, function name is CustomerInformationUpdate, and exception:  {ex.Message}", "Exception");
            }

            return false;
        }

        public bool UpdateCustomerInformation(string id, string name, Image image, int gender, bool nameUpdate, bool imageUpdate, bool genderUpdate)
        {
            return CustomerInformationUpdate(id, name, image, gender, nameUpdate, imageUpdate, genderUpdate);
        }

        public int TotalData(string type)
        {
            int totalDataCount = 0;

            try
            {
                string query = "SELECT * FROM [" + type + " Information]";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        // Execute the query and process the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                totalDataCount++; // Increment the match count
                            }
                        }
                    }
                    connection.Close();
                }

                return totalDataCount; // Return the total number of matches
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }



        public bool CustomerRegistration(string id, string name, string email, string countryCode, string phoneNumber, string gender, string password)
        {
            return CustomerRegistrationFunction(id, name, email, countryCode, phoneNumber, gender, password);
        }
        public CustomDataType_CustomerFound_CustomerIDNameEmailPhoneNumber CustomerForgotPasswordCustomerFound(string search)
        {
            return IsCustomerExists(search);
        }

        public int CustomerResetPassword(string Id, string password)
        {
            return UpdatePassword(Id, password, "Customer");
        }

        public int UpdateCustomerPassword(string Id, string password)
        {
            return UpdatePassword(Id, password, "Customer");
        }

        private void InsertBusInformation(string adminID, string number, string name, string cechisNumber, string engineNumber, string engineType, string busType, string companyName, string ownerName, int totalSeat)
        {
            try
            {
                Equipment equipment = new Equipment();  
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();
                    string query = @"INSERT INTO 
                                        [Bus Information] 
                                            ([Bus Number], [Bus Name], [Chassis Number], 
                                             [Engine Number], [Enginee Type], [Bus Type], 
                                             [Company Name], [Owner ID], [Number Of Seats], 
                                             [Date], [Time], [Added By])
                                     VALUES 
                                            (@BusNumber, @BusName, @CechisNumber, 
                                             @EngineNumber, @EngineType, @BusType, 
                                             @CompanyName, @OwnerName, @TotalSeat, 
                                             @Date, @Time, @AddedBy)";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command for string companyName, legalStructure, address, phoneNumber, email, ownerShip, licensesNumber, permitNumber
                        command.Parameters.AddWithValue("@BusNumber", number);
                        command.Parameters.AddWithValue("@BusName", name);
                        command.Parameters.AddWithValue("@CechisNumber", cechisNumber);
                        command.Parameters.AddWithValue("@EngineNumber", engineNumber);
                        command.Parameters.AddWithValue("@EngineType", engineType);
                        command.Parameters.AddWithValue("@BusType", busType);
                        command.Parameters.AddWithValue("@CompanyName", companyName);
                        command.Parameters.AddWithValue("@OwnerName", ownerName);
                        command.Parameters.AddWithValue("@TotalSeat", totalSeat);
                        command.Parameters.AddWithValue("@Date", equipment.DataBaseFormatDate(equipment.TodayDate()));
                        command.Parameters.AddWithValue("@Time", equipment.Time());
                        command.Parameters.AddWithValue("@AddedBy", adminID);


                        // Execute the query to insert the data into the database
                        command.ExecuteNonQuery();

                        CustomMessageBox.Show("Company Added Succesfully", "Successful");
                    }

                    connection.Close();
                }
            }


            catch (Exception ex)
            {
                CustomMessageBox.Show($"Class nami databse function name is InsertBusInformation and exception: { ex.Message}", "Exception in Data Store proccess");
            }
        }
        public void BusRegistration(string adminID, string busNumber, string name, string cechisNumber, string engineNumber, string engineType, string busType, string companyName, string ownerName, int totalSeat)
        {
            InsertBusInformation(adminID, busNumber, name, cechisNumber, engineNumber, engineType, busType, companyName, ownerName, totalSeat);
        }
        public int maxData(string type)
        {
            try
            {
                // MessageBox.Show(Type);
                string tableName = "[" + type + " Information]";
                string columnName = "[ID]";

                string query = $"SELECT MAX({columnName}) FROM {tableName}";
                //  SELECT MAX(["Serial Number]) FROM[Company Information];


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int maxValue = Convert.ToInt32(result);
                            return maxValue;
                        }

                        else
                        {
                            return 0;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the maximum value: " + ex.Message, "Error");
                return -1;
            }
        }
        public void DataDeleted(string id, string type)
        {
            DeleteData(id, type);
        }
        private void UpdateEmailVerification(string id, string Verification)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE 
                                        [Customer Verify Information] 
                                    SET 
                                        [Email Verified] = @Verification 
                                    WHERE 
                                        [Customer ID] = @ID";

                    connection.Open();

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Verification", Verification);
                        command.ExecuteNonQuery();

                        connection.Close();
                    }

                }
            }

            catch(Exception ex)
            {
                CustomMessageBox.Show("Class name is databse function name is UpdateEmailVerification and exception: " + ex.Message);
            }
        }
        public void EmailVerificationUpdate(string id, string Verification)
        {
            UpdateEmailVerification(id, Verification);
        }
        private void UpdatePhoneNumberVerification(string id, string verification)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE 
                                        [Customer Verify Information] 
                                    SET 
                                        [Phone Number Verified] = @Verification 
                                    WHERE 
                                        [Customer ID] = @ID";

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Verification", verification);
                        command.ExecuteNonQuery();

                        connection.Close();
                    }

                }
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is databse function name is UpdateEmailVerification and exception: " + ex.Message);
            }
        }
        public void PhoneNumberVerificationUpdate(string id, string verification)
        {
            UpdatePhoneNumberVerification(id, verification);
        }
        public void updateData(string id, string name, string email, string phoneNumber, string gender, string password, string type)
        {
            UpdateData(id, name, email, phoneNumber, gender, password, type);
        }
        public string LastID(string type)
        {
            if (type == "Ticket") { return GetLastTicketNumber(); }

            if (type == "Office") { return GetOfficeLastID(); }

            if(type == "Bus Reporting") { return BusReporting(); }
             
            return GetLastID(type);
        }


        public void SoldTicketStoreData(string id, byte[] pdf, string password)
        {
            SoldTicketStore(id, pdf, password);
        }

        private string GetOfficeLastID()
        {
            string lastID = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 ID FROM [Office Information] ORDER BY [Date] DESC, [Time] DESC";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lastID = reader["ID"].ToString();
                            }
                        }
                    }
                }
                return lastID;
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is Office and function name is OfficeID and exception: " + ex.Message);
                return lastID;
            }
        }

        private string BusReporting()
        {
            string lastID = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        TOP 1 [Reporting ID] 
                                     FROM 
                                        [Bus Reporting Information] 
                                    ORDER BY 
                                        [Date] DESC, [Time] DESC";
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lastID = reader["Reporting ID"].ToString();
                            }
                        }
                    }
                }
                return lastID;
            }

            catch (Exception ex)
            {
                CustomMessageBox.Show("Class name is Office and function name is OfficeID and exception: " + ex.Message);
                return lastID;
            }
        }


    }
}

