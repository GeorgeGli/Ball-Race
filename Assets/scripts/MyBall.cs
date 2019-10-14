using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyBall : MonoBehaviour {

    public  int position;
    public Text positionText;
    string pos;
	private Rigidbody rb;
    public int score;
    float scoreSum;
    public Text gmScore;
     int frames;
    public int framesNum;
    bool onGround;
     AudioSource crash;
    int scoreFlag;
    public GameObject gameOver;
    public Text goMsg;
    public GameObject[] oppPositions;


    void Start () {
        for (int i = 0; i < oppPositions.Length; i++)
        {

            oppPositions[i].gameObject.SetActive(true);
        }
        scoreFlag = 0;
        onGround = true;
        frames = 0;
        score = 0;
        position = 2;

        GetComponent<Rigidbody>().AddForce(0f, 0f, 10000f, ForceMode.Force);
        crash=GetComponent<AudioSource>();

        pos = position.ToString();
        positionText.text = (pos + "th");
    }

  

    void Update () {
        
        if (scoreFlag == 0) {  //upologismos score
            scoreSum += 0.1f;
        }
       
        score = Mathf.RoundToInt(scoreSum);
        string gameScore = score.ToString();
        gmScore.text = ("Score: "+gameScore);

        pos = position.ToString();
        positionText.text = (pos + "th");

        float x = GetComponent<Transform>().position.x;
       
        if (Input.GetKey("right"))  //deksia aristera 
        {
            if (x < 9)   //check an vrisketai sta oria ths pistas
            {
               
                transform.Translate(0.3f, 0, 0);

            }
           
        }
        if (Input.GetKey("left"))
        {
            if (x > -9)
            {
                transform.Translate(-0.3f, 0, 0);
            }
           
        }


       if (onGround)
        {
            if (frames == framesNum)
            {

                GetComponent<Rigidbody>().AddForce(0f, 0f, 110f, ForceMode.Force);
                frames = 0;

            }

            frames++;

            if (Input.GetKeyDown("space"))  //jump
            {

                GetComponent<Rigidbody>().AddForce(0f, 85f, 0f, ForceMode.Impulse);
                onGround = false;

            }

        }
        else
        {
            GetComponent<Rigidbody>().AddForce(0f, -5f, 0f, ForceMode.Impulse);
        }
            

    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag =="obstacle" || col.gameObject.tag=="wreckingBall" || col.gameObject.tag == "ball")  // end of the game otan xtuphsei
        {
            Time.timeScale = 0;

            for (int i = 0;i< oppPositions.Length; i++){

                oppPositions[i].gameObject.SetActive(false);
            }

            crash.Play();
            if (position != 1)
            {
                
                goMsg.text = ( "Game Over!");
            }
            else if (position == 1)
            {
                goMsg.text = ("You collect "+score+" points!");
            }
            gameOver.SetActive(true);
            
            scoreFlag = 1;
        }
      
        if (col.gameObject.tag == "road")
        {
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider col)   //speed boost
    {
        if (col.gameObject.tag == "boost")
        {
            
            GetComponent<Rigidbody>().AddForce(0f, 0f, 180f, ForceMode.Impulse);
        }
    }
}
