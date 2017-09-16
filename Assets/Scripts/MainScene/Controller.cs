using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public GameObject player;
	public GameObject finger;

	private Vector3 clickedPos;
	private Vector3 releasePos;
	private bool isClick;
	public Vector3 prePosition;
	public bool preBoneActive;

	// Use this for initialization
	void Start () {
		this.isClick=false;
		this.preBoneActive=false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(this.finger.active);
		if(this.finger.active==false){
			this.preBoneActive=false;
			return;
		}else{
			if(this.preBoneActive==true){
				Debug.Log("move:"+(finger.transform.position-prePosition)*200);
				this.player.GetComponent<Rigidbody>().AddForce((finger.transform.position-prePosition)*200);
			}

			this.prePosition=this.finger.transform.position;
			this.preBoneActive=true;
		}
		

		
		
		

		if(Input.GetMouseButtonDown(0)){
			this.clickedPos=Input.mousePosition;
			this.isClick=true;
			Debug.Log(this.clickedPos);
		}

		if(Input.GetMouseButton(0)){
			this.player.GetComponent<Rigidbody>().velocity=Vector3.zero;
			this.player.GetComponent<Rigidbody>().AddForce((clickedPos-Input.mousePosition)*-10);
		}

		if(Input.GetMouseButtonUp(0)){
			this.releasePos=Input.mousePosition;

			this.player.GetComponent<Rigidbody>().AddForce((clickedPos-releasePos)*10);
		}

	}
}
