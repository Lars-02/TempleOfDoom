using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Observers;
using CODE_GameLib.RoomObjects.Wearable;

namespace CODE_GameLib.Entity
{
    public class Player : Entity, IBaseObservable<IPlayer>, IPlayer
    {
        private readonly List<IObserver<IPlayer>> _observers = new List<IObserver<IPlayer>>();
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

        public IDisposable Subscribe(IObserver<IPlayer> observer)
        {
            _observers.Add(observer);
            return new Subscription(() => _observers.Remove(observer));
        }

        private void NotifyObservers(IPlayer player)
        {
            foreach (var observer in _observers) observer.OnNext(player);
        }
    }

    public interface IPlayer : IEntity
    {
        public IEnumerable<Cheat> EnabledCheats { get; }
        public IEnumerable<IWearable> Inventory { get; }
        public ILocation StartLocation { get; }
        public IDisposable Subscribe(IObserver<IPlayer> observer);
        public void AddToInventory(IWearable wearable);
        public void ToggleCheat(Cheat cheat);
        public bool IsCheatEnabled(Cheat cheat);
    }
}