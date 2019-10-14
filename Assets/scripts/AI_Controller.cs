using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Controller : MonoBehaviour {

    public Text opponentPos;
    public int pos;
    string p;
    public GameObject b;
    float distance = 45.1f;
    public int test = 0;
    public bool rightShiftDone;
    int flag;


    void Start()
    {
        rightShiftDone = false;
        GetComponent<Rigidbody>().AddForce(0f, 0f, 10000f, ForceMode.Force); //arxikh dunamh gia na ksekinisei

        flag = 0;
    }

    

    void Update () {



        GetComponent<Rigidbody>().AddForce(0f, 0f, 108f, ForceMode.Force); //dunamh ana frame


        
        float dis = b.GetComponent<Transform>().position.z;
        float myDis = GetComponent<Transform>().position.z;
        float y = dis - myDis;

        if (y > 10)     // check gia to pote na eksafanizei kai na emfanizei thn 8esh tou analoga to pou vrisketai h mpala tou paixth
        {
            opponentPos.gameObject.SetActive(false);
            flag = 0;
            
        }
        if (y < -200)
        {
            opponentPos.gameObject.SetActive(false);
            flag = 1;
        }
        else if (y<-180 && flag==1)
        {
            opponentPos.gameObject.SetActive(true);

            flag = 0;
        }
        p = pos.ToString();
         opponentPos.text = (p+"th");

        Vector3 oppPos = Camera.main.WorldToScreenPoint(this.transform.position);
        opponentPos.transform.position = oppPos;

       
        RaycastHit hit;
        
        if (Physics.SphereCast(transform.position,0.6f, new Vector3 (0f, 0f, 1f), out hit,distance))  //spherecast gia anixneush antikeimenou kai algori8mos gia na phgainei automata
        {


             if (hit.collider.tag == "obstacle") {

                

                if (!rightShiftDone && (transform.position.x+2) >= 8)
                {
                    rightShiftDone = true;
                }
        
                if (rightShiftDone && (transform.position.x-2) <= -8)
                {
                    rightShiftDone = false;
                }

                if (rightShiftDone && (transform.position.x - 2) > -8)
                {
                    transform.Translate(-2.0f, 0, 0);
                }
                if (!rightShiftDone && (transform.position.x + 2) < 8)
                {
                    transform.Translate(2.0f, 0, 0);
                }



            }

            if (hit.collider.tag == "wreckingBall")
            {

                GameObject wBall = GameObject.FindGameObjectWithTag(hit.collider.tag);
                bool dir = wBall.GetComponent<obstacleMove>().right;

                if (dir )
                {  
                    if((transform.position.x - 2) > -8.5)
                       transform.Translate(-3.0f, 0, 0);
                    else
                       transform.Translate(+6f, 0, 0);
                }

                if(!dir) 
                {   
                    if((transform.position.x+2) < 8.5)
                        transform.Translate(+3.0f, 0, 0);
                    else
                        transform.Translate(-6f, 0, 0);
                }
            }
          
        }

   
	}


    private void OnCollisionEnter(Collision coll)  // detect collisions
    {
        if (coll.gameObject.tag == "obstacle")
        {
            this.opponentPos.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "wreckingBall" || coll.gameObject.tag == "ball")
        {
            this.opponentPos.gameObject.SetActive(false);
            
            Destroy(gameObject);
        }

    
    }


}
