using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float tiempodevida = 0;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        tiempodevida = tiempodevida + Time.deltaTime;
        if (tiempodevida>20)
        {
            Destroy(gameObject);
        }
       
    }

  
}
