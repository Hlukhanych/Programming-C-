using System;
using ConsoleApp1;
using Microsoft.Data.SqlClient;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GitHub\Programming-CS\lab5-6-7\ConsoleApp1\ConsoleApp1\SA2_Hlukhanych.mdf;Integrated Security=True";
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
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
    }
}