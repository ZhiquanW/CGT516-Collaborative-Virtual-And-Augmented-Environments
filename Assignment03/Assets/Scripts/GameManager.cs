using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] gameObjArr;
    public Camera mainCamera;
    public GameObject rabbetObj;
    public GameObject keyObj;

    Vector3 prePos = new Vector3(0, 0, 0);
    public Vector3 preObjPos;
    GameObject chosenObj;
    public AudioSource audioManager;
    public static GameManager instance;
    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        ActivateTargetObjects(new int[] { 2, 3 });
        UIManager.instance.UpdateInstruction();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 screenPos = Input.mousePosition;
            preObjPos = screenPos;
            Ray tmpRay = Camera.main.ScreenPointToRay(screenPos);
            RaycastHit tmpHit;
            if (Physics.Raycast(tmpRay, out tmpHit)) {
                if (tmpHit.collider.gameObject.CompareTag("CUBE")) {
                    GameObject chosenObj = tmpHit.collider.gameObject;
                    float mZCoord = Camera.main.WorldToScreenPoint(chosenObj.transform.position).z;
                    screenPos.z = mZCoord;
                    preObjPos = Camera.main.ScreenToWorldPoint(screenPos);
                }
            }
        }
        if (Input.GetMouseButton(0)) {
            Vector3 screenPos = Input.mousePosition;
            Ray tmpRay = Camera.main.ScreenPointToRay(screenPos);
            RaycastHit tmpHit;
            if (Physics.Raycast(tmpRay, out tmpHit)) {
                if (tmpHit.collider.gameObject.CompareTag("CUBE")) {
                    chosenObj = tmpHit.collider.gameObject;
                    float mZCoord = Camera.main.WorldToScreenPoint(chosenObj.transform.position).z;
                    screenPos.z = mZCoord;
                    Vector3 mWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
                    Vector3 offsetPos = mWorldPos - preObjPos;
                    chosenObj.transform.position += offsetPos;
                    preObjPos = mWorldPos;

                }
            }

        }
        if (Input.GetKey(KeyCode.R)) {
            chosenObj.GetComponent<Rigidbody>().AddTorque(Vector3.forward * 10);
            if(UIManager.instance.index == 2) {
                UIManager.instance.UpdateInstruction();
                rabbetObj.GetComponent<TargetObjController>().isTarget = true;
                keyObj.GetComponent<TargetObjController>().isTarget = true;
                gameObjArr[2].GetComponent<TargetObjController>().isDone = true;
                gameObjArr[3].GetComponent<TargetObjController>().isDone = true;
            }else if (UIManager.instance.index == 4) {
              
                rabbetObj.GetComponent<TargetObjController>().isTarget = false;
                keyObj.GetComponent<TargetObjController>().isTarget = false;
                gameObjArr[0].GetComponent<TargetObjController>().isDone = true;
                gameObjArr[1].GetComponent<TargetObjController>().isDone = true;
            }
        }
        //scale 
        float inputScroll = Input.mouseScrollDelta.y;
        if (inputScroll != 0) {
            Camera.main.fieldOfView *= 1 - 0.05f * inputScroll;
        }
        //rotate camera
        Vector3 fwd = mainCamera.transform.forward;
        fwd.Normalize();
        if (Input.GetMouseButtonDown(1)) {
            Vector3 screenPos = Input.mousePosition;
            prePos = screenPos;
        }

        if (Input.GetMouseButton(1)) {
            Vector3 screenPos = Input.mousePosition;
            Vector3 preOffset = screenPos - prePos;
            prePos = screenPos;
            Vector3 targetPos = new Vector3(Screen.width / 2, Screen.height / 2, 0) + preOffset;
            Ray tmpRay = Camera.main.ScreenPointToRay(targetPos);
            mainCamera.transform.forward = tmpRay.direction;
        }

        Vector3 fwdOffset = mainCamera.transform.forward * Input.GetAxisRaw("Vertical")*0.1f ;
        Vector3 hztOffst = mainCamera.transform.right * Input.GetAxisRaw("Horizontal")*0.1f ;
        mainCamera.transform.position += fwdOffset + hztOffst;

    }

    void GetMouseWorldPos() {

    }

    public void ActivateTargetObjects(int [] _indexs) {
        foreach(var i in _indexs) {
            gameObjArr[i].GetComponent<TargetObjController>().isTarget = true;
        }
    }
    public void DeactivateTargetObjects(int[] _indexs) {
        foreach (var i in _indexs) {
            gameObjArr[i].GetComponent<TargetObjController>().isTarget = false;
        }
    }
}