using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour {

	public Transform target;
	public Transform thisGameObject;
	public float speed;
	void Update() {
		Vector3 targetDir = target.position - thisGameObject.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(thisGameObject.forward, targetDir, step, 1.0F);
		Debug.DrawRay(thisGameObject.position, newDir, Color.red);
		Debug.Log (thisGameObject.position);
		thisGameObject.rotation = Quaternion.LookRotation(newDir);
		Debug.Log (thisGameObject.rotation);

	}
}
