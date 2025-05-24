using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrajectoryManager : MonoBehaviour
{
    //References to objects involved
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lineRenderer;
    [SerializeField] private GameObject joystickManager;
    [SerializeField] private GameObject AnchorManager;

    // Private fields for scripts so the reference is easier
    private stringsGeneration joystickScript;
    private trajectoryPredictor lineRendererScript;
    [SerializeField] private Transform playerTransform;
    private movement playerMovementScript;
    private AnchorManager AnchorManagerScript;


    void Start()
    {
        // Initialize references to the scripts and other components
        joystickScript = joystickManager.GetComponent<stringsGeneration>();
        lineRendererScript = lineRenderer.GetComponent<trajectoryPredictor>();
        playerTransform = playerTransform.GetComponent<Transform>();
        AnchorManagerScript = AnchorManager.GetComponent<AnchorManager>();
        playerMovementScript = player.GetComponent<movement>();
        lineRendererScript.finalPoint = playerTransform.position; // Initialize the final point to zero (Zero being player position)
    }

    // Update is called once per frame
    void Update()
    {
        if (AnchorManagerScript.isPressed == true)
        {
            // lineRenderer constant updates JOYSTICK STUFF only if the joystick is pressed
            lineRendererScript.setPlayerPosition(playerTransform.position);
            lineRendererScript.setDirection(joystickScript.getDirection());
            lineRendererScript.setjoystickDistance(joystickScript.getLength());
            lineRendererScript.calculateDirectionDistanceAndAngle();
            lineRendererScript.setAngle(joystickScript.angle);
            lineRendererScript.setJoyStickIsPressed(AnchorManagerScript.isPressed);
        }
        lineRendererScript.drawLine(); // The line will always be drawn, even if the joystick is not pressed so the trajectory gets hidden


        // Player updates PLAYER MOVEMENT STUFF
        playerMovementScript.moveFlag = AnchorManagerScript.isPressed;
        if (AnchorManagerScript.isPressed != true)
        {
            lineRendererScript.setRenderPoints(new Vector3[] { playerTransform.position, playerTransform.position });
            playerMovementScript.moveToDirection(lineRendererScript.finalPoint);
        }


    }
}
