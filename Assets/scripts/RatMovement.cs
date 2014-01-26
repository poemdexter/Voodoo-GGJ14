using UnityEngine;
using System.Collections;

public class RatMovement : MonoBehaviour
{
    public float speed = 1.0f;
    float direction = -1.0f;
    
    void Update()
    {
        transform.Translate(direction * transform.right * speed * Time.deltaTime);
    }
    
    public void FlipDirection()
    {
        direction = -direction;
    }
}