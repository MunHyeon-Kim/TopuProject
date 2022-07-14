using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField]
    GameObject point;
    [SerializeField]
    private int mode;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }



    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (mode)
        {
            case 1:
                DataManager.Power += 0.1f;
                break;
            case 2:
                DataManager.Score += 100;
                break;
            case 3:
                DataManager.Spell += 1;
                break;
            case 4:
                DataManager.Life += 1;
                break;
            default:
                break;
        }


        Destroy(point);
    }
}
