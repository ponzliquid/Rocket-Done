using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	
	//public GameObject planet;	// 引力の発生する星
	public float coefficient;	// 万有引力係数
	public float forceAbleDistance; // 力が及ぶ範囲

	public GameObject[] planets;

	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {
		this.planets=GameObject.FindGameObjectsWithTag("Planet");

		foreach(GameObject planet  in this.planets){
			// 自分自身は計算の対象外
			if(planet==this.gameObject)continue;

			// 星に向かう向きの取得
			Vector3 direction = planet.transform.position - transform.position;
			// 星までの距離の２乗を取得
			float distance = direction.magnitude;
			if(distance>planet.GetComponent<Planet>().forceAbleDistance)continue;

			distance *= distance;
			// 万有引力計算
			float gravity = coefficient * planet.GetComponent<Rigidbody>().mass * this.GetComponent<Rigidbody>().mass / distance;

			// 力を与える
			// Debug.Log(distance);
			this.GetComponent<Rigidbody>().AddForce(gravity * direction.normalized, ForceMode.Force);
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
