using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    Animator anim;
    public bool stopStabAnimation = false;
    public bool destroyRatsTrigger = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (stopStabAnimation) {
            stopStabAnimation = false;
            anim.SetBool("Stabbing", false);
        }
        
        if (destroyRatsTrigger) {
            destroyRatsTrigger = false;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DestroyRats();
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        // on hit rat, die die die
        if (col.gameObject.CompareTag("Rat")) {
            Respawn();
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("RatTail")) {
            Destroy(col.gameObject);
            anim.SetBool("Stabbing", true);
        }
    }

    void Respawn()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().RespawnPlayer();
        Destroy(this.gameObject);
    }
}