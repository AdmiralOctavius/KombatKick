using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float damageAmount = 10;
	
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Health>().ChangeHealth(-damageAmount);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Health>().ChangeHealth(-damageAmount);
        //Add destroy game object
    }
}
