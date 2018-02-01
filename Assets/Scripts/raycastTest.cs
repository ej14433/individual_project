using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastTest : MonoBehaviour {

	GameObject item;
	float item_size;
	bool is_open;

	public GameObject hatch;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = hatch.GetComponent<Animator> ();
		is_open = false;
	}

	GameObject GetItem (float range){
		Vector3 position = gameObject.transform.position;
		RaycastHit hit;
		Vector3 target = position + Camera.main.transform.forward * range;

		if (Physics.Linecast (position, target, out hit)) {
			return hit.collider.gameObject;
		} else {
			return null;
		}
	}


	// Update is called once per frame
	void Update () {

		item = GetItem (5);

		if (item != null) {
			
			if (item.name == "hatch" && is_open == true) {
				if (Input.GetMouseButtonDown (0)) {
					anim.Play ("close_hatch");
				}
				is_open = false;
			}

			if (item.name == "hatch" && is_open == false) {
				if (Input.GetMouseButtonDown (1)) {
					anim.Play ("open_hatch");
				}
				is_open = true;
			}

			if (item.name == "engine") {
				if (Input.GetMouseButton (1)) {
					
				}
			}
		}
	}
}
