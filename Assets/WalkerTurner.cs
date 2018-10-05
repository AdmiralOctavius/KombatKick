using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerTurner : MonoBehaviour {

    public bool chaserEnemy;
    public bool RightMove = true;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 5;

    public bool enemyShooter = false;
    public GameObject laserPrefab;
    public float fireRate = 1;
    float lastFireTime = float.MinValue;
    public AudioSource walkerSound;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       /* GameObject player = Globals.playerObject;
        if (Vector2.Distance(transform.position, player.transform.position) >= MinDist)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.forward,MaxDist);
            
            if(Physics2D.Raycast(transform.position, transform.forward, MaxDist))
            {
                    Debug.Log("Enemy sees player");
                if(ray.collider.gameObject.tag == "Player")
                {
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }

            }
            else
            {
                transform.position.Scale(new Vector3(transform.localScale.x * -1, 1, 1));
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
        }*/
    }

    void FixedUpdate()
    {

        //transform.position = new Vector2(transform.forward = + (MoveSpeed * Time.deltaTime), transform.position.y);
        //transform.forward = new Vector3(transform.position.x + (MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        if (RightMove)
        {

            transform.position = new Vector3(transform.position.x + (MoveSpeed * Time.deltaTime), transform.position.y,1);
        }
        else
        {

            transform.position = new Vector3(transform.position.x - (MoveSpeed * Time.deltaTime), transform.position.y, 1);
        }

        if (enemyShooter == true)
        {
            RaycastHit2D playercheck = Physics2D.Raycast(transform.position, transform.forward, 5f);
            if(Physics2D.Raycast(transform.position, transform.forward, 5f))
            {
                Instantiate(laserPrefab, transform.position, transform.rotation);
                lastFireTime = Time.time;

                walkerSound.Play();
            }
        }
    }
}
