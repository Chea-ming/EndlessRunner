using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15f; // Speed of the player movement
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move up and down based on W/S key
        float DirectionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, DirectionY).normalized;
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(0, playerDirection.y * moveSpeed);
    }
}
