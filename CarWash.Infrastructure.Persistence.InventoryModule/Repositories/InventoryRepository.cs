using System;
using NHibernate;

namespace CarWash.Infrastructure.Persistence.InventoryModule.Repositories
{
    using Domain.InventoryModule.Models;
    using Domain.InventoryModule.Repositories;

    public class InventoryRepository : Repository<Inventory, Guid>, IInventoryRepository
    {
        public InventoryRepository(ISession session) : base(session)
        {
        }
    }
}