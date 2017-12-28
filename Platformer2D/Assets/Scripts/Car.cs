using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public float speed;
    Vector3 rotate;

   
	// Use this for initialization
	void Start () {

       rotate = new Vector3(gameObject.transform.localScale.x  , gameObject.transform.localScale.y, gameObject.transform.localScale.z);
      
    }
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Transform>().position.x > 42 || GetComponent<Transform>().position.x < -42)
        {
            rotate.x *= -1;

            gameObject.transform.localScale = rotate;
        }
        GetComponent<Rigidbody2D>().transform.Translate(new Vector3(speed * Time.deltaTime * rotate.x *-1, 0f, 0f));
	}
}
