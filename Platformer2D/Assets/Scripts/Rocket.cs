using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Transform heroDirection;

    public GameObject rocket;


	// Use this for initialization
	void Start () {

        heroDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().transform;


    }

    // Update is called once per frame
    void Update () {
		
        if (Input.GetButtonDown("Fire1") )
        {
            GameObject shoot = Instantiate(rocket, GetComponentInParent<Transform>().position, Quaternion.identity) as GameObject;

            shoot.transform.localScale = new Vector3(heroDirection.localScale.x, shoot.transform.localScale.y, shoot.transform.localScale.z);       

        }
	}
}
