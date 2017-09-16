using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fowardCamera : MonoBehaviour {

	public GameObject player;
	public GameObject mcamera;
	
	// Update is called once per frame
	void Update () {
		mcamera.transform.localPosition = Vector3.MoveTowards(mcamera.transform.localPosition,new Vector3(player.transform.localPosition.x ,player.transform.localPosition.y,-6), 2.0f * Time.deltaTime);

	}
}
