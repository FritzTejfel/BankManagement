using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BankManagement.Services
{
    public class LoginCheck
    {
        private readonly string ConnectionString = "Server=DESKTOP-B4RNTT3;Database=BankDB;Integrated Security=True;MultipleActiveResultSets=true";
        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;


        public bool CustomerCheck(string firstname, int code)
        {
            List<Customer> findcustomer = new List<Customer>();

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string Line = "SELECT * FROM Customers WHERE Firstname = @firstname AND  PinCode = @code";

                    using (command = new SqlCommand(Line, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@firstname", firstname);
                        command.Parameters.AddWithValue("@code", code);

                        using (reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                findcustomer
                                    .Add(
                                    new Customer(
                                    reader.GetValue(3).ToString(),
                                    reader.GetValue(4).ToString(),
                                    reader.GetValue(1).ToString(),
                                    Convert.ToDateTime(reader.GetValue(2).ToString()),
                                    reader.GetValue(5).ToString()));
                            }
                        }

                    }

                    if (findcustomer.First().Equals(null))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return false;
                }
            }

        }
    }
}
