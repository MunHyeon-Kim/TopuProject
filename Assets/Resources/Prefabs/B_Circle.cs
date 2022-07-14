using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Circle : MonoBehaviour
{

    public static bool freezing = false;


    [SerializeField]
    public float speed = 5.0f;

    void Start()
    {


    }


    void Update()
    {
        if (freezing == false)
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        else if (freezing)
        {
            StartCoroutine(frez());
        }
    }

    IEnumerator frez()
    {
        System.Random rand2 = new System.Random();
        while (true)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            transform.Rotate(0, 0,  (float)rand2.NextDouble() * 360);
            freezing = false;
            break;
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
