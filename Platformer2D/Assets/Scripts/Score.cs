using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    private static float point = 0f;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int value)
    {
        point += value;
        gameObject.GetComponent<Text>().text = "SCORE" + " " + point;

       
    }
}
