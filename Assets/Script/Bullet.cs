using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    

    [SerializeField]
    public float speed = 5.0f;
    
    void Start()
    {
        
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    
    void OnBecameInvisible()
    {

        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(this.gameObject);
    }

    void BulletClear()
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        Charactor.OnBulletClear += BulletClear;
    }

    private void OnDisable()
    {
        Charactor.OnBulletClear -= BulletClear;
    }
}
