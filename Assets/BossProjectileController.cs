using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileController : MonoBehaviour
{
    Rigidbody2D myBody;
    public float projectileSpeed;

    private void Awake()
    {
        //Get local gameobject rigidbody
        myBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.y > 0)
        {
            myBody.AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(-1, 0) * projectileSpeed, ForceMode2D.Impulse);
        }
        //Pass vector2 and add value to x axis(travels horizontally)

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
