using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public class SystemUpdater : MonoBehaviour
    {
        [SerializeField] private List<SOSystem> systems = new List<SOSystem>();

        public void Awake()
        {
            foreach (SOSystem system in systems)
            {
                system.Init(this);
            }
        }

        private void Update()
        {
            for (int i = systems.Count - 1; i >= 0; i--)
            {
                systems[i].Update();
            }
        }
    } 
}
