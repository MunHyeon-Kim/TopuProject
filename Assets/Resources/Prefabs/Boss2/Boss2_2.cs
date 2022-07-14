using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss2_2 : MonoBehaviour
{
    public static bool bossStart = true;
    public int oneShoting = 10;
    public float speed = 10.0f;
    public GameObject Boss;
    public static GameObject player;

    [SerializeField]
    GameObject Tan;
    [SerializeField]
    GameObject Tan2;

    [SerializeField]
    Text text;
    public int phase = 1; // 12345

    public static int Hp1 = 1000;
    int MaxHp = 1000;

    public Slider hpbar;
    public Slider hpbar2;

    public GameObject uI;

    PlayerStat stat;


    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(Boss, iTween.Hash("path", iTweenPath.GetPath("Boss2-2"), "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop, "time", 12.0f));

        uI.SetActive(true);

        stat = player.gameObject.GetComponent<PlayerStat>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bossStart)
        {
            StartCoroutine(InBoss(1));



            bossStart = false;
        }

        if (phase == 1)
            Hpbar();

    }
    //스펠, 이동, hp, 점수



    IEnumerator InBoss(int phas)
    {
        int bossCounter = 60;

        switch (phas)
        {
            case 1:
                StartCoroutine(SpellStart());
                Hp1 = 1000;
                break;
        }


        while (true)
        {
            text.text = $"{bossCounter}";
            bossCounter--;
            if (bossCounter < 0)
                break;
            if (Hp1 < 0)
                break;

            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    void Hpbar()
    {

        if (Hp1 <= 0)
        {

            hpbar.value = 0;
            return;
        }

        hpbar.value = (float)Hp1 / (float)MaxHp;
    }

    
    void PhaseDeath()
    {

        hpbar.value = 1;
        hpbar2.value = 1;

        phase++;

        //점수 계산 {}
        if (phase == 2)
        {
            //stage1 end
            uI.SetActive(false);
            // Zako part2 start
            Destroy(this.gameObject);
        }
        /*if (phase == 1 || phase == 3)
            hpbar.gameObject.SetActive(false);
        else
            hpbar.gameObject.SetActive(true);*/

        
        StartCoroutine(InBoss(phase));
    }


    IEnumerator SpellStart()
    {
        float angle = 360 / oneShoting;

        int counter = 0;

        

            do
            {
            if (counter == 12)
            {

                counter = 0;
                Bullet2.start = true;

            }

            if (counter == 3)
                Bullet2.start = false;


            if (counter != 0 && counter != 1 && counter != 2)
            {
                for (int i = 0; i < oneShoting; i++)
                {

                    GameObject obj;
                    obj = (GameObject)Instantiate(Tan, this.transform.position, Quaternion.identity);

                    //보스의 위치에 bullet을 생성합니다.
                    obj.GetComponent<Rigidbody2D>().AddForce
                        (new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting),
                        speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));


                    obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting - 90));
                }
            }
              
            
            
            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

            counter++;

            yield return new WaitForSecondsRealtime(1.0f);
        } while (true);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hp1 -= 10;
        if (Hp1 < 0)
        {
            Hp1 = 1000;
            PhaseDeath();
        }
    }
}
