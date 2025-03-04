using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect; // Reference to the explosion prefab
    public float explosionRadius = 5f; // Radius of the explosion
    public float explosionForce = 700f; // Force of the explosion
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is the player
        if (collision.CompareTag("Player"))
        {
            Explode();
            Destroy(player.gameObject);
        }

    }

    void Explode()
    {
        // Instantiate explosion effect
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Apply explosion force to nearby objects
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 explosionDirection = nearbyObject.transform.position - transform.position;
                rb.AddForce(explosionDirection.normalized * explosionForce);
            }
        }

        // Destroy the bomb after the explosion
        Destroy(gameObject);
    }
}
