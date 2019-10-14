using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject[] enemies; //pinakas me ta dia8esima antikeimena
  
    
    int randEnemy;
    Vector3 tmp;
    public GameObject followBall;  // h mpala tou paixth
    List<GameObject> obstacleList= new List<GameObject>();  
    GameObject clone;
    int frames;
    int framesNum = 2;

    void Start () {

        frames = 0;
	}
	
	
	void Update () {

        

            tmp = transform.localScale;                //na gennaei antikeimena  se random z
         float randomz = Random.Range(60f, 85f);
         tmp.z += randomz;
      
        transform.localScale = tmp;

        if (frames == framesNum)    //ana 2 frames
        {

            randEnemy = Random.Range(0, 7);  //random epilogh antikeimenou


            if (randEnemy == 0)     // dhmiourgia klonou kai eisagwgh sthn lista
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-7, 7), 3.13f, tmp.z);
                clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                obstacleList.Add(clone);
            }
            if (randEnemy == 1)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-6, 3), 6.2f, tmp.z);
                clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                obstacleList.Add(clone);
            }
            if (randEnemy == 2)
            {
                Vector3 spawnPosition = new Vector3(-2.4f, 6.64f, tmp.z);
                clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                obstacleList.Add(clone);
            }
            if (randEnemy == 3)
            {
                Vector3 spawnPosition = new Vector3(0f, 2.27f, tmp.z);
                clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                obstacleList.Add(clone);
            }
            if (randEnemy == 4)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-5, -1), 1.05f, tmp.z);
                clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                obstacleList.Add(clone);
            }
            if (randEnemy == 5)
            {
                Vector3 spawnPosition = new Vector3(-2.4f, 6.64f, tmp.z);
                clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                obstacleList.Add(clone);
            }
           
            if (randEnemy == 6)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-5.5f, 5.5f), 0.29f, tmp.z);
                clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                obstacleList.Add(clone);
            }

            frames = 0;
        }
        frames++;
        
        

        float ball_z = followBall.GetComponent<Transform>().position.z;   //check an h mpala tou paixth perase kai an perase diagrafh antikeimenou

        for(int i = 0; i < obstacleList.Count; i++)
        {
            float clone_z = obstacleList[i].gameObject.GetComponent<Transform>().position.z;

            if (ball_z > clone_z)
            {
                
                Destroy(obstacleList[i].gameObject,1f);
                obstacleList.RemoveAt(i);
            }
        }

    }
    
}
