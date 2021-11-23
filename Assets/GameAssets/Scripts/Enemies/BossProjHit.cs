using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BossProjHit : MonoBehaviour
{
    public float weaponDamage;

    BossProjectileController myPC;

    public GameObject particleFX;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<BossProjectileController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //get the other item that collided with this gameobject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(particleFX, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
            Destroy(gameObject);
            
            //checking if bullet collided with enemy
            if (collision.tag == "Player")
            {
                //Getting health and applying damange from collided enemy
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                knockBack(player, collision);
                playerHealth.applyPlayerDamage(weaponDamage);
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

    private void knockBack(PlayerController playerController, Collider2D collision)
    {
        CameraShaker.Instance.ShakeOnce(5f, 10f, 0.5f, 0.5f);
        playerController.knockBackCount = playerController.knockBackLenght;
        if (collision.transform.position.x < transform.position.x) { playerController.knockFromRight = true; }
        else { playerController.knockFromRight = false; }
    }
}
