using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;
    private Controller ctrl;

    public float force = 1000;
    private Light lt;
    private float newRed, newGreen, newBlue, newRed2, newGreen2, newBlue2;

	// Use this for initialization
	void Start () {

        lt = GetComponent<Light>();
        rb = GetComponent<Rigidbody>();
        ctrl = FindObjectOfType<Controller>();

        RandomizeLightLevel();
        RandomizeColor();

        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - sp).normalized;

        force = 1700;
        rb.AddForce(-ctrl.firingArc * force);
        Destroy(gameObject, 3f);

    }

    void RandomizeColor()
    {
        newRed2 = Random.Range(0, 0.9f);
        newGreen2 = Random.Range(0, 0.9f);
        newBlue2 = Random.Range(0, 0.9f);
        gameObject.GetComponent<Renderer>().material.color = new Color(newRed2, newGreen2, newBlue2);
    }

    void RandomizeLightLevel()
    {
        newRed = Random.Range(0, 255);
        newGreen = Random.Range(0, 255);
        newBlue = Random.Range(0, 255);
        lt.color = new Color(newRed, newGreen, newBlue, 255);
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime * 5);
	}
}
