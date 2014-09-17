using System;

namespace CarWash.Infrastructure.Persistence.InventoryModule.Mappings
{
    using Domain.InventoryModule.Models;

    public class InventoryMap : EntityMap<Inventory, Guid>
    {
        public InventoryMap()
        {
            Map(x => x.Name);
            Map(x => x.Description);
            Component(x => x.Measurement, m => MeasurementMap.Mapping());
            Component(x => x.Cost, m => MoneyMap.Mapping());
        }
    }
}