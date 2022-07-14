using System.Collections;

using System.Collections.Generic;

using UnityEngine;
public class Target : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    Curve bezierCurve; //타겟 오브젝트에 이 스크립트를 붙이고 BezierCurve의 인스턴스를 만들어서 사용합니다

    Transform tr; //타겟오브젝트의 Transform을 다룰 변수

    float time;

    void Start()
    {

        tr = GetComponent<Transform>(); //이 스크립트가 붙은 오브젝트에서 Transform을 가져옵니다

        time = 0;

    }
    void Update()
    {

        time += Time.deltaTime;

        tr.position = move(Mathf.Lerp(0, 1, time / 5.0f)); //5초동안 움직입니다

    }

    /*Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 a = Mathf.Lerp(p0, p1, t);
        Vector3 b = Mathf.Lerp(p1, p2, t);
        Vector3 c = Mathf.Lerp(p2, p3, t);
        Vector3 d = Mathf.Lerp(a, b, t);
        Vector3 e = Mathf.Lerp(b, c, t);
        Vector3 pointOnCurve = Lerp(d, e, t);

        return pointOnCurve;
    }*/

    public Vector2 move(float t)
    {

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
}
