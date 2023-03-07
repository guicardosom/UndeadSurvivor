using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Damage
{
    public Damage(float v, DamageType t)
    {
        value = v;
        type = t;
    }

    public DamageType type;
    public float value;
}

public enum DamageType
{
    Physical,
    Magical,
    Poison
}