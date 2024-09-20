using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxSpeed;

    private Vector2 ballDirection;
    private Vector2 velocity;

    private int hitCounter = 0;
    private Rigidbody2D rb, rb2;
    public ScoreManager scoreManager;
    public GameObject hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        ballDirection = new Vector2(-1,Random.Range(-1.0f, 1.0f));
              
        StartCoroutine(Launch()); 
    }

    private void Restart()
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
    }

    public IEnumerator Launch()
    {
        Restart();
        hitCounter = 0;
        yield return new WaitForSeconds(1);
        MoveBall(ballDirection);
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = startSpeed + (hitCounter * extraSpeed);
        rb.velocity = direction * ballSpeed;
        if(ballSpeed < maxSpeed)
            hitCounter++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Racket1" || collision.gameObject.name == "Racket2")
        {
            Instantiate(hitSound,transform.position,transform.rotation);
            Vector3 racketPosition = collision.transform.position;
            float racketSize = collision.collider.bounds.size.y;
            ballDirection.x *= -1;
            ballDirection.y = (ballDirection.y-racketPosition.y)*racketSize/3;
            MoveBall(ballDirection);
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "TopBorder" || collision.gameObject.name == "BottomBorder")
        {
            ballDirection.y *= -1;
            MoveBall(ballDirection);
        }

        if (collision.gameObject.name == "RightBorder")
        {
            scoreManager.goal1();
            StartCoroutine(Launch()); 
        }
        else if (collision.gameObject.name == "LeftBorder")
        {
            scoreManager.goal2();
            StartCoroutine(Launch()); 
        }
    }

}
