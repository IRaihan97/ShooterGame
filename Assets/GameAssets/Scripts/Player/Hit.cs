using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public float weaponDamage;

    ProjectileController myPC;

    public GameObject particleFX;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //get the other item that collided with this gameobject
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null) return;
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Destroy(gameObject);
            Instantiate(particleFX, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
            //checking if bullet collided with enemy
            if (other.tag == "Enemy" || other.tag == "Boss")
            {
                //Getting health and applying damange from collided enemy
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.addDamage(weaponDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Destroy(gameObject);
        }
    }
}
