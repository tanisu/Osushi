using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    bool isFall;
    int dir = 1;
    [SerializeField] float power;

    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(GameManager.I.gamestate == GameManager.GAMESTATE.GAMEOVER)
        {
            StopMove();
        }

        if(GameManager.I.gamestate == GameManager.GAMESTATE.PLAY)
        {
            if (isFall)
            {
                transform.localPosition -= Vector3.up * Time.deltaTime;
            }
            else
            {
                transform.Translate(new Vector3(1, 0, 0) * power * dir * Time.deltaTime);
            }
        }


        if (transform.localPosition.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public void MoveDir()
    {
        dir = -1;
        transform.localScale = new Vector3(1, 1, 1);
    }



    public void Falling()
    {
        isFall = true;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFall = false;
        }
    }

    private void StopMove()
    {
        rgbd2d.velocity = Vector3.zero;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Food"))
        {
           // rgbd2d.velocity = Vector3.zero;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Floor"))
    //    {
    //        rgbd2d.gravityScale = 1.0f;
    //    }
    //    if (collision.CompareTag("Player"))
    //    {
    //        rgbd2d.velocity = Vector3.zero;
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
