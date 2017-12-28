using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public GameObject healthBar;
    public AudioClip[] hurtAudioClip;
    public AudioClip healthPickupAudio;

    Vector3 healthBarValue;
    GameObject cameraFollow;


    private bool invincibility = false;
    private bool isDead;


	// Use this for initialization
	void Start () {

        isDead = false;

        healthBarValue = healthBar.GetComponent<Transform>().localScale;

        cameraFollow = GameObject.Find("Main Camera");

        cameraFollow.GetComponent<CameraFollow>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            
            GetComponent<Animator>().SetTrigger("Die");

            GetComponent<CapsuleCollider2D>().enabled = false;

            GetComponent<PlayerMove>().enabled = false;

            GetComponent<Rigidbody2D>().gravityScale = 1f;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincibility)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GetComponent<AudioSource>().PlayOneShot(hurtAudioClip[Random.Range(0, hurtAudioClip.Length)]);

                DecreaseHealth(0.2f);
            }

            else if (collision.gameObject.tag == "ExplosionFX")
            {
                DecreaseHealth(0.4f);
            }


            healthBar.GetComponent<Transform>().localScale = healthBarValue;

            invincibility = true;

            StartCoroutine(DisableInvincibility());

        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "health")
        {
            Destroy(collision.gameObject);

            if (healthBarValue.x >= 1f)
            {
                healthBarValue.x += 0f;
            }

            else healthBarValue.x += 0.2f;

            healthBar.GetComponent<Transform>().localScale = healthBarValue;

            GetComponent<AudioSource>().PlayOneShot(healthPickupAudio);
        }

        else if (collision.gameObject.name == "killTrigger")
        {
            isDead = true;
        }
        
    }

    private void DecreaseHealth(float x)
    {
        if (x > healthBarValue.x)
        {
            healthBarValue.x = 0f;

            isDead = true;
        }

        else healthBarValue.x -= x;

    }

    IEnumerator DisableInvincibility()
    {
        yield return new WaitForSeconds(0.4f);
        invincibility = false;
    }
    
  
    
}
