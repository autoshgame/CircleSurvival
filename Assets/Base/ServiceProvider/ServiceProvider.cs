using System;
using System.Collections.Generic;

namespace AutoShGame.Base.ServiceProvider
{
    public static class ServiceProvider
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        // Register a service
        public static void Register<T>(T service)
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
            {
                throw new InvalidOperationException($"Service of type {type} is already registered.");
            }

            _services[type] = service;
        }

        // Resolve a service
        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (_services.TryGetValue(type, out var service))
            {
                return (T)service;
            }

            throw new InvalidOperationException($"Service of type {type} is not registered.");
        }

        // Optionally, remove a service
        public static void Unregister<T>()
        {
            var type = typeof(T);
            if (!_services.Remove(type))
            {
                throw new InvalidOperationException($"Service of type {type} is not registered.");
            }
        }
    }
}