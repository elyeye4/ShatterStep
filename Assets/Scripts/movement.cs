using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D player; // Reference to the player Rigidbody2D
    private float speed = 15f; // Speed of the player movement
    public bool moveFlag = false;
    [SerializeField] private Transform screenCenter;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

    }

    public void moveToDirection(Vector3 moveTo)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime); // Moves the player to moveTo vector which represents the direction of the ray created by joystick
    }
}
