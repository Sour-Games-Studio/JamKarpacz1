using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 1f;

    private Rigidbody rb;
    private Vector3 moveDirection;

    private float dashDistance = 5f;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        ProcessInputs();
    }
    void FixedUpdate() {
         Vector3 movement = ProcessInputs() * (moveSpeed * Time.fixedDeltaTime);
            GetComponent<Rigidbody>().MovePosition(transform.position + movement);
    }

    Vector3 ProcessInputs() {

        Vector3 inputs =new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = new Vector3(inputs.x, 0, inputs.z);
        //if spacebar then dash
        if (Input.GetKeyDown(KeyCode.Space)) {
            Dash(moveDirection);
        }
        return moveDirection;

    }
    
    void Dash(Vector3 moveDriection) {
        rb.AddForce(moveDirection * dashDistance, ForceMode.Impulse);
    }
    
}