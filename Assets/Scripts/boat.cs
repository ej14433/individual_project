﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour {

	private Rigidbody rbody;
	public float turnSpeed = 1000.0f;
	public float accSpeed = 1000.0f;
	public float prop_speed = 200.0f;
	public float tilt = 20.0f;
	public float bank = 20.0f;

	public GameObject engine;
	public GameObject boat_obj;
	public GameObject propellers;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		propellers.transform.eulerAngles = new Vector3 (0.0f, engine.transform.eulerAngles.y, propellers.transform.eulerAngles.z + v * prop_speed);
		engine.transform.eulerAngles = new Vector3 (boat_obj.transform.eulerAngles.x, boat_obj.transform.eulerAngles.y + 180.0f - h * 45.0f, boat_obj.transform.eulerAngles.z);
		if (v >= 0) {
			boat_obj.transform.eulerAngles = new Vector3 (-v * tilt, boat_obj.transform.eulerAngles.y, -h * v * bank);
		}
		//boat_obj.transform.eulerAngles = new Vector3 (0f, boat_obj.transform.eulerAngles.y, 0f);
		rbody.AddTorque (0f, h * v * turnSpeed * Time.deltaTime, 0.0f);

		rbody.AddForce (transform.forward * accSpeed * v * Time.deltaTime);

		boat_obj.transform.position = new Vector3 (boat_obj.transform.position.x, 1.0f, boat_obj.transform.position.z);
		engine.transform.eulerAngles = new Vector3 (-boat_obj.transform.eulerAngles.x, boat_obj.transform.eulerAngles.y + 180.0f - h * 45.0f, boat_obj.transform.eulerAngles.z);

	}
}

