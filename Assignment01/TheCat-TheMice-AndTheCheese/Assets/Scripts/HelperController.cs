using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperController : MonoBehaviour {

	// Use this for initialization
	public bool isHold;
	public Vector3 targetPos;
	public float moveSpeed;
	private Rigidbody helperRigidbody;
	void Start () {
		helperRigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (isHold) {
				isHold = false;
			}
			else {
				Vector3 screenPos = Input.mousePosition;
				Ray tmpRay = Camera.main.ScreenPointToRay(screenPos);
				RaycastHit tmpHit;
				if (Physics.Raycast(tmpRay, out tmpHit)) {
					if (tmpHit.collider.gameObject.CompareTag("Helper")) {
						isHold = true;
					}
				}
			}
		}

		if (isHold) {
			Vector3 screenPos = Input.mousePosition;
			Ray tmpRay = Camera.main.ScreenPointToRay(screenPos);
			RaycastHit tmpHit;
			if (Physics.Raycast(tmpRay, out tmpHit)) {
				if (tmpHit.collider.gameObject.CompareTag("Terrain")) {
					targetPos= tmpHit.point;
				}
			}

			Vector3 tmpDir = Vector3.Normalize(targetPos - this.transform.position);
			this.helperRigidbody.velocity = tmpDir * moveSpeed;
		}
	}

}
