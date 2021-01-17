using CODE_TempleOfDoom_DownloadableContent;

namespace CODE_GameLib.Entity
{
    public class EnemyLocationAdapter : Location
    {
        private readonly Enemy _adaptee;

        public EnemyLocationAdapter(Enemy enemy, IRoom startingRoom)
        {
            _adaptee = enemy;
            Room = startingRoom;
        }

        public sealed override IRoom Room { get; protected set; }

        public override int X
        {
            get => _adaptee.CurrentXLocation;
            protected set => _adaptee.CurrentXLocation = value;
        }

        public override int Y
        {
            get => _adaptee.CurrentYLocation;
            protected set => _adaptee.CurrentYLocation = value;
        }

        public void Update()
        {
            NotifyObservers(this);
        }
        
        public override bool SetLocation(ILocation location)
        {
            if (location.Room.IsWall(location.X, location.Y))
                return false;
            Room = location.Room;
            X = location.X;
            Y = location.Y;
            NotifyObservers(this);
            return true;
        }
    }
}