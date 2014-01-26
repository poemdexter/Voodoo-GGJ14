using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public AudioSource musicIntro;
    public AudioSource musicLoop;
    
    bool stopped = false;
    
    void Update()
    {
        if (!stopped) {
            if (!musicIntro.isPlaying && !musicLoop.isPlaying) {
                musicLoop.Play();
            }
        }
    }
    
    public void StopMusic()
    {
        stopped = true;
        musicLoop.Stop();
        musicIntro.Stop();
    }
}
