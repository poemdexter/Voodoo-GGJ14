using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public AudioSource musicIntro;
    public AudioSource musicLoop;
    
    void Update()
    {
        if (!musicIntro.isPlaying && !musicLoop.isPlaying) {
            musicLoop.Play();
        }
    }
}
