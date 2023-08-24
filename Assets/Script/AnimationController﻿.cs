using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
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
        _animator.SetTrigger(JUMP);
    }

    public void OnChangeDirection(bool isMovingRight)
    {
        _spriteRenderer.flipX = isMovingRight;
    }

    public void ToggleBool(string boolName)
    {
        _animator.SetBool(boolName, !_animator.GetBool(boolName));
    }

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
