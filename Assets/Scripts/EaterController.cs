using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterController : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("isEat",true);
        AudioManager.I.PlaySE();
        if (collision.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            GameManager.I.EatCount();
        }
        else if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            GameManager.I.GameOver();
        }
        
        
    }

    public void EatEnd()
    {
        anim.SetBool("isEat", false);
    }
}
