using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    internal class OrderRepository : IRepository<Order>
    {
        protected SqlConnection _connection;
        public OrderRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<Order> GetAll()
        {
            var orders = new List<Order>();
            string query = "SELECT * FROM Orders";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();

                        order.Id = Convert.ToInt32(reader["Id"]);
                        order.LastName = Convert.ToString(reader["LastName"]);
                        order.NameOfOrder = Convert.ToString(reader["NameOfOrder"]);
                        order.SumOfOrder = Convert.ToInt32(reader["SumOfOrder"]);
                        order.LastNameOfCustpmer = Convert.ToString(reader["LastNameOfCustomer"]);
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetByName(string lastName)
        {
            var orders = new List<Order>();
            string querty = $"SELECT * FROM Orders WHERE LastName LIKE '{lastName}%';";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            NameOfOrder = Convert.ToString(reader["NameOfOrder"]),
                            SumOfOrder = Convert.ToInt32(reader["SumOfOrder"]),
                            LastNameOfCustpmer = Convert.ToString(reader["LastNameOfCustomer"])
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetByLastNameEqualLastNameOfCustomer()
        {
            var orders = new List<Order>();
            string querty = $"SELECT * FROM Orders WHERE LastName = LastNameOfCustomer AND SumOfOrder <= 800";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            NameOfOrder = Convert.ToString(reader["NameOfOrder"]),
                            SumOfOrder = Convert.ToInt32(reader["SumOfOrder"]),
                            LastNameOfCustpmer = Convert.ToString(reader["LastNameOfCustomer"])
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetDistinctNameOfOrder()
        {
            var orders = new List<Order>();
            string querty = $"SELECT DISTINCT NameOfOrder FROM Orders";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            NameOfOrder = Convert.ToString(reader["NameOfOrder"]),
                            SumOfOrder = Convert.ToInt32(reader["SumOfOrder"]),
                            LastNameOfCustpmer = Convert.ToString(reader["LastNameOfCustomer"])
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetAVG()
        {
            var orders = new List<Order>();
            string querty = $"SELECT AVG(SumOfOrder) AS AVGColumn FROM Orders";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            NameOfOrder = Convert.ToString(reader["NameOfOrder"]),
                            SumOfOrder = Convert.ToInt32(reader["SumOfOrder"]),
                            LastNameOfCustpmer = Convert.ToString(reader["LastNameOfCustomer"])
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetNameOfOrderCount()
        {
            var orders = new List<Order>();
            string querty = $"SELECT COUNT(*) AS NameOfOrderCount, NameOfOrder FROM [Order] GROUP BY NameOfOrder HAVING COUNT(*)>=1;";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            NameOfOrder = Convert.ToString(reader["NameOfOrder"]),
                            SumOfOrder = Convert.ToInt32(reader["SumOfOrder"]),
                            LastNameOfCustpmer = Convert.ToString(reader["LastNameOfCustomer"])
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetOrderBy()
        {
            var orders = new List<Order>();
            string querty = $"SELECT  [Order].LastName, [Order].NameOfOrder, [Order].SumOfOrder FROM [Order] ORDER BY [Order].SumOfOrder;";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            NameOfOrder = Convert.ToString(reader["NameOfOrder"]),
                            SumOfOrder = Convert.ToInt32(reader["SumOfOrder"]),
                            LastNameOfCustpmer = Convert.ToString(reader["LastNameOfCustomer"])
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public bool Update(Order order)
        {
            using (SqlCommand command = new SqlCommand(
               String.Format("UPDATE [Order] SET SumOfOrder = 600 WHERE SumOfOrder = 500;", order.LastName, order.SumOfOrder, order.NameOfOrder, order.LastNameOfCustpmer),
               _connection))
            {
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
