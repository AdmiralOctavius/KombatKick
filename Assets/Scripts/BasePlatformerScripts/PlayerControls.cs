using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5;
    Vector2 respawnPoint;

	void Start ()
    {
        Globals.playerObject = gameObject;//4th way to reference a gameobject from another - have the gameobject tell the other one about itself instead of vice versa
        respawnPoint = transform.position;
	}

    void Update()//More responsive - checks our input each frame
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (transform.position.y <= -10)
        {
            rb.velocity = Vector2.zero;
            transform.position = respawnPoint;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check if we are on the ground right now
            GameObject feet = transform.GetChild(0).gameObject;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .5f);
            foreach (Collider2D col in colliders)
            {
                //Don't jump off ourselves
                if (col.gameObject != this.gameObject)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);//Ignore previous falling velocity so we jump the full amount each time.
                                        
                    rb.AddForce(Vector2.up * 600);

                    break;
                }
            }
        }
    }
	
	void FixedUpdate ()
    {
        //Handle left and right movement
        float movement = Input.GetAxis("Horizontal") * speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(movement, rb.velocity.y, 0);       
	}
}
