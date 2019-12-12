using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movelevels : MonoBehaviour
{
    [SerializeField] private string newLevel;

    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel );
        }
    }

}
