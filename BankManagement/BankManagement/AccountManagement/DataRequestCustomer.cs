using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace BankManagement.AccountManagement
{
    public class DataRequestCustomer
    {
        private readonly string ConnectionString = "Server=DESKTOP-B4RNTT3;Database=BankDB;Integrated Security=True;MultipleActiveResultSets=true";
        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;

        public Customer GetCustomerById(int id)
        {
            List<Customer> findcustomer = new List<Customer>();

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string Line = "SELECT * FROM Customers WHERE Id = @id";

                    using (command = new SqlCommand(Line, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                findcustomer
                                    .Add(
                                    new Customer (
                                    reader.GetValue(3).ToString(), 
                                    reader.GetValue(4).ToString(),
                                    reader.GetValue(1).ToString(), 
                                    Convert.ToDateTime(reader.GetValue(2).ToString()),
                                    reader.GetValue(5).ToString()));                                
                            }                                
                        }

                    }

                    return findcustomer.First();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return null;
                }
            }

        }

        public List<Customer> GetCustomerByName(string Firstname, string Lastname)
        {
            List<Customer> findcustomer = new List<Customer>();

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string Line = "SELECT * FROM Customers WHERE Firstname = @firstname AND Lastname = @lastname";

                    using (command = new SqlCommand(Line, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@firstname", Firstname);
                        command.Parameters.AddWithValue("@lastname", Lastname);

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

                    return findcustomer;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return null;
                }
            }
        }

        public Customer GetCustomerByAddress(string address)
        {
            List<Customer> findcustomer = new List<Customer>();

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string Line = "SELECT * FROM Customers WHERE Address = @address";

                    using (command = new SqlCommand(Line, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@address", address);

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

                    return findcustomer.First();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return null;
                }
            }

        }

        public int GetPinCode(string address, string firstname)
        {
            int code = 0;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string Line = "SELECT * FROM Customers WHERE Address = @address AND Firstname = @firstname";

                    using (command = new SqlCommand(Line, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@firstname", firstname);

                        using (reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                code = int.Parse(reader.GetValue(6).ToString());
                            }
                        }

                    }

                    return code;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return code;
                }
            }
        }

    }
}
