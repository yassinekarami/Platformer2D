using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject explosionCircle;
    public AudioClip bombFuseAudioClip;

    Transform parent;
	// Use this for initialization
	void Start () {

        parent = gameObject.transform.parent;

        GetComponentInParent<AudioSource>().PlayOneShot(bombFuseAudioClip);

        GetComponentInChildren<ParticleSystem>().Play();
        Destroy(gameObject, 2f);
  
	}
	
	// Update is called once per frame
	void Update () {
		
        
	}

    private void OnDestroy()
    {
        Instantiate(explosionCircle, gameObject.transform.position, Quaternion.identity).transform.SetParent(parent);
    }

    

}
