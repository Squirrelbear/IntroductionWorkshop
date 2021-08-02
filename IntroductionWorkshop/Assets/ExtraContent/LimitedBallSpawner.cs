using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedBallSpawner : MonoBehaviour
{
    // List of multiple balls to spawn randomly from
    public List<GameObject> balls;
    // Position where the spawner first started
    public Vector3 startPos;
    // The offset on the X axis from the start position
    public float offset;
    // Reference to the object to enable when the game has been won
    public GameObject winObject;
    // The material that has to be on all objects to win
    public Material winningMaterial;
    // The maximum number of balls that can be spawned.
    public int spawnLimit;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        offset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // When the A key is Pressed Down
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Search for all the objects with a specific tag and count the number of them to limit spawns.
            if (GameObject.FindGameObjectsWithTag("Ball").Length >= spawnLimit)
            {
                return;
            }

            // Spawn a random ball from the balls array.
            Instantiate(balls[Random.Range(0, balls.Count)], transform.position, Quaternion.identity);

            // Move the spawner along on the x-axis.
            offset += 1.5f;
            if (offset > 3)
            {
                offset = -1;
            }
            transform.position = new Vector3(startPos.x + offset, startPos.y + startPos.z);

            // Check if all the balls contain the winning material.
            int countUsingMaterial = 0;
            GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in allBalls)
            {
                // Necessary to use "StartsWith" because the prefab spawned elements have (instance) at the end.
                if (ball.GetComponent<MeshRenderer>().material.name.StartsWith(winningMaterial.name))
                {
                    countUsingMaterial++;
                }
            }

            // If the max limit are all that colour show the win message.
            if (countUsingMaterial == spawnLimit)
            {
                winObject.SetActive(true);
            }
        } 
    }
}
