using System;
using UnityEngine;

//public enum PlayerNumber { PlayerOne, PlayerTwo}
public class PlayerController : MonoBehaviour
{
   //[SerializeField] private PlayerNumber playerNumber;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private LocationMarkerScript locationMarker;
    [SerializeField] private AnimationController﻿ animationController;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private bool _movingFlag = false;
    private bool _isMovingRight = true;

    private void FixedUpdate()
    {
        Vector2 moveTo;// = Vector2.Lerp(transform.position,new(locationMarker.transform.position.x,transform.position.y), moveSpeed * Time.deltaTime);
                       //  playerRigidbody.AddForce((moveTo - new Vector2(transform.position.x, transform.position.y)) * moveSpeed * Time.deltaTime,ForceMode2D.Force);
        if (locationMarker.isActiveAndEnabled)
        {
            Vector3 locationDelta = locationMarker.transform.position - transform.position;
            locationDelta = locationDelta.normalized;

            if (!_movingFlag)
            {
                animationController.OnIdle();
                _movingFlag = true;
            }

            if (_isMovingRight != (0 > locationDelta.normalized.x))
            {
                _isMovingRight = (0 > locationDelta.normalized.x);
                animationController.OnChangeDirection(_isMovingRight);
            }
            moveTo = new(locationDelta.x, 0);
            playerRigidbody.AddForce(moveTo * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        else if (_movingFlag)
        {
            animationController.OnIdle();
            _movingFlag = false;
        }
    }

    public void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    public void Throw()
    {
        throw new NotImplementedException(); // TODO Implement
    }

    private void OnValidate()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animationController = GetComponentInChildren<AnimationController>();
    }
}
