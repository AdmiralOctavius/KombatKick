using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUp : MonoBehaviour {

    float TimeElapsed = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeElapsed += Time.deltaTime;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Time: " + TimeElapsed.ToString();

    }
}
