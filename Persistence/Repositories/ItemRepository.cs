using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Item>> GetItemsOfPurchaseOrder()
        {
            var allItems = await _dbContext.Items.Include(x => x.PurchaseOrders).ToListAsync();
            return allItems;
        }

    }
}
