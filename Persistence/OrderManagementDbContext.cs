using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class OrderManagementDbContext : DbContext
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options)
                   : base(options)
        {
        }

        public DbSet<PurchaseOrder> ?PurchaseOrders { get; set; }
        public DbSet<Item> ?Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderManagementDbContext).Assembly);

            var carGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                Name = "Car"
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                Name = "Van"
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}"),
                Name = "Bicycle"
            });

            modelBuilder.Entity<PurchaseOrder>().HasData(new PurchaseOrder
            {
                Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Vendor = "John & Sons Toyota Dealers",
                Total = 6500000,
                PlacedOn = DateTime.Now,
                DeliverOn = DateTime.Now.AddMonths(6),
                Notes = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ItemId = carGuid
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
