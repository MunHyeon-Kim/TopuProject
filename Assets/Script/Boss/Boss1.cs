using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss1 : MonoBehaviour
{
    public static bool bossStart = false;
    public int oneShoting = 40;
    public float speed = 10.0f;
    public GameObject Boss;
    public static GameObject player;
    public GameObject image;
    public GameObject EndGame;

    [SerializeField]
    GameObject Tan;
    [SerializeField]
    GameObject Tan2;
    [SerializeField]
    GameObject B1;
    [SerializeField]
    GameObject B2;
    [SerializeField]
    GameObject B3;
    [SerializeField]
    GameObject B4;

    [SerializeField]
    Text text;
    public int phase = 0; // 12345

    public static int Hp1 = 100000000;
    int MaxHp = 1000;

    public Slider hpbar;
    public Slider hpbar2;

    public GameObject uI;

    PlayerStat stat;


    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(Boss, iTween.Hash("path", iTweenPath.GetPath("Boss1"), "easetype", iTween.EaseType.linear, "time", 5.0f));

        uI.SetActive(true);
        
        stat = player.gameObject.GetComponent<PlayerStat>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bossStart)
        {
            StartCoroutine(InBoss(1));

            phase = 1;

            bossStart = false;
        }

        if (phase == 1 || phase == 3)
            Hpbar();
        else
            Hpbar2();

    }
    //스펠, 이동, hp, 점수

    IEnumerator Image() {
        int counter = 0;
        while (true)
        {
            counter++;

            image.SetActive(true);

            if (counter == 2)
            {
                image.SetActive(false);
                break;
            }

            yield return new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator InBoss(int phas)
    {
        int bossCounter = 60;

        switch (phas)
        {
            case 1:
                bossCounter = 60;
                StartCoroutine(Simple1());
                Hp1 = 1000;
                break;
            case 2:
                bossCounter = 60;
                StopCoroutine(Simple1());
                StartCoroutine(Image());
                StartCoroutine(IcycallPoll());
                Hp1 = 1000;
                break;
            case 3:
                bossCounter = 60;
                StopCoroutine(IcycallPoll());
                StopCoroutine(SpellStart());
                StartCoroutine(Simple1());
                Hp1 = 1000;
                break;
            case 4:
                bossCounter = 60;
                StopCoroutine(Simple1());
                StartCoroutine(Image());
                StartCoroutine(Diamondfreeze());
                Hp1 = 1000;
                break;
            default:
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

    void Hpbar2()
    {

        if (Hp1 <= 0)
        {
            hpbar2.value = 0;
            return;
        }

        hpbar2.value = (float)Hp1 / (float)MaxHp;
    }
    void PhaseDeath()
    {
        if (phase == 1)
        {
            hpbar.value = 0;
            hpbar2.value = 1;
        }

        if (phase == 2)
        {
            hpbar.value = 1;
            hpbar2.value = 1;
        }

        if (phase == 3)
        {
            hpbar.value = 0;
            hpbar2.value = 1;
        }


        //점수 계산 {}
        if (phase == 4)
        {
            //stage1 end
            hpbar.gameObject.SetActive(false);
            hpbar2.gameObject.SetActive(false);
            Destroy(this.gameObject);
            EndGame.SetActive(true);
        }
        /*if (phase == 1 || phase == 3)
            hpbar.gameObject.SetActive(false);
        else
            hpbar.gameObject.SetActive(true);*/

        phase++;
        StartCoroutine(InBoss(phase));
    }
        

    IEnumerator Simple1()
    {
        int oneshoot = 3;
        int count = 1;
        while (true)
        {
            if (phase == 1 || phase == 3)
            { }
            else
                break;

            if (count%22 < 15)
            for (int i = 1; i <= oneshoot; i++)
            {
                GameObject obj;
                obj = (GameObject)Instantiate(Tan, transform.position, Quaternion.identity);
                obj.transform.Rotate(0, 0, i*30+120);
            }

            if (count % 22 > 15)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject obj2;
                    obj2 = (GameObject)Instantiate(Tan, transform.position, Quaternion.identity);
                    Vector2 direction = new Vector2(
                        transform.position.x - player.transform.position.x,
                        transform.position.y - player.transform.position.y
            );

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
                    Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, 10000.0f);
                    obj2.transform.rotation = rotation;
                    obj2.transform.Rotate(0, 0, 180.0f);
                }
            }
            



            count++;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        
    }

    

    IEnumerator IcycallPoll()
    {
        StartCoroutine(SpellStart());
        //iTween.MoveTo(Boss, iTween.Hash("path", iTweenPath.GetPath("Boss2"), "easetype", iTween.EaseType.linear, "time", 5.0f));

        int counter = 0;
        GameObject[] tan;
        tan = new GameObject[4];
        while (true)
        {
            if (phase != 2)
                break;

            tan[0] = Instantiate(B1, transform.position, Quaternion.identity);
            tan[1] = Instantiate(B2, transform.position, Quaternion.identity);
            tan[2] = Instantiate(B3, transform.position, Quaternion.identity);
            tan[3] = Instantiate(B4, transform.position, Quaternion.identity);




            counter++;

            yield return new WaitForSecondsRealtime(1.0f);
        }
    }
    IEnumerator Diamondfreeze()
    {
        // 치르노의 현재 위치 주변에서 생성점을 무작위 생성 

        // 생성점에서 무작위 방향 사출 

        // 사출되고 일정시간이되면 프리즈

        // 프리즈가 풀리고 랜덤 방향 재이동 

        //반복 
        int counter = 0;
        int oneshoot = 20;

        float angle = 360 / oneshoot;

        do
        {
            if (phase != 4)
                break;
            
            for (int j = 0; j < 12; j++)
            {
                System.Random rand = new System.Random();
                Vector2 setPosition = new Vector2(this.transform.position.x + (float)rand.NextDouble() * 3 - 1.5f, this.transform.position.y + (float)rand.NextDouble() * 2 - 1.5f);
                System.Random rand2 = new System.Random();
                for (int i = 0; i < oneshoot; i++)
                {
                    
                    GameObject obj;
                    obj = (GameObject)Instantiate(Tan2, setPosition , Quaternion.identity);

                    //보스의 위치에 bullet을 생성합니다.
                    /*obj.GetComponent<Rigidbody2D>().AddForce
                        (new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneshoot),
                        speed * Mathf.Sin(Mathf.PI * i * 2 / oneshoot)));*/


                    obj.transform.Rotate(0,0, (360 * i / oneshoot - 90) + (float)rand2.NextDouble() * 500);
                    
                }
                
                yield return new WaitForSecondsRealtime(0.3f);
            }

            if (counter == 3 || counter == 6 || counter == 9 || counter == 12)
            {
                B_Circle.freezing = true;
            }

            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

            counter += 3;

            yield return new WaitForSecondsRealtime(3.0f);
        } while (true);

    }
    IEnumerator SpellStart()
    {
        float angle = 360 / oneShoting;

        do
        {
            for (int j = 0; j < 2; j++)
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
                yield return new WaitForSecondsRealtime(0.3f);
            }

            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

            yield return new WaitForSecondsRealtime(3.0f);
        } while (true);

    }

    // 적 캐릭터와 자기 캐릭터의 위치 관계 (각도)를 취득 
    public float GetAim()
    {
        float dx = player.transform.position.x - transform.position.x;
        float dy = player.transform.position.y - transform.position.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }

    IEnumerator _Update2()
    {
        float baseDirection = GetAim();
        int count = 0;
        while (true)
        {


            // 짝수 탄용 느낌으로, 자기 캐릭터 각도를 분리 상하 3 개씩 0.05 초마다 총알 발사 
            for (int index = -3; index < 3; index++)
            {
                GameObject obj;
                Rigidbody2D temp;

                // 새장 중심 각도를 설정합니다. 첫 번째 자기 캐릭터 각도를 중심으로 +30도 ~ -30도 범위를 흔들 흔들 움직이는 
                float dir = baseDirection + Mathf.Sin(count * Mathf.Deg2Rad) * 30.0f;
                obj = (GameObject)Instantiate(Tan, transform.position, Quaternion.identity);
                temp = obj.GetComponent<Rigidbody2D>();
                Vector2 ToPlayerDir = new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);

                temp.AddForce(ToPlayerDir.normalized * 3.0f);
                obj.transform.Rotate(0, 0, dir + index * 30 - 90);

                //Bullet.Add(transform.position.x, transform.position.y, dir + index * 30 + 15, 3);
            }
            yield return new WaitForSeconds(0.05f);
            count++;
        }
    }
    //새장탄
    IEnumerator _Update3()
    {
        float baseDirection = GetAim();
        int count = 0;
        int rad = 0;
        while (true)
        {


                GameObject obj;
                Rigidbody2D temp;

                obj = (GameObject)Instantiate(Tan, transform.position, Quaternion.identity);
                temp = obj.GetComponent<Rigidbody2D>();
                Vector2 ToPlayerDir = new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);

                temp.AddForce(ToPlayerDir.normalized * 1.0f);
                obj.transform.Rotate(0, 0, rad);

            rad += 8;

            yield return new WaitForSeconds(0.05f);
            count++;
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (phase == 0)
        { 
        }
        else
            Hp1 -= 10;
        if (Hp1 < 0)
        {
            Hp1 = 1000;
            PhaseDeath();
        }
    }
}
