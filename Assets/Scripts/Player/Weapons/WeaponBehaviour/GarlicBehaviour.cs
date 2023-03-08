using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MonoBehaviour
{
    [SerializeField] protected float destroyAfterSeconds;

    private static GarlicController gc;

    void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);

        if (gc == null)
            gc = FindObjectOfType<GarlicController>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        gameObject.transform.position = GarlicController.pm.transform.position;
    }
}
