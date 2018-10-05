using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float damageAmount = 10;
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Health>().ChangeHealth(-damageAmount);

        }
        else if (col.gameObject.tag == "Laser")
        {

        }
        else if (col.gameObject.tag == "Enemy")
        {
            
            col.gameObject.GetComponent<Health>().ChangeHealth(-damageAmount);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Health>().ChangeHealth(-damageAmount);

        }
        else if(col.gameObject.tag == "Laser")
        {

        }
        else if(col.gameObject.tag == "Enemy")
        {
            
            col.gameObject.GetComponent<Health>().ChangeHealth(-damageAmount);
        }
        else
        {
            

            Destroy(gameObject);
        }

        //Add destroy game object
    }
}
