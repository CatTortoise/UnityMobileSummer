using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    #region STATE_NAMES
    private const string IDLE = "IsIdel";
    private const string JUMP = "Jump";
    private const string SPRINT = "Sprint";
    #endregion

    public void OnIdle()
    {
        ToggleBool(IDLE);
    }

    public void OnJump()
    {
        animator.SetTrigger(JUMP);
    }

    public void OnChangeDirection(bool isMovingRight)
    {
        spriteRenderer.flipX = isMovingRight;
    }

    public void ToggleBool(string boolName)
    {
        animator.SetBool(boolName, !animator.GetBool(boolName));
    }

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
