using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public static float speed = 600.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (VirtualJoystic.isInput)
        {
            transform.Translate(VirtualJoystic.inputVector * Time.deltaTime * speed);

        }
        
    }

    public void Move(Vector3 vector)
    {
        transform.position += vector * Time.deltaTime * speed;
    }

}
