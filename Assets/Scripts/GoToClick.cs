using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClick : MonoBehaviour {

	public GameObject player;

	public void GoToLocation(GameObject location) {
		player.transform.position = location.transform.position;
	}
}
