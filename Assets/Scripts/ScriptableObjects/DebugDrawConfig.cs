using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugDrawConfigObj", menuName = "ScriptableObjects/DebugDrawConfig", order = 1)]
public class DebugDrawConfig : ScriptableObject
{
    public bool drawDebugVisualScanners;
}
