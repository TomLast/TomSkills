using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Projectile")]
public class ProjectileData : ScriptableObject
{
    public AnimationCurve xOffset;
    public AnimationCurve yOffset;
    public float xOffsetScale;
    public float yOffsetScale;
    public float Range;
    public float Speed;
}
