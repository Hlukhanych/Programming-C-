using System;
using ConsoleApp1;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GitHub\Programming-CS\lab5-6-7\ConsoleApp1\ConsoleApp1\SA2_Hlukhanych.mdf;Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GitHub\Programming-CS\lab5-6-7\ConsoleApp1\ConsoleApp1\SA2_Hlukhanych.mdf;Integrated Security=True");

            var dbContextOptions = optionsBuilder.Options;

            Console.WriteLine("lab6 or lab7: ");
            var rq = Console.ReadLine();
            if (rq.ToLower() == "lab6")
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    var rep = new OrderRepository(connection);

                    while (true)
                    {
                    Start: Console.WriteLine("Введіть яку операцію ви хочете робити з таблицею:");
                        Console.WriteLine("а - вибрати всі замовленя;");
                        Console.WriteLine("b - вибрати замовлення за фамілією;");
                        Console.WriteLine("с - вибрати замовлення за фамілією замовника та відправника та сумою менше 800;");
                        Console.WriteLine("d - знайти унікальні замовлення;");
                        Console.WriteLine("e - знайти середнє арифметичне замовлень;");
                        Console.WriteLine("f - знайти кількість повторень замовлень;");
                        Console.WriteLine("g - відсортувати за сумою замовлення;");
                        Console.WriteLine("h - редагування замовлення");
                        Console.WriteLine("exit - закінчити");
                        Console.WriteLine(":");

                        string request = Console.ReadLine();
                        List<Order> orders = rep.GetAll();
                        if (request.ToLower() == "a")
                        {
                            orders = rep.GetAll();
                            foreach (Order order in orders)
                            {
                                Console.WriteLine($"{order.LastName}");
                            }
                        }
                        else if (request.ToLower() == "b")
                        {
                            orders = rep.GetByLastName("Ivanov");
                            foreach (Order order in orders)
                            {
                                Console.WriteLine($"{order.NameOfOrder}");
                            }
                        }
                        else if (request.ToLower() == "c")
                        {
                            orders = rep.GetByLastNameEqualLastNameOfCustomer(2000);
                            foreach (Order order in orders)
                            {
                                Console.WriteLine($"{order.NameOfOrder}");
                            }
                        }
                        else if (request.ToLower() == "d")
                        {
                            orders = rep.GetDistinctNameOfOrder();
                            foreach (Order order in orders)
                            {
                                Console.WriteLine($"{order.LastName} | {order.SumOfOrder} | {order.NameOfOrder}");
                            }
                        }
                        else if (request.ToLower() == "e")
                        {
                            rep.GetAVG();
                        }
                        else if (request.ToLower() == "f")
                        {
                            rep.GetNameOfOrderCount();
                        }
                        else if (request.ToLower() == "g")
                        {
                            orders = rep.GetOrderBy();
                            foreach (Order order in orders)
                            {
                                Console.WriteLine($"{order.LastName} | {order.SumOfOrder} | {order.NameOfOrder}");
                            }
                        }
                        else if (request.ToLower() == "h")
                        {
                            rep.Update(700, 600);

                            orders = rep.GetAll();
                            foreach (Order order in orders)
                            {
                                Console.WriteLine($"{order.LastName} | {order.SumOfOrder} | {order.NameOfOrder}");
                            }
                        }
                        else if (request.ToLower() == "exit")
                        {
                            break;
                        }
                    }
                }
            }

            else if (rq.ToLower() == "lab7")
            {
                using (var context = new OrderContext(dbContextOptions))
                {
                    var orderRepository = new OrderRepEntity(context);

                    while (true)
                    {
                    Start: Console.WriteLine("Введіть яку операцію ви хочете робити з таблицею:");
                        Console.WriteLine("а - вибрати всі замовленя;");
                        Console.WriteLine("b - вибрати замовлення за фамілією;");
                        Console.WriteLine("с - вибрати замовлення за фамілією замовника та відправника та сумою менше 800;");
                        Console.WriteLine("d - знайти унікальні замовлення;");
                        Console.WriteLine("e - знайти середнє арифметичне замовлень;");
                        Console.WriteLine("f - знайти кількість повторень замовлень;");
                        Console.WriteLine("g - відсортувати за сумою замовлення;");
                        Console.WriteLine("h - редагування замовлення");
                        Console.WriteLine("exit - закінчити");
                        Console.WriteLine(":");

                        string request = Console.ReadLine();

                        if (request.ToLower() == "a")
                        {
                            List<Order> allOrders = orderRepository.GetAll();
                            Console.WriteLine("All Orders:");
                            PrintOrders(allOrders);
                        }
                        else if (request.ToLower() == "b")
                        {
                            List<Order> ordersByLastName = orderRepository.GetByLastName("Ivanov");
                            Console.WriteLine("\nOrders by Last Name:");
                            PrintOrders(ordersByLastName);
                        }
                        else if (request.ToLower() == "c")
                        {
                            List<Order> ordersByLastNameAndSum = orderRepository.GetByLastNameEqualLastNameOfCustomer(2000);
                            Console.WriteLine("\nOrders by Last Name and Sum:");
                            PrintOrders(ordersByLastNameAndSum);
                        }
                        else if (request.ToLower() == "d")
                        {
                            List<Order> distinctOrders = orderRepository.GetDistinctNameOfOrder();
                            Console.WriteLine("\nDistinct Name of Orders:");
                            PrintOrders(distinctOrders);
                        }
                        else if (request.ToLower() == "e")
                        {
                            orderRepository.GetAVG();
                        }
                        else if (request.ToLower() == "f")
                        {
                            orderRepository.GetNameOfOrderCount();
                        }
                        else if (request.ToLower() == "g")
                        {
                            List<Order> orderedOrders = orderRepository.GetOrderBy();
                            Console.WriteLine("\nOrders Ordered by Sum of Order:");
                            PrintOrders(orderedOrders);
                        }
                        else if (request.ToLower() == "h")
                        {
                            orderRepository.Update(1000, 500);

                            List<Order> updatedOrders = orderRepository.GetAll();
                            Console.WriteLine("\nUpdated Orders:");
                            PrintOrders(updatedOrders);
                        }
                        else if (request.ToLower() == "exit")
                        {
                            break;
                        }
                    }
                }
            }

            static void PrintOrders(List<Order> orders)
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"Id: {order.Id}, Last Name: {order.LastName}, Name of Order: {order.NameOfOrder}, Sum of Order: {order.SumOfOrder}, Last Name of Customer: {order.LastNameOfCustomer}");
                }
            }
        }
    }
}