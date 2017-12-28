using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public GameObject hero;

    GameObject healthBar;
    Vector3 offset;
    // Use this for initialization
    void Start()
    {

        healthBar = GameObject.Find("HealthBar");
        offset = transform.position - hero.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = offset + hero.transform.position;

        if (healthBar.transform.localScale.x <= 0.5f && healthBar.transform.localScale.x >= 0.25f)
        {
              healthBar.GetComponent<SpriteRenderer>().color = new Color(57, 113, 43, 255);
        }
        
        else if (healthBar.transform.localScale.x < 0.25f)
        {
            healthBar.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        }

        

    } 
}
