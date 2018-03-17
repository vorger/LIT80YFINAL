using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPlayerMovement : MonoBehaviour {

    public Vector3 position;
    public float speed = 20.0f;
    private Rigidbody rb;
    int rotat, y;
    Vector3 direction;

    void Update()
    {
        if (transform.position == position)
        {
            position = new Vector3(Random.Range(-32.0f, 20.0f), Random.Range(9.0f, 17.0f), Random.Range(-12.0f, 12.0f));
        }
        if (Time.frameCount % 60 == 0)
            calc();
        transform.Rotate(direction, Time.deltaTime * rotat);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
    }

    // Use this for initialization
    void Start()
    {
        position = new Vector3(Random.Range(-32.0f, 20.0f), Random.Range(9.0f, 17.0f), Random.Range(-12.0f, 12.0f));
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
    }

    void OnDrawGizmosSelected()
    {
        if (position != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, position);
        }
    }

    void calc()
    {
        y = Random.Range(0, 10);
        if (y % 2 == 0)
            direction = Vector3.up;
        else
            direction = Vector3.down;
        rotat = Random.Range(5, 60);
    }
}
