using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunShoot : StateMachineBehaviour
{
    Rigidbody2D enemyRB;
    Boss boss;

    float nextShootTime;
    float shootDuration;
    public GameObject bullet;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        boss = animator.GetComponentInParent<Boss>();
        enemyRB = animator.GetComponentInParent<Rigidbody2D>();
        if (boss.isFlipped)
        {
            enemyRB.velocity = new Vector2(2f, 0) * 2f;
            
        }
        else
        {
            enemyRB.velocity = new Vector2(-2f, 0) * 2f;
        }
        boss.shootProjectile();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("RunShoot", false);
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
