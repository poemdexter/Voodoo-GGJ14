using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnpoint;
	
    void Update()
    {
	
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnpoint.position, Quaternion.identity);
    }
}
