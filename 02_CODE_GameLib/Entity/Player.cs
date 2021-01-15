using System.Collections.Generic;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Entity
{
    public class Player : Entity, IPlayer
    {
        public List<Cheat> Cheats { get; } = new List<Cheat>();

        public List<IWearable> Inventory { get; } = new List<IWearable>();

        public Player(int lives, ILocation location) : base(lives, location)
        {
        }

        public bool AddToInventory(IWearable wearable)
        {
            Inventory.Add(wearable);
            NotifyObservers(this);
            return true;
        }
    }
}
