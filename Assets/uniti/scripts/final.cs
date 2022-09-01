using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class final : MonoBehaviour
{
    public static int dio = 0;

    public Text avertencia ;

void OnCollisionEnter2D(Collision2D other)
    {
      
     if(dio>=1)
        {

            SceneManager.LoadScene("finalmalo");

        }
        else
        {
            SceneManager.LoadScene("finalbueno");
        }

    }
    void Update()
    {
      
    }
}
