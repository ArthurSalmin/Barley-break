using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberScript : MonoBehaviour {
    public bool status = true;
	// Use this for initialization
	void Start () {
        if (gameObject.transform.name == "16")
        {
            status = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
