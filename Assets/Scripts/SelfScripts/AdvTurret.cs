using UnityEngine;

public class AdvTurret : MonoBehaviour
{
    public GameObject laserPrefab;
    public float fireRate = 1;
    public bool useLineOfSight;
    public float lookDist = 5f;
    

    float lastFireTime = float.MinValue;
    public AudioSource turretSound;
    /*
     * SOH CAH TOA
     * Sin Opposite over Hypoteneuse
     * Cosine Adjacent over Hypoteneuse
     * Tangent Opposite over Adjacent
        Θ = Theta = Angle
        Tan(Θ) = Opposite/Adjacent
        Θ = ArcTan(Opposite/Adjacent)
        ArcTan returns only 0-90 degrees
        Most math libraries/game engines have an 'ATAN2' function that returns 0-360 degrees

        */


    void Update ()
    {
        GameObject player = Globals.playerObject;
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        
        Vector3 dif = player.transform.position - transform.position;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dif.y, dif.x);
        transform.eulerAngles = new Vector3(0, 0, angle);

		if(Time.time - (1/fireRate) > lastFireTime)
        {
            if (useLineOfSight == false)
            {
                Instantiate(laserPrefab, transform.position, transform.rotation);
                lastFireTime = Time.time;

                turretSound.Play();

            }
            else
            {
                RaycastHit2D playerHit = Physics2D.Raycast(this.transform.position, dif, lookDist);
                if (Physics2D.Raycast(this.transform.position, dif, lookDist))
                {
                  if (playerHit.collider.gameObject.tag == "Player")
                  {
                      Debug.Log("Got here in turret");
                      Instantiate(laserPrefab, transform.position, transform.rotation);
                      lastFireTime = Time.time;

                      turretSound.Play();
                  }

                }
            }

        }
	}
}
