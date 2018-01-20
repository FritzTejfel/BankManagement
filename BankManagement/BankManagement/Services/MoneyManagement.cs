using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace BankManagement.Services
{
    public class MoneyManagement
    {
        private readonly string ConnectionString = "Server=DESKTOP-B4RNTT3;Database=BankDB;Integrated Security=True;MultipleActiveResultSets=true";
        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;

        public void Inlay(int code, double amount)
        {
            double balance = 0;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string commandline = "SELECT * FROM Accounts WHERE PinCode = @code";
                    string addBalance = "UPDATE Accounts SET Balance = @bal WHERE PinCode = @code";

                    using (command = new SqlCommand(commandline, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@code", code);

                        using (reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                balance = double.Parse(reader.GetValue(1).ToString());
                            }
                        }                    
                    }

                    double sum = balance + amount;

                    using (command = new SqlCommand(addBalance, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@bal", sum);
                        command.Parameters.AddWithValue("@code", code);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public void Takeout(int code, double amount)
        {
            double balance = 0;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string commandline = "SELECT * FROM Accounts WHERE PinCode = @code";
                    string addBalance = "UPDATE Accounts SET Balance = @bal WHERE PinCode = @code";

                    using (command = new SqlCommand(commandline, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@code", code);

                        using (reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                balance = double.Parse(reader.GetValue(1).ToString());
                            }
                        }
                    }

                    double sum = balance - amount;

                    using (command = new SqlCommand(addBalance, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@bal", sum);
                        command.Parameters.AddWithValue("@code", code);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }

        }
    }
}
