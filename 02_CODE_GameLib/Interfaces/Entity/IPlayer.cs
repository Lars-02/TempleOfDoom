using System.Collections.Generic;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Interfaces.Entity
{
    public interface IPlayer : IEntity
    {
        public bool Won { get; }

        public IEnumerable<IWearable> Inventory { get; }

        public bool AddToInventory(IWearable wearable);

        
    }
}
