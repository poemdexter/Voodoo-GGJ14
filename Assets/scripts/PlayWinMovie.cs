using UnityEngine;
using System.Collections;

public class PlayWinMovie : MonoBehaviour
{
    public bool triggered = false;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!triggered && col.CompareTag("Player")) {
            triggered = true;
            col.gameObject.GetComponent<PlayerMovement>().enabled = false;
            col.gameObject.GetComponent<JumpPhysics2D>().enabled = false;
            Camera.main.GetComponent<MusicController>().StopMusic();
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
            renderer.enabled = true;
            ((MovieTexture)(renderer.material.mainTexture)).Play();
            audio.Play();
        }
    }
}
