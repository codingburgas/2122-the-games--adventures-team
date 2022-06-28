using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        WinMenuUI.SetActive(true);
    }

    public void Restart()
    {
        WinMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("StartMenu");
    }
}
