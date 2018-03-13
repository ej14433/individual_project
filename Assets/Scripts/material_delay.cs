using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material_delay : MonoBehaviour {

	private Renderer rend;
	private Material material;

	public void ChangeSkin(Material m){

		rend = GetComponent<Renderer> ();
		material = m;
		rend.material = material;

	}
}
