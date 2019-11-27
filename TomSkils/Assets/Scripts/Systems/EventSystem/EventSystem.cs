using System;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class EventSystem : SOSystem
    {
        public delegate void EventListener(Events.BaseEvent e);

        private Dictionary<Type, List<EventListener>> eventListeners = new Dictionary<Type, List<EventListener>>();

        public override void Update() { }

        public void RaiseEvent<T>(Events.BaseEvent e) where T : Events.BaseEvent
        {
            if (!eventListeners.ContainsKey(e.GetType())) return;

            for (int i = eventListeners[e.GetType()].Count - 1; i >= 0; i--)
            {
                eventListeners[e.GetType()][i]((T)e);
            }
        }

        public void AddListener<T>(EventListener listener) where T : Events.BaseEvent
        {
            if (!eventListeners.ContainsKey(typeof(T)))
            {
                eventListeners.Add(typeof(T), new List<EventListener>() { listener });
                return;
            }
            if (!eventListeners[typeof(T)].Contains(listener))
                eventListeners[typeof(T)].Add(listener);
        }

        public void RemoveListener<T>(EventListener listener)
        {
            if (!eventListeners.ContainsKey(typeof(T)))
                return;

            if (eventListeners[typeof(T)].Contains(listener))
                eventListeners[typeof(T)].Remove(listener);
        }
    }
}