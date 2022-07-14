using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    public GameObject escMenu;
    public int mode = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                
                Time.timeScale = 0;
                escMenu.SetActive(true);
            }
        }
    }
    public void backGame() {
        escMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void regame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("nomal_stage1");
    }

    public void Title() {
        SceneManager.LoadScene("Lobby");

    }

    public void Exit() {
        Time.timeScale = 1;
        Application.Quit();
    }

}
