using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbetController : MonoBehaviour
{
    public bool isPlugIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider colliderInfo) {
        if(colliderInfo.gameObject.name == "Key") {
            isPlugIn = true;
            UIManager.instance.UpdateInstruction();
        }
    }
}
