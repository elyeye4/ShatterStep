using UnityEngine;

public class CamaraConLimites2D : MonoBehaviour
{
    public Transform player; // Reference to player
    public Vector3 offset;                // Desplazamiento de la cámara respecto al jugador
    public float interpotalion = 0.001f;        // Velocity when following the camera to the player

    void LateUpdate()
    {
        if (player != null)
        {
            // To be implemented
        }
    }
}