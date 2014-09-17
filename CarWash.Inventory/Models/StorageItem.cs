using System;

namespace CarWash.Domain.InventoryModule.Models
{
    public class StorageItem : Entity<Guid>
    {
        public StorageItem(Storage storage, Inventory inventory, Measurement initialStock)
        {
            _storage = storage;
            _inventory = inventory;
            _stock = initialStock;
        }

        private readonly Storage _storage;
        public virtual Storage Storage
        {
            get { return _storage; }
        }

        private readonly Inventory _inventory;
        public virtual Inventory Inventory
        {
            get { return _inventory; }
        }

        private Measurement _stock;
        public virtual Measurement Stock
        {
            get { return _stock; }
        }

        public void AddStock(Measurement quantity)
        {
            _stock += quantity;
        }
    }
}