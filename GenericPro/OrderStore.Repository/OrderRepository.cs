using Microsoft.EntityFrameworkCore;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;
using OrderStore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStore.Repository
{
    public class OrderRepository : IOrder
    {        
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Task<int> Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
           return await _context.orders.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName)
        {
            return await _context.orders.Where(c => c.OrderDetails.Contains(orderName)).ToListAsync();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
