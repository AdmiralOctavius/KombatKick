using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpDisplay : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Hp: " + player.GetComponent<Health>().health.ToString();

        if(player.GetComponent<Health>().health <= 0)
        {
            SceneManager.LoadScene("LossScreen");
        }
	}
}
