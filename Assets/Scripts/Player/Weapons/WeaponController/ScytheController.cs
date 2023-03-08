using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheController : BaseWeapon
{
    protected override void Start()
    {
        base.Start();
    }

    protected override Damage Attack()
    {
        GameObject spawnedScythe = Instantiate(prefab);
        spawnedScythe.transform.position = transform.position;
        spawnedScythe.GetComponent<ScytheBehaviour>().DirectionHandler(pm.lastMoveDirection);
        return base.Attack();
    }
}
