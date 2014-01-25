using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
     
    void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime); 
    }
}