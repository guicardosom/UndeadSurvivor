using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBehaviour : WeaponBehaviour
{
    ScytheController sc;

    protected virtual void Start()
    {
        base.Start();
        sc = FindObjectOfType<ScytheController>();
    }

    void Update()
    {
        transform.position += direction * sc.AttackSpeed * Time.deltaTime;
    }
}
