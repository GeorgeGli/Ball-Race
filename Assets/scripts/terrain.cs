using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain : MonoBehaviour {

    Vector3 temp;
    
	void Start () {
      
	}
	
	
	void Update () {
        temp = transform.localScale;  //epektash terain me vash ton xrono
        temp.z += Time.deltaTime*10;
        
       
        transform.localScale = temp;
	}
}
