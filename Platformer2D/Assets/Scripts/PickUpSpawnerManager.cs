using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawnerManager : MonoBehaviour {

    public GameObject[] pickUp;
    public GameObject[] spawnPoint;

    float timer;
    GameObject instantiateGameObject;
    // Use this for initialization
    void Start () {

        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer >= 5f)
        { 

            instantiateGameObject = Instantiate(pickUp[RandomIndex(pickUp)], spawnPoint[RandomIndex(spawnPoint)].transform.position, Quaternion.identity);

            instantiateGameObject.transform.SetParent(gameObject.transform);

            timer = 0f;
        }

        Destroy(instantiateGameObject, 8f);

    }

    private int RandomIndex(GameObject[] array)
    {
        return Random.Range(0, array.Length);
    }
 

}
