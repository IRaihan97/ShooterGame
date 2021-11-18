using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public float restartTime;
    bool restartNow = false;
    float resetTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (restartNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void restartTheGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
