using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.RoomObjects.Wearable;

namespace CODE_GameLib.Entity
{
    public class Player : Entity, IPlayer
    {
        private readonly List<Cheat> _enabledCheats = new List<Cheat>();
        private readonly List<IWearable> _inventory = new List<IWearable>();

        public Player(int lives, ILocation location) : base(lives, location)
        {
            StartLocation = new Location(location.Room, location.X, location.Y);
        }

        public IEnumerable<Cheat> EnabledCheats => _enabledCheats;
        public ILocation StartLocation { get; }
        public IEnumerable<IWearable> Inventory => _inventory;


        public void AddToInventory(IWearable wearable)
        {
            _inventory.Add(wearable);
            NotifyObservers(this);
        }

        public void ToggleCheat(Cheat cheat)
        {
            if (_enabledCheats.Contains(cheat))
                _enabledCheats.Remove(cheat);
            else
                _enabledCheats.Add(cheat);
        }

        public bool IsCheatEnabled(Cheat cheat)
        {
            return EnabledCheats.Any(enabledCheat => enabledCheat == cheat);
        }

        public void Shoot(IEnumerable<IEnemy> enemiesInRange)
        {
            foreach (var enemy in enemiesInRange)
                enemy.ReceiveDamage(1);
        }
    }

    public interface IPlayer : IEntity
    {
        public IEnumerable<Cheat> EnabledCheats { get; }
        public IEnumerable<IWearable> Inventory { get; }
        public ILocation StartLocation { get; }
        public void AddToInventory(IWearable wearable);
        public void ToggleCheat(Cheat cheat);
        public bool IsCheatEnabled(Cheat cheat);
        public void Shoot(IEnumerable<IEnemy> enemiesInRange);
    }
}