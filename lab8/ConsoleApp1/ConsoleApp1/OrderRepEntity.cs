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

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetByLastName(string lastName)
        {
            return await _context.Orders.Where(o => o.LastName.StartsWith(lastName)).ToListAsync();
        }

        public async Task<List<Order>> GetByLastNameEqualLastNameOfCustomer(int num)
        {
            return await _context.Orders.Where(o => o.LastName == o.LastNameOfCustomer && o.SumOfOrder <= num).ToListAsync();
        }

        public async Task<List<Order>> GetDistinctNameOfOrder()
        {
            return await _context.Orders.Distinct().ToListAsync();
        }

        public async Task GetAVG()
        {
            double averageValue = await _context.Orders.AverageAsync(o => o.SumOfOrder);
            Console.WriteLine($"Average Order Sum: {averageValue}");
        }


        public async Task<List<Order>> GetNameOfOrderCount()
        {
            var orderCounts =await _context.Orders
                .GroupBy(o => o.NameOfOrder)
                .Where(g => g.Count() >= 1)
                .Select(g => new Order
                {
                    NameOfOrder = g.Key,
                    SumOfOrder = g.Count()
                })
                .ToListAsync();

            foreach (var order in orderCounts)
            {
                Console.WriteLine($"{order.SumOfOrder} | {order.NameOfOrder}");
            }

            return new List<Order>();
        }

        public async Task<List<Order>> GetOrderBy()
        {
            return await _context.Orders.OrderBy(o => o.SumOfOrder).ToListAsync();
        }

        public async Task<bool> Update(int sum, int sum1)
        {
            var ordersToUpdate = await _context.Orders.Where(o => o.SumOfOrder == sum1).ToListAsync();

            foreach (var order in ordersToUpdate)
            {
                order.SumOfOrder = sum;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
