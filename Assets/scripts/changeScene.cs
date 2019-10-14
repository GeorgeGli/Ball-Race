using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    public GameObject insPanel;
    public GameObject menuPanel;

    public void changeToScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("_MainScene");
     
    }
    public void changeToMenu()
    {

        SceneManager.LoadScene("_menu");
    }

    public void ClickExit()

    {
        Application.Quit();
    }



    public void ins() {

        insPanel.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);

    }

    public void back()
    {

        insPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);

    }
    



}
