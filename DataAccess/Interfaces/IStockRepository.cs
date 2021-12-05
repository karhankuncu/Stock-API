using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        public Task<Stock> Update(string VariantCode, int Quantity);
        public Task<List<Stock>> GetByProductCode(string ProductCode);
        public Task<Stock> GetByVariantCode(string ProductCode);
    }
}
