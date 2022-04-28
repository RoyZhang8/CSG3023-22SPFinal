/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    [Header("General Settings")]
    private AudioSource audioSource;
    public AudioClip projectSound;
    public Text ballTxt;
    private bool isInPlay;
    public int numberOfBalls;
    public GameObject paddle;
    public GameObject ball;
    public int score;
    public Text scoreTxt;

    [Header("Ball Settings")]
    private Rigidbody rb;
    public float intialForce;
    public float speed;




    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }//end Awake()


        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        ballTxt.SendMessage ("Balls: " + numberOfBalls);
        scoreTxt.SendMessage("Score: " + score);
        if(!isInPlay)
        {
            ball.transform.position = paddle.transform.position;
           
        }
        if(!isInPlay && Input.GetKeyDown(KeyCode.Space))
        {
            isInPlay = true;
            Move();
        }

    }//end Update()

    void Move()
    {
        rb.AddForce(intialForce, intialForce, intialForce);
    }


    private void LateUpdate()
    {
        if (isInPlay)
        {
            rb.velocity = speed * rb.velocity.normalized;
        }

    }//end LateUpdate()


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(projectSound);
        GameObject other = collision.gameObject;
        if(other.tag == "Brick")
        {
            score += 100;
            Destroy(other);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OutBounds")
        {
            numberOfBalls--;
        }
        if(numberOfBalls > 0)
        {
            SetStartingPos();
        }
    }






}
