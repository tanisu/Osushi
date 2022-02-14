using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanController : MonoBehaviour
{
    Animator anim;
       
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void AnimStart()
    {
        gameObject.SetActive(true);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Food"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        GameManager.I.GameOver();
    }
}
