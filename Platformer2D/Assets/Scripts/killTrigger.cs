using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killTrigger : MonoBehaviour {


    public GameObject splashAnimation;

    

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject splash = Instantiate(splashAnimation, collision.gameObject.transform.position, Quaternion.identity) as GameObject;

        Destroy(splash, 0.5f);

        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(RestartGame());
        }

    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
}
