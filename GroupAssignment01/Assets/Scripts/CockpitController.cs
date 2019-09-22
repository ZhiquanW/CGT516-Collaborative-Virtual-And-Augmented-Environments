using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitController : MonoBehaviour {
    public GameObject cockpitRobe;

    public float cockliftSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LiftCockpit() {
        this.transform.position += cockliftSpeed * Time.deltaTime * Vector3.up;
        cockpitRobe.transform.localScale -= cockliftSpeed * Time.deltaTime * Vector3.up;
    }
}
