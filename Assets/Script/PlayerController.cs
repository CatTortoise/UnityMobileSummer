using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum PlayerNumber { PlayerOne, PlayerTwo}
public class PlayerController : MonoBehaviour
{
   //[SerializeField] private PlayerNumber playerNumber;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private LocationMarkerScript locationMarker;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private AnimationController﻿ animation;
    private bool _movingFlag;
    private bool IsMovingRight;

    private void Start()
    {
        _movingFlag = false;
        IsMovingRight = true;
    }
    private void FixedUpdate()
    {

        Vector2 moveTo;// = Vector2.Lerp(transform.position,new(locationMarker.transform.position.x,transform.position.y), moveSpeed * Time.deltaTime);
                       //  playerRigidbody.AddForce((moveTo - new Vector2(transform.position.x, transform.position.y)) * moveSpeed * Time.deltaTime,ForceMode2D.Force);
        if (locationMarker.isActiveAndEnabled)
        {
            Vector3 vector3 = locationMarker.transform.position - transform.position;
            vector3 = vector3.normalized;

            if (!_movingFlag)
            {
                animation.ChangeIdolBool();
                _movingFlag = true;
            }

            if (IsMovingRight != (0 > vector3.normalized.x))
            {
                IsMovingRight = (0 > vector3.normalized.x);
                animation.ChangeDirection(IsMovingRight);
            }
            moveTo = new(vector3.x, 0);
            playerRigidbody.AddForce(moveTo * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        else
        {
            if (_movingFlag)
            {
                animation.ChangeIdolBool();
                _movingFlag = false;
            }
        }
    }

    public void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpSpeed , ForceMode2D.Impulse);
    }



}
