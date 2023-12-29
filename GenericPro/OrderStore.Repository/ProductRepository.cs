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
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public int Complete()
        {
            return 1;
        }
        public async Task<int> Add(Product entity)
        {
            await _context.products.AddAsync(entity);
            var saveData = await _context.SaveChangesAsync();
            return saveData;
        }

        public async Task<Product> Get(int id)
        {
            var GetData = await _context.products.FirstOrDefaultAsync(x => x.ProductId == id);            
            return GetData;           
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
           var AllData = await _context.products.ToListAsync();            
           return AllData;
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
