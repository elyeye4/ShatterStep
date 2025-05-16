using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
    [SerializeField] Transform circleAnchor; // Anchor we are moving
    [SerializeField] Collider2D circleCollider; // Sprite collider to check the distance from the anchor
    private float velocity = 5f;
    private float maxRadius = 1f; // Maximum distance from circleAnchor center
    public bool isPressed = false; // This flag is constanly updated on playerTrajectoryManager.cs script to check if the joystick is pressed or not and share this information among other scripts
    private bool isStillPressed = false;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)circleAnchor.position;
        // While left click is pressed within maximum radious boundaries
        if (Input.GetMouseButton(0) && direction.magnitude < maxRadius)
        {
            isStillPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isStillPressed = false;
            isPressed = false;
            transform.position = circleCollider.transform.position; // Returns anchor to its original position when the left click is released
        }
        // While left click hasn't been released
        if (isStillPressed == true)
        {
            isStillPressed = true;
            isPressed = true;
            moveAnchor(mousePosition, direction); // Updates anchor position
        }
        // If right click is pressed, the anchor will be moved to the center of the circleCollider
        if (Input.GetMouseButton(1))
        {
            transform.position = circleCollider.transform.position;
            isStillPressed = false;
        }
    }

    void moveAnchor(Vector2 mousePosition, Vector2 direction)
    {
        // Check if the distance exceeds the maximum radius
        if (direction.magnitude > maxRadius)
        {
            direction = direction.normalized * maxRadius;
        }

        // Calculate the new position within the circular boundary taking circleAnchor center and the direction the mouse is pointing to
        Vector2 newPosition = (Vector2)circleAnchor.position + direction;

        // Smoothly move the object toward the target position
        transform.position = Vector2.Lerp(transform.position, newPosition, Time.deltaTime * velocity);
    }
}