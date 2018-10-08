using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;

    void Start ()
    {
	    	
	}	
	
    void Update ()
    {
		if(followObject)
        {
            //Smooth camera approach
            transform.position = Vector3.Lerp(transform.position, new Vector3(followObject.transform.position.x,
                followObject.transform.position.y, transform.position.z), .1f);
            //Direct transform
            //transform.position = new Vector3(followObject.transform.position.x, 
              //  followObject.transform.position.y, transform.position.z);
        }
	}
}
