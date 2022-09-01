using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrador : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float time=0 ;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        time= time + Time.deltaTime;
        if (time> 1)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        paredfalza e = other.collider.GetComponent<paredfalza>();
        if (e != null)
        {
            e.desapareser();
        }
        Destroy(gameObject);

    }
}

