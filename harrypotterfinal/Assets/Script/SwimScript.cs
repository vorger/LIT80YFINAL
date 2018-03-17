using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwimScript : MonoBehaviour {
	
	public float speed = 17.5f;
    private bool win = false;
    public Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();

    }

	// Update is called once per frame
	void Update () {
        if (win == true)
        {
            if (Input.anyKey)
                Invoke("restart", 15);
        }
        else
        {
            if (Input.anyKey)
            {
                transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
            }
            
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("stadium"))  // or if(gameObject.CompareTag("YourWallTag"))
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snitch"))
        {
            win = true;
        }
    }

    private void restart()
    {
        SceneManager.LoadScene("hp final project");
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(5f);
        // do something
    }
}