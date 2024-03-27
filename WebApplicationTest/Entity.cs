using System.Data;
using WebApplicationTest.Models;
using System.Data.SqlClient;
namespace WebApplicationTest
{
    public class Entity : IEntity
    {
        private IConfiguration Configuration;
        public Entity(IConfiguration configuration) { 
            Configuration = configuration;
        }
        public bool Save(Customer customer)
        {
            var isSave = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Connection")))
                {
                    SqlCommand command = new SqlCommand(Constant.AddCustomer, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@customer_name", customer.CustomerName);
                    command.Parameters.AddWithValue("@customer_address", customer.CustomerAddress);
                    command.Parameters.AddWithValue("@customer_email", customer.CustomerEmail);

                    connection.Open();
                    command.ExecuteNonQuery();
                    isSave = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // assuming if error go to logs
                isSave = false;
            }

            return isSave;
            
        }


        public bool update(Customer customer)
        {
            var isSave = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Connection")))
                {
                    SqlCommand command = new SqlCommand(Constant.UpdateCustomer, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", customer.Id);
                    command.Parameters.AddWithValue("@customer_name", customer.CustomerName);
                    command.Parameters.AddWithValue("@customer_address", customer.CustomerAddress);
                    command.Parameters.AddWithValue("@customer_email", customer.CustomerEmail);

                    connection.Open();
                    command.ExecuteNonQuery();
                    isSave = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // assuming if error go to logs
                isSave = false;
            }

            return isSave;

        }


        public bool delete(string Id)
        {
            var isSave = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Connection")))
                {
                    SqlCommand command = new SqlCommand(Constant.DeleteCustomerById, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    isSave = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // assuming if error go to logs
                isSave = false;
            }

            return isSave;

        }

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Connection")))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(Constant.GetCustomer, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.Id = Convert.ToInt32(reader["id"]);
                            customer.CustomerName = reader["Customer_name"] != DBNull.Value ? reader["Customer_name"].ToString()! : "";
                            customer.CustomerEmail = reader["Customer_Email"] != DBNull.Value ?  reader["Customer_Email"].ToString()! : "";
                            customer.CustomerAddress = reader["Customer_address"] != DBNull.Value ? reader["Customer_address"].ToString()! : "";

                            customers.Add(customer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // assuming if error go to logs
            }

            return customers;

        }


        public Customer GetCustomerById(string Id)
        {
            Customer customer = new Customer();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Connection")))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(Constant.GetCustomerById, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", Id);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                     
                        reader.Read();
                        customer.Id = Convert.ToInt32(reader["id"]);
                        customer.CustomerName = reader["Customer_name"] != DBNull.Value ? reader["Customer_name"].ToString()! : "";
                        customer.CustomerEmail = reader["Customer_Email"] != DBNull.Value ? reader["Customer_Email"].ToString()! : "";
                        customer.CustomerAddress = reader["Customer_address"] != DBNull.Value ? reader["Customer_address"].ToString()! : "";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // assuming if error go to logs
            }

            return customer;

        }

    }
}
