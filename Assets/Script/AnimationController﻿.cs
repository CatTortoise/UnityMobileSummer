using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    #region STATE_NAMES
    public const string IDLE = "IsIdel";
    public const string JUMP = "Jump";
    public const string THROW = "Throw";
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
