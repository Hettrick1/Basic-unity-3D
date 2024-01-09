using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 movement = transform.forward * 50 * Time.deltaTime;
        transform.position = transform.position + movement;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
}
