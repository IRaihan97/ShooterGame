using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    Animator enemyAnimations;

    public float movementDuration;
    float startingTime;

    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    public GameObject enemyGraphic;

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
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5)
            {
                flip();
                nextFlipChance = Time.time + flipTime;
            }
        }

        if (startingTime <= Time.time)
        {
            if (!facingRight) { enemyBody.AddForce(new Vector2(-1, 0) * enemySpeed); }
            else { enemyBody.AddForce(new Vector2(1, 0) * enemySpeed); }//Add force to opposite diraction if facingright
            enemyAnimations.SetBool("isCharging", true);//changes animation to charging
        }
        enemyAnimations.SetBool("isCharging", false);//changes animation to charging
    }

    private void flip()
    {
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
}
