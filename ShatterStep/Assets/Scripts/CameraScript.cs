using UnityEngine;

public class CamaraConLimites2D : MonoBehaviour
{
    public Transform playerPos; // Referencia al jugador
    public Vector3 offset;                // Desplazamiento de la cámara respecto al jugador
    public float interpolation = 0.001f;        // Velocidad de interpolación

    void LateUpdate()
    {
        if (playerPos != null)
        {
            // Temporarily unused
        }
        
    }
}