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

	public bool useLeapMotion;
	public float leapSpeed;

	public GameObject clickecPosObject;
	public GameObject sphereObj;

	public GameObject dragPosObject;
	public GameObject sphereObj2;

	// Use this for initialization
	void Start () {
		this.isClick=false;
		this.preBoneActive=false;
	}

	private void MoveLeapMotion(){
		if(this.dragPosObject!=null)Destroy(this.dragPosObject.gameObject);
		Debug.Log(this.finger.active);
		if(this.finger.active==false){
			this.preBoneActive=false;
			if(this.clickecPosObject!=null){
				Destroy(this.clickecPosObject.gameObject);
			}
			return;
		}else{
			if(this.preBoneActive==true){
				// アクティブ中
				Debug.Log("move:"+(finger.transform.localPosition-prePosition)*40);
				this.player.GetComponent<Rigidbody>().AddForce((finger.transform.localPosition-prePosition).normalized*this.leapSpeed);

				//this.dragPosObject= Instantiate(this.sphereObj2.gameObject,this.finger.transform);
				//this.dragPosObject.transform.parent=null;

				// アクティブになった瞬間
				this.prePosition=this.finger.transform.localPosition;
				//this.clickecPosObject=Instantiate(this.sphereObj.gameObject,this.finger.transform);
				//this.clickecPosObject.transform.parent=null;
				this.preBoneActive=true;
			}else{// アクティブになった瞬間
				this.prePosition=this.finger.transform.localPosition;
				//this.clickecPosObject=Instantiate(this.sphereObj.gameObject,this.finger.transform);
				//this.clickecPosObject.transform.parent=null;
				this.preBoneActive=true;
			}
		}
	}

	private void MoveMouse(){
		if(Input.GetMouseButtonDown(0)){
			this.clickedPos=Input.mousePosition;
			this.isClick=true;
			Debug.Log(this.clickedPos);
		}

		if(Input.GetMouseButton(0)){
			this.player.GetComponent<Rigidbody>().velocity=Vector3.zero;
			this.player.GetComponent<Rigidbody>().AddForce((clickedPos-Input.mousePosition)*-30);
		}

		if(Input.GetMouseButtonUp(0)){
			this.releasePos=Input.mousePosition;
			this.isClick=false;

			//this.player.GetComponent<Rigidbody>().AddForce((clickedPos-releasePos)*10);
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*if(this.useLeapMotion){
			this.MoveLeapMotion();	
		}else{
			this.MoveMouse();
		}*/
		
		this.MoveLeapMotion();
		this.MoveMouse();
		
		
		

		

	}
}
