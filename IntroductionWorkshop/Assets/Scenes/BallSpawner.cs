using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Reference to an object that can be set inside the Inspector
    public GameObject ballPrefab;

    // List of multiple balls to spawn randomly from
    public List<GameObject> balls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the A key is Pressed Down
        if(Input.GetKeyDown(KeyCode.A))
        {
            // Write to the Console
            //Debug.Log("Something is happening...");

            // Create an object cloning the ballPrefab object spawning it at the position 
            // of the current object this script is attached to with no change to rotation.
            //Instantiate(ballPrefab, transform.position, Quaternion.identity);

            // Spawn a random ball from the balls array.
            Instantiate(balls[Random.Range(0,balls.Count)], transform.position, Quaternion.identity);
        }
    }
}
