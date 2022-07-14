using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Zako2;
    [SerializeField]
    GameObject Zako3;

    [SerializeField]
    GameObject Boss;

    [SerializeField]
    GameObject power;
    [SerializeField]
    GameObject point;
    [SerializeField]
    GameObject Spell;
    [SerializeField]
    GameObject Life;


    Stat _stat;

    void Init()
    {
        _stat = gameObject.GetComponent<Stat>();
        switch (_stat.number)
        {
            case 1:
                iTween.MoveTo(Zako2, iTween.Hash("path", iTweenPath.GetPath("Zako"), "easetype", iTween.EaseType.linear, "time", 10.0f));
                break;
            case 2:
                iTween.MoveTo(Zako3, iTween.Hash("path", iTweenPath.GetPath("Zako2"), "easetype", iTween.EaseType.linear, "time", 10.0f));
                break;
            default:
                break;
        }

    }


    void Start()
    {
        Init();
        //StartCoroutine(ChaseSpreadShot());
        StartCoroutine(Chase5());
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
        switch (_stat.number)
        {
            case 1:
                PointCreate(Zako2);
                Destroy(Zako2);
                break;
            case 2:
                PointCreate(Zako3);
                Destroy(Zako3);
                break;
            default:
                break;
        }
        
        //Zako2.SetActive(false); // ¿¢Æ¼º£ÀÌÆ® false??
    }


    void PointCreate(GameObject zako)
    {
        GameObject power2 = GameObject.Instantiate(power);
        GameObject point2 = GameObject.Instantiate(point);
        GameObject bumb2 = GameObject.Instantiate(Spell);
        GameObject Life2 = GameObject.Instantiate(Life);
        power2.transform.position = new Vector2(zako.transform.position.x, zako.transform.position.y);
        point2.transform.position = new Vector2(zako.transform.position.x + 1, zako.transform.position.y);
        bumb2.transform.position = new Vector2(zako.transform.position.x - 1, zako.transform.position.y);
        Life2.transform.position = new Vector2(zako.transform.position.x - 2, zako.transform.position.y);
    }
    
    IEnumerator Chase()
    {
        while (true)
        {
            if (Player != null)
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
                obj.transform.Rotate(0, 0, digree+90.0f);

                yield return new WaitForSecondsRealtime(0.5f);
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


                    Vector2 ToPlayerDir = new Vector2(Player.transform.position.x, Player.transform.position.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);

                    temp.AddForce(ToPlayerDir.normalized * _stat._Speed);
                    digree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    obj.transform.Rotate(0, 0, digree + 80.0f + (float)i * 5);
                }



                yield return new WaitForSecondsRealtime(0.5f);
            }
            else
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Enter{_stat._hp}");
        _stat._hp -= 100;
    }

}
