using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer[] rendererList;
    public UIManager UI;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 screenPos = Input.mousePosition;

            Ray tmpRay = Camera.main.ScreenPointToRay(screenPos);

            RaycastHit tmpHit;

            if (Physics.Raycast(tmpRay, out tmpHit))
            {
                Debug.Log(tmpHit.collider.gameObject.name);
                if (tmpHit.collider.gameObject.name == "body")
                {
                    tmpHit.collider.gameObject.GetComponent<Renderer>().material.SetTexture("1",UI.)


                }

            }

        }

    }



}

