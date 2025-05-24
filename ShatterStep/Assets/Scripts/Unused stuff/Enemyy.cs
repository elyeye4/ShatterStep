using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    Rigidbody2D enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        StartCoroutine(Coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if needed
    }

    void MoveToRandomDirection()
    {
        // Generate a random direction vector
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // Apply a force to the Rigidbody2D to move the enemy smoothly
        float moveSpeed = 5f;
        enemy.velocity = randomDirection * moveSpeed;
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            // Wait for 2 seconds before changing direction
            yield return new WaitForSeconds(0.5f);

            // Call the method again to change direction
            MoveToRandomDirection();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle collision with player
            Debug.Log("Enemy collided with player!");
            // You can add more logic here, like reducing player health or destroying the enemy
        }
        else if (other.CompareTag("Wall"))
        {
            // Handle collision with wall
            Debug.Log("Enemy collided with wall!");
            // You can add more logic here, like changing direction or destroying the enemy
        }
    }
}

