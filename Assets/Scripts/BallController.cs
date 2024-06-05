using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    // RigidBody
    public Rigidbody rb;
    // Impulso bola
    public float impulseForce = 3f;

    private bool ignoreNextCollision;

    private void OnCollisionEnter(Collision collision)
    {   

        // Evitar multiples coliciones
        if (ignoreNextCollision)
        {
            return;
        }

        // Colision añade puntos
        GameManager.singleton.AddScore(1);

        // Evitar errores al colicionar
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        // Ya coliciono
        ignoreNextCollision = true;
        // Llamar cada 2 segundos para cambiar valor de colicion
        Invoke("AllowNextCollision", 0.2f);
    }

    private void AllowNextCollision()
    {
        ignoreNextCollision = false;
    }
}
