using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBehaviour : MonoBehaviour
{
    [SerializeField] protected float destroyAfterSeconds;

    private Vector3 direction;

    private static ScytheController sc;

    void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);

        if (sc == null)
            sc = FindObjectOfType<ScytheController>();

        DirectionHandler(ScytheController.pm.lastMoveDirection);
    }

    void Update()
    {
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        transform.position += direction * sc.AttackSpeed * Time.deltaTime;
    }

    public void DirectionHandler(Vector3 dir)
    {
        direction = dir;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (direction.x < 0 && direction.y == 0) //left
        {
            scale.y *= -1;
        }
        else if (direction.x == 0 && direction.y < 0) //down
        {
            scale.y *= -1;
            rotation.z = 0f;
        }
        else if (direction.x == 0 && direction.y > 0) //up
        {
            rotation.z = 0f;
        }
        else if (direction.x > 0 && direction.y > 0) //right up
        {
            rotation.z = -45f;
        }
        else if (direction.x > 0 && direction.y < 0) //right down
        {
            rotation.z = -135f;
        }
        else if (direction.x < 0 && direction.y > 0) //left up
        {
            scale.y *= -1;
            rotation.z = -135f;
        }
        else if (direction.x < 0 && direction.y < 0) //left down
        {
            scale.y *= -1;
            rotation.z = -45f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
