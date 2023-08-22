using System;
using UnityEngine;

//public enum PlayerNumber { PlayerOne, PlayerTwo}
public class PlayerController : MonoBehaviour
{
   //[SerializeField] private PlayerNumber playerNumber;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private LocationMarker _locationMarker;
    [SerializeField] private AnimationController﻿ _animationController;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    private bool _movingFlag = false;
    private bool _isMovingRight = true;

    private void FixedUpdate()
    {
        Vector2 moveTo;// = Vector2.Lerp(transform.position,new(locationMarker.transform.position.x,transform.position.y), moveSpeed * Time.deltaTime);
                       //  playerRigidbody.AddForce((moveTo - new Vector2(transform.position.x, transform.position.y)) * moveSpeed * Time.deltaTime,ForceMode2D.Force);
        if (_locationMarker.isActiveAndEnabled)
        {
            Vector3 locationDelta = _locationMarker.transform.position - transform.position;
            locationDelta = locationDelta.normalized;

            if (!_movingFlag)
            {
                _animationController.OnIdle();
                _movingFlag = true;
            }

            if (_isMovingRight != (0 > locationDelta.normalized.x))
            {
                _isMovingRight = (0 > locationDelta.normalized.x);
                _animationController.OnChangeDirection(_isMovingRight);
            }
            moveTo = new(locationDelta.x, 0);
            _playerRigidbody.AddForce(moveTo * _moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        else if (_movingFlag)
        {
            _animationController.OnIdle();
            _movingFlag = false;
        }
    }

    public void Jump()
    {
        _playerRigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }

    public void Throw()
    {
        throw new NotImplementedException(); // TODO Implement
    }

    private void OnValidate()
    {
        _playerRigidbody = GetComponentInChildren<Rigidbody2D>();
        _animationController = GetComponentInChildren<AnimationController>();
    }
}
