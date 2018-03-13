using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastTest : MonoBehaviour {

	GameObject item;
	float item_size;
	bool is_open;
	bool bag_open;
	public Canvas ui;

	private Animator anim;

	// Use this for initialization
	void Start () {
		is_open = false;
		bag_open = false;
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
			Debug.Log (item.name);
			if (item.name == "hatch" && is_open == true) {
				if (Input.GetMouseButtonDown (0)) {
					anim = item.GetComponent<Animator> ();
					anim.Play ("close_hatch");
					is_open = false;
				} 
			}
			if (item.name == "hatch" && is_open == false) {
				if (Input.GetMouseButtonDown (1)) {
					anim = item.GetComponent<Animator> ();
					anim.Play ("open_hatch");
					is_open = true;
				} 
			}
			if (item.tag == "Bag" && bag_open == true) {
				if (Input.GetMouseButtonDown (0)) {
					anim = item.GetComponent<Animator> ();
					anim.Play ("close_bag");
					bag_open = false;
				} 
			}
			if (item.tag == "Bag" && bag_open == false) {

				if (Input.GetMouseButtonDown (1)) {
					anim = item.GetComponent<Animator> ();
					anim.Play ("open_bag");
					bag_open = true;
				} 
			}
		}
	}
}
