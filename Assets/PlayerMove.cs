using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private AudioSource jump;

    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private float jumpHeight = 10;

    private bool grounded;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.GetContact(0).normal == Vector3.up)
            grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,10,0), ForceMode.Impulse);
        jump = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1);
        rb.velocity = input * speed + Vector3.up * rb.velocity.y;
        transform.LookAt(input + transform.position);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jump.Play();
        }
        //var input = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1);
        //rb.AddForce(input * speed);
    }
}
