using Domain.Common;
using Domain.Entities;
using MediatR;
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

        private readonly IMediator _mediator;

        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options, IMediator mediator)
                   : base(options)
        {
            _mediator = mediator;
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
                Name = "Car",
                Description = "Toyota AXE 3",
                Quantity = 1,
                Price = 6500000,
            });

            modelBuilder.Entity<PurchaseOrder>().HasData(new PurchaseOrder
            {
                Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Vendor = "John & Sons Toyota Dealers",
                Total = 6500000,
                PlacedOn = DateTime.Now,
                DeliverOn = DateTime.Now.AddMonths(6),
                Notes = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ItemId = "abcd"
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
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

            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
