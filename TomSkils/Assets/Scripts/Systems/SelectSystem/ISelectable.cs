using UnityEngine;

namespace TomSkills
{
    public interface ISelectable
    {
        void OnSelected(Vector3 point, KeyCode key);
    } 
}
