using UnityEngine;
using System.Collections;

public class RatMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float currentTime = 0;
    public float switchTime = 2.0f;
    
    void Update()
    {
        if ((currentTime += Time.deltaTime) > switchTime) {
            speed = -speed;
            currentTime = 0;
        }
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}