using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour {

	public List<Transform> targetObjects;

	public Transform targetTrans;

	public float moveSpeed;

	private Rigidbody catRigidbody;
	private NavMeshAgent catAgent;

	// Use this for initialization
	public 
	void Start () {
		catRigidbody = this.GetComponent<Rigidbody>();
		catAgent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		//Choose Target
		var minDis = float.MaxValue;
		foreach (var obj in targetObjects) {
			var tmpDis = Vector3.Distance(this.transform.position, obj.transform.position);
			if (tmpDis < minDis) {
				minDis = tmpDis;
				targetTrans = obj;
			}
		}
		//Move to Target
		catAgent.SetDestination(targetTrans.position);
		
	}
}
