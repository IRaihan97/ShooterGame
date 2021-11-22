using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : StateMachineBehaviour
{

    Boss boss;
    EnemyHealth enemyHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
        boss = animator.GetComponentInParent<Boss>();
        enemyHealth = animator.GetComponent<EnemyHealth>();
        if(enemyHealth.currentHealth >= enemyHealth.enemyMaxHealth / 2)
        {
            boss.normalPattern();
        }
        if(enemyHealth.currentHealth < enemyHealth.enemyMaxHealth / 2)
        {
            boss.enragedPattern();
        }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.lookAtPlayer();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
