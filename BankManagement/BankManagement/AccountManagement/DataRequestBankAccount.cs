using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace BankManagement.AccountManagement
{
    public class DataRequestBankAccount
    {
        private readonly string ConnectionString = "Server=DESKTOP-B4RNTT3;Database=BankDB;Integrated Security=True;MultipleActiveResultSets=true";
        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;

        public double GetBalance(int code)
        {
            double balance = 0;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string Line = "SELECT * FROM Accounts WHERE PinCode = @code";

                    using (command = new SqlCommand(Line, sqlConnection))
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

                    return balance;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return balance;
                }
            }
        }


    }
}
