using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour {
    public GameObject targetObj;
    public Vector3 offsetPos;
    public float moveSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        this.transform.position = Vector3.Lerp(this.transform.position, targetObj.transform.position+offsetPos, 0.1f);
        this.transform.Rotate(this.transform.up, rotateSpeed * Time.deltaTime);
    }
}