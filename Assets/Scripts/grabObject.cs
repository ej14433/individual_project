using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabObject : MonoBehaviour {

	GameObject grabbedObject;
	float grabbedObjectSize;

	private Animator _animator;

	void Start(){
		_animator = GetComponent<Animator> ();
	}

	GameObject GetObject(float range){

		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;

		if (Physics.Linecast (position, target, out raycastHit)) {
			return raycastHit.collider.gameObject;
		}
		else {
			return null;
		}
	}

	void TryGrab(GameObject grabObject) {

		if (grabObject == null || !CanGrab(grabObject)) {
			return;
		}

		grabbedObject = grabObject;
		grabbedObjectSize = grabObject.GetComponent<Renderer> ().bounds.size.magnitude;
	}

	bool CanGrab(GameObject candidate){
	
		return candidate.GetComponent<Rigidbody> () != null;
	
	}

	void Drop(){
		if (grabbedObject == null) {
			return;
		}

		if (grabbedObject.GetComponent<Rigidbody>() != null) {
		
			grabbedObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;

		}

		grabbedObject = null;

	}

	

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {

			if (grabbedObject == null) {
			
				TryGrab (GetObject (5));
			
			} else {
			
				Drop ();

			}
		}

		if (grabbedObject != null) {



			if (grabbedObject.name == "hatch") {

				_animator.Play ("open_hatch");

			} else {
				Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
				grabbedObject.transform.position = newPosition;	
			}
		}
		
	}
}
