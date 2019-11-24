﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class TestPaC : PointAndClickSkill
    {
        protected override void PaCSkill()
        {
            target.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
