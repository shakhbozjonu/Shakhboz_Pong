using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBalls : MonoBehaviour
{
    private bool isDoubleBall = false;
    private GameObject secondBall;
    public GameObject ball;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && !isDoubleBall)
        {
            DoubleBall();
            isDoubleBall = true;
        }else if(Input.GetKeyDown(KeyCode.F) && isDoubleBall && secondBall)
        {
            Destroy(secondBall);
            isDoubleBall = false;
        }
            
    }

    public void DoubleBall()
    {
        secondBall = Instantiate(ball, transform.position, transform.rotation);
    }
}
