using System;
using ConsoleApp1;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace lab4
{
    class Program
    {
        static async void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GitHub\Programming-CS\lab5-6-7\ConsoleApp1\ConsoleApp1\SA2_Hlukhanych.mdf;Integrated Security=True");

            var dbContextOptions = optionsBuilder.Options;

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
                        List<Order> allOrders = await orderRepository.GetAllAsync();
                        Console.WriteLine("All Orders:");
                        PrintOrders(allOrders);
                    }
                    else if (request.ToLower() == "b")
                    {
                        List<Order> ordersByLastName = await orderRepository.GetByLastName("Ivanov");
                        Console.WriteLine("\nOrders by Last Name:");
                        PrintOrders(ordersByLastName);
                    }
                    else if (request.ToLower() == "c")
                    {
                        List<Order> ordersByLastNameAndSum = await orderRepository.GetByLastNameEqualLastNameOfCustomer(2000);
                        Console.WriteLine("\nOrders by Last Name and Sum:");
                        PrintOrders(ordersByLastNameAndSum);
                    }
                    else if (request.ToLower() == "d")
                    {
                        List<Order> distinctOrders = await orderRepository.GetDistinctNameOfOrder();
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
                        List<Order> orderedOrders = await orderRepository.GetOrderBy();
                        Console.WriteLine("\nOrders Ordered by Sum of Order:");
                        PrintOrders(orderedOrders);
                    }
                    else if (request.ToLower() == "h")
                    {
                        orderRepository.Update(1000, 500);

                        List<Order> updatedOrders = await orderRepository.GetAllAsync();
                        Console.WriteLine("\nUpdated Orders:");
                        PrintOrders(updatedOrders);
                    }
                    else if (request.ToLower() == "exit")
                    {
                        break;
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