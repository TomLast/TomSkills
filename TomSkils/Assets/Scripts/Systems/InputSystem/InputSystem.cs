using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class InputSystem : SOSystem
    {
        public List<KeyCode> keys = new List<KeyCode>();
        public EventSystem eventSystem;

        private Events.KeyEvent keyEvent = new Events.KeyEvent();
        private Events.KeyDownEvent keyDownEvent = new Events.KeyDownEvent();

        public override void Init(SystemUpdater mb)
        {
            base.Init(mb);
            mb.AddToUpdate(this);
        }

        public override void Update()
        {
            foreach(KeyCode key in keys)
            {
                if (Input.GetKeyDown(key))
                {
                    keyDownEvent.Value = key;
                    eventSystem?.RaiseEvent<Events.KeyDownEvent>(keyDownEvent);
                }
            }
            foreach (KeyCode key in keys)
            {
                if (Input.GetKey(key))
                {
                    keyEvent.Value = key;
                    eventSystem?.RaiseEvent<Events.KeyEvent>(keyEvent);
                }
            }
        }
    }
}
