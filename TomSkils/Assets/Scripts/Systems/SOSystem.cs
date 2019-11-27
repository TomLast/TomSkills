using UnityEngine;

namespace TomSkills
{
    public abstract class SOSystem : ScriptableObject
    {
        public virtual void Init(SystemUpdater mb) { this.mb = mb; }

        public virtual void Update() { }

        private MonoBehaviour mb;
    } 
}
