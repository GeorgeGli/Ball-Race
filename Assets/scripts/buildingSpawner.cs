using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingSpawner : MonoBehaviour {

    public GameObject[] buildings;
    int randBuildingL;
    int randBuildingR;
    public GameObject followBall;
    List<GameObject> buildList = new List<GameObject>();
    GameObject clone;
    Vector3 tmp;

    


    void Update()  //paromoia logikh me to spawner twn antikeimenwn
    {

       
        tmp = transform.localScale;
        float randz = Random.Range(50f, 100f);
        tmp.z += randz;

        transform.localScale = tmp;


        randBuildingL = Random.Range(0, 3);
        randBuildingR = Random.Range(0, 3);

        if (randBuildingL == 0)
        {
            Vector3 spawnPosition = new Vector3(-13.31f, 4.15f, tmp.z);
            clone = Instantiate(buildings[randBuildingL], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            buildList.Add(clone);
        }

        if (randBuildingL == 1)
        {
            Vector3 spawnPosition = new Vector3(-13.62f, 2.8f, tmp.z);
            clone = Instantiate(buildings[randBuildingL], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            buildList.Add(clone);

        }

        if (randBuildingL == 2)
        {
            Vector3 spawnPosition = new Vector3(-11.99f, 1.64f, tmp.z);
            clone = Instantiate(buildings[randBuildingL], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            buildList.Add(clone);

        }



        if (randBuildingR == 0)
        {
            Vector3 spawnPosition = new Vector3(13.31f, 4.15f, tmp.z);
            clone = Instantiate(buildings[randBuildingR], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            buildList.Add(clone);

        }

        if (randBuildingR == 1)
        {
            Vector3 spawnPosition = new Vector3(13.62f, 2.8f, tmp.z);
            clone = Instantiate(buildings[randBuildingR], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            buildList.Add(clone);

        }

        if (randBuildingR == 2)
        {
            Vector3 spawnPosition = new Vector3(11.85f, 1.64f, tmp.z);
            clone = Instantiate(buildings[randBuildingR], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            buildList.Add(clone);

        }



        float ball_z = followBall.GetComponent<Transform>().position.z;

        for (int i = 0; i < buildList.Count; i++)
        {
            float clone_z = buildList[i].gameObject.GetComponent<Transform>().position.z;

            if (ball_z > clone_z)
            {
             
                Destroy(buildList[i].gameObject, 1f);
                buildList.RemoveAt(i);
            }
        }
    }
   
}
