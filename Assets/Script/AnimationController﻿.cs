using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    

    public void ChangeIdolBool()
    {
        ChangeBool("IsIdel");
    }


    public void ChangeDirection(bool isMovingRight)
    {
        sprite.flipX = isMovingRight;
    }
    
    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }


    public void ChangeBool(string boolName)
    {
        if (animator.GetBool(boolName))
        {
            animator.SetBool(boolName, false);
        }
        else
        {
            animator.SetBool(boolName, true);
        }
    }
}
