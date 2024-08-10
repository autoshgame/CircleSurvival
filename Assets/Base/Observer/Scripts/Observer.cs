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

        public void RegisterObserver<T>(IObservableAutoSh<T> observer)
        {
            Type key = typeof(T);
            if (!observers.ContainsKey(key))
            {
                observers[key] = new List<IObservableAutoSh<T>>();
            }

            ((List<IObservableAutoSh<T>>)observers[key]).Add(observer);
        }

        public void RemoveObserver<T>(IObservableAutoSh<T> observer)
        {
            Type key = typeof(T);
            if (observers.ContainsKey(key))
            {
                ((List<IObservableAutoSh<T>>)observers[key]).Remove(observer);
            }
        }

        public void NotifyObservers<T>(T data)
        {
            Type key = typeof(T);
            if (observers.ContainsKey(key))
            {
                // Create a snapshot of the current observers to avoid modification during enumeration
                var currentObservers = new List<IObservableAutoSh<T>>(((List<IObservableAutoSh<T>>)observers[key]));

                foreach (var observer in currentObservers)
                {
                    observer.OnObserverNotify(data);
                }
            }
        }
    }

    public interface IObservableAutoSh<T>
    {
        void OnObserverNotify(T data);
    }
}
