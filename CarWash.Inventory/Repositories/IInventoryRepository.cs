using System;

namespace CarWash.Domain.InventoryModule.Repositories
{
    using Models;

    public interface IInventoryRepository : IRepository<Inventory, Guid>
    {
    }
}