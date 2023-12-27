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
            string query = "SELECT * FROM [Order]";
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
        public List<Order> GetByLastName(string lastName)
        {
            var orders = new List<Order>();
            string querty = $"SELECT * FROM [Order] WHERE LastName LIKE '{lastName}%';";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (lastName == Convert.ToString(reader["LastName"]))
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
            }
            return orders;
        }
        public List<Order> GetByLastNameEqualLastNameOfCustomer(int num)
        {
            var orders = new List<Order>();
            string querty = $"SELECT * FROM [Order] WHERE LastName = LastNameOfCustomer AND SumOfOrder <= {num}";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToString(reader["LastName"]) == Convert.ToString(reader["LastNameOfCustomer"]))
                        {
                            if (Convert.ToInt32(reader["SumOfOrder"]) <= num)
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
                }
            }
            return orders;
        }
        public List<Order> GetDistinctNameOfOrder()
        {
            var orders = new List<Order>();
            string querty = $"SELECT DISTINCT * FROM [Order]";
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

                        var uniqueValues = orders.Distinct().ToList();
                        orders.Clear();
                        orders.AddRange(uniqueValues);
                    }
                }
            }
            return orders;
        }
        public List<Order> GetAVG()
        {
            var orders = new List<Order>();
            string querty = $"SELECT AVG(SumOfOrder) AS AVGColumn FROM [Order]";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["AVGColumn"] != DBNull.Value && reader["AVGColumn"] != null)
                        {
                            double averageValue = Convert.ToDouble(reader["AVGColumn"]);
                            Console.WriteLine($"Average Order Sum: {averageValue}");
                        }
                    }
                }
            }
            return orders;
        }

        public class OrderCount
        {
            public int NameOfOrderCount { get; set; }
            public string NameOfOrder { get; set; }
        }
        public List<Order> GetNameOfOrderCount()
        {
            var orders = new List<Order>();
            var orderCounts = new List<OrderCount>();
            string querty = $"SELECT COUNT(*) AS NameOfOrderCount, NameOfOrder FROM [Order] GROUP BY NameOfOrder HAVING COUNT(*) >= 1";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["NameOfOrderCount"] != DBNull.Value && reader["NameOfOrder"] != DBNull.Value)
                        {
                            int count = Convert.ToInt32(reader["NameOfOrderCount"]);
                            string nameOfOrder = Convert.ToString(reader["NameOfOrder"]);

                            OrderCount orderCount = new OrderCount
                            {
                                NameOfOrderCount = count,
                                NameOfOrder = nameOfOrder
                            };

                            orderCounts.Add(orderCount);
                        }
                    }

                    foreach (OrderCount order in orderCounts)
                    {
                        Console.WriteLine($"{order.NameOfOrderCount} | {order.NameOfOrder}");
                    }
                }
            }
            return orders;
        }
        public List<Order> GetOrderBy()
        {
            var orders = new List<Order>();
            string querty = $"SELECT * FROM [Order] ORDER BY [Order].SumOfOrder";
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
                    orders.Sort((x, y) => x.SumOfOrder.CompareTo(y.SumOfOrder));
                }
            }
            return orders;
        }
        public bool Update(int sum, int sum1)
        {
            using (SqlCommand command = new SqlCommand(
               String.Format("UPDATE [Order] SET SumOfOrder = {0} WHERE SumOfOrder = {1}", sum, sum1),
               _connection))
            {
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
