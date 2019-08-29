using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHelperController : MonoBehaviour {

	public float moveSpeed;
	public GameObject playerObj;
	public Vector3 targetPos;
	public GameObject[] catArray;

	private Rigidbody aHelperRididbody;
	// Use this for initialization
	void Start () {
		aHelperRididbody = this.GetComponent<Rigidbody>();
		catArray = GameObject.FindGameObjectsWithTag("Cat");
	}
	
	// Update is called once per frame
	void Update () {
		float minDis = float.MaxValue;
		foreach (var cat in catArray) {
			float tmpDis = Vector3.Distance(cat.transform.position, playerObj.transform.position);
			if (tmpDis < minDis) {
				minDis = tmpDis;
				targetPos = (cat.transform.position + playerObj.transform.position) / 2;

			}
		}

		aHelperRididbody.velocity = Vector3.Normalize(targetPos - this.transform.position) * moveSpeed;

	}
}
