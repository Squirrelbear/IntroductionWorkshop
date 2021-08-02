using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when the sphere object this is attached to is clicked.
    void OnMouseDown()
    {
        // Create a DestroyObject object, attach it to the current game object and use the reference to the newly
        // created script to then set the time until the object is destroyed using the other script.
        DestroyObject scriptRef = gameObject.AddComponent<DestroyObject>();
        scriptRef.destroyTime = 1;
    }
}
