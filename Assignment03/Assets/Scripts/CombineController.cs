using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineController : MonoBehaviour
{
    public FatherCombineController father;
    public BoxCollider combineCollider;
    public bool isAttached;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnTriggerEnter(Collider colliderInfo) {
        if (colliderInfo.name == "Combine11") {
            father.setBoxCollider();
            UIManager.instance.UpdateInstruction();
        }
    }
}
