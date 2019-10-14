using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour {

    int flag=0;
    public bool right;
	void Start () {
		
	}
	
	
	void Update () {

        float x=GetComponent<Transform>().position.x;

        if (x >= 7.7f)
        {
            flag = 1;
        }
        else if (x <= -7.7f)
        {
            flag = 0;
        }

        if (x < 7.7f && flag==0)
        {
            transform.Translate(0.2f, 0, 0);
            right = true;
        }
        else if(x>-7.7f && flag==1)
        {
            transform.Translate(-0.2f, 0, 0);
            right = false;
            
        }
	}
}
