using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] gameObjArr;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 screenPos = Input.mousePosition;
            Ray tmpRay = Camera.main.ScreenPointToRay(screenPos);
            RaycastHit tmpHit;
            if (Physics.Raycast(tmpRay, out tmpHit)) {
                if (tmpHit.collider.gameObject.CompareTag("CUBE")) {
                    GameObject chosenObj = tmpHit.collider.gameObject;
                    Debug.Log(chosenObj.name);
                    float mZCoord = Camera.main.WorldToScreenPoint(chosenObj.transform.position).z;
                    screenPos.z = mZCoord;
                    Vector3 mWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
                    chosenObj.transform.position = mWorldPos;
                }
            }

        }
        if (Input.GetKey(KeyCode.R)) {
            gameObjArr[0].GetComponent<Rigidbody>().AddTorque(Vector3.forward * 10);
        }
    }

    void GetMouseWorldPos() {

    }
}