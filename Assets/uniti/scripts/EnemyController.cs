using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 5.0f;
    public float pan = 5.0f;
    public int cambio = 1;
    Rigidbody2D rigidbody2D;
    public float timer = 5f;
    int direction = 1;
    public int Dic = 1;
    public bool broken = true;
    public static int velocimi = 1;
    public int lim = 3;
    float distancia;
    float tiempodecaminata;
    public Rigidbody2D rubypocicion;
    
    float horizontal;
    float verticl;
    Vector2 lookDirection = new Vector2(1, 0);



    Animator animator;

    public AudioSource walkiing;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        speed = Random.Range(4.0f, 10.0f);

    }

    void Update()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won’t be executed.
       
        if (!broken)
        {


        }


        if (velocimi > lim)
        {
            lim = lim + 5;
            speed = speed * 2;
        }

        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            direction = direction * -1;
            timer = Random.Range(1.0f, 7.0f);
            cambio = cambio + 1;
        }

        if (speed < 0)
        {

        }
    }

    void FixedUpdate()
    {

        //remember ! inverse the test, so if broken is true !broken will be false and return won’t be executed.
        if (!broken)
        {
            pan -= Time.deltaTime;
            if (pan <= 0)
            {
                broken = true;
                rigidbody2D.simulated = true;
                pan = changeTime;
                walkiing.Play();
                animator.SetTrigger("bla");

            }
        }


        Vector2 position = rigidbody2D.position;

        horizontal = Input.GetAxis("Horizontal");
        verticl = Input.GetAxis("Vertical");
        distancia = Vector2.Distance(rigidbody2D.position, rubypocicion.position);
        if (distancia < 5)
        {

            tiempodecaminata = tiempodecaminata + Time.deltaTime;
            Vector2 move = new Vector2(horizontal, verticl);
         
                tiempodecaminata = 0;


            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }
            

            position = position + 0.02f * (rubypocicion.position - rigidbody2D.position);
            animator.SetFloat("Move X", lookDirection.x);
            animator.SetFloat("Move Y", lookDirection.y);
        }
        else
        {


            if (vertical)
            {
                position.y = position.y + Time.deltaTime * speed * direction;


                if (cambio == 2)
                {
                    cambio = 1;
                    vertical = false;

                }


                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", direction);
            }
            else
            {
                position.x = position.x + Time.deltaTime * speed * direction;


                if (cambio == 2)
                {
                    cambio = 0;
                    vertical = true;
                }


                animator.SetFloat("Move X", direction);
                animator.SetFloat("Move Y", 0);
            }
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        timer = 0;
      


    }

    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;

        //optional if you added the fixed animation
      

    }

}