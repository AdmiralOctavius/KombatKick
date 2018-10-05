using UnityEngine;

public class KatControls: MonoBehaviour
{
    public float speed = 5;
    Vector2 respawnPoint;

    private string spriteNames = "KombatKatSheet";
    private int spriteVersion = 0;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private bool inJump;
    private float jumpSpeed = .5233f;
    private float jumpDecay = .04f;
    private float noHoldSpeed = .1f;
    private float fallSpeed = -.06f;
    private bool recentJump = false;
    private int jumpIterator = 0;
    private bool isFalling;
    public bool doubleJump = false;
    public Sprite spr_neutral;
    public Sprite spr_jump;
    public AudioSource playerSound;

    public AudioClip gunSound;
    public AudioClip jumpSound;

    public GameObject laserPrefab;

    void Start ()
    {
        Globals.playerObject = gameObject;//4th way to reference a gameobject from another - have the gameobject tell the other one about itself instead of vice versa
        respawnPoint = transform.position;

        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(spriteNames);

        spr_neutral = gameObject.GetComponent<SpriteRenderer>().sprite;

        Debug.Log(sprites.ToString());
        inJump = false;
        isFalling = false;
	}

    void Update()//More responsive - checks our input each frame
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

      /*  if(rb.velocity.y < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spr_neutral;

        }*/
        
            
   

        if (transform.position.y <= -10)
        {
            rb.velocity = Vector2.zero;
            transform.position = respawnPoint;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
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

                    playerSound.Play();

                    this.gameObject.GetComponent<SpriteRenderer>().sprite = spr_jump;
                    break;
                }
            }
        }*/

    }
	
	void FixedUpdate ()
    {
        Transform position = GetComponent<Transform>();
        Vector3 jumpStart;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(laserPrefab, transform.GetChild(1).position, transform.rotation);
            playerSound.PlayOneShot(gunSound);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inJump == false)
            {
                jumpStart = this.GetComponent<Transform>().position;
                transform.position = new Vector3(transform.position.x, transform.position.y + (jumpSpeed), 0);
                inJump = true;
                jumpIterator = 1;

                playerSound.PlayOneShot(jumpSound);

                this.gameObject.GetComponent<SpriteRenderer>().sprite = spr_jump;
                recentJump = true;
                doubleJump = true;
            }
            else if(doubleJump == true)
            {

                jumpStart = this.GetComponent<Transform>().position;
                transform.position = new Vector3(transform.position.x, transform.position.y + (jumpSpeed), 0);
                inJump = true;
                jumpIterator = 1;

                playerSound.PlayOneShot(jumpSound);

                this.gameObject.GetComponent<SpriteRenderer>().sprite = spr_jump;
                recentJump = true;
                doubleJump = false;
            }
            else
            {
              
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {

            if (inJump && recentJump == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (jumpSpeed - (jumpDecay * jumpIterator)), 0);
                
                jumpIterator++;
            }
            else
            {
                
                //transform.position = new Vector3(transform.position.x, transform.position.y + (jumpSpeed - (jumpDecay * jumpIterator)), 0);
                jumpIterator++;
                recentJump = false;
            }
            //GameObject feet = transform.GetChild(0).gameObject;
            //Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .5f);
            //foreach (Collider2D col in colliders)
            //{
                //Don't jump off ourselves
             //   if (col.gameObject != this.gameObject)
             //   {
                    
            //    }

            //}


        }
        else
        {

            if (inJump)
            {
                if(-(jumpDecay * jumpIterator) < fallSpeed)
                {
                    //Supposed to be a cap on fall speed
                    //transform.position = new Vector3(transform.position.x, transform.position.y + fallSpeed, 0);
                    transform.position = new Vector3(transform.position.x, transform.position.y + (noHoldSpeed - (jumpDecay * jumpIterator)), 0);
                    jumpIterator++;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + (noHoldSpeed - (jumpDecay * jumpIterator)), 0);
                    jumpIterator++;

                }
               
            }
        }
        

        GameObject feet = transform.GetChild(0).gameObject;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .005f);
        RaycastHit2D footRay = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.005f);
        if (footRay.collider == null && inJump == false)
        {
            if(isFalling == false)
            {
                jumpIterator = 0;
            }
            
            transform.position = new Vector3(transform.position.x, transform.position.y + (noHoldSpeed - (jumpDecay * jumpIterator)), 0);
            jumpIterator++;
            isFalling = true;
        }

        foreach (Collider2D col in colliders)
        {
            //Debug.Log("Got here");

            //Don't jump off ourselves
            if (col.gameObject != this.gameObject)
            {
                inJump = false;
                jumpIterator = 0;
                isFalling = false;
                doubleJump = false;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spr_neutral;
                break;
            }

        }
      

        //Handle left and right movement
        float movement = Input.GetAxis("Horizontal") * speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(movement, rb.velocity.y, 0);    
        
	}
}
