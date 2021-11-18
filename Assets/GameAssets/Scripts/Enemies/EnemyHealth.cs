using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            
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
