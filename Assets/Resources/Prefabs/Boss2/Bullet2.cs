using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{

    public static  bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector2.up * 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (start) {

            transform.Translate(Vector2.up * Time.deltaTime * 5.0f);

        }
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
