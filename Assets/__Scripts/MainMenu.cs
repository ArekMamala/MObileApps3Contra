using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PLayGame(){
        Debug.Log("game Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);     
    }    

    public void PLayEasyGame(){
        Debug.Log("game Scene");
            SceneManager.LoadScene("Level1" );
    }    

    
    public void PLayMediumGame(){
        Debug.Log("game Scene");
            SceneManager.LoadScene("Level2" );
    }    

    public void PLayHardGame(){
        Debug.Log("game Scene");
            SceneManager.LoadScene("Level3" );
    }    
    
    

     public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }    

}
