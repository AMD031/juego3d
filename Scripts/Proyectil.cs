using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    public Vector3  objetivo;

    private float velocidadDisparo = 40f;
    void Start()
    {

        //objetivo = enemigo.transform.position;
      
       // objetivo2 = GameObject.FindGameObjectWithTag("Enemigo").transform.position;
    }

    // Update is called once per frame

    private void Awake()
    {
        Invoke("autodesctruir",1.5f);
    }

    void  autodesctruir()
    {
        Destroy(gameObject);
    }

    void Update()
    {

        if (objetivo !=  Vector3.zero)
        {
            //Debug.Log(objetivo);
            float step = velocidadDisparo * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, objetivo, step);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            other.gameObject.GetComponent<SaludEnemigo>().TakeDamage(5);

            other.gameObject.GetComponent<EnemyIA>().jugadorEncontrado = true;
            GameObject.Destroy(gameObject);
        }

    }


}
