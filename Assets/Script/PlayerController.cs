using System;
using UnityEngine;

//public enum PlayerNumber { PlayerOne, PlayerTwo}
public class PlayerController : MonoBehaviour
{
   //[SerializeField] private PlayerNumber playerNumber;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private LocationMarker _locationMarker;
    [SerializeField] private AnimationController﻿ _animationController;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    private Vector2 _moveTo;
    private bool _movingFlag = false;
    private bool _isMovingRight = true;

    #region Projectile Tags
    private const string APPLE = "apple";
    #endregion

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
        if (_inputManager.IsEnemy)
        {
            _inputManager.IsEnemyReset();
            Throw();

        }
    }


    public void MoveTo(Vector3 locationDelta)
    {        
        if (_isMovingRight != (0 > locationDelta.normalized.x))
        {
            _isMovingRight = (0 > locationDelta.normalized.x);
            _animationController.OnChangeDirection(_isMovingRight);
            _moveTo = new(locationDelta.x, 0);
        }
        
        _playerRigidbody.AddForce(_moveTo * _moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
    }
    public void Jump()
    {
        _playerRigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }

    public void Throw()
    {
        ProjectileController.Instance.SpawnFromPool(APPLE, transform.position, transform.rotation);
    }

    private void OnValidate()
    {
        _playerRigidbody = GetComponentInChildren<Rigidbody2D>();
        _animationController = GetComponentInChildren<AnimationController>();
    }
}
