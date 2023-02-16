using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PurchaseOrder?> GetByIdWithItemsAsync(Guid id) {
            return await _dbContext.Set<PurchaseOrder>().Include(p => p.Items).FirstAsync(p => p.Id == id); 
        }

        public async Task<IReadOnlyList<PurchaseOrder>> ListAllWithItemsAsync()
        {
            return await _dbContext.Set<PurchaseOrder>().Include(p => p.Items).ToListAsync();
        }
    }   
}
