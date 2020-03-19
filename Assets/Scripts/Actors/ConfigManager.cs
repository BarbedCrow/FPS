using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{

    [SerializeField] private DebugDrawConfig dbgDrawConfig;

    public DebugDrawConfig DbgDrawConfig { get { return dbgDrawConfig; } set { } }

    public static ConfigManager GetConfigManager()
    {
        return GameObject.FindGameObjectWithTag(Tags.CONFIG_MANAGER).GetComponent<ConfigManager>();
    }
}
