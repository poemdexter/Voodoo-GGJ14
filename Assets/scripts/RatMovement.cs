using UnityEngine;
using System.Collections;

public class RatMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public bool canJump = false;
    public Vector2 jumpPower;
    public Vector2 gravity;
    Vector2 currentJumpVector;
    
    float direction = -1.0f;
    
    void Update()
    {
        if (CompareTag("Rat1") || CompareTag("Rat2"))
            transform.Translate(direction * transform.right * speed * Time.deltaTime);
        else if (CompareTag("Rat3") && canJump) {
            canJump = false;
            currentJumpVector = jumpPower;
        }
        
        if (!canJump) {
            currentJumpVector += gravity;
            transform.Translate(currentJumpVector * Time.deltaTime);
        }
    }
    
    public void FlipDirection()
    {
        direction = -direction;
    }
}