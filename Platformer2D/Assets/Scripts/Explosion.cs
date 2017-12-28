using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {


    public AudioClip explosionAudioClip;

	// Use this for initialization
	void Start () {

        GetComponentInParent<AudioSource>().PlayOneShot(explosionAudioClip);
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, 0.1f);
	}

    
}
