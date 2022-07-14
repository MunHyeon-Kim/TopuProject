using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinTan : MonoBehaviour
{
    [SerializeField] [Header("이동속도")] [Range(1f, 50f)] float speed = 5f;
    [SerializeField] [Header("파동빈도")] [Range(1f, 40f)] float frequency = 20f;
    [SerializeField] [Header("파동높이")] [Range(0.2f, 15f)] float waveHeight = 0.5f;

    Vector3 pos, localScale;
    bool dirRight = true;

    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
    }

    void Update()
    {

        GoRight();

        /*if (transform.position.x > dist)
            dirRight = false;
        else if (transform.position.x < -dist)
            dirRight = true;

        if (dirRight)
            GoRight();
        else
            GoLeft();*/
    }

    void GoRight()
    {
        localScale.x = 1;
        transform.transform.localScale = localScale;
        pos -= transform.up * Time.deltaTime * speed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * waveHeight;

    }

    void GoLeft()
    {
        localScale.x = -1;
        transform.transform.localScale = localScale;
        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * waveHeight;
    }
}
