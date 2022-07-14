using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataManager : MonoBehaviour
{

    //Player 
    public static int Life = 3;
    public static int Spell = 3;

    public static uint Score = 0;
    public static uint HighScore = 0;
    public static float Power = 0.0f;
    public GameObject gameover;

    void Start()
    {
        
    }

    
    void Update()
    {
        
        if (Life == 0)
            gameover.SetActive(true);
    }
}
