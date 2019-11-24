using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class SelectSystem : SOSystem
    {
        public LayerMask selectableLayer;
        public EventSystem eventSystem;

        private Ray ray;
        private RaycastHit hit;
        private Camera camera;

        public override void Init(MonoBehaviour mb)
        {
            base.Init(mb);
            camera = Camera.main;
            eventSystem?.AddListener<Events.KeyDownEvent>(Raycast);
        }

        public override void Update()
        {

        }

        public void Raycast(Events.BaseEvent e)
        {
            Events.KeyDownEvent keyEvent = (Events.KeyDownEvent)e;
            if (keyEvent.Value == KeyCode.Mouse0 || keyEvent.Value == KeyCode.Mouse1)
            {
                ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    ISelectable selectable = hit.collider.gameObject.GetComponent<ISelectable>();

                    if (selectable != null)
                    {
                        selectable.OnSelected(hit.point, Input.GetMouseButtonDown(0) ? KeyCode.Mouse0 : KeyCode.Mouse1);
                    }
                }
            }
        }
    }
}
