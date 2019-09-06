using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherCombineController : MonoBehaviour
{
    public GameObject[] children;
    public BoxCollider[] boxes;
    public bool isAttached;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void setBoxCollider() {
        if (!isAttached) {
            for (int i = 0; i < boxes.Length; ++i) {
                Debug.Log("3");
                boxes[i].size = children[i].GetComponent<BoxCollider>().size;
                boxes[i].center = children[i].transform.position - this.transform.position;
                children[i].transform.SetParent(this.transform);
                Destroy(children[i].GetComponent<BoxCollider>());
                Destroy(children[i].GetComponent<Rigidbody>());
            }
            isAttached = !isAttached;
            this.gameObject.AddComponent<Rigidbody>();
            this.GetComponent<Rigidbody>().useGravity = false;
            
        }
       


    }
}
