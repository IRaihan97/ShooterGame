using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float damageRate;
    //pushes player away
    public float pushBackForce;


    float nextDamage = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float currentTime = Time.time;
        if (collision.tag == "Player" && nextDamage < currentTime)
        {
            Debug.Log(collision.tag);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerHealth.applyPlayerDamage(damage);
            playerController.knockBackCount = playerController.knockBackLenght;
            if (collision.transform.position.x < transform.position.x) { playerController.knockFromRight = true; }
            else { playerController.knockFromRight = false; }
            nextDamage = Time.time + damageRate;

            
            //pushBack(collision.transform);
        }
    }

    private void pushBack(Transform pushedObject)
    {
        Vector2 pushDir = new Vector2(100f, 20f);
        pushDir *= pushBackForce;
        Rigidbody2D pushBody = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushBody.velocity = Vector2.zero;
        pushBody.AddForce(pushDir, ForceMode2D.Force);
        
        
        
    }
}
