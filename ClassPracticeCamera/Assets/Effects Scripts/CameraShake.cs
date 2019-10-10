using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cam;
    public float intensity = 0.1f;
    public float duration = 1.0f;
    public float shakeAbsorption = 1.0f;
    public bool isShake = false;
    public Vector3 startPosition;
    public float shakeDuration;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        startPosition = cam.localPosition;
        shakeDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShake)
        {
            if (duration > 0)
            {
                cam.localPosition = startPosition + Random.insideUnitSphere * intensity;
                duration -= Time.deltaTime * shakeAbsorption;
            }
            else
            {
                isShake = false;
                duration = shakeDuration;
                cam.localPosition = startPosition;
            }
        }
    }
}
