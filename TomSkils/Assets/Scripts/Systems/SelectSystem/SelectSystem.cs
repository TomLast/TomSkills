using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class SelectSystem : SOSystem
    {
        public LayerMask selectableLayer;
        public EventSystem eventSystem;
        public RaycastHitVariable raycastHitVariable;

        private Ray ray;
        private RaycastHit hit;
        private Camera camera;

        public override void Init(SystemUpdater mb)
        {
            base.Init(mb);
            camera = Camera.main;
            eventSystem?.AddListener<Events.KeyDownEvent>(SelectObject);
            mb.AddToUpdate(this);
        }

        public override void Update()
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                raycastHitVariable.Value = hit;
            }
            else
                raycastHitVariable.Value = default;
        }

        public void SelectObject(Events.BaseEvent e)
        {
            Events.KeyDownEvent keyEvent = (Events.KeyDownEvent)e;
            if (keyEvent.Value == KeyCode.Mouse0 || keyEvent.Value == KeyCode.Mouse1)
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
