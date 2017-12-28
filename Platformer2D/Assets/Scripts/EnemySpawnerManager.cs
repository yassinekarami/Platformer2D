using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour {


    public GameObject[] enemy;
    public GameObject[] spawnPoint;

    private float timer;
    private int index;
	// Use this for initialization
	void Start () {

        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer >= 0.75f)
        {
            index = RandomIndex(spawnPoint);

            GameObject instantiate = Instantiate(enemy[RandomIndex(enemy)] , spawnPoint[index].transform.position , Quaternion.identity) as GameObject;

            instantiate.transform.SetParent(gameObject.transform);

            spawnPoint[index].GetComponentInChildren<ParticleSystem>().Play();

            timer = 0f;
        }
    
	}

    private int RandomIndex(GameObject[] array)
    {
        return Random.Range(0, array.Length);
    }
}
