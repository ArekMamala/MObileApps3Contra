using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // == public fields ==
    // == private fields ==
    [SerializeField]
    private float moveSpeed = 7.0f;
    private bool facingRight = true;

    public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;
    public float checkradious;
    public GameObject heart1, heart2, heart3, heart4;
    private Rigidbody2D rb;
    public Joystick joystick;
    

    //rb = GetComponent<Rigidbody2D>();
    public int health = 100;
    public GameObject deathEffect;
    //start method
    void Start()
    {
        health = 100;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        heart4.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        MovJoystick();
        //transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run
        if (Input.GetKeyDown(KeyCode.W))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            // GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3), ForceMode2D.Impulse);

        }
        
    }

    public void MovJoystick(){

        //joystick
        var deltaX = joystick.Horizontal * Time.deltaTime * moveSpeed;

        //joystick
        var deltaY = joystick.Vertical * Time.deltaTime * moveSpeed;
        

        if (facingRight == false && deltaX > 0 ) //|| deltaX1 > 0))
        {
            Flip();
        }
        else if (facingRight == true && deltaX < 0) // || deltaX1 < 0 ))
        {
            Flip();
        }

        // add the change to the current position
        var newXPos = transform.position.x + deltaX;
       // var newXPos = transform.position.x + deltaX1;
        
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);


    }
    private void Move()
    {
        // find the change signal from the keyboard/input device
        // create a value for the change
        // Time.deltaTime - frame rate independent - same experience
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


       //joystick
        //var deltaX = joystick.Horizontal * Time.deltaTime * moveSpeed;

        //joystick
        //var deltaY = joystick.Vertical * Time.deltaTime * moveSpeed;
        

        if (facingRight == false && deltaX > 0 ) //|| deltaX1 > 0))
        {
            Flip();
        }
        else if (facingRight == true && deltaX < 0) // || deltaX1 < 0 ))
        {
            Flip();
        }

        // add the change to the current position
        var newXPos = transform.position.x + deltaX;
       // var newXPos = transform.position.x + deltaX1;
        
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);

    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void takeDamage(int damage)
    {
        if (gameObject != null)
        {
            health -= damage;
            switch (health)
            {
                case 100:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(true);
                    break;
                case 75:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(false);
                    break;
                case 50:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    break;
                case 25:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    break;
                case 0:
                    heart1.gameObject.SetActive(false);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    Die();
                    break;


                    // Do something  
            }

        }

        if (health <= 0 && gameObject != null)
        {
            Die();
        }

    }


    public void gainLives(int damage)
    {
        health += damage;
        switch (health)
        {
            case 100:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                break;
            case 75:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(false);
                break;
            case 50:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                break;
            case 25:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                Die();
                break;

        }

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        if (gameObject == null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }   //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void savePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPLayer();
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;


    }

}
