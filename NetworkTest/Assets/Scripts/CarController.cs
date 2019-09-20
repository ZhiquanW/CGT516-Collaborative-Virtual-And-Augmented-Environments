using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CarController : MonoBehaviour {
    public float moveSpeed;

    public float rotateSpeed;
    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!this.GetComponent<NetworkIdentity>().isLocalPlayer) {
            return;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        transform.Rotate(0.0f,h*rotateSpeed*Time.deltaTime,0.0f);
        transform.Translate(0.0f,0.0f,v*moveSpeed*Time.deltaTime);
    }
}
