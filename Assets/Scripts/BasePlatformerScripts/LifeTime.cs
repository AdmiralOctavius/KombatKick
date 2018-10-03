using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifetime = 3;

	void Start ()
    {
        Invoke("KillMe", lifetime);
	}

    void KillMe()
    {
        Destroy(gameObject);
    }
}
