using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public class Champion : MonoBehaviour, ISelectable
    {
        public bool IsUsingSelectSkill { get; set; } = false;
        public float PaCRadius { get; set; }
        public ChampionStats Stats;
        public Effect effect;

        [SerializeField] private EventSystem eventSystem;
        
        private Events.GameObjectClickedEvent clickedEvent;

        private void Start()
        {
            clickedEvent = new Events.GameObjectClickedEvent();
            clickedEvent.Value = gameObject;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                effect.Use<MovementSpeed>(this, Stats.GetStatValue<MovementSpeed>());
        }

        public void OnSelected(Vector3 point, KeyCode key)
        {
            if(key == KeyCode.Mouse0)
            {
                clickedEvent.pos = point;
                clickedEvent.mouseKey = key;
                eventSystem?.RaiseEvent<Events.GameObjectClickedEvent>(clickedEvent);
            }
        }

        private void OnDrawGizmos()
        {
            if(IsUsingSelectSkill)
            {
                Gizmos.color = Color.green;

                Gizmos.DrawWireSphere(transform.position, PaCRadius);
            }
        }
    } 
}
