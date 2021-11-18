using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //Camera follows this
    public float smoothing;//How quickly the camera follows

    private Vector3 offset;//difference between character and camera
    private float lowY; //lowest Y position for the camera to go to.

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y - 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            if (transform.position.y < -30f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

    }
}
