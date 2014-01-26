using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    Animator anim;
    public bool stopStabAnimation = false;
    public bool destroyRatsTrigger = false;
    bool killrats1 = false;
    bool killrats2 = false;
    bool killrats3 = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (stopStabAnimation) {
            stopStabAnimation = false;
            anim.SetBool("Stabbing", false);
            if (killrats3)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PrepDestroyRats(3);
            else if (killrats2)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PrepDestroyRats(2);
            else if (killrats1)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PrepDestroyRats(1);
        }
        
        if (destroyRatsTrigger) {
            destroyRatsTrigger = false;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PlayHurtSound();
            if (killrats3)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DestroyRats(3);
            else if (killrats2)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DestroyRats(2);
            else if (killrats1)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DestroyRats(1);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        // on hit rat, die die die
        if (col.gameObject.CompareTag("Rat1") || col.gameObject.CompareTag("Rat2") || col.gameObject.CompareTag("Rat3")) {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PlayDeathSound();
            Respawn();
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("RatTail1")) {
            Destroy(col.gameObject);
            killrats1 = true;
            anim.SetBool("Stabbing", true);
        }
        
        if (col.gameObject.CompareTag("RatTail2")) {
            Destroy(col.gameObject);
            killrats2 = true;
            anim.SetBool("Stabbing", true);
        }
        
        if (col.gameObject.CompareTag("RatTail3")) {
            Destroy(col.gameObject);
            killrats3 = true;
            anim.SetBool("Stabbing", true);
        }
    }

    void Respawn()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().RespawnPlayer();
        Destroy(this.gameObject);
    }
}