using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    [SerializeField] private string newLevel;

    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            Pause();


        }
    }
      void Pause(){
         pauseMenuUI.SetActive(true);
         Time.timeScale = 0f;
         GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
