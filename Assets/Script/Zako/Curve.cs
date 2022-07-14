using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public Vector2 move(float t) { 
    
        Vector2 v = new Vector3(
            p1.transform.position.x * (1 - t) * (1 - t) * (1 - t)

        + p2.transform.position.x * 3 * t * (1 - t) * (1 - t)

        + p3.transform.position.x * 3 * t * t * (1 - t)

        + p4.transform.position.x * t * t * t

    , 

     p1.transform.position.y * (1 - t) * (1 - t) * (1 - t)

    + p2.transform.position.y * 3 * t * (1 - t) * (1 - t)

    + p3.transform.position.y * 3 * t * t * (1 - t)

    + p4.transform.position.y * t * t * t);
        return v;
            
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
