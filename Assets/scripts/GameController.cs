using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnpoint;

    public void RespawnPlayer()
    {
        GameObject newPlayer = (GameObject)Instantiate(playerPrefab, spawnpoint.position, Quaternion.identity);
        Camera.main.GetComponent<CameraFollowPlayer>().HandlePlayerRespawn(newPlayer.transform);
    }
}
