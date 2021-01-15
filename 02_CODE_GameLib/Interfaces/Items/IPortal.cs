namespace CODE_GameLib.Interfaces.Items
{
    public interface IPortal : IItem
    {
        ILocation Destination { get; }
    }
}