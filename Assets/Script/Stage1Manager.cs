using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Manager : MonoBehaviour
{
    
    public GameObject zako1;
    public GameObject zako3;
    public GameObject Boss;

    public GameObject Player;

    public GameObject startText;

    public bool fd = false;



    public GameObject[] _thiszako;
    GameObject _thiszako2;
    GameObject middleBoss;
    public GameObject[] _fairy;
    public static int pase = 1;
    [SerializeField]
    int _counter = 60;
    int _counter2 = 0;
    public int bossTimer = 40;

    [SerializeField]
    GameObject convers;


    [SerializeField]
    GameObject power;
    [SerializeField]
    GameObject point;
    [SerializeField]
    GameObject Spell;
    [SerializeField]
    GameObject Life;

    private void Awake()
    {
        zako2.number = 1;
        Boss1.Hp1 = 1000000000;
        DataManager.Life = 3;
        DataManager.Spell = 3;

        DataManager.Score = 0;
        DataManager.HighScore = 0;
        DataManager.Power = 0.0f;
}

    void Start()
    {
        


        StartCoroutine(Stage());
        _thiszako = new GameObject[90];
        _fairy = new GameObject[6];
        for (int i = 0; i < 90; i++)
        {
            _thiszako[i] = Instantiate(Resources.Load<GameObject>($"Prefabs/zako/zako1/zako2 ({i+1})"));
        }

        for (int i = 0; i < 6; i++)
        {
            _fairy[i] = Instantiate(Resources.Load<GameObject>($"Prefabs/zako/Fairy/fairy ({i+1})"));

        }


        Player = Instantiate(Resources.Load<GameObject>($"Prefabs/Charactor"));
        Player.transform.position = new Vector2(-7.0f, -7.0f);
        zako2.Player = Player;
        Fairy.Player = Player;
        Boss1.player = Player;
    }

    
   

   

    void InBoss()
    {
        Boss.SetActive(true);

    }

    IEnumerator zako_1()
    {
        
        
        while (_counter2 < 10)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;
            

            yield return new WaitForSecondsRealtime(0.2f);
        }


    }

    IEnumerator zako_2()
    {

        Debug.Log($"_counter2{_counter2}");
        while (_counter2 < 30)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;


            yield return new WaitForSecondsRealtime(0.4f);
        }


    }

    IEnumerator zako_3()
    {

        Debug.Log($"_counter2{_counter2}");
        while (_counter2 < 40)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;


            yield return new WaitForSecondsRealtime(0.5f);
        }


    }

    IEnumerator zako_4()
    {

        Debug.Log($"_counter2{_counter2}");
        while (_counter2 < 51)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;


            yield return new WaitForSecondsRealtime(0.5f);
        }


    }

    IEnumerator zako_5()
    {

        Debug.Log($"_counter2{_counter2}");
        while (_counter2 < 60)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;


            yield return new WaitForSecondsRealtime(0.5f);
        }


    }

    IEnumerator zako_6()
    {

        Debug.Log($"_counter2{_counter2}");
        while (_counter2 < 70)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;


            yield return new WaitForSecondsRealtime(0.5f);
        }


    }

    IEnumerator zako_7()
    {

        Debug.Log($"_counter2{_counter2}");
        while (_counter2 < 80)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;


            yield return new WaitForSecondsRealtime(0.5f);
        }


    }
    IEnumerator zako_8()
    {

        Debug.Log($"_counter2{_counter2}");
        while (_counter2 < 90)
        {
            _thiszako[_counter2].SetActive(true);

            _counter2++;


            yield return new WaitForSecondsRealtime(0.5f);
        }


    }

    IEnumerator Stage()
    {
        while (true)
        {
            
            if (_counter == 59)
            {
                
                StartCoroutine(zako_1());
            }

            if (_counter == 50)
            {
                startText.SetActive(true);
               
            }


            if (_counter == 45)
            {
                startText.SetActive(false);
                StartCoroutine(zako_2());
            }
             
            if (_counter == 40)
            {
                _fairy[0].gameObject.SetActive(true);
                _fairy[1].gameObject.SetActive(true);
                //InBoss();
                //convers.SetActive(true);
            }

            if (_counter == 35)
            {
                StartCoroutine(zako_3());
            }

            if (_counter == 30)
            {
                StartCoroutine(zako_4());
            }

            if (_counter == 27)
            {
                StartCoroutine(zako_5());
            }

            if (_counter == 22)
            {
                _fairy[2].gameObject.SetActive(true);
            }
            if (_counter == 18)
            {
                StartCoroutine(zako_6());
            }

            if (_counter == 13)
            {
                StartCoroutine(zako_7());
            }

            if (_counter == 7)
            {
                StartCoroutine(zako_8());
            }

            if (_counter == -5)
            {
                convers.SetActive(true);
                InBoss();
            }


            if (_counter == 15)
            {
                _fairy[3].gameObject.SetActive(true);
                _fairy[4].gameObject.SetActive(true);
                _fairy[5].gameObject.SetActive(true);
            }

            _counter --;
            yield return new WaitForSecondsRealtime(1f);
        }
    }




    public void PointCreate(GameObject zako)
    {

        power = Instantiate(Resources.Load<GameObject>("Prefabs/Power"));
        point = Instantiate(Resources.Load<GameObject>("Prefabs/point"));
        //Spell = Instantiate(Resources.Load<GameObject>("Prefabs/Spell"));
        //Life = Instantiate(Resources.Load<GameObject>("Prefabs/up"));
        power.transform.position = new Vector2(zako.transform.position.x, zako.transform.position.y);
        point.transform.position = new Vector2(zako.transform.position.x + 1, zako.transform.position.y);
        /*Spell.transform.position = new Vector2(zako.transform.position.x - 1, zako.transform.position.y);
        Life.transform.position = new Vector2(zako.transform.position.x - 2, zako.transform.position.y);*/
    }

}


