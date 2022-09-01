using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gota : MonoBehaviour
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
    public float  pisomojado= 0;
    float distancia;
    public Rigidbody2D rubypocicion;
    public GameObject charco;
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
        speed = Random.Range(1.0f, 10.0f);
        pisomojado = Random.Range(10.0f,30.0f);

    }

    void Update()
    {
        pisomojado = pisomojado - Time.deltaTime;
        if (final.dio == 6)
        {

            rigidbody2D.simulated = false;

            walkiing.Stop();
        }
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
            timer = Random.Range(3.0f, 7.0f);
            cambio = cambio + 1;
        }

        if (speed < 0)
        {

        }
    }

    void FixedUpdate()
    {

        if (pisomojado <= 0)
        {
            pisomojado = Random.Range(10.0f, 30.0f);
            GameObject mojado = Instantiate(charco,rigidbody2D.position + Vector2.up * 1f, Quaternion.identity);

            mojado projectile = mojado.GetComponent<mojado>();
            projectile.Launcher(lookDirection, 0);
          
        }
       


        Vector2 position = rigidbody2D.position;

        horizontal = Input.GetAxis("Horizontal");
        verticl = Input.GetAxis("Vertical");
        distancia = Vector2.Distance(rigidbody2D.position, rubypocicion.position);
       
       


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