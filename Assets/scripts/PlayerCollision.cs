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
    }

    void Respawn()
    {
        Debug.Log("Respawn");
    }
}