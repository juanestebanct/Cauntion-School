using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class c2 : MonoBehaviour
{

    public float tiempo;
    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        if (tiempo > 3)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
