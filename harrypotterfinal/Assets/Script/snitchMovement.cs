using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class snitchMovement : MonoBehaviour {
    
    public Vector3 position;
    public float speed = 11.0f;
    private bool win = false;

    void Update()
    {
        if (win != true)
        { 
            if (transform.position == position)
            {
                position = new Vector3(Random.Range(-32.0f, 20.0f), Random.Range(9.0f, 17.0f), Random.Range(-12.0f, 12.0f));
            }
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, position, step);
        }
        
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
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            win = true;
        }
    }
}
