using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    public delegate void SpellClearHandler();

    public static event SpellClearHandler OnBulletClear;

    public static Charactor instance;
    public int shotmode = 1;
    public int shiftmode = 1;

    [SerializeField]
    GameObject Tan;
    [SerializeField]
    GameObject Player;

    private float _speed = 10.0f;
    private float _DelayTime = 0.05f;
    private bool isDelay=false;
    public static float speed = 10.0f;



    void Start()
    {
        
    }



    
    void Update()
    {

        

        if (DataManager.Power >= 0.0f && DataManager.Power < 1.0f)
        {
            shotmode = 1;
        }

        if (DataManager.Power >= 1.0f && DataManager.Power < 2.0f)
        {
            shotmode = 2;
        }

        if (DataManager.Power >= 2.0f && DataManager.Power < 3.0f)
        {
            shotmode = 3;
        }

        if (DataManager.Power >= 3.0f && DataManager.Power < 4.0f)
        {
            shotmode = 4;
        }

        input();
        if (transform.position.y < -9.8f)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 10.0f);
        }

        if (transform.position.y > -0.21f)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10.0f);
        }

        if (transform.position.x > -4.19f)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 10.0f);
        }

        if (transform.position.x < -11.87f)
        {
            transform.Translate(Vector2.right * Time.deltaTime * 10.0f);
        }
    }

    void input()
    {
        
        if (true)
        {
            if (!isDelay)
            {
                isDelay = true;
                if (shiftmode == 1)
                {
                    if (shotmode == 1)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        PlayerTan.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                    }
                    if (shotmode == 2)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        GameObject t2 = Instantiate(Tan);
                        PlayerTan.transform.position = new Vector2(this.transform.position.x + 0.2f, this.transform.position.y);
                        t2.transform.position = new Vector2(this.transform.position.x - 0.2f, this.transform.position.y);
                    }
                    if (shotmode == 3)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        GameObject t2 = Instantiate(Tan);
                        GameObject t3 = Instantiate(Tan);
                        GameObject t4 = Instantiate(Tan);
                        PlayerTan.transform.position = new Vector2(this.transform.position.x + 0.2f, this.transform.position.y);
                        t2.transform.position = new Vector2(this.transform.position.x - 0.2f, this.transform.position.y);
                        t3.transform.position = new Vector2(this.transform.position.x + 0.25f, this.transform.position.y - 0.05f);
                        t4.transform.position = new Vector2(this.transform.position.x - 0.25f, this.transform.position.y - 0.05f);
                        t3.transform.Rotate(0, 0, -30.0f);
                        t4.transform.Rotate(0, 0, 30.0f);
                    }
                    if (shotmode == 4)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        GameObject t2 = Instantiate(Tan);
                        GameObject t3 = Instantiate(Tan);
                        GameObject t4 = Instantiate(Tan);
                        GameObject t5 = Instantiate(Tan);
                        GameObject t6 = Instantiate(Tan);

                        PlayerTan.transform.position = new Vector2(this.transform.position.x + 0.2f, this.transform.position.y);
                        t2.transform.position = new Vector2(this.transform.position.x - 0.2f, this.transform.position.y);
                        t3.transform.position = new Vector2(this.transform.position.x + 0.25f, this.transform.position.y + 0.1f);
                        t4.transform.position = new Vector2(this.transform.position.x - 0.25f, this.transform.position.y + 0.1f);
                        t5.transform.position = new Vector2(this.transform.position.x + 0.3f, this.transform.position.y - 0.1f);
                        t6.transform.position = new Vector2(this.transform.position.x - 0.3f, this.transform.position.y - 0.1f);
                        t3.transform.Rotate(0, 0, -30.0f);
                        t4.transform.Rotate(0, 0, 30.0f);
                        t5.transform.Rotate(0, 0, -30.0f);
                        t6.transform.Rotate(0, 0, 30.0f);
                    }
                }
                else
                {

                    if (shotmode == 1)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        PlayerTan.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                    }
                    if (shotmode == 2)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        GameObject t2 = Instantiate(Tan);
                        PlayerTan.transform.position = new Vector2(this.transform.position.x + 0.2f, this.transform.position.y);
                        t2.transform.position = new Vector2(this.transform.position.x - 0.2f, this.transform.position.y);
                    }
                    if (shotmode == 3)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        GameObject t2 = Instantiate(Tan);
                        GameObject t3 = Instantiate(Tan);
                        GameObject t4 = Instantiate(Tan);
                        PlayerTan.transform.position = new Vector2(this.transform.position.x + 0.2f, this.transform.position.y);
                        t2.transform.position = new Vector2(this.transform.position.x - 0.2f, this.transform.position.y);
                        t3.transform.position = new Vector2(this.transform.position.x + 0.25f, this.transform.position.y - 0.05f);
                        t4.transform.position = new Vector2(this.transform.position.x - 0.25f, this.transform.position.y - 0.05f);
                    }
                    if (shotmode == 4)
                    {
                        GameObject PlayerTan = Instantiate(Tan);
                        GameObject t2 = Instantiate(Tan);
                        GameObject t3 = Instantiate(Tan);
                        GameObject t4 = Instantiate(Tan);
                        GameObject t5 = Instantiate(Tan);
                        GameObject t6 = Instantiate(Tan);

                        PlayerTan.transform.position = new Vector2(this.transform.position.x + 0.2f, this.transform.position.y);
                        t2.transform.position = new Vector2(this.transform.position.x - 0.2f, this.transform.position.y);
                        t3.transform.position = new Vector2(this.transform.position.x + 0.25f, this.transform.position.y + 0.1f);
                        t4.transform.position = new Vector2(this.transform.position.x - 0.25f, this.transform.position.y + 0.1f);
                        t5.transform.position = new Vector2(this.transform.position.x + 0.3f, this.transform.position.y - 0.1f);
                        t6.transform.position = new Vector2(this.transform.position.x - 0.3f, this.transform.position.y - 0.1f);
                    }

                }
                

                StartCoroutine(Delay());
            }
            else
            {

            }
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 4.0f;
            shiftmode = 2;

        }
        else {
            _speed = 10.0f;
            shiftmode = 1;
        }
            

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (DataManager.Spell <= 0)
                return;

            DataManager.Spell -= 1;

            if(OnBulletClear != null)
                OnBulletClear();
        }

        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
        }*/

        if (VirtualJoystic.isInput)
        {
            transform.Translate(VirtualJoystic.inputVector * Time.deltaTime * speed);

        }


    }

    public void Move(Vector3 vector)
    {
        transform.position += vector * Time.deltaTime * speed;
    }



    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(_DelayTime);
        isDelay = false;
    }
}
