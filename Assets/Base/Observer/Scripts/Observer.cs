using System;
using System.Collections.Generic;
using AutoShGame.Base.MonoSingleton;

namespace AutoShGame.Base.Observer
{
    /// <summary>
    /// Observer implementation
    /// <br></br>
    /// <br></br>
    /// WARNING!!! Not thread-safe, memory-leak observer pattern
    /// </summary>
    public class Observer : Singleton<Observer>
    {
        private Dictionary<Type, object> observers = new Dictionary<Type, object>();

        public void RegisterObserver<T>(IObserver<T> observer)
        {
            Type key = typeof(T);
            if (!observers.ContainsKey(key))
            {
                observers[key] = new List<IObserver<T>>();
            }

            ((List<IObserver<T>>)observers[key]).Add(observer);
        }

        public void RemoveObserver<T>(IObserver<T> observer)
        {
            Type key = typeof(T);
            if (observers.ContainsKey(key))
            {
                ((List<IObserver<T>>)observers[key]).Remove(observer);
            }
        }

        public void NotifyObservers<T>(T data)
        {
            Type key = typeof(T);
            if (observers.ContainsKey(key))
            {
                foreach (var observer in (List<IObserver<T>>)observers[key])
                {
                    observer.OnObserverNotify(data);
                }
            }
        }
    }
}

