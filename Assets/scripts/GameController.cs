using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnpoint;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(2, 2);   // ignore, ignore
        Physics2D.IgnoreLayerCollision(11, 11); // rat, rat
        Physics2D.IgnoreLayerCollision(11, 12); // rat, tail
    }
    
    public void RespawnPlayer()
    {
        GameObject newPlayer = (GameObject)Instantiate(playerPrefab, spawnpoint.position, Quaternion.identity);
        Camera.main.GetComponent<CameraFollowPlayer>().HandlePlayerRespawn(newPlayer.transform);
    }
    
    public void PrepDestroyRats(int ratID)
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat" + ratID);
        foreach (GameObject rat in rats) {
            if (rat.name != ("Rat" + ratID + "(Clone)")) {
                rat.GetComponent<Animator>().enabled = false;
                rat.GetComponent<RatMovement>().enabled = false;
            }
        }
    }
    
    public void DestroyRats(int ratID)
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat" + ratID);
        Debug.Log(rats.Length);
        foreach (GameObject rat in rats) {
            if (rat.name != ("Rat" + ratID + "(Clone)")) {
                rat.GetComponent<RatExplode>().Explode();
            }
        }
    }
}
