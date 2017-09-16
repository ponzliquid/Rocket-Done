using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	
	//public GameObject planet;	// 引力の発生する星
	public float coefficient;	// 万有引力係数
	public float forceAbleDistance; // 力が及ぶ範囲

	//public GameObject[] planets;
	public List<GameObject> planets;

	public GameObject gravityField;
	private GameObject gravityFieldInstance;

	private bool isGravityArea;

	// Use this for initialization
	void Start () {
		//this.gravityField=Resources.Load("Prefabs/GravityField") as GameObject;
		this.gravityFieldInstance= Instantiate(this.gravityField.gameObject,this.transform);
		this.gravityFieldInstance.transform.localScale=new Vector3(this.forceAbleDistance*2,this.forceAbleDistance*2,1)/this.transform.localScale.x;
		this.gravityFieldInstance.transform.parent=this.transform;
		this.gravityFieldInstance.transform.localPosition=new Vector3(0,0,1);
	}
	
	void FixedUpdate () {
		this.planets=new List<GameObject>(GameObject.FindGameObjectsWithTag("Planet"));
		this.planets.AddRange(new List<GameObject>(new List<GameObject>(GameObject.FindGameObjectsWithTag("Goal"))));
		//AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("Goal")));

		this.isGravityArea=false;
		foreach(GameObject planet  in this.planets){
			// 自分自身は計算の対象外
			if(planet==this.gameObject){
				continue;
			}
			
			// 星に向かう向きの取得
			Vector3 direction = planet.transform.position - transform.position;
			// 星までの距離の２乗を取得
			float distance = direction.magnitude;
			if(distance>planet.GetComponent<Planet>().forceAbleDistance){
				continue;
			}
			this.isGravityArea=true;

			distance *= distance;
			// 万有引力計算
			float gravity = coefficient * planet.GetComponent<Rigidbody>().mass * this.GetComponent<Rigidbody>().mass / distance;

			// 力を与える
			// Debug.Log(distance);
			this.GetComponent<Rigidbody>().AddForce(gravity * direction.normalized, ForceMode.Force);
		}

		// 重力波の影響を受けていなければ，減速させる
		if(this.isGravityArea==false){
			this.GetComponent<Rigidbody>().velocity*=0.98f;
		}
	}

	void OnCollisionEnter(Collision other){
		//Destroy(this.gameObject);
		Debug.Log("Enter");
		this.GetComponent<Rigidbody>().velocity=Vector3.zero;
	}

	void OnCollisionStay(Collision other){
		this.GetComponent<Rigidbody>().velocity=Vector3.zero;
	}
}
