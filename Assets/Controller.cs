using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {


    public Text ballsFiredText;
    public Text ballSpeedText;
    private int ballsFiredCount = 0;

    public Button quicker, slower;

    public GameObject ball;
    public Vector3 firingArc;
    private Quaternion origin;
    private Vector3 mouse_pos;
    private Vector3 player_pos;
    private Vector3 camera_pos;

    private float firingCooldown = 0.1f;
    private bool onCooldown;
    


	// Use this for initialization
	void Start () {
        origin = new Quaternion(transform.position.x, transform.position.y, transform.position.z, 1);
        camera_pos = Camera.main.transform.position;
        ballSpeedText.text = "Speed : " + firingCooldown;

	}

    private void Update()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5;
        player_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        firingArc = camera_pos - player_pos;
        Debug.DrawLine(camera_pos, player_pos, Color.cyan);

        
        if (Input.GetKey(KeyCode.Mouse0) && !onCooldown)
             {
               Shoot();
               onCooldown = true;
           }
        if (Input.GetKey(KeyCode.A))
        {
            if (firingCooldown < 1.5f)
            {
                firingCooldown *= 1.3f;
                ballSpeedText.text = "Speed : " + firingCooldown.ToString("F5");
            } else
            {
                firingCooldown = 1.5f;
                ballSpeedText.text = "Speed : " + firingCooldown.ToString("F5");
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (firingCooldown > 0.00001f)
            {
                firingCooldown *= 0.7f;
                ballSpeedText.text = "Speed : " + firingCooldown.ToString("F5");
            } else
            {
                firingCooldown = 0.00001f;
                ballSpeedText.text = "Speed : " + firingCooldown.ToString("F5");
            }
        }
    }


    void Shoot()
    {
        Instantiate(ball, player_pos, origin);
        ballsFiredCount++;
        if (ballsFiredCount < 1000)
        {
            ballsFiredText.text = "Balls Fired : " + ballsFiredCount;
        } else if (ballsFiredCount > 1000 && ballsFiredCount < 2000)
        {
            ballsFiredText.text = "Balls Fired : Too many.";
        } else
        {
            ballsFiredText.text = "Balls Fired : " + ballsFiredCount + " ..";
        }
        StartCoroutine(coolDown(firingCooldown));
    }

    IEnumerator coolDown(float firingCooldown)
    {
        yield return new WaitForSeconds(firingCooldown);
        onCooldown = false;
    }
}
