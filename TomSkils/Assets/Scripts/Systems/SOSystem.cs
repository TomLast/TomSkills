using UnityEngine;

namespace TomSkills
{
    public abstract class SOSystem : ScriptableObject
    {
        public virtual void Init(MonoBehaviour mb) { this.mb = mb; }

        public abstract void Update();

        private MonoBehaviour mb;
    } 
}
