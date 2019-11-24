using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionCamera : MonoBehaviour
{
    [SerializeField] private Transform champion;
    [SerializeField] private float distance;
    [Range(0, 89)] 
    [SerializeField] private float angle;
    [SerializeField] private bool constantlyUpdatePos;
    [SerializeField] private float maxZoomIN;
    [SerializeField] private float maxZoomOUT;

    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = champion.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPos != champion.position && !constantlyUpdatePos) return;
        UpdatePos();
    }

    public void UpdatePos()
    {
        Vector2 pointOnUnitCircle = new Vector2(Mathf.Cos(Mathf.Clamp(angle, 0, 89) * Mathf.Deg2Rad), Mathf.Sin(Mathf.Clamp(angle, 0, 89) * Mathf.Deg2Rad));
        Vector3 targetPos = champion.position + (new Vector3(0, pointOnUnitCircle.y, -pointOnUnitCircle.x) * Mathf.Clamp(distance, maxZoomIN, maxZoomOUT));
        transform.position = targetPos;//new Vector3(champion.position.x, pointOnUnitCircle.y * Mathf.Clamp(distance, maxZoomIN, maxZoomOUT), -pointOnUnitCircle.x * Mathf.Clamp(distance, maxZoomIN, maxZoomOUT));
        transform.LookAt(champion);
    }

    private void OnDrawGizmos()
    {
        if (UnityEditor.EditorApplication.isPlaying) return;
        UpdatePos();
        
    }
}
