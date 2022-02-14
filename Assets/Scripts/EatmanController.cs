using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatmanController : MonoBehaviour
{
    Animator anim;
    [SerializeField] TanController tan;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void EatStart()
    {
        anim.SetBool("EatStart",true);
    }

    public void TanStart()
    {
        tan.AnimStart();
    }
}
