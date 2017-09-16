using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour {

	public GameObject ExploadObj;

	void OnCollisionEnter(Collision c){
		//if (c.gameObject.tag != "Goal") {
			Destroy (c.gameObject);
			Instantiate (ExploadObj, c.gameObject.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			SceneManager.LoadScene("resultScene", LoadSceneMode.Additive);
		//}
	}

}
