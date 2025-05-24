using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stringsGeneration : MonoBehaviour
{
    //External References
    [SerializeField] private Transform leftBasePoint;
    [SerializeField] private Transform rightBasePoint;
    [SerializeField] private Transform anchorCenter;
    [SerializeField] private Transform baseCenter;
    [SerializeField] private GameObject coneSprite; // SpriteRenderer for the bowstring
    //Internal Variables
    private float dividoreros = 5f; // Divisor for the length of the coneSprite
    private Sprite cone;
    private Vector2 leftBase;
    private Vector2 rightBase;
    private Vector3 direction;
    private Vector3 length;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        cone = coneSprite.GetComponent<SpriteRenderer>().sprite;
        leftBase = leftBasePoint.position;
        rightBase = rightBasePoint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Left ray
        Vector3 leftDirection = anchorCenter.position - leftBasePoint.position;
        float leftDistance = leftDirection.magnitude; // Calculate the current length of the ray
        Ray leftRay = new Ray(leftBasePoint.position, leftDirection.normalized);
        Debug.DrawRay(leftRay.origin, leftRay.direction * leftDistance, Color.red);

        // Right ray
        Vector3 rightDirection = anchorCenter.position - rightBasePoint.position;
        float rightDistance = rightDirection.magnitude;
        Ray rightRay = new Ray(rightBasePoint.position, rightDirection.normalized);
        Debug.DrawRay(rightRay.origin, rightRay.direction * rightDistance, Color.red);

        // Rotate the coneSprite to face anchorCenter
        RotateConeSprite();

    }

    void RotateConeSprite()
    {
        length = anchorCenter.position - baseCenter.position; // Height of cone
        float scaler = (length.magnitude / cone.bounds.size.x) / dividoreros; // Rescale the coneSprite based on the length of the ray and the size of the sprite then divides by 5f
        direction = anchorCenter.position - coneSprite.transform.position; // Calculate angle
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Rotation of the coneSprite
        coneSprite.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        //Rescaling of the coneSprite
        coneSprite.transform.localScale = new Vector3(0.1f, scaler, 1);

    }
    public Vector3 getDirection()
    {
        return direction;
    }
    public Vector3 getLength()
    {
        return length;
    }
}