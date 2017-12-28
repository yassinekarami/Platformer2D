using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public AudioClip[] enemyDeathAudioClip;
    public Sprite deadEnemy;

    private float direction;


    Vector3 enemyScale;
    GameObject score;
    
    

    // Use this for initialization
    void Start()
    {
        
        direction = 1;
        enemyScale = GetComponent<Transform>().localScale;

        score = GameObject.Find("Score");



    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector3(direction * 700f * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponentInParent<AudioSource>().PlayOneShot(enemyDeathAudioClip[Random.Range(0, enemyDeathAudioClip.Length)]);

            Destroy(gameObject);

            score.GetComponent<Score>().UpdateScore(25);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            direction *= -1;

            enemyScale.x *= direction;

            GetComponent<Transform>().localScale = enemyScale;
        }
        if (collision.gameObject.tag == "ExplosionFX")
        {
            Destroy(gameObject);

            score.GetComponent<Score>().UpdateScore(50);
        }

    }

}
