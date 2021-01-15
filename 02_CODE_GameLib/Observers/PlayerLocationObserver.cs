using System;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.BoobyTraps;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Observers
{
    public class PlayerLocationObserver : IObserver<ILocation>
    {
        private readonly IGame _game;

        public PlayerLocationObserver(IGame game, ILocation location)
        {
            _game = game;
            location.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ILocation location)
        {
            var roomItem = location.Room.Items.FirstOrDefault(item =>
                item.X == location.X && item.Y == location.Y);
            switch (roomItem)
            {
                case IWearable wearable:
                    _game.Player.AddToInventory(wearable);
                    break;
                case IBoobyTrap boobyTrap:
                    _game.Player.ReceiveDamage(boobyTrap.Damage);
                    break;
                case IPressurePlate _:
                    foreach (var connection in location.Room.Connections.Where(conn => conn.Door is IToggleDoor))
                        connection.Door.Opened = !connection.Door.Opened;
                    break;
            }

            if (roomItem is IWearable || roomItem is IDisappearingTrap)
                location.Room.Items.Remove(roomItem);

            _game.Update();
        }
    }
}