using UnityEngine;
using System.Collections;

public class TriggerSection : MonoBehaviour
{
    bool triggered = false;
    public Transform newSpawnpoint;
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!triggered) {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().spawnpoint = newSpawnpoint;
        }
    }
}
