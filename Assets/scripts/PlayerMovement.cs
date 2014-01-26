using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Animator anim;
    float scale;
    public Vector2 wallRayTopOffset = Vector2.zero;
    public Vector2 wallRayBottomOffset = Vector2.zero;

    void Start()
    {
        scale = transform.localScale.x;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        if (movement != 0) {
            if (movement < 0) {
                transform.Translate(new Vector2(movement, 0) * speed * Time.deltaTime);
                anim.SetBool("Moving", true);
            } else if (movement > 0) {
                transform.Translate(new Vector2(movement, 0) * speed * Time.deltaTime);
                anim.SetBool("Moving", true);
            } else {
                anim.SetBool("Moving", false);
            }
            transform.localScale = (movement < 0) ? new Vector2(scale, scale) : new Vector2(-scale, scale);
        } else {
            anim.SetBool("Moving", false);
        }
        
        // ensure we aren't rotating
        transform.rotation = Quaternion.identity;
    }
}