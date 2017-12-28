using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject explosion;

    Transform heroDirection;

    float shootDirection;
    bool isShoot;

	// Use this for initialization
	void Start () {

        isShoot = false;

        heroDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().transform;
	}
	
	// Update is called once per frame
	void Update () {

        BulletDirection();

        gameObject.transform.Translate(Vector3.right * shootDirection * 25f * Time.deltaTime);
           
	}

    private void BulletDirection()
    {
        if (!isShoot)
        {
            shootDirection = heroDirection.localScale.x;
        }

        isShoot = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);

            GameObject explosionEffect = Instantiate(explosion, collision.transform.position, Quaternion.identity);

            Destroy(explosionEffect, 0.5f);
        }

    }
}
