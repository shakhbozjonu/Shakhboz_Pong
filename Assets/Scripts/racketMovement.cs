using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class racketMovement : MonoBehaviour
{

    public float racketSpeed;
    public InputAction playerControls;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        racketDirection = playerControls.ReadValue<Vector2>().normalized;
        
    }

    void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
