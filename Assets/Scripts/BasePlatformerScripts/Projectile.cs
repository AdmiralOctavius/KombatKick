using UnityEngine;

public class Projectile : MonoBehaviour
{
    //GameObject player;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * 10;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
