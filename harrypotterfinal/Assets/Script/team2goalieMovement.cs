using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class team2goalieMovement : MonoBehaviour {

    public Vector3 position;
    public float speed = 9.0f;

    void Update()
    {
        if (transform.position == position)
        {
            position = new Vector3(Random.Range(23.7f, 24.1f), Random.Range(7.2f, 8.8f), Random.Range(12.6f, 15.6f));
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
    }

    // Use this for initialization
    void Start()
    {
        position = new Vector3(Random.Range(23.7f, 24.1f), Random.Range(7.2f, 8.8f), Random.Range(12.6f, 15.6f));
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
    }
}
