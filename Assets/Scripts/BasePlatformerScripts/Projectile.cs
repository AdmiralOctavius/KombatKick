using UnityEngine;

public class Projectile : MonoBehaviour
{
    //GameObject player;
    public bool leftR;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update ()
    {
        if (leftR)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * 10;

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * 10 * -1;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Laser")
        {

        }
        else
        {
            //Destroy(col.gameObject);
            //Destroy(gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser")
        {

        }
        else
        {
            //Destroy(col.gameObject);
            //Destroy(gameObject);

        }
    }
}
