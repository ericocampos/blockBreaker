using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

    // Use this for initialization
    void Start()
    {
        // Finding the Paddle
        paddle = GameObject.FindObjectOfType<Paddle>();

        // Starting with the ball on the platform
        paddleToBallVector = this.transform.position - paddle.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // The ball stay on the platform
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait  for the left mouse button click to release the ball
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse Clicked");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            this.GetComponent<Rigidbody2D>().velocity += tweak;            
        }
    }
}
