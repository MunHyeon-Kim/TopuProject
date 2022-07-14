using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ouk : MonoBehaviour
{

    [SerializeField]
    GameObject DeathBullet;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    public static GameObject Player;

    public GameObject this_zako;
    [SerializeField]
    GameObject this_zako2;



    public int number;



    Stat _stat;

    void Init()
    {
        iTween.MoveTo(this_zako2, iTween.Hash("path", iTweenPath.GetPath($"Ouk{number}"), "easetype", iTween.EaseType.linear, "time", 12.0f));
        _stat = gameObject.GetComponent<Stat>();
        StartCoroutine(Oukshot());

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
        while (true)
        {
            if (Player != null)
            {
                for (int i = 0; i < 5; i++)
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



                yield return new WaitForSecondsRealtime(0.5f);
            }
            else
                break;

        }
    }

    IEnumerator Oukshot()
    {

        //반복 
        int counter = 0;
        int oneshoot = 20;

        float angle = 360 / oneshoot;

        do
        {

                System.Random rand2 = new System.Random();
                for (int i = 0; i < oneshoot; i++)
                {

                    GameObject obj;
                    obj = (GameObject)Instantiate(bullet, this.transform.position, Quaternion.identity);



                    obj.transform.Rotate(0, 0, (360 * i / oneshoot - 90) + (float)rand2.NextDouble() * 500);

                }


            yield return new WaitForSecondsRealtime(3.0f);
        } while (true);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Enter{_stat._hp}");
        _stat._hp -= 100;
    }

    void OnBecameInvisible()
    {

        Destroy(this.gameObject);

    }
}

