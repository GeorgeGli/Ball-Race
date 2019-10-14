using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionSort : MonoBehaviour {

    public List<GameObject> balls;  
    float[] z;


    void Start () {

        
        z = new float[balls.Count];
       
    }
	
	
	void Update () {


        z = new float[balls.Count];   //gia thn 8esh ths ka8e mpalas
        for (int i = 0; i < balls.Count; i++)
        {

            if (balls[i].gameObject == null)
            {
                
                balls.RemoveAt(i);
            }
        }
      


        for (int i = 0; i < balls.Count; i++)
         {
             z[i] =(float) balls[i].GetComponent<Transform>().position.z;
         }

        Array.Sort(z);  //sortarisma pianka
        Array.Reverse(z); //kai reverse gia na exw thn swsth seira

        for (int i=0; i < z.Length; i++)
        {
            for(int j=0;j< z.Length; j++)
            {
                if(z[i]==balls[j].GetComponent<Transform>().position.z)
                {
                    if (j == 0)
                    {
                       
                        balls[j].GetComponent<MyBall>().position = i+1;
                    }
                    else
                    {
                        
                        balls[j].GetComponent<AI_Controller>().pos = i+1;
                    }
                      
                }
            }

        }
    }
}
