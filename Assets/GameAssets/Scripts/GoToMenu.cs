using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    public float restartTime;
    bool restartNow = false;
    float resetTime;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (restartNow && resetTime <= Time.time)
        {
            
            Application.LoadLevel(0);
        }
    }

    public void goToMainMenu()
    {
        text.gameObject.SetActive(true);
        restartNow = true;
        resetTime = Time.time + restartTime;
    }


}
