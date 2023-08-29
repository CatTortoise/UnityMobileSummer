using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private ProjectileController _projectileController;
    [SerializeField] private AnimationController﻿ _animationController;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private LocationMarker _locationMarker;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    private Vector2 _moveTo;
    private bool _movingFlag = false;
    private bool _isMovingRight = true;

    private void FixedUpdate()
    {
        if (_locationMarker.isActiveAndEnabled)
        {
            Vector3 locationDelta = _locationMarker.transform.position - transform.position;
            locationDelta = locationDelta.normalized;

            if (!_movingFlag)
            {
                _animationController.OnIdle();
                _movingFlag = true;
            }
            MoveTo(locationDelta);

        }
        else if (_movingFlag)
        {
            _animationController.OnIdle();
            _movingFlag = false;
        }
        if (_inputManager.IsTargetingEnemy)
        {
            _inputManager.IsEnemyReset();
            ThrowApple();
        }
    }

    public void MoveTo(Vector2 locationDelta)
    {
        bool isMovingRight = locationDelta.normalized.x > 0;
        if (_isMovingRight != isMovingRight)
        {
            _animationController.OnChangeDirection(_isMovingRight);
            _moveTo = new(locationDelta.x, 0);
        }
        _isMovingRight = isMovingRight;

        _playerRigidbody.AddForce(_moveTo * _moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
    }
    public void Jump()
    {
        _playerRigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }

    public void ThrowApple()
    {
        var launchDirection = _isMovingRight? Vector2.right : Vector2.left;
        _projectileController.Throw(launchDirection);
    }

    private void OnValidate()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _projectileController = GetComponent<ProjectileController>();
        _animationController = GetComponentInChildren<AnimationController>();
    }
}
