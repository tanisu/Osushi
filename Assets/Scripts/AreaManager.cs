using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] FoodSpawn[] spawns;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(playerPos.position.x > 0)
        {
            spawns[0].canSpawn = true;
            spawns[1].canSpawn = false;

            //Debug.Log("�E��");
            //spawns[0].SetActive(true);
            //spawns[1].SetActive(false);
        }
        else
        {
            spawns[0].canSpawn = false;
            spawns[1].canSpawn = true;
            //Debug.Log("����");
            //spawns[0].SetActive(false);
            //spawns[1].SetActive(true);
        }
    }
}
