using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public class SystemUpdater : MonoBehaviour
    {
        [SerializeField] private List<SOSystem> systems = new List<SOSystem>();

        private List<SOSystem> updatingSystems = new List<SOSystem>();

        public void Awake()
        {
            foreach (SOSystem system in systems)
            {
                system.Init(this);
            }
        }

        private void Update()
        {
            for (int i = updatingSystems.Count - 1; i >= 0; i--)
            {
                updatingSystems[i].Update();
            }
        }

        public void AddToUpdate(SOSystem system)
        {
            if (!updatingSystems.Contains(system)) updatingSystems.Add(system);
        }
        public void RemoveFromUpdate(SOSystem system)
        {
            if (updatingSystems.Contains(system)) updatingSystems.Remove(system);
        }
    }
}
