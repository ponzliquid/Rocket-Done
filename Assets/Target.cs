using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Target : MonoBehaviour {

	public GameObject controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag=="Goal"){
			SceneManager.LoadScene("resultScene", LoadSceneMode.Additive);
		}
	}
}
