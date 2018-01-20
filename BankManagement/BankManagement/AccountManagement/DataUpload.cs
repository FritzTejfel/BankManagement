using BankManagement.Models;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BankManagement.AccountManagement
{
    public class DataUpload
    {
        private readonly string ConnectionString = "Server=DESKTOP-B4RNTT3;Database=BankDB;Integrated Security=True;MultipleActiveResultSets=true";
        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;

        public void AddCustomer(Customer customer)
        {
            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string commandLine =
                        "INSERT INTO Customers (Firstname, Lastname, Address, DayOfBirth, PhoneNumber, PinCode) " +
                        "VALUES (@Firstname,@Lastname,@Address,@DayOfBirth, @PhoneNumber, @PinCode)";

                    using (command = new SqlCommand(commandLine, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Firstname", customer.Firstname);
                        command.Parameters.AddWithValue("@Lastname", customer.Lastname);
                        command.Parameters.AddWithValue("@Address", customer.Address);
                        command.Parameters.AddWithValue("@DayOfBirth", customer.DayOfBirth);
                        command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        command.Parameters.AddWithValue("@PinCode", customer.PinCode);

                        command.ExecuteNonQuery();
                    }
                }

                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }

                sqlConnection.Close();
            }
        }

        public void AddBankAccount(BankAccount account)
        {
            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string commandLine =
                        "INSERT INTO Accounts (Balance, CustomerId, Created, PinCode) " +
                        "VALUES (@balance,@customerid,@created,@pincode)";

                    using (command = new SqlCommand(commandLine, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@balance", account.Balance);
                        command.Parameters.AddWithValue("@customerid", account.CustomerId);
                        command.Parameters.AddWithValue("@created", account.Created);
                        command.Parameters.AddWithValue("@pincode", account.PinCode);

                        command.ExecuteNonQuery();
                    }
                }

                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }

                sqlConnection.Close();

            }
        }
    }
}
