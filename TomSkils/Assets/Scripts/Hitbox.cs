using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Hitbox : MonoBehaviour
{
    public Mesh HitboxMesh;
    public float HitboxScale;

    private MeshFilter meshFilter;
    private MeshCollider meshCollider;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = HitboxMesh;

        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = HitboxMesh;
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
        meshCollider.enabled = false;

        transform.localScale = Vector3.one * HitboxScale;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            meshCollider.enabled = !meshCollider.enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }
}
