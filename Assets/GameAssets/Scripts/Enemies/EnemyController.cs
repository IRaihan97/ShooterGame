using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    Animator enemyAnimations;

    public float movementDuration;
    bool facingRight = false;
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
        if (pattern == 2) jumpPattern();     
    }

    private void jumpPattern()
    {
        if (enemyAnimations == null) return;
        if (Time.time > nextFlipChance)
        {
            enemyAnimations.SetTrigger("Jump");
            enemyBody.velocity = (new Vector2(0, 1) * enemySpeed);
            nextFlipChance = Time.time + movementDuration;
        }


    }

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
