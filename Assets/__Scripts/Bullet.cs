using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed =20f;
    public int damage = 25;
    //public Rigidbody2D rb;
    
    float moveSpeed = 7f;

	public Rigidbody2D rb;

	PlayerMovement target;
	Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.velocity = transform.right * speed;
        target = GameObject.FindObjectOfType<PlayerMovement>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement enemy = hitInfo.GetComponent<PlayerMovement>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);

        if (hitInfo.gameObject.name.Equals ("playerCharacter")) {
			Debug.Log ("Hit!");
			Destroy (gameObject);
	}
    }

  
}
