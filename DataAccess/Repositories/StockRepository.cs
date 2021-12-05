using DataAccess.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
          
        }

        public async Task<List<Stock>> GetByProductCode(string ProductCode)
        {
           return await _context.Stock.Where(x => x.ProductCode == ProductCode)
                .Select(x => new Stock { 
                  Id = x.Id,
                  VariantCode = x.VariantCode,
                  ProductCode = x.ProductCode,
                  Quantity = x.Quantity
                }).ToListAsync().ConfigureAwait(false);
        }
        public async Task<Stock> GetByVariantCode(string VariantCode)
        {
            return await _context.Stock.Where(x => x.VariantCode == VariantCode)
                 .Select(x => new Stock
                 {
                     Id = x.Id,
                     VariantCode = x.VariantCode,
                     ProductCode = x.ProductCode,
                     Quantity = x.Quantity
                 })
                .FirstOrDefaultAsync();
        }

        public async Task<Stock> Update(string VariantCode, int Quantity)
        {
            var Entity =  await _context.Stock.FirstOrDefaultAsync(x => x.VariantCode == VariantCode);
            if (Entity == null)
                return null;

            Entity.Quantity = Quantity;
            Entity.UpdateTime = DateTime.Now;

            _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Entity;
        }
    }
}
