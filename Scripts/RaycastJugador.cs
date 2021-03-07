using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// C# example.

public class RaycastJugador : MonoBehaviour
{
    Move move;
    private float distanciaDisparo = 20;

    private void Start()
    {

        move = GameObject.FindGameObjectWithTag("Jugador").GetComponent<Move>();
       
    }

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanciaDisparo, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if (hit.collider.gameObject.tag == "Enemigo")
            {
                move.dispara = true;
                move.enemigoActual = hit.collider.gameObject;

            }

        }
        else
        {
            move.dispara = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanciaDisparo, Color.green);
            //Debug.Log("Did not Hit");
        }
    }
}