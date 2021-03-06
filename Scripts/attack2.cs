using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state


    GameObject jugador;
    Rigidbody rb;
    EnemyIA ia;

    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         jugador = GameObject.FindGameObjectWithTag("Jugador");
         rb = animator.GetComponent<Rigidbody>();
         ia = animator.GetComponentInParent<EnemyIA>();
         ia.sonidoPincho();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(stateInfo);

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        ia.sonidoPincho();
        if (Vector3.Distance(rb.position, jugador.transform.position) <= 1.3f)
        {
             jugador.GetComponent<Health>().TakeDamage(20);
                

        }
       // jugador.GetComponent<Move>().sonidodisparar();
        animator.ResetTrigger("atacar");
    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
