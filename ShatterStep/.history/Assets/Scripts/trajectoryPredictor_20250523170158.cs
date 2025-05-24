using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectoryPredictor : MonoBehaviour
{
    // Internal Variables
    private LineRenderer lineRenderer;
    private Vector3[] points = new Vector3[2]; // Array to store the 2 points of the line
    private Vector3 Direction;
    private float Angle;
    private Vector3 playerPosition;
    private GameObject AAS;
    
    private Vector3 joystickDistance;
    private bool joyStickIsPressed = false;
    public Vector3 finalPoint;
    private float maxLineLength = 10f; // Adjust based on your game's needs
    //private float lineWidth = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        //Define texture here

    }

    public void drawLine()
    {
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }

    public void setRenderPoints(Vector3[] newPoints)
    {
        points = newPoints;
    }

    public void calculateDirectionDistanceAndAngle()
    {
        if (joyStickIsPressed)
        {
            float distance = Mathf.Clamp(Direction.magnitude * 5, 0, maxLineLength);

            // Compute manual rotation using trigonometry
            float radians = Angle * Mathf.Deg2Rad; // Convert degrees to radians
            float rotatedX = Mathf.Cos(radians) * distance;
            float rotatedY = Mathf.Sin(radians) * distance;

            Vector3 rotatedPoint = new Vector3(rotatedX, rotatedY, 0); // Ensure proper axis alignment

            finalPoint = playerPosition - rotatedPoint;


            setRenderPoints(new Vector3[] { playerPosition, finalPoint });
        }
        else
        {
            setRenderPoints(new Vector3[] { playerPosition, playerPosition });
        }
    }

    public void setDirection(Vector3 newDirection)
    {
        Direction = newDirection;
    }
    public void setjoystickDistance(Vector3 newDistance)
    {
        joystickDistance = newDistance;
    }
    public void setAngle(float newAngle)
    {
        Angle = newAngle;
    }
    public void setPlayerPosition(Vector3 newPosition)
    {
        playerPosition = newPosition;
    }
    public void setJoyStickIsPressed(bool newState)
    {
        joyStickIsPressed = newState;
    }
}
