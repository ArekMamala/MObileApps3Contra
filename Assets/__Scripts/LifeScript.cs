using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
        public int extraLive = 25;

    public void OnTrggerEnter2d(Collider2D col){

        PlayerMovement player = GetComponent<PlayerMovement>();
        player.health += 25;
        Destroy(gameObject);
        
    }
}
