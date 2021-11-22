using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject playerObj;

    public bool isFlipped = true;
    public bool enraged = false;
    Animator animator;
    public GameObject bullet;
    public GameObject muzzle;

    

    public void lookAtPlayer()
    {
        if (playerObj == null) return;
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

    public void normalPattern()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(pattern1(animator));
    }

    public void enragedPattern()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(pattern2(animator));

    }


    IEnumerator pattern1(Animator animator)
    {
        yield return new WaitForSecondsRealtime(1f);
            int num = Random.Range(1, 3);
            if (num == 1)
            {
                animator.SetBool("Shoot", true);
            }
            else if (num == 2)
            {
                animator.SetBool("RunShoot", true);
                //yield return new WaitForSecondsRealtime(1f);
                //animator.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
            }
    }

    IEnumerator pattern2(Animator animator)
    {
        yield return new WaitForSecondsRealtime(1f);
        int num = Random.Range(1, 4);
        if (num == 1)
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
            animator.SetBool("Shoot", true);
        }
    }

    public void shootProjectile()
    {
        Instantiate(bullet, new Vector3(muzzle.transform.position.x, muzzle.transform.position.y, -1), muzzle.transform.rotation);     
    }
}
