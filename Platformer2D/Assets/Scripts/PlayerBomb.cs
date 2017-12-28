using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBomb : MonoBehaviour {

    public static bool haveBomb;
    public GameObject bomb;
    public GameObject uiBomb;
    public AudioClip bombPickupAudio;
    public GameObject pickupSpawner;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButtonDown("Fire2") && haveBomb)
        {
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity).transform.SetParent(pickupSpawner.transform);

            uiBomb.GetComponent<Image>().color = new Color(255,255,255,0);

            haveBomb = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BombPickup")
        {
            Destroy(collision.gameObject);

            uiBomb.GetComponent<Image>().color = new Color(255, 255, 255, 255);

            haveBomb = true;

            GetComponent<AudioSource>().PlayOneShot(bombPickupAudio);
        }

    }
}
