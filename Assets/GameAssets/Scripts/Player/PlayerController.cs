using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed;

    Rigidbody2D myBody;
    Animator myAnim;
    bool facingRight;

    //jump variables
    bool grounded = true;
    float checkerRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpVelocity;
    int extraJumps;
    public int extraJumpsValue;

    //shooting
    public Transform muzzle;
    public GameObject bullet;
    public GameObject chargedBullet;
    public float fireRate;
    float nextFire = 0f;
    
    public float knockBack;//force
    public float knockBackCount;//time counter
    public float knockBackLenght;
    public bool knockFromRight;

    public bool canCharge;
    public GameObject chargeEffect;
    public float chargeTimer=0f;

    // Start is called before the first frame update
    void Start()
    {
        //Returns reference to attached component
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkerRadius, groundLayer);
        
        myAnim.SetBool("isGrounded", grounded);
    }

    // Update is called once per frame
    void Update()
    {
        //check if character is grounded
        if (grounded==true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
                
                //myAnim.SetBool("isGrounded", grounded);
                //Pushes the body (adding jumpvelocity to y axis)
                //myBody.AddForce(new Vector2(0, jumpVelocity));
            myBody.velocity = Vector2.up * jumpVelocity;
            extraJumps--;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && grounded == true)
        {
            myBody.velocity = Vector2.up * jumpVelocity;
        }


        //Put a value between -1 and 1 when a or d are pressed
        float move = Input.GetAxis("Horizontal");
        
        if(knockBackCount <= 0)
        {
            myAnim.SetFloat("Speed", Mathf.Abs(move));
            myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);

            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.J) && canCharge)
            {
                /*myAnim.SetTrigger("Shoot");
                shoot();*/
                myAnim.SetTrigger("Shoot");
                chargeTimer += Time.deltaTime;
            }

            if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.J)) && chargeTimer >= 0.5f && canCharge)
            {

                chargeEffect.SetActive(true);

            }
            if ((Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.J)) && chargeTimer >= 2f && canCharge ){
                chargeTimer = 0;
                chargeShot();
                if (canCharge == true) 
                {
                    chargeEffect.SetActive(false);
                }
                

            }
            else if ((Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.J) && chargeTimer < 2f)){
                myAnim.SetTrigger("Shoot");
                shoot();
                chargeTimer = 0;
                if (canCharge == true)
                {
                    chargeEffect.SetActive(false);
                }


            }

        }
        else
        {
            if (knockFromRight)
            {
                myBody.velocity = Vector2.zero;
                myBody.velocity = new Vector2(-knockBack, 5);
                
            }
            else
            {
                myBody.velocity = Vector2.zero;
                myBody.velocity = new Vector2(knockBack, 5);
                
            }
            knockBackCount -= Time.deltaTime;
        }
        //Get overall animation values and set it a specific value
        
        
        //go to the right ( > 0) 
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        

    }
    
    private void flip()
    {
        //Reverse current facing right status
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void shoot()
    {

        //Instatiating bullet object based on current time
        if (Time.time > nextFire)
        {
            
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, muzzle.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(bullet, muzzle.position, Quaternion.Euler(new Vector3(0, 0, 180)));//flip if not facing right
            }

        }    
    }

    private void chargeShot()
    {
        //Instatiating bullet object based on current time
        if (Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                CameraShaker.Instance.ShakeOnce(20f, 20f, 0.5f, 0.1f);
                Instantiate(chargedBullet, muzzle.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                CameraShaker.Instance.ShakeOnce(20f, 20f, 0.5f, 0.1f);
                Instantiate(chargedBullet, muzzle.position, Quaternion.Euler(new Vector3(0, 0, 180)));//flip if not facing right
            }

        }
    }
}
