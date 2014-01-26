using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float scale;
    Animator anim;

    void Start()
    {
        scale = transform.localScale.x;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(movement, 0) * speed * Time.deltaTime);

        if (movement != 0) {
            transform.localScale = (movement < 0) ? new Vector2(scale, scale) : new Vector2(-scale, scale);
            anim.SetBool("Moving", true);
        } else {
            anim.SetBool("Moving", false);
        }
    }
}