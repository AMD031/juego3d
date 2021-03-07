using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyIA : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject jugador;
    //public float distance = 1.2f;
    public GameObject[] rutina ;
    private int i = 0;
    private bool regresar = false;
    public bool jugadorEncontrado = false;
    private Animator anim;
/*    private bool jugadorCerca = false; */
    public bool muerto = false;
    public AudioClip spike;
    private AudioSource audio;



    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = spike;
    }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
      
    }



    // Update is called once per frame
    void FixedUpdate()
    {
      

        //Debug.Log(Vector3.Distance(target.transform.position, gameObject.transform.position));
        //Debug.Log(Vector3.Distance(rutine[i].transform.position, gameObject.transform.position));
        // if ( Vector3.Distance(rutine[i].transform.position, gameObject.transform.position) < distance)
        // {
        // agent.SetDestination(target.transform.position);
        // Debug.Log(i);

        if (jugadorEncontrado && !muerto)
        {
            agent.SetDestination(jugador.transform.position);
        }

        if (muerto)
        {
            agent.isStopped = true;
            anim.SetBool("muerto", true);
        }


       // if (jugadorEncontrado && jugadorCerca)
        //{
            //anim.SetBool("atacar", true);
           
        //}
        //else
       // {
           // anim.SetBool("atacar", false);
        //}



        if (!jugadorEncontrado)
        {   
            if (i <= rutina.Length - 1 && i >= 0)
            {
                agent.SetDestination(rutina[i].transform.position);
            }
            else
            {
                // i =0 ;   
                regresar = !regresar;
               // Debug.Log(regresar);
                if (regresar && i >= rutina.Length - 1)
                {
                    i = rutina.Length - 2;

                }

                if (!regresar)
                {
                    i = 1;
                }
            }   
        }
         
           
     
    }

    


    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log( "Entra" + " "+other.tag);
   
            if ( other.gameObject == rutina[i] )
            {
                if (!regresar)
                {
                  i++;
                }
                else
                {
                  i--;
                }

            }

  

    /*    if (other.gameObject.tag == "Jugador")
        {
            jugadorCerca = true;
         
        }*/


    }

/*    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Jugador")
        {
            jugadorCerca = false;
        }
        
    }*/

    public void sonidoPincho()
    {
        if (audio!=null)
        {
           // Debug.LogWarning("sonado");
            audio.Play();
        }
        else
        {
            Debug.LogWarning(" sonido pincho null");
        }
    }



}
