using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerBullet : MonoBehaviour
{

    public float speed =20f;
    public Rigidbody2D rb;
    public int damage = 25;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
		Debug.Log (hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }

			Destroy (gameObject);
	    
    }
}
