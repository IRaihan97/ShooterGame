using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    // Start is called before the first frame update
    public float aliveTime;

    private void Awake()
    {
        Destroy(gameObject, aliveTime);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
