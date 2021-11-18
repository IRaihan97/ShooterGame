using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    PlayerController playerControl;
    Rigidbody2D playerBody;

    Animator playerAnim;

    public AudioClip playerDeath;

    public RestartGame restart;

    public GameObject deathEffect;

    bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerControl = GetComponent<PlayerController>();
        playerAnim = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            playerAnim.SetTrigger("Damaged");
        }
        damaged = false;
    }

    public void applyPlayerDamage(float damage)
    {
        
        if (damage <= 0) { return; }

        playerAnim.SetTrigger("Damaged");
        //playerBody.velocity = new Vector2(-1000, 30);
        currentHealth -= damage;
        /*healthBar.value = currentHealth;

        playerAS.clip = playerHurt;
        playerAS.Play();*/

        damaged = true;

        if (currentHealth <= 0) { makeDead(); }
    }

    public void makeDead()
    {
        //Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(playerDeath, transform.position, 1f);
        Instantiate(deathEffect, transform.position, transform.rotation);
        //gameOver.gameObject.SetActive(true);
        //Animator gameOverAnim = gameOver.GetComponent<Animator>();
        //gameOverAnim.SetTrigger("gameOver");
        restart.restartTheGame();

    }

    

}
