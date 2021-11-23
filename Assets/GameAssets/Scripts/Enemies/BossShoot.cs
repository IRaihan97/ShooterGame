using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : StateMachineBehaviour
{
    Boss boss;
    public GameObject projectile;
    public GameObject muzzle;

    float nextProjTime = 0;
    float pauseDuration = 0.1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponentInParent<Boss>();
        if (boss.enraged == false)
        {
            boss.shootProjectile();
        }
        
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss.enraged == true)
        {
            if(Time.time > nextProjTime)
            {
                boss.shootProjectile();
                nextProjTime = Time.time + pauseDuration;
            }
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Shoot", false);
    }

}
