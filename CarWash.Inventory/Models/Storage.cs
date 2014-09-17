using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarWash.Domain.InventoryModule.Models
{
    public class Storage : Entity<Guid>
    {
        public Storage(String name)
        {
            _name = name;
            _storedInventories = new List<StorageItem>();
        }

        private String _name;
        public virtual String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;
        public virtual String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private readonly IList<StorageItem> _storedInventories;
        public virtual IList<StorageItem> StoredInventories
        {
            get { return new ReadOnlyCollection<StorageItem>(_storedInventories); }
        }
    }
}