using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJumpIndicator : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(player.GetComponent<KatControls>().doubleJump == false)
        {
            gameObject.GetComponent<Image>().color = Color.blue;

        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
	}
}
