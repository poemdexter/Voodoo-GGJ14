using UnityEngine;
using System.Collections;

public class RatChangeDirection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Environment")) {
            Vector3 temp = transform.parent.localScale;
            transform.parent.GetComponent<RatMovement>().FlipDirection();
            transform.parent.localScale = new Vector3(-temp.x, temp.y, temp.z);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Environment")) {
            Vector3 temp = transform.parent.localScale;
            transform.parent.GetComponent<RatMovement>().FlipDirection();
            transform.parent.localScale = new Vector3(-temp.x, temp.y, temp.z);
        }
    }
}
