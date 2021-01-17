using System;

namespace CODE_GameLib.Interfaces
{
    public interface IBaseObservable<out T> : IObservable<T>
    {
    }
}