using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;

    private float currentHealth;

    //public AudioClip deathSound;

    public GameObject enemyDeathFX;
    

    AudioSource asour;
    // Start is called before the first frame update
    void Start()
    {
        asour = GetComponent<AudioSource>();
        currentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if (currentHealth > 0)
        {
            
            currentHealth -= damage;
            CameraShaker.Instance.ShakeOnce(4f, 5f, 0.5f, .1f);
        }
        
        

        if (currentHealth <= 0)
        {
            CameraShaker.Instance.ShakeOnce(10f, 10f, .1f, 1.1f);
            makeDead();
        }
    }

    private void makeDead()
    {
        
        
        Destroy(gameObject.transform.parent.gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        //if (canDrop) { Instantiate(drop, transform.position, transform.rotation); }
    }
}
