using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp1
{
    internal class OrderRepEntity : IRepository<Order>
    {
        protected OrderContext _context;

        public OrderRepEntity(OrderContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetByLastName(string lastName)
        {
            return _context.Orders.Where(o => o.LastName.StartsWith(lastName)).ToList();
        }

        public List<Order> GetByLastNameEqualLastNameOfCustomer(int num)
        {
            return _context.Orders.Where(o => o.LastName == o.LastNameOfCustomer && o.SumOfOrder <= num).ToList();
        }

        public List<Order> GetDistinctNameOfOrder()
        {
            return _context.Orders.Distinct().ToList();
        }

        public void GetAVG()
        {
            double averageValue = _context.Orders.Average(o => o.SumOfOrder);
            Console.WriteLine($"Average Order Sum: {averageValue}");
        }


        public List<Order> GetNameOfOrderCount()
        {
            var orderCounts = _context.Orders
                .GroupBy(o => o.NameOfOrder)
                .Where(g => g.Count() >= 1)
                .Select(g => new Order
                {
                    NameOfOrder = g.Key,
                    SumOfOrder = g.Count()
                })
                .ToList();

            foreach (var order in orderCounts)
            {
                Console.WriteLine($"{order.SumOfOrder} | {order.NameOfOrder}");
            }

            return new List<Order>();
        }

        public List<Order> GetOrderBy()
        {
            return _context.Orders.OrderBy(o => o.SumOfOrder).ToList();
        }

        public bool Update(int sum, int sum1)
        {
            var ordersToUpdate = _context.Orders.Where(o => o.SumOfOrder == sum1).ToList();

            foreach (var order in ordersToUpdate)
            {
                order.SumOfOrder = sum;
            }

            _context.SaveChanges();
            return true;
        }
    }
}
