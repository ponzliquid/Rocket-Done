using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScenePlayer : MonoBehaviour
{
    public List<GameObject> startToSelectFalse = new List<GameObject>();
    public List<GameObject> startToSelectTrue = new List<GameObject>();


    public void OnClickStart(){
        foreach (GameObject gb in startToSelectFalse){
            gb.SetActive(false);
        }

        foreach(GameObject gb in startToSelectTrue){
            gb.SetActive(true);
        }
    }
}


