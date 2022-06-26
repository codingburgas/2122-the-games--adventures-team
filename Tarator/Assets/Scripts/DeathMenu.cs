using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            deathMenuUI.SetActive(true);
        }
    }

    public void Restart()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
    }
}
