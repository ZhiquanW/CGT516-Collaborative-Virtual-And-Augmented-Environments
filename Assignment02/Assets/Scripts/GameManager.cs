using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Renderer[] rendererList;
    public GameObject carModel;
    public GameObject[] carPartList;
    public Vector3[] iniTransformList;
    public UIManager UI;
    public GameObject selectedPart;
    public Camera mainCamera;
    public static GameManager instance;
    public Mesh mesh;
    public bool meshChosen;
    void Awake() {
        instance = this;
    }
    // Use this for initialization
    void Start() {
        for (int i = 0; i < carPartList.Length; ++i) {
            iniTransformList[i] = carPartList[i].transform.position;
        }
    }

    Vector3 preMousePos;
    // Update is called once per frame
    void Update() {
        float inputScroll = Input.mouseScrollDelta.y;
        if (inputScroll != 0) {
            Camera.main.fieldOfView *= 1+0.1f * inputScroll;
        }

        //carModel.transform.localScale *= (1+Input.mouseScrollDelta.y);
        Vector3 fwd = mainCamera.transform.forward;
        fwd.Normalize();
        if (Input.GetMouseButton(1)) {
            Vector3 vaxis = Vector3.Cross(fwd, Vector3.right);
            carModel.transform.Rotate(vaxis, -10*Input.GetAxis("Mouse X"), Space.World);
            Vector3 haxis = Vector3.Cross(fwd, Vector3.up);
            carModel.transform.Rotate(haxis, -10*Input.GetAxis("Mouse Y"), Space.World);

        }
        if (Input.GetMouseButtonDown(0)) {

            Vector3 screenPos = Input.mousePosition;

            Ray tmpRay = Camera.main.ScreenPointToRay(screenPos);

            RaycastHit tmpHit;

            if (Physics.Raycast(tmpRay, out tmpHit)) {
                selectedPart = tmpHit.collider.gameObject;
                Debug.Log(tmpHit.collider.gameObject.name);
                foreach (var obj in carPartList) {
                    if (selectedPart == obj) {
                        if (UI.colorChosen != -1) {
                            tmpHit.collider.gameObject.GetComponent<Renderer>().material.color = UI.colorList[UI.colorChosen];
                        } else if (UI.textureChosen != -1) {
                            tmpHit.collider.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", UI.textureList[UI.textureChosen].texture);

                        } else if (UI.activeReplace) {
                            if (!meshChosen) {
                                mesh = tmpHit.collider.gameObject.GetComponent<MeshFilter>().mesh;
                            } else {
                                tmpHit.collider.gameObject.GetComponent<MeshFilter>().mesh = mesh;
                            }
                            meshChosen = !meshChosen;
                        } 
                    }
                }

            }

        }

    }



}
