using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public GameObject juan ;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            juan.SetActive(true);
            Destroy(gameObject);  
         
            EnemyController.velocimi = EnemyController.velocimi + 3;
            final.dio = final.dio + 1;
        }

    
    }
}

