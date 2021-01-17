using System.Collections.Generic;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.RoomObjects.Wearable;

namespace CODE_GameLib.Interfaces.Entity
{
    public interface IPlayer : IEntity
    {
        public List<IWearable> Inventory { get; }
        public List<Cheat> Cheats { get; }
        public ILocation StartLocation { get; }
        public bool AddToInventory(IWearable wearable);
    }
}