﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour {

	private Rigidbody rbody;
	public float turnSpeed = 1000f;
	public float accSpeed = 1000f;
	public float prop_speed = 200f;
	public float tilt = 20f;

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

		propellers.transform.eulerAngles = new Vector3 (0f, engine.transform.eulerAngles.y, propellers.transform.eulerAngles.z + v * prop_speed);
		engine.transform.eulerAngles = new Vector3 (0f, boat_obj.transform.eulerAngles.y - h * 45f, boat_obj.transform.eulerAngles.z);

		//boat_obj.transform.eulerAngles = new Vector3 (0f, boat_obj.transform.eulerAngles.y, 0f);
		rbody.AddTorque (0f, h * v * turnSpeed * Time.deltaTime, 0f);



		rbody.AddForce (transform.forward * accSpeed * v * Time.deltaTime);

	}
}
