using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimManager : MonoBehaviour
{
    public Animator anim;
    public static WolfAnimManager instance;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void Land()
    {
        anim.SetTrigger("Land");
    }

    public void Spin()
    {
        anim.SetTrigger("Spin");
    }

    public void StopSpin()
    {
        anim.SetTrigger("StopSpin");
    }

    public void Move(bool isMoving)
    {
        anim.SetBool("IsMoving", isMoving);
    }
}
