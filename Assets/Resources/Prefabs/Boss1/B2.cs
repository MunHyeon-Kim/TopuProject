using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2 : Bullet
{


    public int number;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shot());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    IEnumerator shot()
    {

        this.speed = 3.0f;
        if (number == 1)
        {
            gameObject.transform.Rotate(0, 0, 90);
            while (true)
            {
                yield return new WaitForSecondsRealtime(0.5f);
                gameObject.transform.Rotate(0, 0, 90);
                break;

            }
        }

        if (number == 2)
        {
            gameObject.transform.Rotate(0, 0, 90);
            while (true)
            {
                yield return new WaitForSecondsRealtime(1.0f);
                gameObject.transform.Rotate(0, 0, 90);
                break;

            }

        }

        if (number == 3)
        {
            gameObject.transform.Rotate(0, 0, -90);
            while (true)
            {
                yield return new WaitForSecondsRealtime(0.5f);
                gameObject.transform.Rotate(0, 0, -90);
                break;

            }
        }

        if (number == 4)
        {
            gameObject.transform.Rotate(0, 0, -90);
            while (true)
            {
                yield return new WaitForSecondsRealtime(1.0f);
                gameObject.transform.Rotate(0, 0, -90);
                break;

            }
        }
    }



}
