using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] EnemyController food;
    [SerializeField] LayerMask layer;
    [SerializeField] float spawnInterval;
    enum DIRECTION
    {
        TO_RIGHT,
        TO_LEFT
    }
    [SerializeField] DIRECTION direction;

    int maxCount = 50;
   // float interval = 0;
    Queue<EnemyController> objQueue;
    //Vector3 downPos;
    Vector3 leftStartPoint;
    Vector3 rightStartPoint;
    Vector3 endPoint;
    public bool canSpawn = false;
    void Start()
    {
        objQueue = new Queue<EnemyController>(maxCount);
        for(int i = 0;i < maxCount; i++)
        {
            EnemyController tmpObj = Instantiate(food);
            tmpObj.transform.parent = transform;
            tmpObj.transform.localPosition = new Vector3(100, 100, 0);
            tmpObj.gameObject.SetActive(false);
            objQueue.Enqueue(tmpObj);
        }
        //downPos = transform.position - Vector3.up * 3f;
        leftStartPoint = transform.position - Vector3.right * 0.2f;
        rightStartPoint = transform.position + Vector3.right * 0.2f;
        endPoint = transform.position - Vector3.up * 5f;

    }

    
    void Update()
    {

        
        //interval -= Time.deltaTime;
        
        if(/*interval <= 0 && !*/ 
            !Physics2D.Linecast(leftStartPoint, endPoint, layer) 
            &&
            !Physics2D.Linecast(rightStartPoint, endPoint, layer)
            && canSpawn && GameManager.I.gamestate == GameManager.GAMESTATE.PLAY)
        {
            EnemyController obj = Launch();
            if(obj != null)
            {
                obj.Falling();
                if(direction == DIRECTION.TO_LEFT)
                {
                    obj.MoveDir();
                }
            }
            //interval = spawnInterval;
        }
        
        
        Debug.DrawLine(leftStartPoint, endPoint);
        Debug.DrawLine(rightStartPoint, endPoint);


    }

    

    private EnemyController Launch()
    {
        if (objQueue.Count <= 0) return null;
        EnemyController tmpObj = objQueue.Dequeue();
        tmpObj.gameObject.SetActive(true);
        tmpObj.transform.localPosition = Vector3.zero;
        return tmpObj;

    }
}
