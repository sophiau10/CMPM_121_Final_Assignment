using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float rotationSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse Y") < -.1)
        {
            transform.Rotate(Vector3.right * rotationSpeed);
        }
        if (Input.GetAxis("Mouse Y") > .1)
        {
            transform.Rotate(Vector3.right * -rotationSpeed);
        }
    }
}
