using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    public float speed = 5.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }

        
    }
}
