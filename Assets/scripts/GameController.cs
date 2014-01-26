using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnpoint;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(2, 2);
        Physics2D.IgnoreLayerCollision(11, 11);
    }
    
    public void RespawnPlayer()
    {
        GameObject newPlayer = (GameObject)Instantiate(playerPrefab, spawnpoint.position, Quaternion.identity);
        Camera.main.GetComponent<CameraFollowPlayer>().HandlePlayerRespawn(newPlayer.transform);
    }
    
    public void DestroyRats()
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat");
        foreach (GameObject rat in rats) {
            rat.GetComponent<RatExplode>().Explode();
        }
    }
}
