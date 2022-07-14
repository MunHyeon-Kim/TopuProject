using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    public static GameObject Player;

    public GameObject this_zako;
    public int oneShoting = 90;

    public int number;
    [SerializeField]
    GameObject this_zako2;

    Stat _stat;

    void Init()
    {

        _stat = gameObject.GetComponent<Stat>();
        StartCoroutine(shot(number));
        iTween.MoveTo(this_zako, iTween.Hash("path", iTweenPath.GetPath($"fairy{number}_1"), "easetype", iTween.EaseType.linear, "time", 2.0f));
    }

    IEnumerator shot(int number)
    {
        int k = 0;

        while (true) {
            
            if (k == 2)
            {
                StartCoroutine(SpellStart());
                
            }
            if(k == 3)
                StartCoroutine(Chase5());

            if (k == 8)
            {
                iTween.MoveTo(this_zako, iTween.Hash("path", iTweenPath.GetPath($"fairy{number}_2"), "easetype", iTween.EaseType.linear, "time", 2.0f));
                break;
            }

            k++;

            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    IEnumerator shot2()
    {
        int k = 0;
        
        while (true)
        {
            if (k == 0)
                iTween.MoveTo(this_zako, iTween.Hash("path", iTweenPath.GetPath("fairy2_1"), "easetype", iTween.EaseType.linear, "time", 2.0f));

            if (k == 2)
            {
                StartCoroutine(SpellStart());

            }
            if (k == 3)
                StartCoroutine(Chase5());

            if (k == 14)
            {
                iTween.MoveTo(this_zako, iTween.Hash("path", iTweenPath.GetPath("fairy2_2"), "easetype", iTween.EaseType.linear, "time", 2.0f));
                break;
            }

            k++;

            yield return new WaitForSecondsRealtime(1.0f);
        }
    }


    void Start()
    {
        Init();
    }


    void Update()
    {
        if (_stat._hp < 0)
        {
            Death();
        }
    }

    void Death()
    {
        PointCreate();
        Destroy(this_zako);

        //Zako2.SetActive(false); // 엑티베이트 false??
    }


    void PointCreate()
    {
        Stage1Manager stage1Manager = new Stage1Manager();

        stage1Manager.PointCreate(this_zako);
    }

    IEnumerator Chase()
    {
        while (true)
        {
            if (Player != null)
            {
                yield return new WaitForSecondsRealtime(5.0f);
                GameObject obj;
                Rigidbody2D temp;
                float digree;

                Vector2 direction = new Vector2(
                    transform.position.x - Player.transform.position.x,
                    transform.position.y - Player.transform.position.y
                );

                obj = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);

                temp = obj.GetComponent<Rigidbody2D>();


                Vector2 ToPlayerDir = new Vector2(Player.transform.position.x, Player.transform.position.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);

                temp.AddForce(ToPlayerDir.normalized * _stat._Speed);
                digree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                obj.transform.Rotate(0, 0, digree + 90.0f);


            }

        }
    }
    IEnumerator Chase_rand()
    {
        while (true)
        {
            if (Player != null)
            {
                System.Random rand = new System.Random();

                float waitTime = (float)rand.NextDouble() * 6;
                Debug.Log($"time{waitTime}");
                yield return new WaitForSecondsRealtime(waitTime);
                GameObject obj;
                Rigidbody2D temp;
                float digree;

                Vector2 direction = new Vector2(
                    transform.position.x - Player.transform.position.x,
                    transform.position.y - Player.transform.position.y
                );

                obj = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);

                temp = obj.GetComponent<Rigidbody2D>();


                Vector2 ToPlayerDir = new Vector2(Player.transform.position.x, Player.transform.position.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);

                temp.AddForce(ToPlayerDir.normalized * _stat._Speed);
                digree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                obj.transform.Rotate(0, 0, digree + 90.0f);


            }

        }
    }
    IEnumerator Chase5()
    {
        int k = 1;

        while (k<6)
        {


            if (Player != null)
            {

                

                for (int i = 0; i < k; i++)
                {
                    GameObject obj;
                    Rigidbody2D temp;
                    float digree;

                    Vector2 direction = new Vector2(
                        transform.position.x - Player.transform.position.x,
                        transform.position.y - Player.transform.position.y
                    );

                    obj = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);

                    temp = obj.GetComponent<Rigidbody2D>();

                    Debug.Log($"dd{Player.transform.position.x}");
                    Vector2 ToPlayerDir = new Vector2(Player.transform.position.x, Player.transform.position.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);

                    temp.AddForce(ToPlayerDir.normalized * 5000.0f);
                    digree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    obj.transform.Rotate(0, 0, digree + 80.0f + (float)i * 5);
                }

                k++;

                yield return new WaitForSecondsRealtime(0.1f);
            }
            else
                break;

        }
    }

    IEnumerator SpellStart()
    {
        float angle = 360 / oneShoting;

        do
        {

            for (int i = 0; i < oneShoting; i++)
            {
                Debug.Log(i);
                GameObject obj;
                obj = (GameObject)Instantiate(bullet, this.transform.position, Quaternion.identity);

                //보스의 위치에 bullet을 생성합니다.
                obj.GetComponent<Rigidbody2D>().AddForce
                    (new Vector2(5 * Mathf.Cos(Mathf.PI * 2 * i / oneShoting),
                    5 * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));


                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting - 90));
            }



            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

            yield return new WaitForSecondsRealtime(3000.0f);
        } while (true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Enter{_stat._hp}");
        _stat._hp -= 50;
    }

    void OnBecameInvisible()
    {

        Destroy(this.gameObject);

    }
}
