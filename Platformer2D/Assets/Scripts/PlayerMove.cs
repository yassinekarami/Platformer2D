using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public AudioClip[] jumpAudioClip;
    public AudioClip[] tauntsAudioClip;
    

    private float horizontalMove;
    private float speed;
    private float direction;
    private float time = 0f;
    private bool facingRight =  true;
    private bool grounded = false ;
    private bool jump = false;
    private bool move = true;



    public float jumpHeight;

    private Transform groundCheck;

	// Use this for initialization
	void Awake () {

        groundCheck = transform.Find("groundCheck");

    }
	
	// Update is called once per frame
	void Update () {
        
        if (TauntsProbability() < 50 && time > 5)
        {
            GetComponent<AudioSource>().PlayOneShot(RandomAudioClip(tauntsAudioClip));

            time = 0f;
        }

        grounded = Physics2D.Linecast(gameObject.transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (grounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (grounded)
        {
            move = true;
        }
                  
    }

    private void FixedUpdate()
    {
        time = time + Time.deltaTime;

        horizontalMove = Input.GetAxis("Horizontal");

        if (move)
        {
            Move(horizontalMove);
        }
        
        if (jump)
        {
            GetComponent<AudioSource>().PlayOneShot(RandomAudioClip(jumpAudioClip));

            GetComponent<Animator>().SetTrigger("Jump");

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight));

            jump = false;

            move = false;

        }
        
        Flip(horizontalMove);
    }

    private float MoveDirection(float h)
    {
        if (h > 0)
        {
            direction = 1;

        }

        else if (h < 0)
        {
            direction = -1;

        }
            
        return direction;
    }

    private void Move(float h)
    {
        speed = 800f;
        

        if (h == 0)
        {
            speed = 0f;
        }
      
        
        GetComponent<Animator>().SetFloat("Speed", speed);

        GetComponent<Rigidbody2D>().velocity = new Vector3(speed * MoveDirection(h) * Time.deltaTime , 0f , 0f);
     
    }


    private void Flip(float h)
    {
        Vector3 rotate = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
       

        if (facingRight && MoveDirection(h) < 0 || !facingRight && MoveDirection(h) > 0) 
        {
            rotate.x = rotate.x * -1;

            facingRight = !facingRight;

            gameObject.transform.localScale = rotate;
        
        }
       
    }


    private AudioClip RandomAudioClip(AudioClip[] array)
    {
        int index = Random.Range(0, array.Length);

        return array[index];
    }

    private int TauntsProbability()
    {
        return Random.Range(0, 100);
    }
}
