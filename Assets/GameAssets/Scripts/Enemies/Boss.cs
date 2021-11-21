using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject playerObj;

    public bool isFlipped = true;
    public bool enraged = false;
    public Animator animator;

    

    public void lookAtPlayer()
    {
        Transform player = playerObj.transform;
        Vector3 boss = transform.localScale;
        boss.z *= -1f;
        
        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = boss;
            transform.Rotate(0f, 180f, 0);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = boss;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void waitTime()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(waitingTime(animator));
    }

    IEnumerator waitingTime(Animator animator)
    {
        yield return new WaitForSecondsRealtime(2f);
        int num = Random.Range(1, 4);
        if(num == 1)
        {
            animator.SetBool("Run", true);
        }
        else if (num == 2)
        {
            animator.SetBool("Jump", true);
            //yield return new WaitForSecondsRealtime(1f);
            //animator.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if(num == 3)
        {
            animator.SetBool("RunShoot", true);
        }
        
        
    }
    

}
