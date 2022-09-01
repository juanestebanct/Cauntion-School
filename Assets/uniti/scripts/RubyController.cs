using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    public Text countext;
    public int maxHealth = 5;
    public int vidas = 3;
    public GameObject projectilePrefab;
    public GameObject borrado;
    float tami=0f;
    public float activacionescoba = 0;
    public float activacionborrador = 0;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    AudioSource audioSource;
    public AudioSource caminata;
    Vector2 lookDirection = new Vector2(1, 0);
    


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        final.dio = 0;
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        activacionescoba = activacionescoba - Time.deltaTime;
        activacionborrador = activacionborrador - Time.deltaTime;
        if ( vidas>0)
        {
          
            horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
               
            }
            else
            {
                caminata.Play();
            }


        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {

            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)

                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

                if(activacionescoba < 0)
                {
                  Launch();
                    activacionescoba = 5;
                }
          
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
                if(activacionborrador < 0)
                {
                    activacionborrador = 5;
                    GameObject borrador = Instantiate(borrado, rigidbody2d.position + Vector2.up * 1f, Quaternion.identity);

                borrador projectile = borrador.GetComponent<borrador>();
                projectile.launch(lookDirection, 300);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
                if (hit.collider != null)
                {
                    Debug.Log("Raycast has hit the object " + hit.collider.gameObject);

                    NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                    if (character != null)
                    {
                        character.DisplayDialog();
                    }
                }
            }
        }
        else
        {
           
            tami = tami + Time.deltaTime;
           
            if(tami >1 )
            {

          
            SceneManager.LoadScene("menu");
             }  
        }
    }
    void FixedUpdate()
    {

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
       
        rigidbody2d.MovePosition(position);
    }

   
  
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 1f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 0);

       
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("profe"))
        {
            SceneManager.LoadScene("atrapado");
        }


    }
}