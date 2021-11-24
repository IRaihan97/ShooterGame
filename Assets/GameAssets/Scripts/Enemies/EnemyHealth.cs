using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;

    public float currentHealth;

    //public AudioClip deathSound;

    public GameObject enemyDeathFX;

    public GoToMenu goToMenu;

    public GameObject healthDrop;

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
            CameraShaker.Instance.ShakeOnce(5f, 15f, 0.1f, 0.5f);
        }
        
        

        if (currentHealth <= 0)
        {
            CameraShaker.Instance.ShakeOnce(30f, 30f, .1f, 0.5f);
            makeDead();
        }
    }

    private void makeDead()
    {
        
        
        Destroy(gameObject.transform.parent.gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        //if (canDrop) { Instantiate(drop, transform.position, transform.rotation); }
        if(gameObject.tag == "Enemy")
        {
            int rand = Random.Range(1, 4);
            if(rand == 3)
            {
                Instantiate(healthDrop, transform.position, transform.rotation);
            }

           
        }
        if (gameObject.tag == "Boss")
        {
            goToMenu.goToMainMenu();
        }
    }


}
