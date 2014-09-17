using System;

namespace CarWash.Domain.InventoryModule.Models
{
    public class Inventory : Entity<Guid>
    {
        private String _name;
        private Measurement _measurement;
        private Money _cost;

        public Inventory(String name, Measurement measurement, Money cost)
        {
            _name = name;
            _measurement = measurement;
            _cost = cost;
        }

        public virtual String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual String Description { get; set; }

        public virtual Measurement Measurement
        {
            get { return _measurement; }
            set { _measurement = value; }
        }

        public virtual Money Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
    }
}