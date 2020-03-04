using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Actor
{
    [SerializeField]
    private FirearmType type;

    public FirearmType Type { get { return type; } set { } }



}

[SerializeField]
public enum FirearmType
{
    SINGLE,
    AUTO,
    BURST
}
