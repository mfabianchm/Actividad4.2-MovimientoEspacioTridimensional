using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    // Movimiento
    private Vector2 lastTapPosition;
    // Posicion Helix
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.localEulerAngles;
    }

    void Update()
    {
        // Izquierdo
        if (Input.GetMouseButton(0))
        {
            // Donde hemos tocado con el mouse
            Vector2 currentTapPosition = Input.mousePosition;

            if (lastTapPosition == Vector2.zero)
            {
                lastTapPosition = currentTapPosition;
            }

            float distance = lastTapPosition.x - currentTapPosition.x;

            // Actualizar la ultima posicion
            lastTapPosition = currentTapPosition;

            // Mover pantalla
            transform.Rotate(Vector3.up * distance);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPosition = Vector2.zero;
        }
    }
}
