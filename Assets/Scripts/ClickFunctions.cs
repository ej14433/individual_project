using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunctions : MonoBehaviour {

	public GameObject cube;
	public float sec;

	public void SetInactiveFor(float sec) {
		
		cube.GetComponent<Renderer> ().enabled = !GetComponent<Renderer> ().enabled;

		Debug.Log ("Waiting...");

		StartCoroutine(Wait ());
	}

	IEnumerator Wait(){

		yield return new WaitForSeconds (sec);

		cube.GetComponent<Renderer> ().enabled = !GetComponent<Renderer> ().enabled;

		Debug.Log ("Done.");
	}
}
