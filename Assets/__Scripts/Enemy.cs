using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // use later for other stuff
    // add the collider stuff, to detect if a bullet hits
    // detect the collisiion
    // destroy the bullet prefab, then this prefab

    public int health =100;
    public GameObject deathEffect;

    //enemy movement variables
    public float speed;
    public float stoppingDistance;
    public float reatreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;  
    public Transform player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    } 

    void Update(){
        if (gameObject != null)
        {
        if (player.position != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > reatreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else{
        }
            timeBtwShots -= Time.deltaTime;

        }
    }

    public void takeDamage(int damage )
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    private int scoreValue = 10;

}
