using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BallMovement;

public class racketAI : MonoBehaviour
{
    public Transform ball;
    public float moveSpeed;
    public float sensitivity;

     void FixedUpdate()
    {
        MoveRacket();    
    }

    public void MoveRacket()
    {
        float distance = Mathf.Abs(ball.position.y - transform.position.y);
        if (distance > sensitivity)
        {
            if (ball.position.y > transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * moveSpeed;
            }

            if (ball.position.y < transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * moveSpeed;
            }
        }

    }
}
