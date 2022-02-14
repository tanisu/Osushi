using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    bool[] isPush = { false,false};
    float interval = 0;
    [SerializeField] float pushInterval;
    [SerializeField] float pushPower;
    enum DIRECTION
    {
        LEFT,
        RIGHT
    }
    DIRECTION direction;

    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        interval -= Time.deltaTime * 0.5f;
        //Debug.Log($"interval {interval}");
        if(interval <= 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(1, 1, 1);
                isPush[0] = true;
                if(direction == DIRECTION.RIGHT)
                {
                    Turn();
                }
                direction = DIRECTION.LEFT;
                
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isPush[1] = true;
                if(direction == DIRECTION.LEFT)
                {
                    Turn();
                }
                direction = DIRECTION.RIGHT;
            }
            interval = pushInterval;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            isPush[0] = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isPush[1] = false;
        }
        
        
        //Debug.Log(isPush[0]);
    }

    
    void FixedUpdate()
    {
        if (isPush[0])
        {
            rgbd2d.AddForce(new Vector2(-pushPower, 0));
        } else if (isPush[1])
        {
            rgbd2d.AddForce(new Vector2(pushPower, 0));
        }

    }

    void Turn()
    {
       // rgbd2d.velocity = Vector3.zero;
        
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Floor"))
    //    {
    //        rgbd2d.gravityScale = 1.0f;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eater"))
        {
            rgbd2d.gravityScale = 0.0f;
            rgbd2d.bodyType = RigidbodyType2D.Static;
            
        }
    }




}
