using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("HouseOutside");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
