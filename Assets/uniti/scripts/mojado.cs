using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class mojado : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float tiempodevida = 0;
    Animator animator;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        tiempodevida = 0;
        animator = GetComponent<Animator>();
    }

    public void Launcher(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        tiempodevida = tiempodevida + Time.deltaTime;
       
        if (tiempodevida > 5)
        {

            animator.SetTrigger("paso");

        }
        if (tiempodevida > 10)
        {

          

        }
        if (tiempodevida > 15)
        {

            animator.SetTrigger("dio");

        }
        if (tiempodevida > 20)
        {
            animator.SetTrigger("sou");
            tiempodevida = 0;
            Destroy(gameObject);

        }

    }


}
