using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public class Environment : MonoBehaviour, ISelectable
    {
        [SerializeField] private EventSystem eventSystem;

        private Events.GameObjectClickedEvent clickedEvent;

        private void Start()
        {
            clickedEvent = new Events.GameObjectClickedEvent();
            clickedEvent.Value = gameObject;
        }
        public void OnSelected(Vector3 point, KeyCode key)
        {
            clickedEvent.pos = point;
            clickedEvent.mouseKey = key;
            eventSystem?.RaiseEvent<Events.GameObjectClickedEvent>(clickedEvent);
        }
    }
}
