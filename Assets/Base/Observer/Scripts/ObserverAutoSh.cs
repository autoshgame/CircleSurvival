using System;
using System.Collections.Generic;

namespace AutoShGame.Base.Observer
{
    /// <summary>
    /// Observer implementation with multi channels (Using Type)
    /// </summary>
    public static class ObserverAutoSh
    {
        private static Dictionary<Type, object> observers = new Dictionary<Type, object>();

        public static void RegisterObserver<T>(IObservableAutoSh<T> ObserverAutoSh)
        {
            Type key = typeof(T);
            if (!observers.ContainsKey(key))
            {
                observers[key] = new List<IObservableAutoSh<T>>();
            }

            ((List<IObservableAutoSh<T>>)observers[key]).Add(ObserverAutoSh);
        }

        public static void RemoveObserver<T>(IObservableAutoSh<T> ObserverAutoSh)
        {
            Type key = typeof(T);
            if (observers.ContainsKey(key))
            {
                ((List<IObservableAutoSh<T>>)observers[key]).Remove(ObserverAutoSh);
            }
        }

        public static void NotifyObservers<T>(T data)
        {
            Type key = typeof(T);
            if (observers.ContainsKey(key))
            {
                // Create a snapshot of the current ObserverAutoShs to avoid modification during enumeration
                var currentObserverAutoShs = new List<IObservableAutoSh<T>>(((List<IObservableAutoSh<T>>)observers[key]));

                foreach (var ObserverAutoSh in currentObserverAutoShs)
                {
                    ObserverAutoSh.OnObserverNotify(data);
                }
            }
        }
    }

    public interface IObservableAutoSh<T>
    {
        void OnObserverNotify(T data);
    }
}
