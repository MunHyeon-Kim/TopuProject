using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lobby : MonoBehaviour
{

    public GameObject settingPennel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("nomal_stage1");
    }

    public void Settings()
    {
        settingPennel.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }
}
