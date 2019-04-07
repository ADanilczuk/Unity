using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_controller : MonoBehaviour {

    private float x_d;
    private float z_d;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x_d= Random.Range(0,5);
        z_d= Random.Range(0,5);
        transform.Rotate(new Vector3(x_d, 0, z_d));
	}
}
