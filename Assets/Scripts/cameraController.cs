using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    public float offset = 5;
    private Vector3 playerPosition;
    public float offsetSmoothing = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.z > 0f)
        {
            playerPosition = new Vector3(player.transform.position.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(player.transform.position.x - offset, playerPosition.y, playerPosition.z);
        }
        // transform.position = playerPosition;
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

    }
}

