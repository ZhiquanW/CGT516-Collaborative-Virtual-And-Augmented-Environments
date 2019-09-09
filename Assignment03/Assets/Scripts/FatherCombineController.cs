using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherCombineController : MonoBehaviour
{
    public GameObject[] children;
    public BoxCollider[] boxes;
    public bool isAttached;
    public int[] preTarget;
    public int[] postTarget;
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
            this.transform.position = GameManager.instance.preObjPos;

            for (int i = 0; i < boxes.Length; ++i) {
                boxes[i].size = children[i].GetComponent<BoxCollider>().size;
                boxes[i].center = children[i].transform.position - this.transform.position;
                children[i].transform.SetParent(this.transform);
                Destroy(children[i].GetComponent<BoxCollider>());
                Destroy(children[i].GetComponent<Rigidbody>());
            }
            isAttached = !isAttached;
            this.gameObject.AddComponent<Rigidbody>();
            this.GetComponent<Rigidbody>().useGravity = false;
            GameManager.instance.DeactivateTargetObjects(preTarget);
            GameManager.instance.DeactivateTargetObjects(postTarget);
            foreach(var i in preTarget) {
                GameManager.instance.gameObjArr[i].GetComponent<TargetObjController>().isTarget = false;

            }


        }
    }
}
