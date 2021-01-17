using System.Collections.Generic;
using CODE_GameLib.Enums;
using CODE_GameLib.RoomObjects.Wearable;

namespace CODE_GameLib.Entity
{
    public class Player : Entity, IPlayer
    {
        public Player(int lives, ILocation location) : base(lives, location)
        {
            StartLocation = new Location(location.Room, location.X, location.Y);
        }

        public List<Cheat> Cheats { get; } = new List<Cheat>();
        public ILocation StartLocation { get; }
        public List<IWearable> Inventory { get; } = new List<IWearable>();

        public void AddToInventory(IWearable wearable)
        {
            Inventory.Add(wearable);
            NotifyObservers(this);
        }
    }

    public interface IPlayer : IEntity
    {
        public List<IWearable> Inventory { get; }
        public List<Cheat> Cheats { get; }
        public ILocation StartLocation { get; }
        public void AddToInventory(IWearable wearable);
    }
}