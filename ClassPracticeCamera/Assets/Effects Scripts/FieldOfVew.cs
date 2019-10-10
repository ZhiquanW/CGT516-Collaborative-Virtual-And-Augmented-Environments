using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVew : MonoBehaviour
{
    public float maxFOV = 60.0f;
    public float minFOV = 30.0f;
    public float speedFOV = 1.0f;
    public Transform target;
    public Camera myCam;
    public float initialFOV;
    public float startTime;
    public bool isFOV;

    // Start is called before the first frame update
    void Start()
    {
        initialFOV= myCam.fieldOfView;
        myCam = this.GetComponent<Camera>();        
    }

    void Update()
    {
        //myCam.transform.LookAt(target);
        if (isFOV)
        {
            float t = Mathf.Sin(Time.time - startTime) * speedFOV;
            myCam.fieldOfView = Mathf.Lerp(maxFOV, minFOV, t);
        }
        else
        {
            startTime = Time.time;
            myCam.fieldOfView = initialFOV;
        }
    }
}
