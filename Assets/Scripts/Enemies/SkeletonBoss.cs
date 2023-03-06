using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class SkeletonBoss : BaseEnemy
{
    [SerializeField] private float followStopDistance;
   
    #region Overriden Methods
    protected override void MoveTowardsTarget()
    {
        if(Vector3.Distance(transform.position, target.position) > followStopDistance)
        {
            // Move Towards
            transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed / 10000);
        }
        else
        {
            //Move Away
            Vector3 moveDirection = transform.position - target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection.normalized, walkSpeed / 10000);
        }
    }
    #endregion
}
