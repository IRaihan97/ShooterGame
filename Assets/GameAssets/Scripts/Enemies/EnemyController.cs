using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    Animator enemyAnimations;

    public float movementDuration;
    //float startingTime;
    //bool isMoving;

    //bool canFlip = true;
    bool facingRight = false;
    //float flipTime = 5f;
    float nextFlipChance = 0f;

    public GameObject enemyGraphic;
    //for pattern selection
    public int pattern;

    Rigidbody2D enemyBody;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimations = GetComponentInChildren<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pattern == 1) movePattern();
        else if (pattern == 2) {jumpPattern();}
        else if (pattern == 3) playerFollow();
        


        /*if (startingTime <= Time.time)
        {
            //Add force to opposite diraction if facingright
            enemyAnimations.SetBool("isCharging", true);//changes animation to charging
        }
        enemyAnimations.SetBool("isCharging", false);*///changes animation to charging
        
    }

    private void playerFollow()
    {
        throw new NotImplementedException();
    }

    private void jumpPattern()
    {
        Debug.Log("Current Time" + Time.time);
        if (Time.time > nextFlipChance)
        {
            Debug.Log("Initial Flip Chance: " + nextFlipChance);
            enemyBody.velocity = (new Vector2(0, 1) * enemySpeed);
            
            if(Time.time > (nextFlipChance + movementDuration) / 2)
            {
                Debug.Log("Stopping Velocity");
                enemyBody.velocity = Vector2.zero;
            }
            Debug.Log("Flip Chance Addition: " + nextFlipChance);
            nextFlipChance = Time.time + movementDuration;
        }


    }

/*    private void stopVelocity()
    {
        float startTime = nextFlipChance + movementDuration;
        if(Time.time > startTime)
        {
            Debug.Log("Stop Velocity");
            enemyBody.velocity = Vector2.zero;
            startTime = Time.time + nextFlipChance + movementDuration;
        }
    }*/

    private void movePattern()
    {
        if(Time.time > nextFlipChance)
        {
            flip();
            if (facingRight) { enemyBody.velocity = new Vector2(1, 0) * enemySpeed; }
            else { enemyBody.velocity = new Vector2(-1, 0) * enemySpeed; }
            nextFlipChance = Time.time + movementDuration;
        }
        
    }


    private void flip()
    {
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
}
