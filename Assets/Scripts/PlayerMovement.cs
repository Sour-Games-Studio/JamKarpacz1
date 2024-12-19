using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    
    private Vector2 inputMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       inputMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate() {
        Vector2 movement = inputMovement.normalized * moveSpeed;
        rigidbody.MovePosition(rigidbody.position + movement * Time.fixedDeltaTime);

    }
    
}