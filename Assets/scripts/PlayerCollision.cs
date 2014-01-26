using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        // on hit rat, die die die
        if (col.gameObject.CompareTag("Rat")) {
            Respawn();
        }

        if (col.gameObject.CompareTag("RatTail")) {
            // stop and play stab animation

        }
    }

    void Respawn()
    {
        Debug.Log("Respawn");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().RespawnPlayer();
        Destroy(this.gameObject);
    }
}