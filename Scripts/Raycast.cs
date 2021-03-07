using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# example.

public class Raycast : MonoBehaviour
{
    public GameObject enemigo;
    private float vision = 20f;
    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 0 << 8; 

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, vision, layerMask))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.tag == "Jugador")
            {
             enemigo.GetComponent<EnemyIA>().jugadorEncontrado = true;

             
            }
           

            //Debug.Log(hit.collider.gameObject.tag);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");


        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * vision, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}