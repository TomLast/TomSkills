using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public class Projectile : MonoBehaviour
    {
        public Vector3 Direction { get; set; }
        public Vector3 startPos { get; set; }
        public Champion caster { get; set; }
        public EventSystem eventSystem;

        [SerializeField] private ProjectileData data;

        private float duration;
        private IEnumerator coroutine;
        private Vector3 xOffset;
        private Vector3 lerpVector;
        private Events.OnTriggerEnterEvent triggerEvent;

        // Start is called before the first frame update
        void Start()
        {
            triggerEvent = new Events.OnTriggerEnterEvent();
            triggerEvent.TriggetCollider = GetComponent<Collider>();

            duration = data.Range / data.Speed;
            coroutine = Tasks.LerpHandle(duration, Move, null, () => Destroy(gameObject));
            Vector2 perpendicular = Vector2.Perpendicular(new Vector2(Direction.x, Direction.z));
            xOffset = new Vector3(perpendicular.x, 0, perpendicular.y);
            StartCoroutine(coroutine);
        }

        private void Move(float t)
        {
            lerpVector = Vector3.Lerp(startPos, startPos + (Direction * data.Speed * duration), t);
            transform.position = lerpVector + xOffset * (data.xOffset.Evaluate(t) * data.xOffsetScale) + Vector3.up * (data.yOffset.Evaluate(t) * data.yOffsetScale);
        }

        private void OnTriggerEnter(Collider other)
        {
            triggerEvent.Other = other;

            eventSystem?.RaiseEvent<Events.OnTriggerEnterEvent>(triggerEvent);
        }
    }
}
