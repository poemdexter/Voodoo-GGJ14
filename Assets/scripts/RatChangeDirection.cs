using UnityEngine;
using System.Collections;

public class RatChangeDirection : MonoBehaviour
{
    Vector2 startPos;
    
    void Start()
    {
        startPos = transform.localPosition;
    }
    
    void Update()
    {
        //ensure collider box doesn't move
        transform.localPosition = startPos;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Environment")) {
            if (transform.parent.CompareTag("Rat1") || transform.parent.CompareTag("Rat2")) {
                Vector3 temp = transform.parent.localScale;
                transform.parent.GetComponent<RatMovement>().FlipDirection();
                transform.parent.localScale = new Vector3(-temp.x, temp.y, temp.z);
            } else if (transform.parent.CompareTag("Rat3")) {
                transform.parent.GetComponent<RatMovement>().canJump = true;
            }
        }
    }
}
