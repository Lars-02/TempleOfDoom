using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class Portal : IPortal
    {
        public int X { get; }
        public int Y { get; }
        public ILocation Destination { get; }
        
        public Portal(int x, int y, ILocation destination)
        {
            Destination = destination;
            Y = y;
            X = x;
        }
    }
}