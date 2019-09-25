using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L)) {
            this.transform.Translate(10*Time.deltaTime*Vector3.forward,Space.World);
        }else if (Input.GetKey(KeyCode.J)) {
            this.transform.Translate(10*Time.deltaTime*Vector3.back,Space.World);
        }else if (Input.GetKey(KeyCode.I)) {
            this.transform.Rotate(10*Time.deltaTime*Vector3.right);
        }else if (Input.GetKey(KeyCode.K)) {
            this.transform.Rotate(-10*Time.deltaTime*Vector3.right);

        }
    }
}
