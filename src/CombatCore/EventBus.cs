using System;
using System.Collections.Generic;

namespace CombatCore
{
    public class EventBus
    {
        private Dictionary<Type, List<Delegate>> Handlers { get; set; }

        public EventBus()
        {
            Handlers = new Dictionary<Type, List<Delegate>>();
        }

        public void Subscribe<T>(Action<T> action)
        {
            var type = typeof(T);
            if (!Handlers.TryGetValue(type, out var typeHandlers))
            {
                typeHandlers = new List<Delegate>();
                Handlers[type] = typeHandlers;
            }
            
            if (!typeHandlers.Contains(action))
            {
                typeHandlers.Add(action);
            }
        }

        public void Unsubscribe<T>(Action<T> action)
        {
            var type = typeof(T);
            if (!Handlers.TryGetValue(type, out var typeHandlers))
            {
                // If it cant get the value that means nothing was subscribed so we can exit early.
                return;
            }

            typeHandlers.Remove(action);
        }

        public void Publish<T>(T @event)
        {
            var type = typeof(T);
            if (!Handlers.TryGetValue(type, out var typeHandlers))
            {
                // If it cant get the value that means nothing was subscribed so we can exit early.
                return;
            }

            foreach (var handler in typeHandlers.ToArray())
            {
                ((Action<T>)handler)(@event);
            }
        }
    }
}