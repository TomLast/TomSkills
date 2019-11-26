using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TomSkills
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ChampionMovement : MonoBehaviour
    {
        public EventSystem eventSystem;

        private NavMeshAgent navMeshAgent;
        private FloatReference movementSpeed;

        public void Awake()
        {
            eventSystem?.AddListener<Events.GameObjectClickedEvent>(Move);
            navMeshAgent = GetComponent<NavMeshAgent>();
            movementSpeed = GetComponent<Champion>().Stats.GetStatValue<MovementSpeed>();
        }

        private void Move(Events.BaseEvent e)
        {
            Events.GameObjectClickedEvent clickedEvent = (Events.GameObjectClickedEvent)e;
            if (clickedEvent.mouseKey == KeyCode.Mouse0) return;
            if(clickedEvent.Value.tag == "Ground")
            {
                navMeshAgent.speed = movementSpeed.Value;
                navMeshAgent.SetDestination(clickedEvent.pos);
            }
        }
    }
}
