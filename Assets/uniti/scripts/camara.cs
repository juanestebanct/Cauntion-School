using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{

    public GameObject cam;
    private Vector3 posicionRelativa;

    // Use this for initialization
    void Start()
    {

        posicionRelativa = transform.position - cam.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = cam.transform.position + posicionRelativa;

    }
}