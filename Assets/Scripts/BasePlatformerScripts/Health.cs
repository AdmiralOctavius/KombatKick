using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth = 100;

    public float health;
    private bool isDead;
	// Use this for initialization
	void Start () {
        health = maxHealth;
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            Destroy(gameObject);
        }
	}

    public void ChangeHealth(float HpChange)
    {
        health = Mathf.Min(health + HpChange, maxHealth);
        Debug.Log("Got here in health");
        if(health <= 0)
        {
            isDead = true;
            
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
